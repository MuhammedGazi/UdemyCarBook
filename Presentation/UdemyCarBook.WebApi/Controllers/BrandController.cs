using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController(
    CreateBrandCommandHandler _createBrandCommandHandler,
    UpdateBrandCommandHandler _updateBrandCommandHandler,
    RemoveBrandCommandHandler _removeBrandCommandHandler,
    GetBrandByIdQueryHandler _getBrandByIdQueryHandler,
    GetBrandQueryHandler _getBrandQueryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
        var values = await _getBrandQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand(int id)
    {
        var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
    {
        await _createBrandCommandHandler.Handle(command);
        return Ok("marka eklendi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBrand(int id)
    {
        await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
        return Ok("marka silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
    {
        await _updateBrandCommandHandler.Handle(command);
        return Ok("marka güncellendi");
    }
}
