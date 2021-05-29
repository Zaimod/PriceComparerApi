﻿using AutoMapper;
using CarParts.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PriceComparer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
         
        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            EmailService emailService = new EmailService();

            await emailService.SendEmailAsync(userForRegistration.Email, "Verification code", $"Your verification code: {emailService.GenerateCode()}");

            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return Ok();
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authetication failed. Wrong user name or password.");

                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken(), emailConfirmed =  await _authManager.IsEmailConfirmed(user.UserName) });
        }

        [HttpPost("sendVerificationCode")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SendVerificationCode([FromBody] SendVerificationCodeDto dto)
        {
            EmailService emailService = new EmailService();
            string email = await _authManager.GetEmailByUserName(dto.userName);
            string code = emailService.GenerateCode(); 

            //HttpContext.Session.SetString("code", code); 

            await emailService.SendEmailAsync(email, "Verification code", $"Your verification code: {code}");

            return Ok();
        }

        [HttpPost("changeEmailConfirmed")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmailConfirmed([FromBody] ChangeEmailConfirmedDto dto)
        {
            //string sentCode = HttpContext.Session.GetString("code");
            if (dto.code.Equals(sentCode))
            {
                await _authManager.IsEmailConfirmed(dto.userName);

                return Ok();
            }

            return BadRequest();
        }
    }
}
