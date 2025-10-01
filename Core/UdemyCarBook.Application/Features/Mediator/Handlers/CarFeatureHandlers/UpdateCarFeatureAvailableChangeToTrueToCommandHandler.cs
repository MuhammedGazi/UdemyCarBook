using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;

public class UpdateCarFeatureAvailableChangeToTrueToCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueToCommand>
{
    public async Task Handle(UpdateCarFeatureAvailableChangeToTrueToCommand request, CancellationToken cancellationToken)
    {
        _repository.ChangeCarFeatureAvailableToTrue(request.Id);
    }
}
