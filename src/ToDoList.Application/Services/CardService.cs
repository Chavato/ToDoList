using AutoMapper;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;

namespace ToDoList.Application.Services
{
    public class CardService : ICardService
    {

        private readonly ICardRepository _cardRepository;
        private readonly IUserInformation _userInformation;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper, IUserInformation userInformation)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
            _userInformation = userInformation;
        }

        public async Task<CardDto> CreateAsync(CardDto cardDto)
        {

            var user = await _userInformation.GetActualUser();

            cardDto.ApplicationUserId = user.Id;

            var card = _mapper.Map<Card>(cardDto);

            await _cardRepository.CreateAsync(card);

            cardDto.Id = card.Id;

            return cardDto;
        }

        public async Task DeleteAllAsync()
        {
            var card = await _cardRepository.GetAllAsync();

            await _cardRepository.DeleteRangeAsync(card);
        }

        public async Task DeleteAsync(Guid cardId)
        {
            var card = await _cardRepository.GetAsync(cardId);

            await _cardRepository.DeleteAsync(card);
        }

        public async Task<IEnumerable<CardDto>> GetAllAsync()
        {
            var cards = await _cardRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CardDto>>(cards);
        }

        public async Task<IEnumerable<CardDto>> GetAllDetailsAsync()
        {
            var cards = await _cardRepository.GetAllDetailsAsync();

            return _mapper.Map<IEnumerable<CardDto>>(cards);
        }

        public async Task<CardDto> GetAsync(Guid cardId)
        {
            var card = await _cardRepository.GetAsync(cardId);

            return _mapper.Map<CardDto>(card);
        }

        public async Task<CardDto> GetDetailsAsync(Guid cardId)
        {
            var card = await _cardRepository.GetDetailsAsync(cardId);

            return _mapper.Map<CardDto>(card);
        }

        public async Task UpdateAsync(CardDto cardDto)
        {
            if (cardDto.Id == null)
            {
                throw new BadRequestException("Invalid id.");
            }

            var card = await _cardRepository.GetAsync((Guid)cardDto.Id);

            card.Update(cardDto.Name,
                        cardDto.Description,
                        cardDto.DifficultyLevel,
                        cardDto.Priority,
                        cardDto.DeadLine,
                        cardDto.StartTime);

            await _cardRepository.UpdateAsync(card);
        }
    }
}