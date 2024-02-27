using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Exceptions;

namespace ToDoList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CheckListController : DefaultController
    {
        private readonly ICheckListService _checkListService;

        public CheckListController(ICheckListService checkListService)
        {
            _checkListService = checkListService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CheckListDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CheckListDto checkList)
        {
            try
            {

                ValidateModelState();

                await _checkListService.CreateAsync(checkList);

                return Ok(checkList);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] CheckListDto checkList)
        {
            try
            {

                ValidateModelState();

                await _checkListService.UpdateAsync(checkList);

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

        [HttpGet("{checkListId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CheckListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid checkListId)
        {
            try
            {

                var checkList = await _checkListService.GetAsync(checkListId);

                return Ok(checkList);
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

        [HttpGet("Details/{checkListId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CheckListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetailsAsync(Guid checkListId)
        {
            try
            {

                var checkList = await _checkListService.GetDetailsAsync(checkListId);

                return Ok(checkList);
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

        [HttpGet("All/{cardId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CheckListDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(Guid cardId)
        {
            try
            {

                var checkLists = await _checkListService.GetAllAsync(cardId);

                return Ok(checkLists);
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

        [HttpGet("All/Details/{cardId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CheckListDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllDetailsAsync(Guid cardId)
        {
            try
            {

                var checkLists = await _checkListService.GetAllDetailsAsync(cardId);

                return Ok(checkLists);
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


        [HttpDelete("{checkListId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid checkListId)
        {
            try
            {

                await _checkListService.DeleteAsync(checkListId);

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

        [HttpDelete("All/{cardId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAllAsync(Guid cardId)
        {
            try
            {

                await _checkListService.DeleteAllAsync(cardId);

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



    }
}