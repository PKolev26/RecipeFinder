using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace RecipeFinder.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message) 
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
