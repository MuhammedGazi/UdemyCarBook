using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class RemoveContactCommandHandler(IRepositor<Contact> _repository)
{
    public async Task Handle(RemoveContactCommand command)
    {
        var value=await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(value);
    }
}
