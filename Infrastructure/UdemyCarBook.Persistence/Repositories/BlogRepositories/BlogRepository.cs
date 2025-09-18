using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories;

public class BlogRepository(CarBookContext _context) : IBlogRepository
{
    public List<Blog> GetAllBlogsWithAuthors()
    {
        var values = _context.Blogs.Include(x => x.Author).ToList();
        return values;
    }

    public List<Blog> GetLast3BlogsWithAuthors()
    {
        var values=_context.Blogs.Include(x => x.Author).OrderByDescending(x=>x.BlogID).Take(3).ToList();
        return values;
    }
}
