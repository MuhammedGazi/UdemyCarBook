using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.BrandDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class AdminBrandController(ApiService _apiService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var value = await _apiService.GetApiAsync<List<ResultBrandDto>>("https://localhost:7243/api/Brand");
        return View(value);
    }

    [HttpGet]
    public async Task<IActionResult> CreateBrand()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Brand", dto);
        return RedirectToAction("Index"); 
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBrand(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateBrandDto>($"https://localhost:7243/api/Brand/{id}");
        return View(value);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Brand", dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveBrand(int id)
    {
        await _apiService.RemoveApiAsync($"https://localhost:7243/api/Brand/{id}");
        return RedirectToAction("Index");
    }

}
