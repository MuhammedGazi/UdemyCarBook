using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler(ICarRepository _repository)
{
    public List<GetCarWithBrandQueryResult> Handle()
    {
        var values= _repository.GetCarListWithBrands();
        return values.Select(x=>new GetCarWithBrandQueryResult
        {
            BrandName=x.Brand.Name,
            BrandId = x.BrandId,
            Model = x.Model,
            CoverImageUrl = x.CoverImageUrl,
            Km = x.Km,
            Transmission = x.Transmission,
            Seat = x.Seat,
            Luggage = x.Luggage,
            Fuel = x.Fuel,
            BıgImageUrl = x.BıgImageUrl,
        }).ToList();
    }
}
