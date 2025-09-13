using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class UpdateSocialMediaCommandHandler(IRepositor<SocialMedia> _repository) : IRequestHandler<UpdateSocialMediaCommand>
{
    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.SocialMediaID);
        value.Url = request.Url;
        value.Icon= request.Icon;
        value.Name = request.Name;
        await _repository.UpdateAsync(value);
    }
}
