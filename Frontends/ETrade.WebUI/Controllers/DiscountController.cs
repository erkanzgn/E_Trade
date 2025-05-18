using ETrade.WebUI.Services.BasketServices;
using ETrade.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult ConfrimDiscountCoupon()
        {

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfrimDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCouponRate(code);

            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;
            var totalNewPriceWithDiscount= totalPriceWithTax-(totalPriceWithTax/100*values);
            ViewBag.totalPriceWithTax= totalNewPriceWithDiscount;

            return RedirectToAction("Index","ShoppingCart", new {code=code, discountRate=values});

        }
    }
}
