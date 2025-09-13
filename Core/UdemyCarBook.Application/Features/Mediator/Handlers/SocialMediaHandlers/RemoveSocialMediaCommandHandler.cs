using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class RemoveSocialMediaCommandHandler(IRepositor<SocialMedia> _repository) : IRequestHandler<RemoveSocialMediaCommand>
{
    public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
