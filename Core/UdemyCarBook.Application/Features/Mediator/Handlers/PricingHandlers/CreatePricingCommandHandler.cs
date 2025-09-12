using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers;

public class CreatePricingCommandHandler(IRepositor<Pricing> _repository) : IRequestHandler<CreatePricingCommand>
{
    public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Pricing
        {
             Name = request.Name,
        });
    }
}
