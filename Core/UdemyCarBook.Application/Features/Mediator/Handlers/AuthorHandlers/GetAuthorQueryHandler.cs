using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class GetAuthorQueryHandler(IRepositor<Author> _repository) : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
{
    public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var values =await _repository.GetAllAsync();
        return values.Select(x=>new GetAuthorQueryResult
        {
            AuthorID = x.AuthorID,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Name=x.Name,
        }).ToList();
    }
}
