using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetCarBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
{
    public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetCarBrandAndModelByRentPriceDailyMax();
        return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult
        {
            CarBrandAndModelByRentPriceDailyMax = value
        };
    }
}
