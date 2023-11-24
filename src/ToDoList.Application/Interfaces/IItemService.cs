using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IItemService
    {
        Task<ItemDto> CreateAsync(ItemDto itemDto);
        Task<ItemDto> UpdateAsync(ItemDto itemDto);
        Task<ItemDto> GetAsync(int itemId);
        Task<IEnumerable<ItemDto>> GetAllAsync(int checkListId);
        Task DeleteAsync(int itemId);
        Task DeleteAllAsync();
    }
}