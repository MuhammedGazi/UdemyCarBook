using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories;

public class CarRepository(CarBookContext _context) : ICarRepository
{
    public List<Car> GetCarListWithBrands()
    {
       var values=_context.Cars.Include(x=>x.Brand).ToList();
        return values;
    }

    public List<Car> GetLast5CarListWithBrands()
    {
        var values=_context.Cars.Include(_x => _x.Brand).OrderByDescending(x=>x.CarId).Take(5).ToList();
        return values;
    }
}
