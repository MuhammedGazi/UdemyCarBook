using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class CreateBlogCommandHandler(IRepositor<Blog> _repository) : IRequestHandler<CreateBlogCommand>
{
    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Blog
        {
            Title = request.Title,
            CoverImageUrl = request.CoverImageUrl,
            CreatedDate = request.CreatedDate,
            AuthorID = request.AuthorID,
            CategoryID = request.CategoryID,
        });
    }
}
