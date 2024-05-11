using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace Moodle.WebSocketManager
{
    public abstract class SocketHandler
    {
        public Connection Connections { get; set; }

        private readonly string _eventsJsonPath = "Data/events.json"; // A JSON fájl elérési útvonala
        public SocketHandler(Connection connections) {
            Connections = connections;
        }

        public virtual async Task OnConnected(System.Net.WebSockets.WebSocket socket)
        {
            Connections.AddSocket(socket);

            // Az események beolvasása a JSON fájlból
            var eventsJson = await File.ReadAllTextAsync(_eventsJsonPath);
            var events = JsonConvert.DeserializeObject<List<Event>>(eventsJson);

            // Az események JSON formátumba alakítása
            var eventsJsonString = JsonConvert.SerializeObject(events);

            // Elküldjük az események JSON formátumban a csatlakozott kliensnek
            await SendMessage(socket, eventsJsonString);
        }

        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await Connections.RemoveSocketAsync(Connections.GetId(socket));
        }

        public async Task SendMessage(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)    return;
            await socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(message), 0, message.Length), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task SendMessage(string id, string message)
        {
            await SendMessage(Connections.GetSocketById(id), message);
        }

        public async Task SendMessageToAll(string message)
        {
            foreach (var con in Connections.GetAllConnections())
                await SendMessage(con.Value, message);
        }

        public abstract Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    }


}
