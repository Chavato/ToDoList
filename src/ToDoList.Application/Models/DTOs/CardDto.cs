using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.Models.DTOs
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public Priority Priority { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime StartTime { get; set; }
        public IEnumerable<CheckList>? CheckLists { get; set; }
    }
}