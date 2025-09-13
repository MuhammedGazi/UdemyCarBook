using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaQueryHandler(IRepositor<SocialMedia> _repository) : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x=>new GetSocialMediaQueryResult
        {
            Icon = x.Icon,
            Name = x.Name,
            SocialMediaID = x.SocialMediaID,
            Url=x.Url,
        }).ToList();
    }
}
