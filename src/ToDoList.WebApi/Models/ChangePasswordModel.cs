using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApi.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;
    }
}