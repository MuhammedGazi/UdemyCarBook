using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialByIdQueryHandler(IRepositor<Testimonial> _repository) : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
{
    public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
       var value=await _repository.GetByIdAsync(request.Id);
        return new GetTestimonialByIdQueryResult
        {
            Comment=value.Comment,
            ImageUrl=value.ImageUrl,
            Name=value.Name,
            TestimonialID=value.TestimonialID,
            Title=value.Title,
        };
    }
}
