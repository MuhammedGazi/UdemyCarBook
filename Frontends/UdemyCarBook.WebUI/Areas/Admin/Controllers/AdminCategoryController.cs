using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CategoryDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminCategory")]
public class AdminCategoryController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultCategoryDto>>("https://localhost:7243/api/Category");
        return View(values);
    }

    [HttpGet]
    [Route("CreateCategory")]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Category", dto);
        return RedirectToAction("Index", "AdminCategory", new {area= "Admin" });
    }

    [HttpGet]
    [Route("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateCategoryDto>($"https://localhost:7243/api/Category/{id}");
        return View(value);
    }

    [HttpPost]
    [Route("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Category", dto);
        return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
    }

    [Route("RemoveCategory/{id}")]
    public async Task<IActionResult> RemoveCategory(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Category?id="+id);
        return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
    }
}
