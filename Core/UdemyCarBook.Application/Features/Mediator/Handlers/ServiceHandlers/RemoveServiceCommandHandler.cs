using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class RemoveServiceCommandHandler(IRepositor<Service> _repository) : IRequestHandler<RemoveServiceCommand>
{
    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
