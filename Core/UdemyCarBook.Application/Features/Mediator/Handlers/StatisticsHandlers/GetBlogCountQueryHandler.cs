using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetBlogCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
{
    public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetBlogCount();
        return new GetBlogCountQueryResult
        {
            BlogCount = value
        };
    }
}
