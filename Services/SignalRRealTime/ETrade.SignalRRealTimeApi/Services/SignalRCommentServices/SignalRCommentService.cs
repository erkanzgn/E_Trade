
using Newtonsoft.Json;

namespace ETrade.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommetService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<int> GetTotalCommentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7076/api/Statistics");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var commentCount=JsonConvert.DeserializeObject<int>(jsonData);
            return commentCount;
        }

    }
}
