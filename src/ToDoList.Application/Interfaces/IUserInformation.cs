using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IUserInformation
    {
        Task<ApplicationUserDto> GetUserByEmailAsync(string email);
    }
}