using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface ICheckListService
    {
        Task<CheckListDto> CreateAsync(CheckListDto checkListDto);
        Task<CheckListDto> UpdateAsync(CheckListDto checkListDto);
        Task<CheckListDto> GetAsync(int checkListId);
        Task<IEnumerable<CheckListDto>> GetAllAsync(int cardId);
        Task DeleteAsync(int checkListId);
        Task DeleteAllAsync();
    }
}