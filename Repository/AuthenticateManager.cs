using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthenticateManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User _user;
      
        public AuthenticateManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            return (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)), 
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> IsEmailConfirmed(string userName)
        {
            _user = await _userManager.FindByNameAsync(userName);

            return (_user != null && await _userManager.IsEmailConfirmedAsync(_user));
        }

        public async Task<string> GetEmailByUserName(string userName)
        {
            _user = await _userManager.FindByNameAsync(userName);

            if(_user != null)
                return _user.Email;

            return null;
        }

        public async Task<bool> ConfirmEmail(string userName)
        {
            _user = await _userManager.FindByNameAsync(userName);

            if (_user != null && !await _userManager.IsEmailConfirmedAsync(_user)) {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(_user);

                return  _userManager.ConfirmEmailAsync(_user, token).Result.Succeeded;         
            }
            return false;
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            try
            {
                _user = _userManager.Users.Where(u => u.Email == userDto.Email).FirstOrDefault();

                _user.FirstName = userDto.FirstName;
                _user.UserName = userDto.UserName;
                _user.LastName = userDto.LastName;
                _user.Birthday = userDto.Birthday;
                _user.PhoneNumber = userDto.PhoneNumber;

                await _userManager.UpdateAsync(_user);

                return true;
            }
           
            catch(Exception ex)
            {
                return false;
            }
        } 
    }
}
