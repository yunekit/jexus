using Microsoft.AspNet.SignalR;

namespace ApiTest.Controllers
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