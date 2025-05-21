using ETrade.WebUI.Services.CommentServices;
using ETrade.WebUI.Services.DiscountServices;
using ETrade.WebUI.Services.StatisticServices.CatalogStatisticServices;
using ETrade.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountService _discountService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountService discountService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountService = discountService;
        }

        public async  Task<IActionResult> Index()
        {
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();

            var getUserCount=await _userStatisticService.GetUserCount();

            var getTotalCommentCount=await _commentService.GetTotalCommentCount();
            var getActiveCommentCount = await _commentService.GetActiveCommentCount();
            var getPassiveCommentCount = await _commentService.GetPassiveCommentCount();

            var getDiscountCouponCount = await _discountService.GetDiscountCouponCount();
          //  var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            ViewBag.getBrandCount= getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;
            ViewBag.getUserCount = getUserCount;
            ViewBag.getActiveCommentCount = getActiveCommentCount;
            ViewBag.getPassiveCommentCount = getPassiveCommentCount;
            ViewBag.getTotalCommentCount = getTotalCommentCount;
            ViewBag.getDiscountCouponCount = getDiscountCouponCount;
          //  ViewBag.getProductAvgPrice = getProductAvgPrice;
            return View();
        }
    }
}
