using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var values = await _apiService.GetApiAsync<ResultCarWithBrandsDto>($"https://localhost:7243/api/Car/{id}");
            return View(values);
        }
    }
}
