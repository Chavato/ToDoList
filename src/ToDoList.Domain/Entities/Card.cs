using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities
{
    public sealed class Card : Entity
    {
        public string Description { get; private set; }
        public DifficultyLevel DifficultyLevel { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime DeadLine { get; private set; }
        public DateTime StartTime { get; private set; }
        public IEnumerable<CheckList>? CheckLists { get; private set; }
        public string ApplicationUserId { get; private set; }

        public Card(string name,
                    string description,
                    DifficultyLevel difficultyLevel,
                    Priority priority,
                    DateTime deadLine,
                    DateTime startTime,
                    string applicationUserId) : base(name)
        {
            Description = description;
            DifficultyLevel = difficultyLevel;
            Priority = priority;
            DeadLine = deadLine;
            StartTime = startTime;
            ApplicationUserId = applicationUserId;
        }

        public void Update(string name,
                           string description,
                           DifficultyLevel difficultyLevel,
                           Priority priority,
                           DateTime deadLine,
                           DateTime startTime)
        {
            Name = name;
            Description = description;
            DifficultyLevel = difficultyLevel;
            Priority = priority;
            DeadLine = deadLine;
            StartTime = startTime;
        }
    }
}