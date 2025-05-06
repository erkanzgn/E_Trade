using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
