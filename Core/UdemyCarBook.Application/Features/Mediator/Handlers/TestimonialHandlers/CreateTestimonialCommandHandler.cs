using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

internal class CreateTestimonialCommandHandler(IRepositor<Testimonial> _repository) : IRequestHandler<CreateTestimonialCommand>
{
    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Testimonial
        {
            Comment = request.Comment,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
            Title = request.Title,
        });
    }
}
