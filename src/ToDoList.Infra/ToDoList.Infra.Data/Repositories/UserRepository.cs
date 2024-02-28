using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Identity;

namespace ToDoList.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            bool isAuthenticate = await _userManager.CheckPasswordAsync(user, password);

            return isAuthenticate;
        }

        public async Task ChangePasswordAsync(string id, string newPassword)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            if (!result.Succeeded)
            {
                throw new Exception("Change password failed.");
            }
        }

        public Task DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterUserAsync(string email, string password)
        {
            ApplicationUser user = new ApplicationUser(email, email);

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault()!.Description);
            }

            await _signInManager.SignInAsync(user, false);
        }

        public Task UpdateUserAsync(string id, string email)
        {
            throw new NotImplementedException();
        }
    }
}