using Microsoft.AspNet.SignalR;

namespace OwinTest.Controllers
{
    public class TestHub : Hub
    {

        public TestHub() { }

        public void SendMessage(string message)
        {

            Clients.All.RecvMessage(message);
        }




    }
}