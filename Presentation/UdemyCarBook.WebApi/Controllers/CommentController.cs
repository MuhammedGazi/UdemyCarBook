using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController(IGenericRepository<Comment> _repository,IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult CommentList()
    {
        var values=_repository.GetAll();
        return Ok(values);
    }

    [HttpPost]
    public  IActionResult CreateComment(Comment comment)
    {
        _repository.Create(comment);
        return Ok("yorum başarılı şekilde eklendi");
    }

    [HttpDelete]
    public IActionResult RemoveComment(int id)
    {
        var value=_repository.GetById(id);
        _repository.Remove(value);
        return Ok("yorum başarılı şekilde silindi");
    }

    [HttpPut]
    public IActionResult UpdateComment(Comment comment)
    {
        _repository.Update(comment);
        return Ok("yorum başarılı şekilde güncellendi");
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        var value = _repository.GetById(id);
        return Ok(value);
    }

    [HttpGet("CommentListByBlog")]
    public IActionResult CommentListByBlog(int id)
    {
        var value = _repository.GetCommentsByBlogId(id);
        return Ok(value);
    }

    [HttpGet("CommentCountByBlog")]
    public IActionResult CommentCountByBlog(int id)
    {
        var value = _repository.GetCountCommentByBlog(id);
        return Ok(value);
    }

    [HttpPost("CreateCommentWithMediator")]
    public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("yorum eklendi");
    }
}
