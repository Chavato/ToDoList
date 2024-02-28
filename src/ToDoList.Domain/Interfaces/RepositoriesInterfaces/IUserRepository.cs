namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUserAsync(string email, string password);
        Task RegisterUserAsync(string email, string password);
        Task UpdateUserAsync(string id, string email);
        Task DeleteUserByIdAsync(string userId);
        Task DeleteUserByNameAsync(string userName);
        Task ChangePasswordAsync(string id, string newPassword);
        Task LogoutAsync();
    }
}