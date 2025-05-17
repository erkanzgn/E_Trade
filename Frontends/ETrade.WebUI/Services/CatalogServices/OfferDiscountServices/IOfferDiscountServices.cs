using ETrade.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace ETrade.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountServices
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto offerDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto offerDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
