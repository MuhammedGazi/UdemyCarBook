using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class UpdateBlogCommandHandler(IRepositor<Blog> _repository) : IRequestHandler<UpdateBlogCommand>
{
    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.BlogID);
        value.Title = request.Title;
        value.CoverImageUrl = request.CoverImageUrl;
        value.AuthorID = request.AuthorID;
        value.CategoryID = request.CategoryID;
        value.CreatedDate = request.CreatedDate;
        await _repository.UpdateAsync(value);
    }
}
