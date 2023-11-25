using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> CreateAsync(ItemDto itemDto);
        Task UpdateAsync(ItemDto itemDto);
        Task<ItemDto> GetAsync(Guid itemId);
        Task<IEnumerable<ItemDto>> GetAllAsync(Guid checkListId);
        Task DeleteAsync(Guid itemId);
        Task DeleteAllAsync(Guid checkListId);
    }
}