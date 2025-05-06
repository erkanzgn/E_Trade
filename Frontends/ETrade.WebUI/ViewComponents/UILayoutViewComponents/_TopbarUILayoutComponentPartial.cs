using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.UILayoutViewComponent
{
    public class _TopbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
