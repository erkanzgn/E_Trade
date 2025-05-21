using ETrade.DtoLayer.DiscountDtos;
using ETrade.DtoLayer.MessageDtos;

namespace ETrade.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        //{
        //    var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/Message/UserMessage/GetMessageInbox?id=" + id);
        //    var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
        //    return values;
        //}


        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"UserMessages/GetMessageInbox/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Hata: " + responseMessage.StatusCode);
                return new List<ResultInboxMessageDto>(); 
            }

            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values ?? new List<ResultInboxMessageDto>(); 
        }


        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"UserMessages/GetMessageSendbox/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Hata: " + responseMessage.StatusCode);
                return new List<ResultSendboxMessageDto>();
            }

            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values ?? new List<ResultSendboxMessageDto>();
        }

        public async Task<int> GetTotalMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync($"UserMessages/GetTotalMessageCount/");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalMessageCountByReciverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"UserMessages/GetTotalMessageCountByReciverId/"+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }


        //////http://localhost:7079/api/UserMessages/GetMessageInbox?id=b

        //public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        //{
        //    var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/Message/UserMessage/GetMessageSendbox?id=" + id);
        //    var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
        //    return values;
        //}
    }
}
