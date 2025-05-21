using ETrade.DtoLayer.DiscountDtos;

namespace ETrade.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDicountCodeDeatilByCode> GetDicountCode(string code);
        Task<int> GetDiscountCouponRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}
