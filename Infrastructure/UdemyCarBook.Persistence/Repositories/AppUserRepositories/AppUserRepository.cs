using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.AppUserRepositories;

public class AppUserRepository(CarBookContext _context) : IAppUserRepository
{
    public async Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
    {
        var values=await _context.AppUsers.Where(filter).ToListAsync();
        return values;
    }
}
