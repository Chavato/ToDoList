using AutoMapper;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;

namespace ToDoList.Application.Services
{
    public class CheckListService : ICheckListService
    {

        private readonly ICheckListRepository _checkListRepository;
        private readonly IMapper _mapper;

        public CheckListService(ICheckListRepository checkListRepository, IMapper mapper)
        {
            _checkListRepository = checkListRepository;
            _mapper = mapper;
        }

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