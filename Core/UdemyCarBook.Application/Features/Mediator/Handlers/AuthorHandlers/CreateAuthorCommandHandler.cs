using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class CreateAuthorCommandHandler(IRepositor<Author> _repository) : IRequestHandler<CreateAuthorCommand>
{
    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Author
        {
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
        });
    }
}
