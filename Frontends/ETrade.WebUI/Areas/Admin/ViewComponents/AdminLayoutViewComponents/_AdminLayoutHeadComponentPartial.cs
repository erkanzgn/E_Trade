using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewcomponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
