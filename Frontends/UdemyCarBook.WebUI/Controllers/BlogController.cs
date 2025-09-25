using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class BlogController(IHttpClientFactory _httpClientFactory,ApiService _apiService) : Controller
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

    [HttpGet]
    public  PartialViewResult AddComment(int id)
    {
        ViewBag.blogid = id;
        return PartialView();
    }
    [HttpPost]
    public async Task<IActionResult> AddComment(CreateCommentDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Comment/CreateCommentWithMediator", dto);
        return RedirectToAction("Index","Default");
    }
}
