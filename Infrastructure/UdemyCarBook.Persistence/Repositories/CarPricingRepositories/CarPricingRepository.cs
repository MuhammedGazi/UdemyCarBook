using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.PricingInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories;

public class CarPricingRepository(CarBookContext _context) : ICarPricingRepository
{
    public List<CarPricing> GetCarPricingWithCars()
    {
        var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand)
          .Include(z => z.Pricing).Where(m=>m.PricingID==2).ToList();
        return values;

    }
}
