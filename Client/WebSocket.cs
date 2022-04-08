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
using static AutoTestMessage.TesterMessage;

namespace Client
{
    public class WebSocket
    {
        private AutoTestMessage.Message task = new AutoTestMessage.Message { MessageType = AutoTestMessage.Message.MessageTypes.None };
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
                    byte[] _recv = udpClient.Receive(ref endpoint);
                    try
                    {
                        string returnData = Encoding.ASCII.GetString(_recv);
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
                                _ = webSocket.SendAsync(new ArraySegment<byte>(
                                    Encoding.ASCII.GetBytes(
                                        new AutoTestMessage.Message
                                        {
                                            MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                                            Content = task.ToString()
                                        }.ToString())), WebSocketMessageType.Text, true, cancellation);
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
                      Console.WriteLine(e.Message);
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
                _ = Task.Run(async () =>
                  {
                      await SendMessage(new AutoTestMessage.Message
                      {
                          MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                          Content = (task = message).ToString()
                      });
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
                      await SendMessage(new AutoTestMessage.Message
                      {
                          MessageType = AutoTestMessage.Message.MessageTypes.WMIMessage,
                          Content = wmiMessage.ToString()
                      });
                      await SendMessage(new AutoTestMessage.Message
                      {
                          MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                          Content = (task = new AutoTestMessage.Message { MessageType = AutoTestMessage.Message.MessageTypes.None }).ToString()
                      });
                  });
            }
            else if (message.MessageType == AutoTestMessage.Message.MessageTypes.TesterMessage)
            {
                
                TesterMessage testerMessage = JsonConvert.DeserializeObject<TesterMessage>(message.Content);
                _ = Task.Run(async () =>
                {
                    await SendMessage(new AutoTestMessage.Message
                    {
                        MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                        Content = (task = message).ToString()
                    });
                    TestResult result =await TesterTest.startTesterAsync(testerMessage.data);
                    await SendMessage(new AutoTestMessage.Message
                    {
                        MessageType = AutoTestMessage.Message.MessageTypes.WMIMessage,
                        Content = result.ToString()
                    });
                    await SendMessage(new AutoTestMessage.Message
                    {
                        MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                        Content = (task = new AutoTestMessage.Message { MessageType = AutoTestMessage.Message.MessageTypes.None }).ToString()
                    });
                });
            }
            //接收配置文件并显示
            else if(message.MessageType == AutoTestMessage.Message.MessageTypes.ConfigFile)
            {
                ConfigFile configFile = JsonConvert.DeserializeObject<ConfigFile>(message.Content);
                Program.ClientMain.UpdatetbConfigFileDetail(ClientMain.JsonFormat(message.Content));
            }
            else if(message.MessageType == AutoTestMessage.Message.MessageTypes.TimeSync)
            {
                AutoTestMessage.Message sending = new AutoTestMessage.Message();
                sending.MessageType = AutoTestMessage.Message.MessageTypes.TimeSync;
                sending.Content = JsonConvert.SerializeObject(DateTimeOffset.Now.ToUnixTimeMilliseconds());
            }
            //执行MAC地址校验
            else if(message.MessageType == AutoTestMessage.Message.MessageTypes.MACVerify)
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                //回传的消息
                AutoTestMessage.Message reply = new AutoTestMessage.Message();
                //指示未通过检查的网卡列表
                List<ManagementObject> invaildNics = new List<ManagementObject>();
                
                foreach (ManagementObject mo in moc2)
                {
                    
                    if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                    {
                        string macaddress = mo["MacAddress"].ToString();

                       if(System.Text.RegularExpressions.
                            Regex.Matches(macaddress, @"([A-Fa-f0-9]{2}[-,:]){5}[A-Fa-f0-9]{2}")
                             .Count != 1)
                        {
                            invaildNics.Add(mo);
                        };
                    }
                    mo.Dispose();
                }
                reply.Content = JsonConvert.SerializeObject(invaildNics);
                reply.MessageType = AutoTestMessage.Message.MessageTypes.MACVerify;

                await SendMessage(reply);
            }
            else
            {
                Console.WriteLine( message.MessageType.ToString()+message.Content);
            }
        }
        public async Task SendMessage(AutoTestMessage.Message message)
        {
            await getServerTask;
            CancellationToken cancellation = new CancellationToken();
            await serverWebSocket.SendAsync(new ArraySegment<byte>(
                Encoding.UTF8.GetBytes(message.ToString())), WebSocketMessageType.Text, true, cancellation);
        }
    }
}