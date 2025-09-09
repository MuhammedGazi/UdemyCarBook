using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler(IRepositor<Car> _repository)
{
    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            BrandId = command.BrandId,
            Model = command.Model,
            CoverImageUrl = command.CoverImageUrl,
            Km=command.Km,
            Transmission=command.Transmission,
            Seat=command.Seat,
            Luggage=command.Luggage,
            Fuel=command.Fuel,
            BıgImageUrl=command.BıgImageUrl,
        });
    }
}
