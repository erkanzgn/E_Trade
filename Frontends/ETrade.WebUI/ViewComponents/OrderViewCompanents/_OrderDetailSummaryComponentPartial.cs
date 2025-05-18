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
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }

    }
}
