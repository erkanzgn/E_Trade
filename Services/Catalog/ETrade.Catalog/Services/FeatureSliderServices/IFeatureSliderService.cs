using ETrade.Catalog.Dtos.FeatureSliderDtos;

namespace ETrade.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto featureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto featureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
