using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VladPC.DAL;
using VladPC.DAL.Models;
using VladPC.BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VladPC.BLL.Interfaces;

namespace VladPC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await _userService.Login(user))
            {
                //var identityUser = await _userService.GetUserByName(user.UserName);
                //var roles = await _userService.GetRoles(identityUser);
                var tokenString = await _userService.GenerateTokenString(user.UserName);

                return Ok(new AuthResponseDto { Token = tokenString });
            }

            return BadRequest();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUserDto user)
        {
            if (await _userService.RegisterUser(user))
            {
                return Ok("Пользователь зарегестрирован");
            }
            return BadRequest();
        }
    }
}
