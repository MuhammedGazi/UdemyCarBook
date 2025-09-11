using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class UpdateFeatureCommandHandler(IRepositor<Feature> _repository) : IRequestHandler<UpdateFeatureCommand>
{
    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.FeatureID);
        value.Name = request.Name;
        await _repository.UpdateAsync(value);
    }
}
