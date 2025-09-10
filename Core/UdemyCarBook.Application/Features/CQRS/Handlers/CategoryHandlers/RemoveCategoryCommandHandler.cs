using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler(IRepositor<Category> _repository)
{
    public async Task Handle(RemoveCategoryCommand command)
    {
        var value=await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(value);
    }
}
