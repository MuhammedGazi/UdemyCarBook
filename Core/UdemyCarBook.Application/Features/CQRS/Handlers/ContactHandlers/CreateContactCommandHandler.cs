using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class CreateContactCommandHandler(IRepositor<Contact> _repository)
{
    public async Task Handle(CreateContactCommand command)
    {
        await _repository.CreateAsync(new Contact
        {
            Email = command.Email,
            Message= command.Message,
            Name = command.Name,
            SendDate = command.SendDate,
            Subject = command.Subject,
        });
    }
}
