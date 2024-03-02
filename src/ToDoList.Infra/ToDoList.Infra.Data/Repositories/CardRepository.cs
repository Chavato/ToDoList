using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly IUserInformation _userInformation;
        public CardRepository(ApplicationDbContext context, IUserInformation userInformation) : base(context)
        {
            _userInformation = userInformation;
        }

        public async Task<IEnumerable<Card>> GetAllDetailsAsync()
        {

            ApplicationUserDto user = await _userInformation.GetActualUser();

            return await _context.Card.AsNoTracking()
                                      .Include(card => card.CheckLists)!
                                      .ThenInclude(checkList => checkList.Items)
                                      .Where(card => card.ApplicationUserId == user.Id)
                                      .ToListAsync();
        }

        public async Task<Card> GetDetailsAsync(Guid cardId)
        {

            ApplicationUserDto user = await _userInformation.GetActualUser();

            var card = await _context.Card.AsNoTracking()
                                      .Include(card => card.CheckLists)!
                                      .ThenInclude(checkList => checkList.Items)
                                      .Where(card => card.Id == cardId && card.ApplicationUserId == user.Id)
                                      .SingleOrDefaultAsync();

            if (card == null)
            {
                throw new NotFoundException("Entity does not exist.");
            }

            return card;
        }

        public override async Task<IEnumerable<Card>> GetAllAsync()
        {
            ApplicationUserDto user = await _userInformation.GetActualUser(); 

            return _context.Card.AsNoTracking()
                                .Where(card => card.ApplicationUserId == user.Id);
        }
    }
}