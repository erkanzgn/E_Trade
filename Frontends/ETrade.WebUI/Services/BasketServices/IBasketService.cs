using ETrade.DtoLayer.BasketDtos;

namespace ETrade.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(BasketItemDto? basketItemDto);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
