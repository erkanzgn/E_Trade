using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
