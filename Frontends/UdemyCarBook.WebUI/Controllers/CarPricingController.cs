using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CarPricingDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarPricingController(ApiService _apiService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var values = await _apiService.GetApiAsync<List<ResultCarPricingListWithModelDto>>("https://localhost:7243/api/CarPricing/GetCarPricingWithTimePeriodList");
            return View(values);
        }
    }
}
