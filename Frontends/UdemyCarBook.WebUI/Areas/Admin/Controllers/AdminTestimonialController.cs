using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.TestimonialDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminTestimonial")]
public class AdminTestimonialController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultTestimonialDto>>("https://localhost:7243/api/Testimonial");
        return View(values);
    }

    [HttpGet]
    [Route("CreateTestimonial")]
    public IActionResult CreateTestimonial()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateTestimonial")]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Testimonial", dto);
        return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
    }

    [HttpGet]
    [Route("UpdateTestimonial/{id}")]
    public async Task<IActionResult> UpdateTestimonial(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateTestimonialDto>($"https://localhost:7243/api/Testimonial/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateTestimonial/{id}")]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Testimonial", dto);
        return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
    }

    [Route("RemoveTestimonial/{id}")]
    public async Task<IActionResult> RemoveTestimonial(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Testimonial?id="+id);
        return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
    }
}
