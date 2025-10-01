using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIDQueryHandler(IReviewRepository _repository) : IRequestHandler<GetReviewByCarIDQuery, List<GetReviewByCarIDQueryResult>>
    {
        public async Task<List<GetReviewByCarIDQueryResult>> Handle(GetReviewByCarIDQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIDQueryResult
            {
                CustomerName = x.CustomerName,
                CarID = x.CarID,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                RatıngValue = x.RatıngValue,
                ReviewDate = x.ReviewDate,
                ReviewID = x.ReviewID   
            }).ToList();
        }
    }
}
