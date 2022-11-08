using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoRealTimeApp.Hubs
{
    public enum Role
    {
        Admin = 1,
        Participant
    }
    public class ChatHub : Hub
    {
        //define a dictionary to store the userid.
        private static Dictionary<string, List<string>> NtoIdMappingTable = new Dictionary<string, List<string>>();
        private ApplicationDbContext _applicationDbContext;
        public readonly static List<ApplicationUser> _Users = new List<ApplicationUser>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        public readonly static List<ApplicationUser> _Connections = new List<ApplicationUser>();

        public ChatHub(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public override async Task OnConnectedAsync()
        {
            if (_Users.Count == 0)
            {
                foreach (ApplicationUser users in _applicationDbContext.Users.ToList())
                {
                    _Users.Add(users);
                }
            }
            var user = _applicationDbContext.Users.Where(u => u.UserName == Context.User.Identity.Name).FirstOrDefault();
            user.ConnectionId = Context.ConnectionId;
            _Connections.Add(user);
            _ConnectionsMap.Add(Context.User.Identity.Name, Context.ConnectionId);
            await Clients.All.SendAsync("UserConnected", _Connections);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //await Clients.All.SendAsync("UserDisConnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(string receiver, string message)
        {
            Room room = new Room();
            Room roomV2 = new Room();
            var userSender = _applicationDbContext.Users.Where(u => u.UserName == Context.User.Identity.Name).FirstOrDefault();
            var userReceiver = _applicationDbContext.Users.Where(u => u.UserName == receiver).FirstOrDefault();
            var roomName = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes($"{userReceiver.DisplayName}{receiver}")));
            var roomNamev2 = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes($"{receiver}{userReceiver.DisplayName}")));

            room = _applicationDbContext.Rooms.Where(room => (room.Name.Equals($"P{roomName}"))).FirstOrDefault();
            roomV2 = _applicationDbContext.Rooms.Where(r => r.Name.Equals($"P{roomNamev2}")).FirstOrDefault();

            if (room != null && roomV2 != null)
            {
                Room newRoom = new Room()
                {
                    Name = $"P{roomName}"
                };
                _applicationDbContext.Rooms.Add(newRoom);
                _applicationDbContext.SaveChanges();
                _applicationDbContext.UserRooms.AddRange(
                 new UserRoom()
                 {
                     UserId = userReceiver.Id,
                     RoomId = newRoom.Id,
                     Role = (int)Role.Participant
                 },

                  new UserRoom()
                  {
                      UserId = userSender.Id,
                      RoomId = newRoom.Id,
                      Role = (int)Role.Participant
                  }
               );
            }

            Message msg = new Message()
            {
                Content = Regex.Replace(message, @"(?i)<(?!img|a|/a|/img).*?>", String.Empty),
                Timestamp = DateTime.Now.Ticks.ToString(),
                FromUser = userSender,
                ToUser = userReceiver,
                ToRoom = _applicationDbContext.Rooms.FirstOrDefault(room => room.Name.Equals($"P{roomName}"))
            };
            _applicationDbContext.Messages.Add(msg);
            _applicationDbContext.SaveChanges();
            string connectionId;
            if (_ConnectionsMap.TryGetValue(userReceiver.UserName, out connectionId))
            {
                // Who is the sender;
                var sender = _Connections.Where(u => u.UserName == userReceiver.UserName).First();

                // Send the message
                await Clients.Caller.SendAsync("SendMsg", msg.Content, msg.FromUser.Avatar);
            }
            // Send the message
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", msg.Content, msg.FromUser.Avatar);
        }
    }
}
