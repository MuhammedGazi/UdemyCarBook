using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarFeatureRepositories;

public class CarFeatureRepository(CarBookContext _context) : ICarFeatureRepository
{
    public void ChangeCarFeatureAvailableToFalse(int id)
    {
        var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
        values.Available = false;
        _context.SaveChanges();
    }

    public async void ChangeCarFeatureAvailableToTrue(int id)
    {
        var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
        values.Available = true;
        _context.SaveChanges();
    }

    public void CreateCarFeatureByCar(CarFeature carFeature)
    {
        _context.CarFeatures.Add(carFeature);
        _context.SaveChanges();
    }

    public List<CarFeature> GetCarFeaturesByCarId(int carID)
    {
        var values=_context.CarFeatures.Include(y=>y.Feature).Where(x=>x.CarID==carID).ToList();
        return values;
    }
}
