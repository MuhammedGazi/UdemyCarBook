using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminComment")]
public class AdminCommentController(ApiService _apiService) : Controller
{
    [Route("Index/{id}")]
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.v=id;
        var value = await _apiService.GetApiAsync<List<ResultCommentDto>>("https://localhost:7243/api/Comment/CommentListByBlog?id="+id);
        return View(value);
    }


}
