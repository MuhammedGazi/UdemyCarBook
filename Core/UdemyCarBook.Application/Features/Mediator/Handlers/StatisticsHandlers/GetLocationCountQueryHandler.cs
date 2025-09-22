using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetLocationCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
{
    public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetLocationCount();
        return new GetLocationCountQueryResult
        {
            LocationCount = value
        };
    }
}
