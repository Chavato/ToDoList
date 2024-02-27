using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AuthenicateUser(string email, string password);
        Task<ApplicationUserDto> RegisterUser(string email, string password);
        Task<ApplicationUserDto> UpdateUser(ApplicationUserDto applicationUser);
        Task DeleteUser(string userId);
        Task<ApplicationUserDto> ChangePassword(ApplicationUserDto applicationUser, string newPassword);
        Task Logout();
    }
}