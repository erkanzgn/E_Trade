using ETrade.DtoLayer.BasketDtos;
using ETrade.WebUI.Services.BasketServices;
using ETrade.WebUI.Services.CatalogServices.ProductServices;
using ETrade.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
 

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async  Task<IActionResult> Index(string code,int discountRate)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var taxPrice=values.TotalPrice*10/100;
            var totalPriceWithTax = values.TotalPrice + taxPrice;
            var discountPrice=totalPriceWithTax*discountRate/100;
            ViewBag.discountPrice = discountPrice;
            ViewBag.taxPrice = taxPrice;
            ViewBag.totalPrice=totalPriceWithTax-discountPrice;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl,
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }


    }
}
