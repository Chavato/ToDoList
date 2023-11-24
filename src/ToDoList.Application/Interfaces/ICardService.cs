using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> CreateAsync(CardDto cardDto);
        Task<CardDto> UpdateAsync(CardDto cardDto);
        Task<CardDto> GetAsync(int cardId);
        Task<IEnumerable<CardDto>> GetAllAsync();
        Task DeleteAsync(int cardId);
        Task DeleteAllAsync();

    }
}