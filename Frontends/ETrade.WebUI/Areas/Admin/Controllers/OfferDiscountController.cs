using ETrade.DtoLayer.CatalogDtos.OfferDiscountDtos;
using ETrade.WebUI.Services.CatalogServices.OfferDiscountServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ETrade.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private IOfferDiscountServices _offerDiscountServices;

        public OfferDiscountController(IOfferDiscountServices offerDiscountServices)
        {
            _offerDiscountServices = offerDiscountServices;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewBag();
            var values = await _offerDiscountServices.GetAllOfferDiscountAsync();
            return View(values);
        }

        private void OfferDiscountViewBag()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif  Listesi";
            ViewBag.v0 = "İndirim Teklifi İşlemleri";
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewBag();

            return View();
        }
        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountServices.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountServices.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewBag();
            var values = await _offerDiscountServices.GetByIdOfferDiscountAsync(id);
            return View(values);
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountServices.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
