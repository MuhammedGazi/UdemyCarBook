using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers;

public class CreateCommentCommandHandler(IRepositor<Comment> _repository) : IRequestHandler<CreateCommentCommand>
{
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Comment
        {
            CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
            Description = request.Description,
            Name = request.Name,
            BlogID = request.BlogID,
            Email = request.Email,
        });
    }
}
