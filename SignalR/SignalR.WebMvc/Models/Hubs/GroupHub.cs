using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.WebMvc.Models.Hubs
{
    public class GroupHub : Hub
    {

        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessage(string sender, string message)
        {
            await Clients.All.SendAsync("SendMessageGroup", sender, message);
        }

        public async Task SendMessageToGroup(string group, string sender, string message)
        {
            await Clients.Group(group).SendAsync("SendMessageGroup", sender, message);
        }
    }
}
