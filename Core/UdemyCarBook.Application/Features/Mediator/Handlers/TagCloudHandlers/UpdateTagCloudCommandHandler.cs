using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class UpdateTagCloudCommandHandler(IRepositor<TagCloud> _repository) : IRequestHandler<UpdateTagCloudCommand>
{
    public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.TagCloudID);
        value.Title = request.Title;
        value.BlogID = request.BlogID;
        await _repository.UpdateAsync(value);
    }
}
