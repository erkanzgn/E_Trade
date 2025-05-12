using ETrade.Catalog.Dtos.OfferDiscountDtos;

namespace ETrade.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto offerDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto offerDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
