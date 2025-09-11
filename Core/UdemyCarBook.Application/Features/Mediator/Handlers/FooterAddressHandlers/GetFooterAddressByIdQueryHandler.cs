using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressByIdQueryHandler(IRepositor<FooterAddress> _repository) : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        return new GetFooterAddressByIdQueryResult
        {
            Address=value.Address,
            Description=value.Description,  
            Email=value.Email,
            FooterAddressID=value.FooterAddressID,
            Phone=value.Phone,
        };
    }
}
