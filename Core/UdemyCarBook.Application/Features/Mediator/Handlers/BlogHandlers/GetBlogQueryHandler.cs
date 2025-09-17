using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogQueryHandler(IRepositor<Blog> _repository) : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
{
    public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x=>new GetBlogQueryResult
        {
            AuthorID = x.AuthorID,
            BlogID = x.BlogID,
            CategoryID = x.CategoryID,
            CoverImageUrl = x.CoverImageUrl,
            CreatedDate = x.CreatedDate,
            Title= x.Title,
        }).ToList();
    }
}
