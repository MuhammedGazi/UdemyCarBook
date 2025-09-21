using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.PricingDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminPricing")]
public class AdminPricingController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var value = await _apiService.GetApiAsync<List<ResultPricingDto>>("https://localhost:7243/api/Pricing");
        return View(value);
    }

    [HttpGet]
    [Route("CreatePricing")]
    public IActionResult CreatePricing()
    {
        return View();
    }
    [HttpPost]
    [Route("CreatePricing")]
    public async Task<IActionResult> CreatePricing(CreatePricingDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Pricing", dto);
        return RedirectToAction("Index", "AdminPricing",new {area= "Admin" });
    }

    [HttpGet]
    [Route("UpdatePricing/{id}")]
    public async Task<IActionResult> UpdatePricing(int id)
    {
        var value = await _apiService.GetApiAsync<UpdatePricingDto>($"https://localhost:7243/api/Pricing/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdatePricing/{id}")]
    public async Task<IActionResult> UpdatePricing(UpdatePricingDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Pricing", dto);
        return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
    }

    [Route("RemovePricing/{id}")]
    public async Task<IActionResult> RemovePricing(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Pricing?id="+id);
        return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
    }
}
