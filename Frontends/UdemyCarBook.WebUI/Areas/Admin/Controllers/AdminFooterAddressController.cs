using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.FooterAddressDtos;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFooterAddress")]
    public class AdminFooterAddressController(ApiService _apiService) : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetApiAsync<List<ResultLocationDto>>("https://localhost:7243/api/FooterAddress");
            return View(values);
        }

        [HttpGet]
        [Route("CreateFooterAddress")]
        public IActionResult CreateFooterAddress()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateLocationDto dto)
        {
            await _apiService.PostApiAsync("https://localhost:7243/api/FooterAddress", dto);
            return RedirectToAction("Index", "AdminFooterAddress",new {area= "Admin" });
        }

        [HttpGet]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var value = await _apiService.GetApiAsync<UpdateLocationDto>($"https://localhost:7243/api/FooterAddress/{id}");
            return View(value);
        }
        [HttpPost]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateLocationDto dto)
        {
            await _apiService.PutApiAsync("https://localhost:7243/api/FooterAddress", dto);
            return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
        }

        [Route("RemoveFooterAddress/{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _apiService.RemoveApiAsync("https://localhost:7243/api/FooterAddress?id="+id);
            return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
        }
    }
}
