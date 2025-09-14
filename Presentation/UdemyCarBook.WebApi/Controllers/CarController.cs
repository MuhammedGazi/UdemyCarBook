using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController(
    CreateCarCommandHandler _createCarCommandHandler,
    UpdateCarCommandHandler _updateCarCommandHandler,
    RemoveCarCommandHandler _removeCarCommandHandler,
    GetCarByIdQueryHandler _getCarByIdQueryHandler,
    GetCarQueryHandler _getCarQueryHandler,
    GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler,
    GetLast5CarWithBrandQueryHandler _getLast5CarWithBrandQueryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var values = await _getCarQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var value=await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Ok("araba eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("araba silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("araba güncellendi");
    }

    [HttpGet("GetCarWithBrand")]
    public IActionResult GetCarWithBrand()
    {
        var values=_getCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("GetLast5CarWithBrandQueryHandler")]
    public IActionResult GetLast5CarWithBrandQueryHandler()
    {
        var values = _getLast5CarWithBrandQueryHandler.Handle();
        return Ok(values);
    }
}
