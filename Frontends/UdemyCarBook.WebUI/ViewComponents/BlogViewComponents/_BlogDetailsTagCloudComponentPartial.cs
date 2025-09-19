using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.TagCloudDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _apiService.GetApiAsync<List<GetByBlogIdTagCloudDto>>($"https://localhost:7243/api/TagCloud/GetTagCloudByBlogId?id=" + id);
            return View(value);
        }
    }
}
