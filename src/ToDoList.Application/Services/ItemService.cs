using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Services
{
    public class ItemService : IItemService
    {
        public Task<ItemDto> CreateAsync(ItemDto itemDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemDto>> GetAllAsync(int checkListId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDto> GetAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDto> UpdateAsync(ItemDto itemDto)
        {
            throw new NotImplementedException();
        }
    }
}