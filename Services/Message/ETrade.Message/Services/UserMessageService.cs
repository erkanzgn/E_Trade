using AutoMapper;
using ETrade.Message.Dal.Context;
using ETrade.Message.Dal.Entities;
using ETrade.Message.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace ETrade.Message.Services
{
    public class UserMessageService:IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessage)
        {
            var value = _mapper.Map<UserMessage>(createMessage);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
            
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
         
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x=>x.ReciverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessage)
        {
            var values = _mapper.Map<UserMessage>(updateMessage);
             _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
    }
}
