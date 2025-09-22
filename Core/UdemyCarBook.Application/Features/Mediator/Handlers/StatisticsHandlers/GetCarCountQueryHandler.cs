using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetCarCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
{
    public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetCarCount();
        return new GetCarCountQueryResult
        {
            CarCount = value,
        };
    }
}
