using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface ICheckListRepository : IRepository<CheckList>
    {
        Task<IEnumerable<CheckList>> GetByCardIdAsync(Guid cardId);
    }
}