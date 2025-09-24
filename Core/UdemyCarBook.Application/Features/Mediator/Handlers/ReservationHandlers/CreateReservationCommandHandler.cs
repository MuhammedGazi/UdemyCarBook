using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers;

public class CreateReservationCommandHandler(IRepositor<Reservation> _repository) : IRequestHandler<CreateReservationCommand>
{
    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Reservation
        {
            Age = request.Age,
            CarID = request.CarID,
            Description = request.Description,
            DriverLicenseYear = request.DriverLicenseYear,
            DropOffLocationID = request.DropOffLocationID,
            PickUpLocationID = request.PickUpLocationID,
            Surname = request.Surname,
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Status = "Rezervasyon Alındı"
        });
    }
}
