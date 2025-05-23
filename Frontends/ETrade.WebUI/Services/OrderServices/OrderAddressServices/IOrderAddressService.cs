using ETrade.DtoLayer.OrderDtos.OrderAddressDtos;

namespace ETrade.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task<List<ResultOrderAddressDto>> GetAllAddressAsync();
        Task<List<UpdateOrderAddressDto>> GetAddressesByUserIdAsync(string id);
        Task CreateAddressAsync(CreateOrderAddressDto orderAddressDto);
        Task UpdateAddressAsync(UpdateOrderAddressDto OrderAddressDto);
        Task DeleteAddressAsync(int id);
        Task<UpdateOrderAddressDto> GetByIdAddressAsync(int id);
    }
}
