using ETrade.DtoLayer.OrderDtos.OrderAddressDtos;

namespace ETrade.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        //Task<List<ResultOrderAddressDto>> GetAllOrderAddressAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto orderAddressDto);
        //Task UpdateOrderAddressAsync(UpdateOrderAddressDto OrderAddressDto);
        //Task DeleteOrderAddressAsync(string id);
        //Task<UpdateOrderAddressDto> GetByIdOrderAddressAsync(string id);
    }
}
