using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.OrderViewCompanents
{
    public class _OrderPaymentMethodComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
