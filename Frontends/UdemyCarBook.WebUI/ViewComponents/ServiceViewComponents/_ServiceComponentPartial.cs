using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial(IHttpClientFactory _httpClientFactory):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7243/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
