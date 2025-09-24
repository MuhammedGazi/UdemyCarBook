using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarPricingController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCarPricingWithCarList()
    {
        var values = await _mediator.Send(new GetCarPricingWithCarQuery());
        return Ok(values);
    }

    [HttpGet("GetCarPricingWithTimePeriodList")]
    public async Task<IActionResult> GetCarPricingWithTimePeriodList()
    {
        var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
        return Ok(values);
    }
}
