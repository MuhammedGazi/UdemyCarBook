using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController
    (CreateAboutCommandHandler _createAboutCommandHandler,
    GetAboutByIdQueryHandler _getAboutByIdQueryHandler, 
    GetAboutQueryHandler _getAboutQueryHandler,
    RemoveAboutCommandHandler _removeAboutCommandHandler,
    UpdateAboutCommandHandler _updateAboutCommandHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await _getAboutQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
    {
        await _createAboutCommandHandler.Handle(command);
        return Ok("hakkımda bilgisi eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAbout(int id)
    {
        await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok("hakkımda bilgisi silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
    {
        await _updateAboutCommandHandler.Handle(command);
        return Ok("hakkımda bilgisi güncellendi");
    }
}
