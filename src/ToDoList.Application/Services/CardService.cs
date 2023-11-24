using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Services
{
    public class CardService : ICardService
    {
        public Task<CardDto> CreateAsync(CardDto cardDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int cardId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CardDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> GetAsync(int cardId)
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> UpdateAsync(CardDto cardDto)
        {
            throw new NotImplementedException();
        }
    }
}