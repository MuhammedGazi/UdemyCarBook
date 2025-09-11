using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class RemoveFeatureCommandHandler(IRepositor<Feature> _repository) : IRequestHandler<RemoveFeatureCommand>
{
    public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
    {
       var value=await _repository.GetByIdAsync(request.Id);
       await _repository.RemoveAsync(value);
    }
}
