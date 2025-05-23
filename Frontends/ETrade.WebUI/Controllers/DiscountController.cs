using ETrade.WebUI.Services.BasketServices;
using ETrade.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public async Task<IActionResult> Index(string code)
        {
            var values = await _discountService.GetByCodeDiscountCouponAsync(code);
            ViewData["codeRate"] = values.Rate;
            return RedirectToAction("Index", "ShoppingCard");
        }

    }
}
