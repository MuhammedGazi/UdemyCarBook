using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers;

public class GetRentACarQueryHandler(IRentACarRepository _repository) : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
{
    public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
        return values.Select(x=>new GetRentACarQueryResult
        {
            CarId=x.CarID,
            Brand=x.Car.Brand.Name,
            Model=x.Car.Model,
            CoverImageUrl=x.Car.CoverImageUrl,
        }).ToList();
    }
}
