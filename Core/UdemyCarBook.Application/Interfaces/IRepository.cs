namespace UdemyCarBook.Application.Interfaces;

public interface IRepositor<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    //delete ve update işlemlerinin async değillerdir ama biz burda isimler standart olsun diye öyle yazdık 
}
