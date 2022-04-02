using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;
using AutoTestMessage;
using Newtonsoft.Json;
using System.Threading;
using Fleck;

namespace Server
{
    public class WebSocket
    {
        private class Client
        {
            public IWebSocketConnection Socket;
            public Message currentTask = new Message { MessageType = Message.MessageTypes.None };
            public List<Message> Task=new List<Message> {
                new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_OperatingSystem" },
                new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_Processor" },
                new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PhysicalMemory" },
                new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_VideoController" },
                new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_DiskDrive" },
                new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_NetworkAdapter" },
                new Message { MessageType = Message.MessageTypes.TesterMessage, Content = 
                    new TesterMessage{
                        data = {
                            { "operator" , "memoyTest" },
                            { "reservedMemory" , (1024*1024*1024).ToString() },//1G保留空间
                            { "memoryPerThread" , (1024*1024*512).ToString() },//512M每线程
                            { "totalTime" , (2*60*1000).ToString() },//测试时间2分钟
                            { "sleepTime" , (60*1000).ToString() },//线程睡眠时间1分钟
                        }
                    }.ToString()
                    },
            };
            public Client(IWebSocketConnection Socket)
            {
                this.Socket = Socket;
            }
        }
        private IDictionary<string, Client> dic_Sockets = new Dictionary<string, Client>();
        private WebSocketServer server;
        private WebSocket()
        {
            _ = BoardServer();
            ListenClient();
        }
        private async Task BoardServer()
        {
            List<IPAddress> iPAddresses = new List<IPAddress>();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    bool isLocal = false;
                    IPInterfaceProperties ip = adapter.GetIPProperties();
                    UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                    foreach (UnicastIPAddressInformation ipadd in ipCollection)
                    {
                        if(ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            if (ipadd.Address.ToString().StartsWith("169.254"))
                            {
                                isLocal = true;
                                break;
                            }
                        }
                    }
                    if (isLocal) continue;
                    IPAddressInformationCollection ipAnycastAddresses = ip.AnycastAddresses;
                    foreach (UnicastIPAddressInformation ipadd in ipCollection)
                    {
                        if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            iPAddresses.Add(ipadd.Address);
                        }
                    }
                }
            }

            UdpClient udpClient = new UdpClient();
            List<IPEndPoint> iPEndPoints = new List<IPEndPoint>(iPAddresses.Select(t => new IPEndPoint(t, 6839)));
            Message info = new Message { MessageType=Message.MessageTypes.ServerUuid,Content = Program.Uuid.ToString() };
            Byte[] sendBytes = Encoding.ASCII.GetBytes(info.ToString());
            await Task.Run(() =>
            {
                while (true)
                {
                    iPEndPoints.ForEach(t => udpClient.Send(sendBytes, sendBytes.Length, t));
                    Thread.Sleep(1000);
                }
            });
            udpClient.Close();
            return;
        }
        private void ListenClient()
        {
            server = new WebSocketServer("ws://0.0.0.0:6839");
            server.Start(socket =>
            {
                socket.OnOpen = () =>   //连接建立事件
                {
                    string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
                    Console.WriteLine(DateTime.Now.ToString() + "|服务器:和客户端:" + clientUrl + " 建立WebSock连接！");
                };
                socket.OnClose = () =>  //连接关闭事件
                {
                    string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
                    //如果存在这个客户端,那么对这个socket进行移除
                    if (dic_Sockets.ContainsKey(clientUrl))
                    {
                        dic_Sockets.Remove(clientUrl);
                        Program.ServerMain.setClientCount(dic_Sockets.Count());
                    }
                    Console.WriteLine(DateTime.Now.ToString() + "|服务器:和客户端:" + clientUrl + " 断开WebSock连接！");
                };
                socket.OnMessage = rawMessage =>  //接受客户端网页消息事件
                {
                    try
                    {
                        Message message = JsonConvert.DeserializeObject<Message>(rawMessage);
                        HandleMessage(message, socket);
                    }
                    catch (JsonReaderException exception)
                    {
                        Console.WriteLine("接收到不正确的消息");
                    }
                };
            });
        }
        private static readonly WebSocket singleInstance = new WebSocket();
        public static WebSocket GetInstance
        {
            get
            {
                return singleInstance;
            }
        }
        private void HandleMessage(Message message, IWebSocketConnection socket)
        {
            if (message.MessageType == Message.MessageTypes.ServerUuid)
            {
                socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.ServerUuid,
                    Content = Program.Uuid
                }.ToString());
            }else if (message.MessageType == Message.MessageTypes.JoinServer)
            {
                socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.JoinServer,
                    Content = message.Content == Program.Uuid ? "OK" : "FAIL"
                }.ToString());
                if (Program.Uuid == message.Content)
                {
                    string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
                    Console.WriteLine("客户端"+ clientUrl + "登录成功");
                    dic_Sockets.Add(clientUrl, new Client(socket));
                    Program.ServerMain.setClientCount(dic_Sockets.Count());
                }
            }else if (message.MessageType == Message.MessageTypes.CurrentTask)
            {
                Console.WriteLine(message);
                Message task = JsonConvert.DeserializeObject<Message>(message.Content);
                if (task.MessageType == Message.MessageTypes.None)
                {
                    string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
                    Console.WriteLine("客户端" + clientUrl + "完成任务" + dic_Sockets[clientUrl].currentTask.MessageType + "完成");
                    if (dic_Sockets[clientUrl].Task.Count() != 0)
                    {
                        Message msg = dic_Sockets[clientUrl].currentTask = dic_Sockets[clientUrl].Task[0];
                        socket.Send(msg.ToString());
                        dic_Sockets[clientUrl].Task.RemoveAt(0);
                    }

                }
            }
            else
            {
                Console.WriteLine(message.ToString());
            }
        }
    }
}