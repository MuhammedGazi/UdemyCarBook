using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SocialMediaList()
    {
        var values = await _mediator.Send(new GetSocialMediaQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSocialMedia(int id)
    {
        var value=await _mediator.Send(new GetSocialMediaByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok("sosyal medya eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveSocialMedia(int id)
    {
        await _mediator.Send(new RemoveSocialMediaCommand(id));
        return Ok("sosyal medya silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok("sosyal medya güncellendi");
    }

}
