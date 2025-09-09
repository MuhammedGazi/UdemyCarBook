using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler(IRepositor<Car> _repository)
{
    public async Task Handle(UpdateCarCommand command)
    {
        var value=await _repository.GetByIdAsync(command.CarId);
        value.BrandId = command.BrandId;
        value.Model = command.Model;
        value.CoverImageUrl = command.CoverImageUrl;
        value.Km=command.Km;
        value.Transmission=command.Transmission;
        value.Seat=command.Seat;
        value.Luggage=command.Luggage;
        value.Fuel=command.Fuel;
        value.BıgImageUrl=command.BıgImageUrl;
        await _repository.UpdateAsync(value);
    }
}
