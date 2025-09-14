using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory _httpClientFactory):ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseData = await client.GetAsync("https://localhost:7243/api/Car/GetLast5CarWithBrandQueryHandler");
        if (responseData.IsSuccessStatusCode)
        {
            var jsonData = await responseData.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
            return View(value);
        }
        return View();
    }
}
