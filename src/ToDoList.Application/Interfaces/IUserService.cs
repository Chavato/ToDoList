using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AuthenicateUserAsync(string email, string password);
        Task<ApplicationUserDto> GetUserByEmailAsync(string userEmail);
        Task<ApplicationUserDto> GetUserByNameAsync(string userName);
        Task RegisterUserAsync(string email, string password);
        Task<ApplicationUserDto> UpdateUserAsync(ApplicationUserDto applicationUser);
        Task DeleteUserByIdAsync(string userId);
        Task DeleteUserByNameAsync(string userName);
        Task ChangePasswordAsync(string newPassword, string userName);
        Task LogoutAsync();
    }
}