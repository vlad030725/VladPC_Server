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
                var tokenString = _userService.GenerateTokenString(user);
                return Ok(tokenString);
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


        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //private readonly IConfiguration _config;

        //public AuthorizationController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _config = config;
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginViewDto model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.UserName);
        //    if (user == null)
        //        return Unauthorized(new { message = "Пользователь не найден" });

        //    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        //    if (!result.Succeeded)
        //        return Unauthorized(new { message = "Неверный пароль" });

        //    var token = await GenerateJwtToken(user);
        //    return Ok(new { token });
        //}



        //[HttpPost]
        //[Route("logoff")]
        //public async Task<IActionResult> LogOff()
        //{
        //    User usr = await GetCurrentUserAsync();
        //    if (usr == null)
        //    {
        //        return Unauthorized(new { message = "Сначала выполните вход" });
        //    }
        //    // Удаление куки
        //    await _signInManager.SignOutAsync();
        //    return Ok(new { message = "Выполнен выход", userName = usr.UserName });
        //}

        //[HttpGet("isauthenticated")]
        //public async Task<IActionResult> IsAuthenticated()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (userId == null)
        //        return Unauthorized(new { message = "No user ID in token" });

        //    var user = await _userManager.FindByIdAsync(userId);

        //    if (user == null)
        //        return Unauthorized(new { message = "User not found" });

        //    return Ok(new
        //    {
        //        message = "Authenticated",
        //        user = new
        //        {
        //            user.Id,
        //            user.UserName
        //        }
        //    });
        //}

        //private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //private async Task<string> GenerateJwtToken(User user)
        //{
        //    var jwtKey = _config["Jwt:Key"];
        //    var jwtIssuer = _config["Jwt:Issuer"];
        //    var jwtAudience = _config["Jwt:Audience"];

        //    var userRoles = await _userManager.GetRolesAsync(user);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.UserName)
        //    };

        //    // Добавляем роли
        //    claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: jwtIssuer,
        //        audience: jwtAudience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddHours(2),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }


}
