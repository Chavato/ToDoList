using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AuthenicateUserAsync(LoginUserDto loginUser);
        Task<ApplicationUserDto> GetUserByEmailAsync(string userEmail);
        Task<ApplicationUserDto> GetUserByNameAsync(string userName);
        Task RegisterUserAsync(RegisterUserDto registerUser);
        Task<ApplicationUserDto> UpdateUserAsync(ApplicationUserDto applicationUser);
        Task DeleteUserByIdAsync(string userId);
        Task DeleteUserByNameAsync(string userName);
        Task ChangePasswordAsync(ChangePasswordDto changePassword, string userName);
        Task LogoutAsync();
    }
}