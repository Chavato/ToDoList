using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
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

        public async Task<CheckList> GetDetailsAsync(Guid checkListId)
        {
            var card = await _context.CheckList.AsNoTracking()
                                               .Include(checkList => checkList.Items)
                                               .Where(checkList => checkList.Id == checkListId)
                                               .SingleOrDefaultAsync();

            if (card == null)
            {
                throw new NotFoundException("Entity does not found.");
            }

            return card;
        }

        public async Task<IEnumerable<CheckList>> GetDetailsByCardIdAsync(Guid cardId)
        {
            return await _context.CheckList.AsNoTracking()
                                           .Include(checkList => checkList.Items)
                                           .Where(checkList => checkList.CardId == cardId)
                                           .ToListAsync();
        }
    }
}