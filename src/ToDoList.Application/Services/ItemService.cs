using AutoMapper;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;

namespace ToDoList.Application.Services
{
    public class ItemService : IItemService
    {

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> CreateAsync(ItemDto itemDto)
        {

            var item = _mapper.Map<Item>(itemDto);

            await _itemRepository.CreateAsync(item);

            itemDto.Id = item.Id;

            return itemDto;
        }

        public async Task DeleteAllAsync(Guid checkListId)
        {

            var items = await _itemRepository.GetByCheckListId(checkListId);

            await _itemRepository.DeleteRangeAsync(items);
        }

        public async Task DeleteAsync(Guid itemId)
        {
            var item = await _itemRepository.GetAsync(itemId);

            await _itemRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync(Guid checkListId)
        {
            var items = await _itemRepository.GetByCheckListId(checkListId);

            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto> GetAsync(Guid itemId)
        {
            var item = await _itemRepository.GetAsync(itemId);

            return _mapper.Map<ItemDto>(item);
        }

        public async Task UpdateAsync(ItemDto itemDto)
        {
            var item = await _itemRepository.GetAsync(itemDto.Id);

            item.Update(itemDto.Name, itemDto.IsDone);

            await _itemRepository.UpdateAsync(item);
        }
    }
}