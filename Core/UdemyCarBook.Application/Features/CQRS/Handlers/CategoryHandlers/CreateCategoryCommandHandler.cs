using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler(IRepositor<Category> _repository)
{
    public async Task Handle(CreateCategoryCommand command)
    {
        await _repository.CreateAsync(new Category
        {
            Name = command.Name,
        });
    }
}
