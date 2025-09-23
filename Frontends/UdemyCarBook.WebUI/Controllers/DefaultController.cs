using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class DefaultController(ApiService _apiService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetApiAsync<List<ResultLocationDto>>("https://localhost:7243/api/Location");
            List<SelectListItem> values2=(from x in values
                                          select new SelectListItem
                                          {
                                              Text=x.Name,
                                              Value=x.LocationID.ToString(),
                                          }).ToList();
            ViewBag.v=values2;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string book_pick_date,string book_off_date,string time_pick, string time_off,string locationID)
        {
            TempData["bookpickdate"] = book_pick_date; 
            TempData["bookoffdate"] = book_off_date; 
            TempData["timepick"] = time_pick; 
            TempData["timeoff"] = time_off; 
            TempData["locationID"] = locationID; 
            return RedirectToAction("Index","RentACarList");
        }
    }
}
