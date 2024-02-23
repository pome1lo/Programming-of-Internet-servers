using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace lw1b.Handlers
{
    public class IISHandler : IHttpHandler
    {
        WebSocket socket;
        public bool IsReusable { get => false; }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequst);
            }
        }
        private async Task WebSocketRequst(AspNetWebSocketContext context) 
        {
            socket = context.WebSocket;
            string s = await Recieve();
            await Send(s);
            int i = 0;
            while (socket.State == WebSocketState.Open)
            {
                Thread.Sleep(1000);
                await Send($"[{i++}]");
            }
        }
        
        private async Task<string> Recieve()
        {
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            
            return System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
        }
        
        private async Task Send(string s)
        {
            var sendBuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("Ответ: " + s));
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        } 


    }
}
