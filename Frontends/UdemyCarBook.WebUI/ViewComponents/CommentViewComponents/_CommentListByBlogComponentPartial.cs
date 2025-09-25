using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial(ApiService _apiService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _apiService.GetApiAsync<List<ResultCommentDto>>("https://localhost:7243/api/Comment/CommentListByBlog?id="+id);
            return View(values);
        }
    }
}
