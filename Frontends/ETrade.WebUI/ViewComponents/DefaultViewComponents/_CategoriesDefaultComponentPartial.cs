using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
