using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
{
    public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetCarCountByFuelGasolineOrDiesel();
        return new GetCarCountByFuelGasolineOrDieselQueryResult
        {
            CarCountByFuelGasolineOrDiesel = value
        };
    }
}
