using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.ReservationDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class ReservationController(ApiService _apiService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.v1 = "Araç Kiralama";
        ViewBag.v2 = "Araç Rezervasyon Formu";
        ViewBag.v3 = id;

        var values = await _apiService.GetApiAsync<List<ResultLocationDto>>("https://localhost:7243/api/Location");
        List<SelectListItem> values2 = (from x in values
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.LocationID.ToString(),
                                        }).ToList();
        ViewBag.v = values2;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateReservationDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Reservation", dto);
        return RedirectToAction("Index","Default");
    }
}
