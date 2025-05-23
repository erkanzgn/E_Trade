using ETrade.Message.Dal.Context;
using ETrade.Message.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticsController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }
        [HttpGet]
        public async  Task<IActionResult> GetTotalMessageCount()

        {
            int value = await _userMessageService.GetTotalMessageCount();
            return Ok(value);
        }
    }
}
