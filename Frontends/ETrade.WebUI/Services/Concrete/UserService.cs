using ETrade.WebUI.Models;
using ETrade.WebUI.Services.Abstracts;
using System.Net;

namespace ETrade.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            var response = await _httpClient.GetAsync("/api/users/getuser");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _contextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDetailViewModel>();
        }
        public async Task<List<AllUserViewModel>> GetAllUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<List<AllUserViewModel>>("/api/appUsers/userlist");
        }

    }

    //public class UserService : IUserService
    //{
    //    private readonly HttpClient _httpClient;

    //    public UserService(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }

    //    public async Task<UserDetailViewModel> GetUserInfo()
    //    {
    //        return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
    //    }
    //}
}
