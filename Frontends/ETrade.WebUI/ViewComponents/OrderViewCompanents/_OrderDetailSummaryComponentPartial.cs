using ETrade.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.OrderViewCompanents
{
    public class _OrderDetailSummaryComponentPartial:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderDetailSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int rate = 0;
            string codeName = null;
            if (ViewData["codeRateP"] != null)
            {
                rate = int.Parse(ViewData["codeRateP"].ToString());
                codeName = ViewData["codeNameP"].ToString();
            }
            var totalValue = await _basketService.GetBasket(null);
            totalValue.DiscountRate = rate;
            totalValue.DiscountCode = codeName;
            return View(totalValue);
        }
    }
}
