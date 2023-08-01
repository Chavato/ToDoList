using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities
{
    public sealed class Card : Entity
    {
        public string Description { get; private set; }
        public IEnumerable<CheckList> CheckLists { get; private set; }
        public DifficultyLevel DifficultyLevel { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime DeadLine { get; private set; }
        public DateTime StartTime { get; private set; }

        public Card(string name,
                    string description,
                    IEnumerable<CheckList> checkLists,
                    DifficultyLevel difficultyLevel,
                    Priority priority,
                    DateTime deadLine,
                    DateTime startTime) : base(name)
        {
            Description = description;
            CheckLists = checkLists;
            DifficultyLevel = difficultyLevel;
            Priority = priority;
            DeadLine = deadLine;
            StartTime = startTime;
        }

    }
}