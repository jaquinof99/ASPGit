using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

        public class MyHub : Hub
        {
            public override Task OnConnected()
            {
                UserHandler.ConnectedIds.Add(Context.ConnectionId);
                return base.OnConnected();
            }

            public override Task OnDisconnected(bool stopCalled)
            {
                UserHandler.ConnectedIds.Remove(Context.ConnectionId);
                return base.OnDisconnected(stopCalled);
            }
        }
        public void Send(string name, string message, string timenow)
        {
            timenow = DateTime.Now.ToString();
            //Call the addNewMEssageToPage method to update clients
            Clients.All.addNewMessageToPage(name, message, timenow);
        }
    }
}