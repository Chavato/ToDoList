using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;
using ToDoList.WebApi.Models;

namespace ToDoList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : DefaultController
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(RegisterUser userRegister)
        {
            try
            {

                ValidateModelState();

                await _userService.RegisterUserAsync(userRegister.Email, userRegister.Password);

                return Ok(new { Message = "User registered" });
            }

            catch (BadRequestException err)
            {
                return Problem(detail: err.Message, statusCode: 400);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginUser user)
        {
            try
            {
                ValidateModelState();

                if (await _userService.AuthenicateUserAsync(user.Email, user.Password))
                {
                    string token = await GenerateTokenAsync(user.Email);

                    return Ok(new { Token = token });
                }
                else
                {
                    return Problem(detail: "User or/and Password are incorrect.", statusCode: 403);
                }
            }

            catch (NotFoundException)
            {
                return Problem(detail: "User or/and Password are incorrect.", statusCode: 403);
            }

            catch (BadRequestException err)
            {
                return Problem(detail: err.Message, statusCode: 400);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangePassword(string newPassword)
        {

            string? userName = HttpContext.User.Identity!.Name;

            if (userName == null)
            {
                throw new Exception("Problem with access user name.");
            }

            await _userService.ChangePasswordAsync(newPassword, userName);

            return Ok(new { Message = "Password changed sucessfully." });
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();

            return NoContent();
        }

        private async Task<string> GenerateTokenAsync(string userName)
        {
            var user = await _userService.GetUserByEmailAsync(userName);

            var claims = new List<Claim>
                {
                new Claim("name", userName),
                new Claim(ClaimTypes.Name, userName),
                new Claim("id", user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            string? jwtSecret = _configuration.GetValue<string>("JWT_SECRET");
            string? jwtValidIssuer = _configuration.GetValue<string>("JWT_VALID_ISSUER");
            string? jwtValidAudience = _configuration.GetValue<string>("JWT_VALID_AUDIENCE");

            if (jwtSecret == null || jwtValidIssuer == null || jwtValidAudience == null)
            {
                throw new MissingEnvironmentVariableException("JWT_SECET, JWT_VALID_ISSUER or JWT_VALID_AUDIENCE are missing");
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

            var token = new JwtSecurityToken(
                issuer: jwtValidIssuer,
                audience: jwtValidAudience,
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token).ToString();

            return tokenString;
        }

    }
}