using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler(IRepositor<Category> _repository)
{
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values=await _repository.GetAllAsync();
        return values.Select(x=> new GetCategoryQueryResult
        {
            CategoryID=x.CategoryID,
            Name = x.Name,
        }).ToList();
    }
}
