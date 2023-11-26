using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetByCheckListIdAsync(Guid checkListId);
    
    }
}