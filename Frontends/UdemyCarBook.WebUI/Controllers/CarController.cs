using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseData = await client.GetAsync("https://localhost:7243/api/Car/GetCarWithBrand");
            if(responseData.IsSuccessStatusCode)
            {
                var jsonData=await responseData.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
