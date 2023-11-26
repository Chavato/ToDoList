using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface ICheckListService
    {
        Task<CheckListDto> CreateAsync(CheckListDto checkListDto);
        Task UpdateAsync(CheckListDto checkListDto);
        Task<CheckListDto> GetAsync(Guid checkListId);
        Task<CheckListDto> GetDetailsAsync(Guid checkListId);
        Task<IEnumerable<CheckListDto>> GetAllAsync(Guid cardId);
        Task<IEnumerable<CheckListDto>> GetAllDetailsAsync(Guid cardId);
        Task DeleteAsync(Guid checkListId);
        Task DeleteAllAsync(Guid cardId);
    }
}