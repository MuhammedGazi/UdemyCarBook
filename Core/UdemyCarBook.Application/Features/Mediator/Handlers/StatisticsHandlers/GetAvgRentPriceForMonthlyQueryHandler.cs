using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
{
    public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetAvgRentPriceForMonthly();
        return new GetAvgRentPriceForMonthlyQueryResult
        {
            AvgRentPriceForMonthly = value
        };
    }
}
