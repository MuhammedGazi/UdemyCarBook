using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetCarCountByKmSmallerThen1000QueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountByKmSmallerThen1000Query, GetCarCountByKmSmallerThen1000QueryResult>
{
    public async Task<GetCarCountByKmSmallerThen1000QueryResult> Handle(GetCarCountByKmSmallerThen1000Query request, CancellationToken cancellationToken)
    {
        var value = _repository.GetCarCountByKmSmallerThen1000();
        return new GetCarCountByKmSmallerThen1000QueryResult
        {
            CarCountByKmSmallerThen1000 = value
        };
    }
}
