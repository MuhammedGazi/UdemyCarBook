using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class CreateTagCloudCommandHandler(IRepositor<TagCloud> _repository) : IRequestHandler<CreateTagCloudCommand>
{
    public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new TagCloud
        {
            Title = request.Title,
            BlogID = request.BlogID,
        });
    }
}
