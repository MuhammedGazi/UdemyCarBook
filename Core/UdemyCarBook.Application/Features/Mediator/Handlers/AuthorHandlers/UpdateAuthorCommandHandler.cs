using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class UpdateAuthorCommandHandler(IRepositor<Author> _repository) : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.AuthorID);
        value.Description = request.Description;
        value.ImageUrl = request.ImageUrl;
        value.Name = request.Name;
        await _repository.UpdateAsync(value);
    }
}
