using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetBlogAuthorIdQuery:IRequest<List<GetBlogAuthorIdQueryResult>>
{
    public GetBlogAuthorIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
