using ToDoList.Domain.Entities;

namespace ToDoList.Application.Models.DTOs
{
    public class CheckListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CardId { get; set; }
        public Card? Card { get; set; }
        public IEnumerable<Item>? Items { get; set; }
    }
}