using ETrade.DtoLayer.CatalogDtos.ProductDtos;
using ETrade.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
             
          var values=await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);
        }


    }
}
