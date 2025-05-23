using ETrade.DtoLayer.DiscountDtos;
using Newtonsoft.Json;

namespace ETrade.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDiscountCouponDto>("Discounts", createCouponDto);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            await _httpClient.DeleteAsync("http://localhost:7071/api/Discounts?id=" + id);
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Discounts");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultDiscountCouponDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<List<ResultDiscountCouponDto>>();
            return value;
        }

        public async Task<GetByIdDiscountCouponDto> GetByCodeDiscountCouponAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Discounts/GetCodeDetailByCode?code=" + code);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdDiscountCouponDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdDiscountCouponDto>();
            return value;
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Discounts/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdDiscountCouponDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDiscountCouponDto>("Discounts", updateCouponDto);
        }

        //private readonly HttpClient _httpClient;

        //public DiscountService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //public async Task<GetByIdDiscountCouponDto> GetDicountCode(string code)
        //{
        //    var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Discounts/GetCodeDetailByCodeAsync?code=" + code);
        //    var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdDiscountCouponDto>();
        //    return values;
        //}

        //public async Task<int> GetDiscountCouponCount()
        //{
        //    var responseMessage = await _httpClient.GetAsync("Discounts/GetDiscountCouponCount");
        //    var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        //    return values;
        //}

        //public async Task<int> GetDiscountCouponRate(string code)
        //{
        //    var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Discounts/GetDiscountCouponRate?code="+code);
        //    var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        //    return values;
        //}
    }
}
