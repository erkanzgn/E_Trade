using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
