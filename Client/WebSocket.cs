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
using System.Management;

namespace Client
{
    public class WebSocket
    {
        private ClientWebSocket serverWebSocket = null;
        private Task getServerTask;
        private WebSocket()
        {
            getServerTask = GetServer();
        }
        ~WebSocket()
        {
            if (serverWebSocket != null) serverWebSocket.Dispose();
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
                        byte[] bytesMessage = Encoding.ASCII.GetBytes(message.ToString());
                        await webSocket.SendAsync(new ArraySegment<byte>(bytesMessage), WebSocketMessageType.Text, true, cancellation);
                        WebSocketReceiveResult result=await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                        message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.ASCII.GetString(buffer, 0, result.Count));
                        if (message.Content == serverInfo.Content)
                        {
                            await webSocket.SendAsync(new ArraySegment<byte>(
                                Encoding.ASCII.GetBytes(
                                    new AutoTestMessage.Message
                                    {
                                        MessageType = AutoTestMessage.Message.MessageTypes.JoinServer,
                                        Content = serverInfo.Content
                                    }.ToString())), WebSocketMessageType.Text, true, cancellation);
                            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                            message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.ASCII.GetString(buffer, 0, result.Count));
                            if (message.MessageType == AutoTestMessage.Message.MessageTypes.JoinServer && message.Content == "OK")
                            {
                                serverWebSocket = webSocket;
                                Program.ClientMain.setServerIP(endpoint.Address.ToString());
                                Program.ClientMain.setServerUUID(Program.serverUUID = serverInfo.Content);
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
            _ = Task.Run(async () =>
              {
                  try
                  {
                      byte[] buffer = new byte[1024 * 1024];
                      CancellationToken cancellation = new CancellationToken();
                      while (true)
                      {
                          WebSocketReceiveResult result = await serverWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                          AutoTestMessage.Message message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.ASCII.GetString(buffer, 0, result.Count));
                          HandleMessage(message);
                      }
                  }
                  catch (Exception e)
                  {
                      Console.WriteLine(e);
                  }
                  finally
                  {
                      Console.WriteLine("finally");
                      serverWebSocket.Dispose();
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
        private async void HandleMessage(AutoTestMessage.Message message)
        {
            if (message.MessageType == AutoTestMessage.Message.MessageTypes.WMIMessage)
            {
                ManagementObjectCollection managementBaseObjects = await WMITest.GetDeatils(message.Content);
                WMIMessage wmiMessage = new WMIMessage();
                wmiMessage.path = message.Content;
                foreach (ManagementObject mo in managementBaseObjects)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    foreach (PropertyData pd in mo.Properties)
                    {
                        data.Add(pd.Name, pd.Value == null ? "null" : pd.Value.ToString());
                    }
                    wmiMessage.data.Add(data);
                }
                SendMessage(new AutoTestMessage.Message
                {
                    MessageType = AutoTestMessage.Message.MessageTypes.WMIMessage,
                    Content = wmiMessage.ToString()
                });
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        public async void SendMessage(AutoTestMessage.Message message)
        {
            await getServerTask;
            CancellationToken cancellation = new CancellationToken();
            await serverWebSocket.SendAsync(new ArraySegment<byte>(
                Encoding.UTF8.GetBytes(message.ToString())), WebSocketMessageType.Text, true, cancellation);
        }
    }
}