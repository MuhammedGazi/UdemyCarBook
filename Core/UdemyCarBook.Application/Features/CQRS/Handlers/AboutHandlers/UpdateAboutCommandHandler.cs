using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler(IRepositor<About> _repository)
{
    public async Task Handle(UpdateAboutCommand command)
    {
        var value = await _repository.GetByIdAsync(command.AboutID);
        value.Description = command.Description;
        value.Title = command.Title;
        value.ImageUrl = command.ImageUrl;
        await _repository.UpdateAsync(value);
    }
}
