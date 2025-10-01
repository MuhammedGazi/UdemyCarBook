using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableChangeToFalseToCommand:IRequest
    {
        public UpdateCarFeatureAvailableChangeToFalseToCommand(int id)
        {
            Id = id;
        }

        public int  Id { get; set; }
    }
}
