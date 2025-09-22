using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces;

public interface ICarRepository
{
    List<Car> GetCarListWithBrands();
    List<Car> GetLast5CarListWithBrands();
    int GetCarCount();
}
