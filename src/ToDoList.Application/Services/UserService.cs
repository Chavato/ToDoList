using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;

namespace ToDoList.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> AuthenicateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> ChangePassword(ApplicationUserDto applicationUser, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> RegisterUser(string email, string password, IEnumerable<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> UpdateUser(ApplicationUserDto applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}