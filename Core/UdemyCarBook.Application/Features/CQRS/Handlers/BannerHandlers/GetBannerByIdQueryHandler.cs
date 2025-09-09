using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerByIdQueryHandler(IRepositor<Banner> _repository)
{
    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var value= await _repository.GetByIdAsync(query.Id);
        return new GetBannerByIdQueryResult
        {
            BannerID = value.BannerID,
            Description = value.Description,
            Title = value.Title,
            VideoDescription = value.VideoDescription,
            VideoUrl = value.VideoUrl
        };
    }
}
