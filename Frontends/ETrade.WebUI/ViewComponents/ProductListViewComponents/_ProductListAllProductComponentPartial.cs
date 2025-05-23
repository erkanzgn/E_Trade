using ETrade.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListAllProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public _ProductListAllProductComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
