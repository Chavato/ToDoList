using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.Models.DTOs
{
    public class CardDto
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Name field could not be empty.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DifficultyLevel DifficultyLevel { get; set; }

        public Priority Priority { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeadLine { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [JsonIgnore]
        public string ApplicationUserId { get; set; } = string.Empty;

        public IEnumerable<CheckListDto>? CheckLists { get; set; }

    }
}