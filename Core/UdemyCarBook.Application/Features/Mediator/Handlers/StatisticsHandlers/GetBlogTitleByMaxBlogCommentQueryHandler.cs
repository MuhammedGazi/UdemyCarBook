using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
{
    public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetBlogTitleByMaxBlogComment();
        return new GetBlogTitleByMaxBlogCommentQueryResult
        {
            BlogTitleByMaxBlogComment = value
        };
    }   
}
