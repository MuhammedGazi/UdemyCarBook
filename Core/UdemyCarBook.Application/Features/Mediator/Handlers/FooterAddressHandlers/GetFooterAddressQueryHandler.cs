using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressQueryHandler(IRepositor<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x=>new GetFooterAddressQueryResult
        {
            Address = x.Address,
            Description = x.Description,
            Email = x.Email,
            FooterAddressID = x.FooterAddressID,
            Phone= x.Phone,
        }).ToList();
    }
}
