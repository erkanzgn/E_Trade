using ETrade.Basket.Dtos;
using ETrade.Basket.Settings;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ETrade.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
           var status=await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            //Alınan veriyi JsonSerializer.Deserialize ile BasketTotalDto türüne dönüştürür 
            var existBasket =await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId,JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
