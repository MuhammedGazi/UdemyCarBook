using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.AuthorDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminAuthor")]
public class AdminAuthorController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultAuthorDto>>("https://localhost:7243/api/Author");
        return View(values);
    }

    [HttpGet]
    [Route("CreateAuthor")]
    public IActionResult CreateAuthor()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateAuthor")]
    public async Task<IActionResult> CreateAuthor(CreateAuthorDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Author", dto);
        return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
    }

    [HttpGet]
    [Route("UpdateAuthor/{id}")]
    public async Task<IActionResult> UpdateAuthor(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateAuthorDto>($"https://localhost:7243/api/Author/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateAuthor/{id}")]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Author", dto);
        return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
    }

    [Route("RemoveAuthor/{id}")]
    public async Task<IActionResult> RemoveAuthor(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Author?id="+id);
        return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
    }
}
