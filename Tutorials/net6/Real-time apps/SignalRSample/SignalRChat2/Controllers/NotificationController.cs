using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat2.Hubs;
using System.ComponentModel.DataAnnotations;

namespace SignalRChat2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public NotificationController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageInfoRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Send([FromBody] MessageInfoRequestDto messageInfoRequestDto)
        {
            await _chatHub.Clients.Users(messageInfoRequestDto.UserId).SendAsync("Notification", messageInfoRequestDto.Content);

            return NoContent();
        }
    }

    public class MessageInfoRequestDto
    {
        [Required]
        public List<string> UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

    }
}
