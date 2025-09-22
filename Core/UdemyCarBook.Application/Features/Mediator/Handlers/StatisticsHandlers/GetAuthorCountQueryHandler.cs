using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetAuthorCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
{
    public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetAuthorCount();
        return new GetAuthorCountQueryResult
        {
            AuthorCount = value
        };
    }
}
