using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Moodle.WebSocketManager
{
    public class Connection
    {
        private ConcurrentDictionary<string, WebSocket> _connenctions = new ConcurrentDictionary<string, WebSocket>();
        public WebSocket GetSocketById(string id)
        {
            return _connenctions.FirstOrDefault(x => x.Key == id).Value;
        }
        public ConcurrentDictionary<string, WebSocket> GetAllConnections() { 
            return _connenctions; 
        }
        public string GetId(WebSocket socket)
        {
            return _connenctions.FirstOrDefault(x => x.Value == socket).Key;
        }

        public async Task RemoveSocketAsync(string id)
        {
            _connenctions.TryRemove(id, out var socket);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Socket closed", CancellationToken.None);
        }
        public void AddSocket(WebSocket socket)
        {
            _connenctions.TryAdd(CreateConnectionId(), socket);
        }

        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}