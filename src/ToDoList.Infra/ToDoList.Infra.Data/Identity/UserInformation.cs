using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Infra.Data.Identity
{
    public class UserInformation : IUserInformation
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserInformation(UserManager<ApplicationUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUserDto> GetActualUser()
        {
            string? userName = _httpContextAccessor.HttpContext!.User.Identity!.Name;

            if (userName == null)
                throw new Exception("Problem with access HttpContext");

            return await GetUserByNameAsync(userName);
        }

        public async Task<ApplicationUserDto> GetUserByEmailAsync(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<ApplicationUserDto>(user);
        }

        public async Task<ApplicationUserDto> GetUserByNameAsync(string name)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(name);

            if (user == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<ApplicationUserDto>(user);
        }
    }
}