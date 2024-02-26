using ToDoList.Domain.Interfaces.RepositoriesInterfaces;

namespace ToDoList.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> AuthenticateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task ChangePassword(string id, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterUser(string email, string password, IEnumerable<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(string id, string email)
        {
            throw new NotImplementedException();
        }
    }
}