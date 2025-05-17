using ETrade.DtoLayer.CatalogDtos.FeatureSliderDtos;
using ETrade.WebUI.Services.CatalogServices.SliderServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ETrade.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewBag();
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }

        private void FeatureSliderViewBag()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewBag();
            return View();
        }
        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status =false;
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewBag();
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(string id, UpdateFeatureSliderDto updateFeatureSliderDto)
        {

            updateFeatureSliderDto.FeatureSliderId = id;
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
