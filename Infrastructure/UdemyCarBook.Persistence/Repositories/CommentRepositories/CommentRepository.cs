using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T>(CarBookContext _context) : IGenericRepository<Comment>
    {
        public void Create(Comment entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            var value=_context.Comments.Select(x=>new Comment
            {
                CommentID=x.CommentID,
                BlogID=x.BlogID,
                CreatedDate=x.CreatedDate,
                Description=x.Description,
                Name=x.Name,
            }).ToList();
            return value;
        }

        public Comment GetById(int id)
        {
            var value= _context.Comments.Find(id);
            return value;
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x=>x.BlogID==id).ToList();
        }

        public void Remove(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentID);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }

        public int GetCountCommentByBlog(int id)
        {
            return _context.Comments.Where(x=>x.BlogID==id).Count();
        }
    }
}
