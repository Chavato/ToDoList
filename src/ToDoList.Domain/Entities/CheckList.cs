namespace ToDoList.Domain.Entities
{
    public sealed class CheckList : Entity
    {
        public int CardId { get; private set; }

        public Card? Card { get; set; }
        public IEnumerable<Item>? Items { get; private set; }

        public CheckList(string name, int cardId) : base(name)
        {
            CardId = cardId;
        }

    }
}