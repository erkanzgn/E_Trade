using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/LogOut")]
    public class LogOutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
