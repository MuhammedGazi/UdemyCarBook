using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationByIdQueryHandler(IRepositor<Location> _repository) : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        return new GetLocationByIdQueryResult
        {
            LocationID = value.LocationID,
            Name=value.Name,
        };
    }
}
