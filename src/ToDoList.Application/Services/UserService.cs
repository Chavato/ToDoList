using ToDoList.Application.Interfaces;
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
    }
}