using ETrade.DtoLayer.DiscountDtos;

namespace ETrade.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDicountCodeDeatilByCode> GetDicountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Discounts/GetCodeDetailByCodeAsync?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDicountCodeDeatilByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Discounts/GetDiscountCouponRate?code="+code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
