using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaByIdQuery:IRequest<GetSocialMediaByIdQueryResult>
{
    public GetSocialMediaByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
