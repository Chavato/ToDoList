using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;

namespace ToDoList.Application.Services
{
    public class CheckListService : ICheckListService
    {
        public Task<CheckListDto> CreateAsync(CheckListDto checkListDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int checkListId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CheckListDto>> GetAllAsync(int cardId)
        {
            throw new NotImplementedException();
        }

        public Task<CheckListDto> GetAsync(int checkListId)
        {
            throw new NotImplementedException();
        }

        public Task<CheckListDto> UpdateAsync(CheckListDto checkListDto)
        {
            throw new NotImplementedException();
        }
    }
}