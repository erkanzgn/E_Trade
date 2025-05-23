using ETrade.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket(null);
            return View(values);
        }
    }
}
