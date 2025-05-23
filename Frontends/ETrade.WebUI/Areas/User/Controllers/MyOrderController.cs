using ETrade.WebUI.Services.Abstracts;
using ETrade.WebUI.Services.OrderServices.OrderOrderingServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/MyOrder")]
    public class MyOrderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderOrderingService _orderOrderingService;

        public MyOrderController(IUserService userService, IOrderOrderingService orderOrderingService)
        {
            _userService = userService;
            _orderOrderingService = orderOrderingService;
        }
        [Route("MyOrderList")]
        public async Task<IActionResult> MyOrderList()
        {
            var appUser = await _userService.GetUserInfo();
            var orders = await _orderOrderingService.GetOrderingByUserIdAsync(appUser.Id);
            return View(orders);
        }
    }
}
