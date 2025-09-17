using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.PricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingWithCars();
    }
}
