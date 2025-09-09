using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandQueryHandler(IRepositor<Brand> _repository)
{
    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var values=await _repository.GetAllAsync();
        return values.Select(x=> new GetBrandQueryResult
        {
            BrandID = x.BrandID,
            Name=x.Name,
        }).ToList();
    }
}
