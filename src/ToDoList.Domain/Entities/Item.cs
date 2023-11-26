namespace ToDoList.Domain.Entities
{
    public class Item : Entity
    {
        public bool IsDone { get; private set; }
        public Guid CheckListId { get; private set; }

        public CheckList? CheckList { get; set; }

        public Item(string name, bool isDone, Guid checkListId) : base(name)
        {
            IsDone = isDone;
            CheckListId = checkListId;
        }

        public void Update(string name, bool isDone)
        {
            Name = name;
            IsDone = isDone;
        }

    }
}