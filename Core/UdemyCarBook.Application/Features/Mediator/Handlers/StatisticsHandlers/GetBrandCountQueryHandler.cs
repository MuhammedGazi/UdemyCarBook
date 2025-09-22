using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetBrandCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
{
    public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetBrandCount();
        return new GetBrandCountQueryResult
        {
            BrandCount = value
        };
    }
}

