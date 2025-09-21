using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.SocialMediaDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminSocialMedia")]
public class AdminSocialMediaController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultSocialMediaDto>>("https://localhost:7243/api/SocialMedia");
        return View(values);
    }

    [HttpGet]
    [Route("CreateSocialMedia")]
    public IActionResult CreateSocialMedia()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateSocialMedia")]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/SocialMedia", dto);
        return RedirectToAction("Index", "AdminSocialMedia", new {area= "Admin" });
    }

    [HttpGet]
    [Route("UpdateSocialMedia/{id}")]
    public async Task<IActionResult> UpdateSocialMedia(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateSocialMediaDto>($"https://localhost:7243/api/SocialMedia/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateSocialMedia/{id}")]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/SocialMedia", dto);
        return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
    }

    [Route("RemoveSocialMedia/{id}")]
    public async Task<IActionResult> RemoveSocialMedia(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/SocialMedia?id="+id);
        return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
    }
}
