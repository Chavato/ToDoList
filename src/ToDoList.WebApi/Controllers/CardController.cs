using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;

namespace ToDoList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : DefaultController
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CardDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CardDto cardDto)
        {
            try
            {

                ValidateModelState();

                cardDto = await _cardService.CreateAsync(cardDto);

                return Ok(cardDto);
            }

            catch (BadRequestException err)
            {
                return Problem(detail: err.Message, statusCode: 400);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] CardDto cardDto)
        {
            try
            {

                ValidateModelState();

                await _cardService.UpdateAsync(cardDto);

                return NoContent();
            }

            catch (BadRequestException err)
            {
                return Problem(detail: err.Message, statusCode: 400);
            }

            catch (NotFoundException err)
            {
                return Problem(detail: err.Message, statusCode: 404);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpGet("{cardId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CardDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid cardId)
        {
            try
            {

                var card = await _cardService.GetAsync(cardId);

                return Ok(card);
            }

            catch (NotFoundException err)
            {
                return Problem(detail: err.Message, statusCode: 404);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpGet("Details/{cardId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CardDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetailsAsync(Guid cardId)
        {
            try
            {

                var card = await _cardService.GetDetailsAsync(cardId);

                return Ok(card);
            }

            catch (NotFoundException err)
            {
                return Problem(detail: err.Message, statusCode: 404);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        { 
            try
            {

                var cards = await _cardService.GetAllAsync();

                return Ok(cards);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpGet("All/Details")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllDetailsAsync()
        {
            try
            {

                var cards = await _cardService.GetAllDetailsAsync();

                return Ok(cards);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid cardId)
        {
            try
            {

                await _cardService.DeleteAsync(cardId);

                return NoContent();
            }

            catch (NotFoundException err)
            {
                return Problem(detail: err.Message, statusCode: 404);
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

        [HttpDelete("All")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAllAsync()
        {
            try
            {

                await _cardService.DeleteAllAsync();

                return NoContent();
            }

            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    return Problem(detail: err.InnerException.Message, statusCode: 500);
                }
                return Problem(detail: err.Message, statusCode: 500);
            }
        }

    }
}