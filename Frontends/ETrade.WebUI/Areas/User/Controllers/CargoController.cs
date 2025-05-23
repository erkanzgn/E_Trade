using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.User.Controllers
{

    [Area("User")]
    [Route("User/Cargo")]
    public class CargoController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
