using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
