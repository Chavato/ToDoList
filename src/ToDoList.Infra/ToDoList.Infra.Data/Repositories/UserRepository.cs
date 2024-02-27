using Microsoft.AspNetCore.Identity;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Identity;

namespace ToDoList.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public Task ChangePasswordAsync(string id, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
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