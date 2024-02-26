namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUser(string email, string password);
        Task<string> RegisterUser(string email, string password, IEnumerable<string> roles);
        Task UpdateUser(string id, string email);
        Task DeleteUser(string userId);
        Task ChangePassword(string id, string newPassword);
        Task Logout();
    }
}