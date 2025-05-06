using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.UILayoutViewComponent
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
