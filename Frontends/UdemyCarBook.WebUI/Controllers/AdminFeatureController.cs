using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class AdminFeatureController(ApiService _apiService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultFeatureDto>>("https://localhost:7243/api/Features");
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateFeature()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Features", dto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        var values = await _apiService.GetApiAsync<UpdateFeatureDto>($"https://localhost:7243/api/Features/{id}");
        return View(values);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Features",dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveFeature(int id)
    {
        await _apiService.RemoveApiAsync($"https://localhost:7243/api/Features/{id}");
        return RedirectToAction("Index");
    }
}
