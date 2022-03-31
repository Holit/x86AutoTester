using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using AutoTestMessage;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Threading;

namespace Client
{
    public class WebSocket
    {
        private ClientWebSocket serverWebSocket = null;
        private WebSocket()
        {
            _ = GetServer();
        }
        private async Task GetServer()
        {
            await Task.Run(async () =>
            {
                UdpClient udpClient = new UdpClient(6839);
                byte[] buffer = new byte[65536];
                while (true)
                {
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] recData = udpClient.Receive(ref endpoint);
                    try
                    {
                        string returnData = Encoding.ASCII.GetString(recData);
                        AutoTestMessage.Message serverInfo = JsonConvert.DeserializeObject<AutoTestMessage.Message>(returnData);
                        ClientWebSocket webSocket = new ClientWebSocket();
                        CancellationToken cancellation = new CancellationToken();
                        
                        await webSocket.ConnectAsync(new Uri("ws://"+ endpoint.Address+ ":6839"), cancellation);

                        AutoTestMessage.Message message = new AutoTestMessage.Message { MessageType = AutoTestMessage.Message.MessageTypes.ServerUuid };
                        byte[] bytesMessage = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message));
                        await webSocket.SendAsync(new ArraySegment<byte>(bytesMessage), WebSocketMessageType.Text, true, cancellation);
                        WebSocketReceiveResult result=await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                        message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.ASCII.GetString(buffer, 0, result.Count));
                        if (message.Content == serverInfo.Content)
                        {
                            await webSocket.SendAsync(new ArraySegment<byte>(
                                Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(
                                    new AutoTestMessage.Message
                                    {
                                        MessageType = AutoTestMessage.Message.MessageTypes.JoinServer,
                                        Content = serverInfo.Content
                                    }))), WebSocketMessageType.Text, true, cancellation);
                            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                            message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.ASCII.GetString(buffer, 0, result.Count));
                            if (message.MessageType == AutoTestMessage.Message.MessageTypes.JoinServer && message.Content == "OK")
                            {
                                serverWebSocket = webSocket;
                                Console.WriteLine("加入服务器成功");
                                break;
                            }
                            else
                            {
                                serverWebSocket.Dispose();
                            }
                        }
                    }
                    catch(JsonReaderException exception) {
                        Console.WriteLine("接收到不正确的消息");
                        Console.WriteLine(exception);
                    }
                    catch(WebSocketException exception)
                    {
                        Console.WriteLine("连接到服务器异常");
                        Console.WriteLine(exception);
                    }
                }
                udpClient.Dispose();

            });
            await Task.Run(async () =>
            {
                byte[] buffer = new byte[1024*1024];
                CancellationToken cancellation = new CancellationToken();
                while (true)
                {
                    WebSocketReceiveResult result = await serverWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                    AutoTestMessage.Message message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.ASCII.GetString(buffer, 0, result.Count));
                    HandleMessage(message);
                }
            });
            return;
        }
        private static readonly WebSocket singleInstance = new WebSocket();
        public static WebSocket GetInstance
        {
            get
            {
                return singleInstance;
            }
        }
        private void HandleMessage(AutoTestMessage.Message message)
        {

        }
    }
}