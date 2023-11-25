using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories
{
    public class CheckListRepository : Repository<CheckList>, ICheckListRepository
    {
        public CheckListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CheckList>> GetByCardIdAsync(Guid cardId)
        {
            return await _context.CheckList.AsNoTracking()
                                           .Where(checkList => checkList.CardId == cardId)
                                           .ToListAsync();
        }
    }
}