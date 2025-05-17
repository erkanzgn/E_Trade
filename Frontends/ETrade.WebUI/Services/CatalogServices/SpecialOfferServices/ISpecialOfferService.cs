using ETrade.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace ETrade.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
