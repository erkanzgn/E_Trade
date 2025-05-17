using ETrade.DtoLayer.CatalogDtos.AboutDtos;

namespace ETrade.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto aboutDto);
        Task UpdateAboutAsync(UpdateAboutDto aboutDto);
        Task DeleteAboutAsync(string id);
        Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
