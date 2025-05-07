using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class ShoppinCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
