using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetCarCountByFuelElectricQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
{
    public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetCarCountByFuelElectric();
        return new GetCarCountByFuelElectricQueryResult
        {
            CarCountByFuelElectric = value
        };
    }
}
