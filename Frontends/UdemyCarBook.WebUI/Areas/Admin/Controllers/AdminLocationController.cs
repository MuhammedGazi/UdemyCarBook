using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Authorize(Roles ="Admin")]
[Area("Admin")]
[Route("Admin/AdminLocation")]
public class AdminLocationController(ApiService _apiService, IHttpClientFactory _httpClientFactory) : Controller
{

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7243/api/Location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
        }
        return View();

    }

    [HttpGet]
    [Route("CreateLocation")]
    public IActionResult CreateLocation()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateLocation")]
    public async Task<IActionResult> CreateLocation(CreateLocationDto dto)
    {
        await _apiService.PostApiAsync("https://localhost:7243/api/Location", dto);
        return RedirectToAction("Index", "AdminLocation", new {area= "Admin" });
    }

    [HttpGet]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(int id)
    {
        var value = await _apiService.GetApiAsync<UpdateLocationDto>($"https://localhost:7243/api/Location/{id}");
        return View(value);
    }
    [HttpPost]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
    {
        await _apiService.PutApiAsync("https://localhost:7243/api/Location", dto);
        return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
    }

    [Route("RemoveLocation/{id}")]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        await _apiService.RemoveApiAsync("https://localhost:7243/api/Location?id="+id);
        return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
    }
}
