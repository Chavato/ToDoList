namespace ToDoList.Domain.Entities
{
    public class Item : Entity
    {
        public bool IsDone { get; private set; }

        public Item(string name, bool isDone) : base(name)
        {
            IsDone = isDone;
        }

    }
}