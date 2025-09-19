using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogAuthorIdQueryHandler(IBlogRepository _repository) : IRequestHandler<GetBlogAuthorIdQuery, List<GetBlogAuthorIdQueryResult>>
{
    public async Task<List<GetBlogAuthorIdQueryResult>> Handle(GetBlogAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var value=_repository.GetBlogByAuthorId(request.Id);
        return value.Select(x => new GetBlogAuthorIdQueryResult
        {
            AuthorID = x.AuthorID,
            BlogID = x.BlogID,
            AuthorName = x.Author.Name,
            AuthorDescription = x.Author.Description,
            AuthorImageUrl = x.Author.ImageUrl
        }).ToList();
    }
}
