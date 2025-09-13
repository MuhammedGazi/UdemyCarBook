using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class UpdateTestimonialCommandHandler(IRepositor<Testimonial> _repository) : IRequestHandler<UpdateTestimonialCommand>
{
    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.TestimonialID);
        value.Comment = request.Comment;
        value.Name = request.Name;
        value.Title = request.Title;
        value.ImageUrl = request.ImageUrl;
        await _repository.UpdateAsync(value);
    }
}
