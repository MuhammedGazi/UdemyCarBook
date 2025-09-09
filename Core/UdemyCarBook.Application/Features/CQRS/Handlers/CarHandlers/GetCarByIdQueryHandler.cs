using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler(IRepositor<Car> _repository)
{
    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var value=await _repository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            BrandId = value.BrandId,
            Model = value.Model,
            CoverImageUrl = value.CoverImageUrl,
            Km = value.Km,
            Transmission = value.Transmission,
            Seat = value.Seat,
            Luggage = value.Luggage,
            Fuel = value.Fuel,
            BıgImageUrl = value.BıgImageUrl,
        };
    }
}
