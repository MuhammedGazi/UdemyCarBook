using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class BlogController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Yazarlarımızın Blogları";
        var client=_httpClientFactory.CreateClient();
        var responseData = await client.GetAsync("https://localhost:7243/api/Blog/GetAllBlogsWithAuthorsList");
        if (responseData.IsSuccessStatusCode)
        {
            var jsonData=await responseData.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthors>>(jsonData);
            return View(values);
        }
        return View();
    }
     
    public async Task<IActionResult> BlogDetail(int id)
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Blog Detayı ve Yorumlar";
        ViewBag.blogid = id;
        return View();
    }
}
