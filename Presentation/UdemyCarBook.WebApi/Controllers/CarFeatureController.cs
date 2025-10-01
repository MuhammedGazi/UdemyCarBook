using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarFeatureController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CarFeatureListByCarId(int id)
    {
        var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
        return Ok(values);
    }

    [HttpGet("CarFeatureAvailableChangeToFalse")]
    public async Task<IActionResult> CarFeatureAvailableChangeToFalse(int id)
    {
        await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseToCommand(id));
        return Ok("araba özelliği false yapıldı");
    }

    [HttpGet("CarFeatureAvailableChangeToTrue")]
    public async Task<IActionResult> CarFeatureAvailableChangeToTrue(int id)
    {
        await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueToCommand(id));
        return Ok("araba özelliği true yapıldı");
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
    {
        _mediator.Send(command);
        return Ok("Ekleme yapıldı");
    }
}
