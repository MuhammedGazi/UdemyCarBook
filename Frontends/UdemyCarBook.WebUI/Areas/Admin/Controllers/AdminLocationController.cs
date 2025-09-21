using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminLocation")]
public class AdminLocationController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultLocationDto>>("https://localhost:7243/api/Location");
        return View(values);
    }

    [HttpGet]
    [Route("CreateLocation")]
    public IActionResult CreateLocation()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateLocation")]
    public async Task<IActionResult> CreateLocation(CreateLocationDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Location", dto);
        return RedirectToAction("Index", "AdminLocation", new {area= "Admin" });
    }

    [HttpGet]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateLocationDto>($"https://localhost:7243/api/Location/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Location", dto);
        return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
    }

    [Route("RemoveLocation/{id}")]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Location?id="+id);
        return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
    }
}
