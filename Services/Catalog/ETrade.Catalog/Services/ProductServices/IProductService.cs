using ETrade.Catalog.Dtos.ProductDtos;

namespace ETrade.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto ProductDto);
        Task UpdateProductAsync(UpdateProductDto ProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
