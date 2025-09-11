using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationQueryHandler(IRepositor<Location> _repository) : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x=>new GetLocationQueryResult
        {
            LocationID = x.LocationID,
            Name=x.Name,
        }).ToList();
    }
}
