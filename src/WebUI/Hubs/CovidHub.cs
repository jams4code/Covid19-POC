using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace Covid19.WebUI.Hubs
{
    public class CovidHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
