using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace UdemyCarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
