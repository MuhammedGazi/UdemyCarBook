using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _apiService.GetApiAsync<GetBlogById>($"https://localhost:7243/api/Blog/" + id);
            var value2 = await _apiService.GetApiAsync<int>($"https://localhost:7243/api/Comment/CommentCountByBlog?id=" + id);
            ViewBag.commentCount =value2;
            return View(value);
        }
    }
}
