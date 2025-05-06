using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.UILayoutViewComponent
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
