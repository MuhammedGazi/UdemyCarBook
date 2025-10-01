using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery:IRequest<GetCarDescriptionQueryResult>
    {
        public GetCarDescriptionQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
