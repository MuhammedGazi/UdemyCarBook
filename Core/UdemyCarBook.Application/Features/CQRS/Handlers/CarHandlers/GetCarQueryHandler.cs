using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarQueryHandler(IRepositor<Car> _repository)
{
    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values=await _repository.GetAllAsync();
        return values.Select(x=> new GetCarQueryResult
        {
            BrandId = x.BrandId,
            Model = x.Model,
            CoverImageUrl = x.CoverImageUrl,
            Km=x.Km,
            Transmission=x.Transmission,
            Seat=x.Seat,
            Luggage=x.Luggage,
            Fuel=x.Fuel,
            BıgImageUrl=x.BıgImageUrl,
        }).ToList();
    }
}
