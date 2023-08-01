namespace ToDoList.Domain.Entities
{
    public sealed class CheckList : Entity
    {
        public IEnumerable<Item> Items { get; private set; }

        public CheckList(IEnumerable<Item> items, string name) : base(name)
        {
            Items = items;
        }

    }
}