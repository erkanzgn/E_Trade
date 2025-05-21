using ETrade.DtoLayer.MessageDtos;

namespace ETrade.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
 
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReciverId(string id);

        //Task CreateMessageAsync(CreateMessageDto createMessage);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessage);
        //Task DeleteMessageAsync(int id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
