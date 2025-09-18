using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetAllBlogsWithAuthorsQueryHandler(IBlogRepository _repository) : IRequestHandler<GetAllBlogsWithAuthorsQuery, List<GetAllBlogsWithAuthorsQueryResult>>
{
    public async Task<List<GetAllBlogsWithAuthorsQueryResult>> Handle(GetAllBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
    {
        var values=_repository.GetAllBlogsWithAuthors();
        return values.Select(x=> new GetAllBlogsWithAuthorsQueryResult
        {
            AuthorID = x.AuthorID,
            AuthorName=x.Author.Name,
            CategoryID=x.CategoryID,
            BlogID=x.BlogID,
            CoverImageUrl=x.CoverImageUrl,
            CreatedDate=x.CreatedDate,
            Title=x.Title, 
            Description=x.Description,
        }).ToList();
    }
}
