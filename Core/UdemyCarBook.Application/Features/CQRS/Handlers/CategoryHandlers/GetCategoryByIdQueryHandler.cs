using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler(IRepositor<Category> _repository)
{
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var value=await _repository.GetByIdAsync(query.Id);
        return new GetCategoryByIdQueryResult
        {
            CategoryID = value.CategoryID,
            Name = value.Name,
        };
    }
}
