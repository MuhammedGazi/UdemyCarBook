using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;

public class GetCarCountByTranmissionIsAutoQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, GetCarCountByTranmissionIsAutoQueryResult>
{
    public async Task<GetCarCountByTranmissionIsAutoQueryResult> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
    {
        var value = _repository.GetCarCountByTransmissionIsAuto(); 
        return new GetCarCountByTranmissionIsAutoQueryResult
        {
            CarCountByTranmissionIsAuto = value
        };
    }
}
