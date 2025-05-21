using ETrade.DtoLayer.IdentityDtos.UserDtos;

namespace ETrade.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDtos>> GetAllUserAsync();
    }
}
