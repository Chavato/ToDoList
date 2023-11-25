using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Item>> GetByCheckListId(Guid checkListId)
        {

            return await _context.Item.AsNoTracking()
                                      .Where(item => item.CheckListId == checkListId)
                                      .ToListAsync();
                                      
        }
    }
}