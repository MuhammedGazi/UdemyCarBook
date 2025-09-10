using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler(IRepositor<Category> _repository)
{
    public async Task Handle(UpdateCategoryCommand command)
    {
        var value=await _repository.GetByIdAsync(command.CategoryID);
        value.Name = command.Name;
        await _repository.UpdateAsync(value);
    }
}
