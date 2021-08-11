using System.Security.Permissions;
using System.Threading.Tasks;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Library.Web.Hubs
{
    public class CommentHub : Hub
    {
     
        public async Task SendComment(object comment)
        {
            await Clients.Others.SendAsync("SendComment",comment);
        }
}
}