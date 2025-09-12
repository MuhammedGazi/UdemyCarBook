using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var values = await _mediator.Send(new GetServiceQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetService(int id)
    {
        var value=await _mediator.Send(new GetServiceByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok("servise eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveService(int id)
    {
        await _mediator.Send(new RemoveServiceCommand(id));
        return Ok("service silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok("service güncellendi");
    }


}
