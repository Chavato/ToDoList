using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;

namespace ToDoList.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserInformation _userInformation;


        public UserService(IUserRepository userRepository, IUserInformation userInformation)
        {
            _userRepository = userRepository;
            _userInformation = userInformation;
        }

        public async Task<bool> AuthenicateUserAsync(string email, string password)
        {
            bool result = await _userRepository.AuthenticateUserAsync(email, password);

            return result;
        }

        public async Task ChangePasswordAsync(string newPassword, string userName)
        {
            ApplicationUserDto user = await _userInformation.GetUserByNameAsync(userName);

            await _userRepository.ChangePasswordAsync(user.Id, newPassword);
        }

        public Task DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUserDto> GetUserByEmailAsync(string userName)
        {
            ApplicationUserDto user = await _userInformation.GetUserByEmailAsync(userName);

            return user;
        }

        public async Task LogoutAsync()
        {
            await _userRepository.LogoutAsync();
        }

        public async Task RegisterUserAsync(string email, string password)
        {
            await _userRepository.RegisterUserAsync(email, password);
        }

        public Task<ApplicationUserDto> UpdateUserAsync(ApplicationUserDto applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}