using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class RemoveFooterAddressCommandHandler(IRepositor<FooterAddress> _repository) : IRequestHandler<RemoveFooterAddressCommand>
{
    public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
