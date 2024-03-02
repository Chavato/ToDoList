using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IUserInformation
    {
        Task<ApplicationUserDto> GetActualUser();
        Task<ApplicationUserDto> GetUserByEmailAsync(string email);
        Task<ApplicationUserDto> GetUserByNameAsync(string name);
    }
}