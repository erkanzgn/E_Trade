using ETrade.Catalog.Dtos.BrandDtos;

namespace ETrade.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto brandDto);
        Task UpdateBrandAsync(UpdateBrandDto brandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
    }
}
