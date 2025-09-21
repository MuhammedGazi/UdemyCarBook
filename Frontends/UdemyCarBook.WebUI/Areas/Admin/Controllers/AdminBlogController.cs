using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminBlog")]
public class AdminBlogController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultAllBlogsWithAuthors>>("https://localhost:7243/api/Blog/GetAllBlogsWithAuthorsList");
        return View(values);
    }

    [Route("RemoveBlog/{id}")]
    public async Task<IActionResult> RemoveBlog(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Blog?id=" + id);
        return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
    }
}
