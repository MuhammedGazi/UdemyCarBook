using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudByBlogIdQueryHandler(ITagCloudRepository _repository) : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
{
    public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetTagCloudsByBlogID(request.Id);
        return values.Select(x=>new GetTagCloudByBlogIdQueryResult
        {
            BlogID = x.BlogID,
            TagCloudID = x.TagCloudID,
            Title=x.Title,
        }).ToList();
    }
}
