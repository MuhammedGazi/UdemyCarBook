using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class CreateServiceCommandHandler(IRepositor<Service> _repository) : IRequestHandler<CreateServiceCommand>
{
    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Service
        {
            Description = request.Description,
            IconUrl = request.IconUrl,
            Title = request.Title,
        });
    }
}
