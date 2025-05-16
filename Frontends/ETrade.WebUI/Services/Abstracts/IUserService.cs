using ETrade.WebUI.Models;

namespace ETrade.WebUI.Services.Abstracts
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
