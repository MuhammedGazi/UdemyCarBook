using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogByIdQueryHandler(IRepositor<Blog> _repository) : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetBlogByIdQueryResult
        {
            AuthorID = value.AuthorID,
            BlogID = value.BlogID,
            CategoryID = value.CategoryID,
            CoverImageUrl = value.CoverImageUrl,
            CreatedDate = value.CreatedDate,
            Title = value.Title,
        };
    }
}
