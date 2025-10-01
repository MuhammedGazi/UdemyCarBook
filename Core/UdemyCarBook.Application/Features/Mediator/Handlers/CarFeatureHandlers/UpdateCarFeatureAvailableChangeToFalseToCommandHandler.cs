using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;

public class UpdateCarFeatureAvailableChangeToFalseToCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<UpdateCarFeatureAvailableChangeToFalseToCommand>
{
    public async Task Handle(UpdateCarFeatureAvailableChangeToFalseToCommand request, CancellationToken cancellationToken)
    {
        _repository.ChangeCarFeatureAvailableToFalse(request.Id);
    }
}
