using ETrade.SignalRRealTimeApi.Services;
using ETrade.SignalRRealTimeApi.Services.SignalRCommentServices;
using ETrade.SignalRRealTimeApi.Services.SignalRMessageServices;
using Microsoft.AspNetCore.SignalR;

namespace ETrade.SignalRRealTimeApi.Hubs
{
    public class SignalRHub:Hub
    {
        //private readonly ISignalRMessageService _messageService;
        private readonly ISignalRCommetService _commetService;

        public SignalRHub(ISignalRMessageService messageService, ISignalRCommetService commetService)
        {
            //_messageService = messageService;
            _commetService = commetService;
        }

        public async Task SendStaticticCount()
        {
         
            var getTotalCommentCount=  await _commetService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReciveCommentCount", getTotalCommentCount);

            //var getTotalMessageCount = _messageService.GetTotalMessageCountByReciverId(id);
            //await Clients.All.SendAsync("ReciveMessageCount", getTotalMessageCount);
        }
    }
}
