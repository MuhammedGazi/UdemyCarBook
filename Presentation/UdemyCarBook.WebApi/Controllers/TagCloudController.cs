using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagCloudController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> TagCloudList()
    {
        var values = await _mediator.Send(new GetTagCloudQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagCloud(int id)
    {
        var value=await _mediator.Send(new GetTagCloudByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
    {
        await _mediator.Send(command);
        return Ok("etiket eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
    {
        await _mediator.Send(command);
        return Ok("etiket güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveTagCloud(int id)
    {
        await _mediator.Send(new RemoveTagCloudCommand(id));
        return Ok("etiket silindi");
    }

    [HttpGet("GetTagCloudByBlogId")]
    public async Task<IActionResult> GetTagCloudByBlogId(int id)
    {
        var value = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
        return Ok(value);
    }

}
