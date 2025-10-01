using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CarPricingDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var values = await _apiService.GetApiAsync<List<ResultCarPricingListWithModelDto>>("https://localhost:7243/api/CarPricing/GetCarPricingWithTimePeriodList");
            return View(values);
        }
    }
}
