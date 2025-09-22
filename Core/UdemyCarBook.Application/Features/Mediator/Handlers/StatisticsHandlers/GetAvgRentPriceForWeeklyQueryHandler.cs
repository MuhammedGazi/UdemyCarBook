using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetAvgRentPriceForWeeklyQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetAvgRentPriceForWeeklyQuery, GetAvgRentPriceForWeeklyQueryResult>
{
    public async Task<GetAvgRentPriceForWeeklyQueryResult> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetAvgRentPriceForWeekly();
        return new GetAvgRentPriceForWeeklyQueryResult
        {
            AvgRentPriceForWeekl = value
        };
    }
}
