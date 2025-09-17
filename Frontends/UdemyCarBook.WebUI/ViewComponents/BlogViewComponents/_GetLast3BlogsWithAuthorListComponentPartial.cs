using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorListComponentPartial(IHttpClientFactory _httpClientFactory):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseData = await client.GetAsync("https://localhost:7243/api/Blog/GetLast3BlogsWithAuthorsList");
            if (responseData.IsSuccessStatusCode)
            {
                var jsonData=await responseData.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
