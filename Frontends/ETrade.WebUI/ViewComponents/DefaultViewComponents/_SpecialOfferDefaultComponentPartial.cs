
using ETrade.DtoLayer.CatalogDtos.SpecialOfferDtos;
using ETrade.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

    }
}
