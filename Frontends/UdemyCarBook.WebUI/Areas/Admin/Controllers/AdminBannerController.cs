using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BannerDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminBanner")]
public class AdminBannerController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var value = await _apiService.GetApiAsync<List<ResultBannerDto>>("https://localhost:7243/api/Banner");
        return View(value);
    }

    [HttpGet]
    [Route("CreateBanner")]
    public IActionResult CreateBanner()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateBanner")]
    public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Banner", dto);
        return RedirectToAction("Index","AdminBanner",new {area="Admin"});
    }

    [HttpGet]
    [Route("UpdateBanner/{id}")]
    public async Task<IActionResult> UpdateBanner(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateBannerDto>($"https://localhost:7243/api/Banner/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateBanner/{id}")]
    public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Banner", dto);
        return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
    }

    [Route("RemoveBanner/{id}")]
    public async Task<IActionResult> RemoveBanner(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Banner?id="+id);
        return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
    }
}
