using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface ICheckListRepository : IRepository<CheckList>
    {
        Task<IEnumerable<CheckList>> GetByCardIdAsync(Guid cardId);
        Task<IEnumerable<CheckList>> GetDetailsByCardIdAsync(Guid cardId);
        Task<CheckList> GetDetailsAsync(Guid checkListId);
    }
}