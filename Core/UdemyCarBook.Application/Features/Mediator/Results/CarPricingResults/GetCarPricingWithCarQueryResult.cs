namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;

public class GetCarPricingWithCarQueryResult
{
    public int CarPricingıd { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Amount { get; set; }
    public string CoverImageUrl { get; set; }
}
