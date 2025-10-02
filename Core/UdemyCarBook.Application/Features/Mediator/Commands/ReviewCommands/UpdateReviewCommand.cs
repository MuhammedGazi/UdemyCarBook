using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands
{
    public class UpdateReviewCommand:IRequest
    {
        public int ReviewId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RatıngValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarID { get; set; }
    }
}
