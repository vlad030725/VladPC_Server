using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace VladPC.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public string GenerateTokenString(LoginUserDto user)
        {
            //var roles = _userManager.GetRolesAsync(await _userManager.FindByNameAsync(user.UserName));

            IEnumerable<System.Security.Claims.Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "admin")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        public async Task<bool> Login(LoginUserDto user)
        {
            var identityUser = await _userManager.FindByNameAsync(user.UserName);
            if (identityUser is null)
                return false;

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public async Task<bool> RegisterUser(LoginUserDto user)
        {
            var identityUser = new User
            {
                UserName = user.UserName,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
    }
}
