using ETrade.DtoLayer.CatalogDtos.BrandDtos;

namespace ETrade.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto brandDto);
        Task UpdateBrandAsync(UpdateBrandDto brandDto);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
    }
}
