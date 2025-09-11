using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler(IRepositor<Contact> _repository)
{
   public async Task Handle(UpdateContactCommand command)
    {
        var value=await _repository.GetByIdAsync(command.ContactID);
        value.Email = command.Email;
        value.SendDate = command.SendDate;
        value.Subject = command.Subject;
        value.Message = command.Message;
        value.Name = command.Name;
        await _repository.UpdateAsync(value);
    }
}
