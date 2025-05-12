using ETrade.Catalog.Dtos.AboutDtos;

namespace ETrade.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto aboutDto);
        Task UpdateAboutAsync(UpdateAboutDto aboutDto);
        Task DeleteAboutAsync(string id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
