using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByCarIDQuery:IRequest<List<GetReviewByCarIDQueryResult>>
    {
        public GetReviewByCarIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
