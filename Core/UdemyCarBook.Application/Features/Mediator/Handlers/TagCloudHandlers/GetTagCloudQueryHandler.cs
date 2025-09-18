using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudQueryHandler(IRepositor<TagCloud> _repository) : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
{
    public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetAllAsync();
        return value.Select(x=>new GetTagCloudQueryResult
        {
            BlogID = x.BlogID,
            TagCloudID = x.TagCloudID,
            Title = x.Title,
        }).ToList();
    }
}
