namespace ToDoList.Domain.Entities
{
    public class Item : Entity
    {
        public bool IsDone { get; private set; }
        public Guid CheckListId { get; set; }

        public CheckList? CheckList { get; set; }

        public Item(string name, bool isDone) : base(name)
        {
            IsDone = isDone;
        }

        public void Update(string name, bool isDone)
        {
            Name = name;
            IsDone = isDone;
        }

    }
}