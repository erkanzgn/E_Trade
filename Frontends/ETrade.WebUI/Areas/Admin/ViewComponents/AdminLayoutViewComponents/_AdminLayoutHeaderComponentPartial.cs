using ETrade.WebUI.Services.Abstracts;
using ETrade.WebUI.Services.CommentServices;
using ETrade.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService,
            ICommentService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int messageCount = await _messageService.GetTotalMessageCountByReciverId(user.Id);
            ViewBag.messageCount = messageCount;


            int totalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.totalCommetCount = totalCommentCount;


            return View();
        }
    }
}
