using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialQueryHandler(IRepositor<Testimonial> _repository) : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetTestimonialQueryResult
        {
            Comment = x.Comment,
            ImageUrl = x.ImageUrl,
            Name = x.Name,
            TestimonialID = x.TestimonialID,
            Title= x.Title,       
        }).ToList();
    }
}
