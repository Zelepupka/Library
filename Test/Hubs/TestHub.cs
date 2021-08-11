using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Test.Hubs
{
    public class TestHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Send", message);
        }
    }
}