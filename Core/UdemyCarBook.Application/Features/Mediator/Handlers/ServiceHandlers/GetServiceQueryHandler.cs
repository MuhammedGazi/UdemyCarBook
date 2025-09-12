using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers;

public class GetServiceQueryHandler(IRepositor<Service> _repository) : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
{
    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x=>new GetServiceQueryResult
        {
            Description = x.Description,
            IconUrl = x.IconUrl,
            ServiceID = x.ServiceID,
            Title=x.Title,
        }).ToList();
    }
}
