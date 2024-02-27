using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Infra.Data.Identity
{
    public class UserInformation : IUserInformation
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserInformation(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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
    }
}