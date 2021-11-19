using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR.WebMvc.Models.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string usuario, string mensagem)
        {
            await Clients.All.SendAsync("ReceiveMessage", usuario, mensagem);
        }
    }
}
