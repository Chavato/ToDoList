using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models.DTOs;

namespace ToDoList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListController : DefaultController
    {
        private readonly ICheckListService _checkListService;

        public CheckListController(ICheckListService checkListService)
        {
            _checkListService = checkListService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CheckListDto checkList)
        {

            ValidateModelState();

            await _checkListService.CreateAsync(checkList);

            return Ok(checkList);
        }
    }
}