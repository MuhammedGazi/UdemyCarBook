using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler(IRepositor<Banner> _repository)
{
    public async Task Handle(UpdateBannerCommand command)
    {
        var values=await _repository.GetByIdAsync(command.BannerID);
        values.VideoDescription = command.VideoDescription;
        values.Title = command.Title;
        values.Description = command.Description;
        values.VideoUrl = command.VideoUrl;
        await _repository.UpdateAsync(values);
    }
}
