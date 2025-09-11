using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

public class GetFooterAddressByIdQuery:IRequest<GetFooterAddressByIdQueryResult>
{
    public GetFooterAddressByIdQuery(int ıd)
    {
        Id = ıd;
    }

    public int Id { get; set; }
}
