using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces.RepositoriesInterfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<IEnumerable<Card>> GetAllDetailsAsync();
        Task<Card> GetDetailsAsync(Guid cardId);
    }
}