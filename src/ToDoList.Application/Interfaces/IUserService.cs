using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AuthenicateUserAsync(string email, string password);
        Task<ApplicationUserDto> GetUserByEmailAsync(string userEmail);
        Task RegisterUserAsync(string email, string password);
        Task<ApplicationUserDto> UpdateUserAsync(ApplicationUserDto applicationUser);
        Task DeleteUserAsync(string userId);
        Task ChangePasswordAsync(string newPassword, string userName);
        Task LogoutAsync();
    }
}