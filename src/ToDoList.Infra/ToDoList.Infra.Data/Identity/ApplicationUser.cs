using Microsoft.AspNetCore.Identity;
using ToDoList.Domain.Entities;

namespace ToDoList.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Card>? Cards { get; set; }

        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName, string email)
        {
            Email = email;
            UserName = userName;
        }
    }
}