using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;

internal class CreateFooterAddressCommandHandler(IRepositor<FooterAddress> _repository) : IRequestHandler<CreateFooterAddressCommand>
{
    public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new FooterAddress
        {
            Address = request.Address,
            Description = request.Description,
            Email = request.Email,  
            Phone = request.Phone,
        });
    }
}
