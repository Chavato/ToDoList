namespace ToDoList.Application.Models.DTOs
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public IEnumerable<CardDto>? ApplicationUserId { get; set; }
    }
}