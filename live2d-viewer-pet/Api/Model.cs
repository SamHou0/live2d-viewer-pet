using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace live2d_viewer_pet.Api
{
    /// <summary>
    /// Provide connection to communicate with live2dviewerex.Call Connect() first before sending requests.
    /// </summary>
    internal class Model
    {
        private static int id = 1;
        internal Uri IPAddress = new Uri("ws://127.0.0.1:10086/api");
        private ClientWebSocket clientWebSocket;
        public Model()
        {
            clientWebSocket = new ClientWebSocket();
        }
        /// <summary>
        /// Send messages to show pop-up windows.
        /// </summary>
        /// <param name="message">The text message shown.</param>
        /// <param name="choices">Buttons. Can be empty if no choices included.</param>
        public async Task SendMessageAsync(string message, string[] choices = null)
        {
            TextMessageData data = new()
            {text = message, choices = choices };
            TextMessage textMessage = new()
            { msg = 11000, msgId = id, data = data };
            Console.WriteLine(textMessage);
            string json=JsonSerializer.Serialize(textMessage);
            await clientWebSocket.SendAsync
                (Encoding.UTF8.GetBytes( json), 
                WebSocketMessageType.Text,true,CancellationToken.None);
            id++;
        }
        /// <summary>
        /// Start WebSocket Listening.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Connect not called.</exception>
        public async Task StartReceiveAsync()
        {
            if (clientWebSocket.State != WebSocketState.Open)
                throw new Exception("WebSocket Closed.");

            var buffer = new byte[4096];
            WebSocketReceiveResult result = null;
            do
            {
                result = await clientWebSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine("Received:" + message + Environment.NewLine);
            }
            while (!result.CloseStatus.HasValue);

        }
        /// <summary>
        /// Should be called on creation.
        /// </summary>
        /// <returns></returns>
        public async Task Connect()
        {
            await clientWebSocket.ConnectAsync
                (IPAddress, CancellationToken.None);
            Console.WriteLine(clientWebSocket.State.ToString());
        }
    }
}
