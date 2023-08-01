namespace ToDoList.Domain.Entities
{
    public abstract class Entity
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        public Entity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreateTime = DateTime.UtcNow;
            ModifyTime = DateTime.UtcNow;
        }
    }
}