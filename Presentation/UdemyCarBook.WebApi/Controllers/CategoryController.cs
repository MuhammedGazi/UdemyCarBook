using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(
        GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler,
        GetCategoryQueryHandler _getCategoryQueryHandler,
        RemoveCategoryCommandHandler _removeCategoryCommandHandler,
        CreateCategoryCommandHandler _createCategoryCommandHandler,
        UpdateCategoryCommandHandler _updateCategoryCommandHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _getCategoryQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value= await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("kategori eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("kategori silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("kategori güncellendi");
        }
    }
}
