using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CarFeatureDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarFeatureByCarIdComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid=id;
            var values = await _apiService.GetApiAsync<List<ResultCarFeatureByCarIdDto>>("https://localhost:7243/api/CarFeature?id=" + id);
            return View(values);
        }
    }
}