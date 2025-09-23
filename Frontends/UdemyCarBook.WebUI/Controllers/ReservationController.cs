using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class ReservationController(ApiService _apiService) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Araç Kiralama";
        ViewBag.v2 = "Araç Rezervasyon Formu";

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
}
