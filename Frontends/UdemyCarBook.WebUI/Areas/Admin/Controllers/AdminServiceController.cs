using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminService")]
public class AdminServiceController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultServiceDto>>("https://localhost:7243/api/Service");
        return View(values);
    }

    [HttpGet]
    [Route("CreateService")]
    public IActionResult CreateService()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateService")]
    public async Task<IActionResult> CreateService(CreateServiceDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Service", dto);
        return RedirectToAction("Index", "AdminService",new {area= "Admin" });
    }

    [HttpGet]
    [Route("UpdateService/{id}")]
    public async Task<IActionResult> UpdateService(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateServiceDto>($"https://localhost:7243/api/Service/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateService/{id}")]
    public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Service", dto);
        return RedirectToAction("Index", "AdminService", new { area = "Admin" });
    }

    [Route("RemoveService/{id}")]
    public async Task<IActionResult> RemoveService(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Service?id=" + id);
        return RedirectToAction("Index", "AdminService", new { area = "Admin" });
    }
}
