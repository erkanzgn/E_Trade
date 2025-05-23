using ETrade.DtoLayer.CatalogDtos.CategoryDtos;
using ETrade.DtoLayer.CatalogDtos.ProductDtos;
using ETrade.WebUI.Services.CatalogServices.CategoryServices;
using ETrade.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ETrade.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBag();

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

    

        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBag();
            var values = await _categoryService.GetAllCategoryAsync();  
            List<SelectListItem> categoriesValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text=x.CategoryName,
                                                        Value=x.CategoryId,
                                                    }).ToList();
            ViewBag.CategoryValues=categoriesValues;
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
       
        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBag();

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoriesValues = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.CategoryId,
                                                     }).ToList();
            ViewBag.CategoryValues = categoriesValues;
            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto  updateProductDto)
        {

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("ProductListWithCategory")]
        [HttpGet]
        public async Task<IActionResult> ProductListWithCategory()
        { 
            ProductViewBag();
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        //[Route("ProductListWithCategory")]
        //public async Task<IActionResult> ProductListWithCategory()
        //{
        //    

        //    //var client = await _httpClientFactory.CreateClient();
        //    //var responseMessage = await client.GetAsync("https://localhost:7074/api/Products/ProductListWithCategory");
        //    //if (responseMessage.IsSuccessStatusCode)
        //    //{
        //    //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        //    //    return View(values);
        //    //}

        //    //return View();
        //}
        void ProductViewBag()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";
        }
    }
}
