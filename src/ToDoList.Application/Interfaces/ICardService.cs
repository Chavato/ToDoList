using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> CreateAsync(CardDto cardDto);
        Task UpdateAsync(CardDto cardDto);
        Task<CardDto> GetAsync(Guid cardId);
        Task<IEnumerable<CardDto>> GetAllAsync();
        Task DeleteAsync(Guid cardId);
        Task DeleteAllAsync();

    }
}