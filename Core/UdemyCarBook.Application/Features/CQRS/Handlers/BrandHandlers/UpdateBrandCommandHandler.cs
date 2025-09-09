using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class UpdateBrandCommandHandler(IRepositor<Brand> _repository)
{
    public async Task Handle(UpdateBrandCommand command)
    {
        var value=await _repository.GetByIdAsync(command.BrandID);
        value.Name = command.Name;
        await _repository.UpdateAsync(value);

    }
}
