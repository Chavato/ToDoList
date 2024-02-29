using ToDoList.Domain.Entities;

namespace ToDoList.Application.Models.DTOs
{
    public class CheckListDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CardId { get; set; }
        public IEnumerable<ItemDto>? Items { get; set; }
    }
}