using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandByIdQueryHandler(IRepositor<Brand> _repository)
{
    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetBrandByIdQueryResult
        {
            BrandID = value.BrandID,
            Name=value.Name,
        };
    }
}
