using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers;

public class RemovePricingCommandHandler(IRepositor<Pricing> _repository) : IRequestHandler<RemovePricingCommand>
{
    public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
