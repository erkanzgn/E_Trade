using ETrade.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ETrade.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.i=id;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Ürün Listesi";
            return View();
        }
        public IActionResult AllProducts()
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Ürün Listesi";
            return View();
        }
     
        public IActionResult ProductDetail(string id)
        {
            ViewBag.x=id;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Ürün Detayları";
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> AddComment(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status =false;
            createCommentDto.ProductId = "680b91778c1feb9794bf6e53";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7076/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
