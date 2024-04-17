using Microsoft.AspNetCore.SignalR;

namespace RecipeFinder.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string profilepicture, string user, string message) 
        {
            await Clients.All.SendAsync("ReceiveMessage", profilepicture, user, message);
        }
    }
}
