using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;
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

        public async Task<bool> AuthenicateUserAsync(LoginUserDto loginUser)
        {
            bool result = await _userRepository.AuthenticateUserByEmailAsync(loginUser.Email, loginUser.Password);

            return result;
        }

        public async Task ChangePasswordAsync(ChangePasswordDto changePassword, string userName)
        {
            ApplicationUserDto user = await _userInformation.GetUserByNameAsync(userName);

            if (await _userRepository.AuthenticateUserByUserNameAsync(userName, changePassword.OldPassword))
                await _userRepository.ChangePasswordAsync(user.Id, changePassword.NewPassword);

            else
                throw new BadRequestException("The old password is wrong.");

        }

        public async Task DeleteUserByIdAsync(string userId)
        {
            await _userRepository.DeleteUserByIdAsync(userId);
        }

        public async Task DeleteUserByNameAsync(string userName)
        {
            await _userRepository.DeleteUserByNameAsync(userName);
        }

        public async Task<ApplicationUserDto> GetUserByEmailAsync(string userName)
        {
            ApplicationUserDto user = await _userInformation.GetUserByEmailAsync(userName);

            return user;
        }

        public async Task<ApplicationUserDto> GetUserByNameAsync(string userName)
        {
            ApplicationUserDto user = await _userInformation.GetUserByNameAsync(userName);

            return user;
        }

        public async Task LogoutAsync()
        {
            await _userRepository.LogoutAsync();
        }

        public async Task RegisterUserAsync(RegisterUserDto registerUser)
        {
            await _userRepository.RegisterUserAsync(registerUser.UserName,
                                                    registerUser.Email,
                                                    registerUser.Password);
        }

        public Task<ApplicationUserDto> UpdateUserAsync(ApplicationUserDto applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}