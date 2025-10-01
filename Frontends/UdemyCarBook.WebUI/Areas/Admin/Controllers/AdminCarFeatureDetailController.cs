using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.CarFeatureDtos;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminCarFeatureDetail")]
public class AdminCarFeatureDetailController(ApiService _apiService) : Controller
{
    [Route("Index/{id}")]
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        var values = await _apiService.GetApiAsync<List<ResultCarFeatureByCarIdDto>>("https://localhost:7243/api/CarFeature?id="+id);
        return View(values);
    }
    [Route("Index/{id}")]
    [HttpPost]
    public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
    {
        foreach(var item in resultCarFeatureByCarIdDto)
        {
            if (item.Available)
            {
                int id = item.CarFeatureID;
                await _apiService.ExecuteApiAsync("https://localhost:7243/api/CarFeature/CarFeatureAvailableChangeToTrue?id="+ id);
            }
            else
            {
                int id = item.CarFeatureID;
                await _apiService.ExecuteApiAsync("https://localhost:7243/api/CarFeature/CarFeatureAvailableChangeToFalse?id=" + id);
            }
        }
        return RedirectToAction("Index","AdminCar");

    }

    [Route("CreateFeatureByCarId")]
    [HttpGet]
    public async Task<IActionResult> CreateFeatureByCarId()
    {
        var values = await _apiService.GetApiAsync<List<ResultFeatureDto>>("https://localhost:7243/api/Feature");
        return View(values);
    }
}
