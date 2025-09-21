using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.ContactDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminContact")]
public class AdminContactController(ApiService _apiService) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultContactDto>>("https://localhost:7243/api/Contact");
        return View(values);
    }
}
