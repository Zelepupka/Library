using System.Security.Permissions;
using System.Threading.Tasks;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Library.Web.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendComment(CommentViewModel comment)
        {
            await this.Clients.All.SendAsync("Send",comment);   
        }
}
}