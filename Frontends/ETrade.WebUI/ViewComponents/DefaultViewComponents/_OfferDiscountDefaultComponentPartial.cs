using ETrade.DtoLayer.CatalogDtos.OfferDiscountDtos;
using ETrade.WebUI.Services.CatalogServices.OfferDiscountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial:ViewComponent
    {
      private readonly IOfferDiscountServices _offerDiscountServices;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountServices offerDiscountServices)
        {
            _offerDiscountServices = offerDiscountServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountServices.GetAllOfferDiscountAsync();
            return View(values);
        }

    }
}
