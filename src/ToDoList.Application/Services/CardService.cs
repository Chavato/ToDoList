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
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardDto> CreateAsync(CardDto cardDto)
        {
            // cardDto.Id = Guid.Empty;
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

        public async Task<CardDto> GetAsync(Guid cardId)
        {
            var card = await _cardRepository.GetAsync(cardId);

            return _mapper.Map<CardDto>(card);
        }

        public async Task UpdateAsync(CardDto cardDto)
        {
            if (cardDto.Id == null)
            {
                throw new BadRequestException("Invalid id.");
            }

            var card = await _cardRepository.GetAsync((Guid)cardDto.Id);

            card.Update(card.Name,
                        card.Description,
                        card.DifficultyLevel,
                        card.Priority,
                        card.DeadLine,
                        card.StartTime);

            await _cardRepository.UpdateAsync(card);
        }
    }
}