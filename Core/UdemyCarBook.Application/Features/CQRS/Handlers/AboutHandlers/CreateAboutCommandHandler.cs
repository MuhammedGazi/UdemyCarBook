using System.Net.Http.Headers;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class CreateAboutCommandHandler(IRepositor<About> _repository)
{
    public async Task Handle(CreateAboutCommand command)
    {
        await _repository.CreateAsync(new About
        {
            Title = command.Title,
            Description = command.Description,
            ImageUrl = command.ImageUrl,
        });
    }
}
