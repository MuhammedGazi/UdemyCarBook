using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutByIdQueryHandler(IRepositor<About> _repository)
{
    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var values= await _repository.GetByIdAsync(query.Id);
        return new GetAboutByIdQueryResult
        {
            AboutID = values.AboutID,
            Description = values.Description,
            ImageUrl = values.ImageUrl,
            Title=values.Title,
        };
    }
}
