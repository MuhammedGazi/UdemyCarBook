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
}
