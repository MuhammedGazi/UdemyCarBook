using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.TagCloudDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;    
            var value=await _apiService.GetApiAsync<List<GetAuthorByBlogAuthorIdDto>>($"https://localhost:7243/api/Blog/GetBlogByAuthorId?id=" + id);
            return View(value);
        }
    }
}
