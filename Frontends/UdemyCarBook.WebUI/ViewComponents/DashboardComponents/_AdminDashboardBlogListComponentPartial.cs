using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetApiAsync<List<ResultAllBlogsWithAuthors>>("https://localhost:7243/api/Blog/GetAllBlogsWithAuthorsList");
            return View(values);
        }
    }
}
