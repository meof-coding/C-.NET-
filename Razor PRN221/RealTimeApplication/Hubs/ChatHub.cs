using Microsoft.AspNetCore.SignalR;

namespace RealTimeApplication.Hubs
{
    public class ChatHub: Hub //The Hub class manages connections, groups, and messaging.
    {
        //The SendMessage method can be called by a connected client to send a message to all clients.
        //JavaScript client code that calls the method to invoke this method.
        //SignalR code is asynchronous to provide maximum scalability.
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
