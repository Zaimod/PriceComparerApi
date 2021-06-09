using AutoMapper;
using CarParts.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="authManager">The authentication manager.</param>
        /// <param name="cache">The cache.</param>
        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager,
            IMemoryCache cache)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _cache = cache;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userForRegistration">The user for registration.</param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            EmailService emailService = new EmailService();

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

        /// <summary>
        /// Authenticates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Sends the verification code.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPost("sendVerificationCode")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SendVerificationCode([FromBody] SendVerificationCodeDto dto)
        {
            EmailService emailService = new EmailService();
            string email = await _authManager.GetEmailByUserName(dto.userName);
            string code = emailService.GenerateCode();

            _cache.Set("code", code, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
             
            //HttpContext.Session.SetString("code", code); 

            await emailService.SendEmailAsync(email, "Verification code", $"Your verification code: {code}");
            
            return Ok();
        }

        /// <summary>
        /// Changes the email confirmed.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPost("changeEmailConfirmed")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmailConfirmed([FromBody] ChangeEmailConfirmedDto dto)
        {
            string codeEmail = null;

            if (_cache.TryGetValue("code", out codeEmail))
            {
                if (dto.code.Equals(codeEmail))
                {
                    await _authManager.ConfirmEmail(dto.userName);
                    _cache.Remove("code");

                    return Ok();
                }
            }

            return BadRequest();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("username/{id}", Name = "getUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = _userManager.Users.Where(u => u.UserName == id).FirstOrDefault();

                UserDto userResult = new UserDto
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Birthday = user.Birthday,
                    Sex = user.Sex,
                    City = user.City,
                    PhoneNumber = user.PhoneNumber
                };
                _logger.LogInfo($"Get User success!");
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Get User failed.");
                return BadRequest();
            }
        }

        /// <summary>
        /// Users the update.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPost("userUpdate")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UserUpdate([FromBody] UserDto dto)
        {
            try
            {
                await _authManager.UpdateUser(dto);

                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
