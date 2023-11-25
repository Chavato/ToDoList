namespace ToDoList.Domain.Entities
{
    public sealed class CheckList : Entity
    {
        public Guid CardId { get; private set; }

        public Card? Card { get; set; }
        public IEnumerable<Item>? Items { get; private set; }

        public CheckList(string name, Guid cardId) : base(name)
        {
            CardId = cardId;
        }

        public void Update(string name)
        {
            Name = name;
        }

    }
}