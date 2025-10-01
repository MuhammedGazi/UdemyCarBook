using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableChangeToTrueToCommand:IRequest
    {
        public UpdateCarFeatureAvailableChangeToTrueToCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
