using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _apiService.GetApiAsync<GetBlogById>($"https://localhost:7243/api/Blogs/" + id);
            return View();
        }
    }
}
