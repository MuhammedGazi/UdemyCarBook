using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class AdminCarController(ApiService _apiService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _apiService.GetApiAsync<List<ResultCarWithBrandsDto>>("https://localhost:7243/api/Car/GetCarWithBrand");
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> CreateCar()
    {
        var values=await _apiService.GetApiAsync<List<ResultBrandDto>>("https://localhost:7243/api/Brand");
        List<SelectListItem> brandValues=(from x in values
                                          select new SelectListItem
                                          {
                                              Text=x.name,
                                              Value=x.brandID.ToString(),
                                          }).ToList();
        ViewBag.BrandValues=brandValues;
        return View();
    }
}
