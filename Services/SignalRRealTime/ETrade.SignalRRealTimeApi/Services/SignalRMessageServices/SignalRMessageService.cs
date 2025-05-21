namespace ETrade.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService:ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReciverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"UserMessages/GetTotalMessageCountByReciverId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
