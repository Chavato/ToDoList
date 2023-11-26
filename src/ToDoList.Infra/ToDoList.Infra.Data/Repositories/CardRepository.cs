using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Card>> GetAllDetailsAsync()
        {
            return await _context.Card.AsNoTracking()
                                      .Include(card => card.CheckLists)
                                      .ThenInclude(checkList => checkList.Items)
                                      .ToListAsync();
        }

        public async Task<Card> GetDetailsAsync(Guid cardId)
        {

            var card = await _context.Card.AsNoTracking()
                                      .Include(card => card.CheckLists)
                                      .ThenInclude(checkList => checkList.Items)
                                      .Where(card => card.Id == cardId)
                                      .SingleOrDefaultAsync();

            if (card == null)
            {
                throw new NotFoundException("Entity does not exist.");
            }

            return card;
        }
    }
}