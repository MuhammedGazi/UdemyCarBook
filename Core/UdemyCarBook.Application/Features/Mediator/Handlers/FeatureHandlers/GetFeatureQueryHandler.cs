using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler(IRepositor<Feature> _repository) : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{//IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>> ilki isteği kimin yapacağı ikincisi dönüş şekli nasıl olacağı
    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var values= await _repository.GetAllAsync();
        return values.Select(x=>new GetFeatureQueryResult
        {
            FeatureID = x.FeatureID,
            Name=x.Name,
        }).ToList();
    }
}
