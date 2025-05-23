using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Profile")]
    public class ProfileController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
