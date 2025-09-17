using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> AuthorList()
    {
        var values = await _mediator.Send(new GetAuthorQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var value=await _mediator.Send(new GetAuthorByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yazar Eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yazar Güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAuthor(int id)
    {
        await _mediator.Send(new RemoveAuthorCommand(id));
        return Ok("Yazar Silindi");
    }
}
