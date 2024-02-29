using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> CreateAsync(CardDto cardDto, string userName);
        Task UpdateAsync(CardDto cardDto);
        Task<CardDto> GetAsync(Guid cardId);
        Task<CardDto> GetDetailsAsync(Guid cardId);
        Task<IEnumerable<CardDto>> GetAllDetailsAsync();
        Task<IEnumerable<CardDto>> GetAllAsync();
        Task DeleteAsync(Guid cardId);
        Task DeleteAllAsync();

    }
}