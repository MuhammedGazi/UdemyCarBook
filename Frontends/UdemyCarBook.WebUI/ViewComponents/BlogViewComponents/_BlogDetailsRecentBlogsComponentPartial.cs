using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetApiAsync<List<ResultLast3BlogsWithAuthors>>("https://localhost:7243/api/Blog/GetLast3BlogsWithAuthorsList");
            return View(values);
        }
    }
}
