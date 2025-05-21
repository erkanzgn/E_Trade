using ETrade.DtoLayer.IdentityDtos.UserDtos;
using Newtonsoft.Json;

namespace ETrade.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDtos>> GetAllUserAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/GetAllUserList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDtos>>(jsonData);
            return values;
        }
    }
}
