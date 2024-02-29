namespace ToDoList.Application.Models.DTOs
{
    public class ItemDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        public Guid CheckListId { get; set; }
    }
}