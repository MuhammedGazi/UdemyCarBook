using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class RemoveBannerCommandHandler(IRepositor<Banner> _repository)
{
    public async Task Handle(RemoveBannerCommand command)
    {
        var value=await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(value);
    }
}
