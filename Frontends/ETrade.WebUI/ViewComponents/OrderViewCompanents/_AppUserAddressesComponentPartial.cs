using ETrade.WebUI.Services.OrderServices.OrderAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents.OrderViewCompanents
{
    public class _AppUserAddressesComponentPartial : ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;

        public _AppUserAddressesComponentPartial(IOrderAddressService orderAddressService)
        {
            _orderAddressService = orderAddressService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appUserId = ViewData["uId"].ToString();
            var addresses = await _orderAddressService.GetAddressesByUserIdAsync(appUserId);
            return View(addresses);
        }
    }
}
