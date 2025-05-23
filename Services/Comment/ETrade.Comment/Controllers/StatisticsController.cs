using ETrade.Comment.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public StatisticsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            var values=await _commentContext.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
