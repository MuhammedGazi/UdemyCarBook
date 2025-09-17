using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class GetAuthorByIdQueryHandler(IRepositor<Author> _repository) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetAuthorByIdQueryResult
        {
            AuthorID = value.AuthorID,
            Description = value.Description,
            ImageUrl = value.ImageUrl,
            Name= value.Name,   
        };
    }
}
