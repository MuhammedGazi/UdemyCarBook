using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class CreateBannerCommandHandler(IRepositor<Banner> _repository)
{
    public async Task Handle(CreateBannerCommand command)
    {
        await _repository.CreateAsync(new Banner
        {
            Description = command.Description,
            Title = command.Title,
            VideoDescription = command.VideoDescription,
            VideoUrl = command.VideoUrl,
        });
    }
}
