using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.ContactDtos;

namespace UdemyCarBook.WebUI.Controllers;

public class ContactController(IHttpClientFactory _httpClientFactory) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto createContactDto)
    {
        var client = _httpClientFactory.CreateClient();
        createContactDto.SendDate = DateTime.Now;
        var jsonData = JsonConvert.SerializeObject(createContactDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7243/api/Contact", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index","Default");
        }
        return View();
    }
}