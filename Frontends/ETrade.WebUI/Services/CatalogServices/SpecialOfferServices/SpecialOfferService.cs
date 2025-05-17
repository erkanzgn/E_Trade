using ETrade.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace ETrade.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService:ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto specialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", specialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers?id=" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return values;

        }
        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return values;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto specialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", specialOfferDto);
        }
    }
}
