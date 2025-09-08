using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutQueryHandler(IRepositor<About> _repository)
{
    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAboutQueryResult
        {
            AboutID = x.AboutID,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Title = x.Title,
        }).ToList();
    }
}
