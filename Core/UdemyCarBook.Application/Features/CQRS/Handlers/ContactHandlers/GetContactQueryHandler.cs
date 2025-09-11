using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler(IRepositor<Contact> _repository)
{
    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values=await _repository.GetAllAsync();
        return values.Select(x=>new GetContactQueryResult
        {
             ContactID = x.ContactID,
             Email = x.Email,
             Message = x.Message,
             Name = x.Name,
             SendDate = x.SendDate,
             Subject=x.Subject,
        }).ToList();
    }
}
