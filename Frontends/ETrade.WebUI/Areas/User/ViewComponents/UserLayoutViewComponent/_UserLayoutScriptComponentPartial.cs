using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
