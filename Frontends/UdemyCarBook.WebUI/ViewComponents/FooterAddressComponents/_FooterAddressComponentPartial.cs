using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.FooterAddressDtos;

namespace UdemyCarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial(IHttpClientFactory _httpClientFactory):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseData = await client.GetAsync("https://localhost:7243/api/FooterAddress");
            if(responseData.IsSuccessStatusCode)
            {
                var jsonData=await responseData.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
