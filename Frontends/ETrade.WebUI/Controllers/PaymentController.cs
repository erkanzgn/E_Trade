using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    
    public class PaymentController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.directory1 = "Trendshop";
            ViewBag.directory2 = "Ödeme Ekranı";
            ViewBag.directory3 = "Kartla Ödeme";
            return View();
        }
    }
}
