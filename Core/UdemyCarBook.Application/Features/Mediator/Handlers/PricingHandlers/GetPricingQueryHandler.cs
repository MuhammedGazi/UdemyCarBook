using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers;

public class GetPricingQueryHandler(IRepositor<Pricing> _repository) : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x=>new GetPricingQueryResult
        {
            Name = x.Name,
            PricingID=x.PricingID,
        }).ToList();
    }
}
