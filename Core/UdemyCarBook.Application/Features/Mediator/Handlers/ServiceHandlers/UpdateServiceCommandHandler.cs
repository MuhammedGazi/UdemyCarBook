using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class UpdateServiceCommandHandler(IRepositor<Service> _repository) : IRequestHandler<UpdateServiceCommand>
{
    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.ServiceID);
        value.Description = request.Description;
        value.IconUrl = request.IconUrl;
        value.Title = request.Title;
        await _repository.UpdateAsync(value);
    }
}
