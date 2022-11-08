using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRealTimeApp.Hubs
{
    public class ChatHub : Hub
    {
        //define a dictionary to store the userid.
        private static Dictionary<string, List<string>> NtoIdMappingTable = new Dictionary<string, List<string>>();
        private ApplicationDbContext _applicationDbContext;

        public ChatHub(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public override async Task OnConnectedAsync()
        {

            var username = Context.User.Identity.Name;
            var userId = Context.UserIdentifier;

            // Get ChatHistory and call the client function. See below
            this.GetHistory(userId);

            List<string> userIds;

            //store the userid to the list.
            if (!NtoIdMappingTable.TryGetValue(username, out userIds))
            {
                userIds = new List<string>();
                userIds.Add(userId);

                NtoIdMappingTable.Add(username, userIds);
            }
            else
            {
                userIds.Add(userId);
            }
            await base.OnConnectedAsync();
        }

        private void GetHistory(string? userId)
        {
            throw new NotImplementedException();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var username = Context.User.Identity.Name;
            var userId = Context.UserIdentifier;
            List<string> userIds;

            //remove userid from the List
            if (NtoIdMappingTable.TryGetValue(username, out userIds))
            {
                userIds.Remove(userId);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task<Task> SendPrivateMessage(string sender, string receiver, string message)
        {
            var userId = NtoIdMappingTable.GetValueOrDefault(receiver);

            if (userId.Count > 0)
            {
                await Clients.User(userId.FirstOrDefault()).SendAsync("ReceiveMessage", sender, message);
            }
            string name = Context.User.Identity.Name;
            //Save the message, sender, receiver and message to database
            //await SaveMessage(sender, receiver, name, message);
            return Clients.User(name).SendAsync("ReceiveMessage", message);

        }

        //private Task SaveMessage(string sender, string receiver, string? name, string message)
        //{
        //    //find user id identity by name 
        //    var senderId = _applicationDbContext.Users.FirstOrDefault(u=> u.)?.Id;
        //}

        //public void SetUserName(string username)
        //{
        //    UserList.AddUser(new User(username, Context.ConnectionId));
        //}
    }
}
