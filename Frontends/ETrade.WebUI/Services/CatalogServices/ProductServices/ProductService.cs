using ETrade.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ETrade.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
     

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto productDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products", productDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products?id=" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", productDto);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        //public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        //{
        //    var responseMessage = await _httpClient.GetAsync("products/ProductListWithCategoryByCategoryId/" + categoryId);
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        //    return values;
        //}
        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/ProductListWithCategoryByCategoryId/{categoryId}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status: {responseMessage.StatusCode}");
            }
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(jsonData))
            {
                return new List<ResultProductWithCategoryDto>();
            }
            Console.WriteLine($"API Response: {jsonData}");
            try
            {
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return values ?? new List<ResultProductWithCategoryDto>();
            }
            catch (JsonException ex)
            {
                // JSON parse hatası durumunda log'layın
                Console.WriteLine($"JSON Parse Error: {ex.Message}");
                Console.WriteLine($"Response Content: {jsonData}");
                throw;
            }
        }
    }
}
