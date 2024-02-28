using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApi.Models
{
    public class LoginUser
    {
        [Required]
        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(10, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}