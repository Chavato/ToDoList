using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(RegisterUser userRegister)
        {
            try
            {

                ValidateModelState();

                ApplicationUserDto user = await _userService.RegisterUser(userRegister.Email, userRegister.Password);

                return Ok(user);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginUser user)
        {
            try
            {
                ValidateModelState();

                if (await _userService.AuthenicateUser(user.Email, user.Password))
                {
                    throw new NotImplementedException();
                    //  TODO: LOGIN LOGIC
                }
                else
                {
                    return Forbid("User or/and Password are incorrect.");
                }
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
        public Task<IActionResult> ChangePassword()
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception err)
            {

            }
        }

        [HttpDelete("[action]")]
        public Task<IActionResult> Logout()
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception err)
            {

            }
        }
    }
}