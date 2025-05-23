using ETrade.DtoLayer.OrderDtos.OrderAddressDtos;
using ETrade.WebUI.Services.OrderServices.OrderAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.OrderViewCompanents
{
    public class _OrderCreateNewAddressComponentPartial : ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;

        public _OrderCreateNewAddressComponentPartial(IOrderAddressService orderAddressService)
        {
            _orderAddressService = orderAddressService;
        }
        public IViewComponentResult Invoke()
        {
            CreateOrderAddressDto? addressCreateModel = new CreateOrderAddressDto();
            var appUserId = ViewData["uId"].ToString();
            ViewBag.AppUserId = appUserId;
            return View(addressCreateModel);

        }
    }
}
