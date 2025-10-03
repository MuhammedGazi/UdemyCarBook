using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class SignalRCarController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
