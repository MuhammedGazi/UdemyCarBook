using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetLast5CarWithBrandQueryHandler(ICarRepository _repository)
{
    public List<GetCarWithBrandQueryResult> Handle()
    {
        var values = _repository.GetLast5CarListWithBrands();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            CarId=x.CarId,
            BrandName = x.Brand.Name,
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
