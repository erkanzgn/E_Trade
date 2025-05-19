using ETrade.Message.Dtos;

namespace ETrade.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessage);
        Task UpdateMessageAsync(UpdateMessageDto updateMessage);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);

    }
}
