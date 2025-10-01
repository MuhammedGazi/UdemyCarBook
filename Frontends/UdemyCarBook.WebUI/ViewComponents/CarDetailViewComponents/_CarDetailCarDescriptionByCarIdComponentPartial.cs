using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CarDescriptionDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarDescriptionByCarIdComponentPartial(ApiService _apiService) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var value = await _apiService.GetApiAsync<ResultCarDescriptionByCarIdDto>("https://localhost:7243/api/CarDescription?id="+ id);
            return View(value);
        }
    }
}


