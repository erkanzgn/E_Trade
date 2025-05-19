using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.User.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
