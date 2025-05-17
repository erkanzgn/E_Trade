using ETrade.DtoLayer.CatalogDtos.ProductDtos;

namespace ETrade.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto ProductDto);
        Task UpdateProductAsync(UpdateProductDto ProductDto);
        Task DeleteProductAsync(string id);
        Task<UpdateProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
