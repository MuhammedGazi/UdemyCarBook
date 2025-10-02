using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler(IRepositor<Review> _repository) : IRequestHandler<CreateReviewCommand>
    {
        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CarID = request.CarID,
                Comment = request.Comment,
                CustomerImage = request.CustomerImage,
                CustomerName = request.CustomerName,
                RatıngValue = request.RatıngValue,
                ReviewDate =DateTime.Parse(DateTime.Now.ToShortDateString())             
            });
        }
    }
}
