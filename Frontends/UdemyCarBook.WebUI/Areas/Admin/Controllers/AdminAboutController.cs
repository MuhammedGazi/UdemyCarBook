using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.AboutDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminAbout")]
public class AdminAboutController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultAboutDto>>("https://localhost:7243/api/Abouts");
        return View(values);
    }

    [HttpGet]
    [Route("CreateAbout")]
    public async Task<IActionResult> CreateAbout()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateAbout")]
    public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Abouts", dto);
        return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
    }

    [HttpGet]
    [Route("UpdateAbout/{id}")]
    public async Task<IActionResult> UpdateAbout(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateAboutDto>($"https://localhost:7243/api/Abouts/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateAbout/{id}")]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Abouts", dto);
        return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
    }

    [Route("RemoveAbout/{id}")]
    public async Task<IActionResult> RemoveAbout(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Abouts?id=" + id);
        return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
    }
}
