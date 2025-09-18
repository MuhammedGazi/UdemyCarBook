using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CategoryDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoryComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _apiService.GetApiAsync<List<ResultCategoryDto>>("https://localhost:7243/api/Category");
            return View(value);
        }
    }
}
