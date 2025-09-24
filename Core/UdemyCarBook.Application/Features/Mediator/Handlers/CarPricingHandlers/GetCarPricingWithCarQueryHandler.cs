using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class GetCarPricingWithCarQueryHandler(ICarPricingRepository _repository) : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
{
    public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetCarPricingWithCars();
        return values.Select(x => new GetCarPricingWithCarQueryResult
        {
            Amount = x.Amount,
            CarPricingıd = x.CarPricingID,
            Brand = x.Car.Brand.Name,
            CoverImageUrl = x.Car.CoverImageUrl,
            Model = x.Car.Model,
            CarId=x.CarID
        }).ToList();
    }
}
