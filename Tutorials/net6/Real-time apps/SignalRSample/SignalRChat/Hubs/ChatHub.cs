using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Caller.SendAsync("Disconnected", "您已下线！");

            await base.OnDisconnectedAsync(exception);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Connected", "您已上线！");

            await base.OnConnectedAsync();
        }

       
    }
}
