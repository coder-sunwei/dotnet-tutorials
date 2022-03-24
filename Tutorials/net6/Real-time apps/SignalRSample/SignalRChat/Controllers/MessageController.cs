using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

namespace SignalRChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHub;

        public MessageController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
        [Route("send")]
        [HttpPost]
        public async Task<IActionResult> Send([FromBody] MessageContent messageContent)
        {
            await _chatHub.Clients.All.SendAsync("AdminMessage", messageContent.Content);

            return NoContent();
        }
    }

    public class MessageContent
    {
        public string Content { get; set; }
    }
}
