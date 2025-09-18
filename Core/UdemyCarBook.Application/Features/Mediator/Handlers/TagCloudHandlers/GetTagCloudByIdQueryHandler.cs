using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudByIdQueryHandler(IRepositor<TagCloud> _repository) : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
{
    public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        return new GetTagCloudByIdQueryResult
        {
            BlogID = value.BlogID,
            TagCloudID = value.TagCloudID,
            Title=value.Title,
        };
    }
}
