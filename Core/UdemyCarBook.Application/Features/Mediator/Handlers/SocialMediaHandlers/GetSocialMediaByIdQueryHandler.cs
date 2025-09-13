using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaByIdQueryHandler(IRepositor<SocialMedia> _repository) : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            Icon = value.Icon,
            Name = value.Name,
            SocialMediaID = value.SocialMediaID,
            Url = value.Url
        };
    }
}
