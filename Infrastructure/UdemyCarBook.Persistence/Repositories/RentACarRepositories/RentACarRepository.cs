using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.RentACarRepositories;

public class RentACarRepository(CarBookContext _context) : IRentACarRepository
{
    public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
    {
        var values = await _context.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
        return values;
    }
}
