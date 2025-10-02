using MediatR;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands
{
    public class CreateReviewCommand:IRequest
    {
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RatıngValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarID { get; set; }

    }
}
