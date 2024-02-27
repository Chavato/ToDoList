using Microsoft.AspNetCore.Identity;

namespace ToDoList.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {

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