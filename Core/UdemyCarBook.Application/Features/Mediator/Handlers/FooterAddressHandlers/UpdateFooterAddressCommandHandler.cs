using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class UpdateFooterAddressCommandHandler(IRepositor<FooterAddress> _repository) : IRequestHandler<UpdateFooterAddressCommand>
{
    public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.FooterAddressID);
        value.Phone = request.Phone;
        value.Address=request.Address;
        value.Description=request.Description;
        value.Email=request.Email;
        await _repository.UpdateAsync(value);
    }
}
