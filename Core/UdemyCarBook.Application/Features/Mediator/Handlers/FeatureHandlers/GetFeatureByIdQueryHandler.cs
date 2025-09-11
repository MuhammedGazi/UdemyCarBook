using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler(IRepositor<Feature> _repository) : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var value=await _repository.GetByIdAsync(request.Id);
        return new GetFeatureByIdQueryResult
        {
            FeatureID = value.FeatureID,
            Name= value.Name,
        };
    }
}
