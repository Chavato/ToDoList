namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUserAsync(string email, string password);
        Task RegisterUserAsync(string email, string password);
        Task UpdateUserAsync(string id, string email);
        Task DeleteUserAsync(string userId);
        Task ChangePasswordAsync(string id, string newPassword);
        Task LogoutAsync();
    }
}