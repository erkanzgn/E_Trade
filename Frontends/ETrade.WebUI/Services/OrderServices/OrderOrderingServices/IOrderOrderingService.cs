using ETrade.DtoLayer.OrderDtos.OrderOrderingDto;

namespace ETrade.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
