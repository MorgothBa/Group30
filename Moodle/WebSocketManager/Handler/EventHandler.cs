using System.Net.WebSockets;
using System.Text;

namespace Moodle.WebSocketManager.Handler
{
    public class EventHandler : SocketHandler
    {
        public EventHandler(Connection connections) : base(connections) {}

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            var socketId = Connections.GetId(socket);
            await SendMessageToAll($"{socketId} jelentkezett!");
        }


        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = Connections.GetId(socket);
            var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            await SendMessageToAll(message);
        }
    }
}
