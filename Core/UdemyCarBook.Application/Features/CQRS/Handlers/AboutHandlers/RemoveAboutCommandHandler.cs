using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class RemoveAboutCommandHandler(IRepositor<About> _repository)
{
    public async Task Handle(RemoveAboutCommand command)
    {
        var value=await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(value);
    }
}
