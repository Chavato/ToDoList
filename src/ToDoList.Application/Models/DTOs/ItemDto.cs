namespace ToDoList.Application.Models.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int CheckListId { get; set; }
    }
}