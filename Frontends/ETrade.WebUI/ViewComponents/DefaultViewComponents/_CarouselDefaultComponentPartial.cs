using ETrade.DtoLayer.CatalogDtos.FeatureSliderDtos;
using ETrade.WebUI.Services.CatalogServices.SliderServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ETrade.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
       private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          var values=await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }

      
    }
}
