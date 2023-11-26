using AutoMapper;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
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

        public async Task<CheckListDto> CreateAsync(CheckListDto checkListDto)
        {

            var checkList = _mapper.Map<CheckList>(checkListDto);

            await _checkListRepository.CreateAsync(checkList);

            checkListDto.Id = checkList.Id;

            return checkListDto;
        }

        public async Task DeleteAllAsync(Guid cardId)
        {
            var checkLists = await _checkListRepository.GetByCardIdAsync(cardId);

            await _checkListRepository.DeleteRangeAsync(checkLists);
        }

        public async Task DeleteAsync(Guid checkListId)
        {

            var checkList = await _checkListRepository.GetAsync(checkListId);

            await _checkListRepository.DeleteAsync(checkList);
        }

        public async Task<IEnumerable<CheckListDto>> GetAllAsync(Guid cardId)
        {

            var checkLists = await _checkListRepository.GetByCardIdAsync(cardId);

            return _mapper.Map<IEnumerable<CheckListDto>>(checkLists);
        }

        public async Task<IEnumerable<CheckListDto>> GetAllDetailsAsync(Guid cardId)
        {
            var checkLists = await _checkListRepository.GetDetailsByCardIdAsync(cardId);

            return _mapper.Map<IEnumerable<CheckListDto>>(checkLists);
        }

        public async Task<CheckListDto> GetAsync(Guid checkListId)
        {

            var checkList = await _checkListRepository.GetAsync(checkListId);

            return _mapper.Map<CheckListDto>(checkList);
        }

        public async Task<CheckListDto> GetDetailsAsync(Guid checkListId)
        {
            var checkList = await _checkListRepository.GetDetailsAsync(checkListId);

            return _mapper.Map<CheckListDto>(checkList);
        }

        public async Task UpdateAsync(CheckListDto checkListDto)
        {

            if (checkListDto.Id == null)
            {
                throw new BadRequestException("Invalid id.");
            }

            var checkList = await _checkListRepository.GetAsync((Guid)checkListDto.Id);

            checkList.Update(checkListDto.Name);

            await _checkListRepository.UpdateAsync(checkList);
        }
    }
}