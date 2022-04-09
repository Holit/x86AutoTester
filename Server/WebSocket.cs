﻿using System;
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
        public class Client
        {
            public IWebSocketConnection Socket;
            private string clientUrl;
            public string ClientUrl { get => clientUrl; }
            public ClientTask currentTask = new ClientTask(new Message { MessageType = Message.MessageTypes.None },"",true);
            private List<ClientTask> Task=new List<ClientTask>(ClientTask.Tasks);


            public Client(IWebSocketConnection Socket)
            {
                this.Socket = Socket;
                clientUrl = Socket.ConnectionInfo.ClientIpAddress + ":" + Socket.ConnectionInfo.ClientPort;
            }
            public int GetRemainTaskCount()
            {
                return Task.Count();
            }
            public ClientTask GetNextTask()
            {
                currentTask = Task[0];
                Task.RemoveAt(0);
                return currentTask;
            }
            public void log(string log)
            {
                Program.ServerMain.setClientLog(clientUrl, log);
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
                bool invaildAdapter = false;
                string[] macs = { "005056", "001C14", "000C29", "000569", //VMware
                                  "080027", //VirtualBox
                                  "00155D" //Hyper-V
                };
                foreach(string mac in macs)
                {
                    //Contains可能不安全，建议改为substr方法
                    if (adapter.GetPhysicalAddress().ToString().Contains(mac)
                        || adapter.Speed == -1
                        || adapter.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Down
                        )
                    {
                        invaildAdapter = true;

                        break;
                    }
                }
                if (invaildAdapter) continue;
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || 
                    adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
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
                            byte[] ipBytes = ipadd.Address.GetAddressBytes();
                            byte[] maskBytes = ipadd.IPv4Mask.GetAddressBytes();
                            byte[] broadBytes = new byte[ipBytes.Length];
                            for(int i=0;i < ipBytes.Length; ++i)
                            {
                                broadBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
                            }
                            iPAddresses.Add(new IPAddress(broadBytes));
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
                Console.WriteLine(DateTime.Now.ToString() + "|试图建立服务器：位于" + server.Location);
                socket.OnOpen = () =>   //连接建立事件
                {
                    string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
                    Console.WriteLine(DateTime.Now.ToString() + "|服务器:和客户端:" + clientUrl + " 建立WebSock连接！");
                };
                socket.OnClose = () =>  //连接关闭事件
                {
                    string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
                    dic_Sockets[clientUrl].log("客户端断开WebSock连接！");
                    //如果存在这个客户端,那么对这个socket进行移除
                    if (dic_Sockets.ContainsKey(clientUrl))
                    {
                        dic_Sockets.Remove(clientUrl);
                        Program.ServerMain.setClientCount(dic_Sockets.Count());
                    }
                    //Console.WriteLine(DateTime.Now.ToString() + "|服务器:和客户端:" + clientUrl + " 断开WebSock连接！");
                };
                socket.OnMessage = rawMessage =>  //接受客户端网页消息事件
                {
                    try
                    {
                        Message message = JsonConvert.DeserializeObject<Message>(rawMessage);
                        HandleMessage(message, socket);
                    }
                    catch (JsonReaderException exception )
                    {
                        Console.WriteLine("接收到不正确的消息" + exception.Message);
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
        private async void HandleMessage(Message message, IWebSocketConnection socket)
        {
            string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
            if (message.MessageType == Message.MessageTypes.ServerUuid)
            {
                _ = socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.ServerUuid,
                    Content = Program.Uuid
                }.ToString());
            }
            else if (message.MessageType == Message.MessageTypes.JoinServer)
            {
                _ = socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.JoinServer,
                    Content = message.Content == Program.Uuid ? "OK" : "FAIL"
                }.ToString());
                if (Program.Uuid == message.Content)
                {
                    dic_Sockets.Add(clientUrl, new Client(socket));
                    dic_Sockets[clientUrl].log("客户端登录成功");
                    Program.ServerMain.setClientCount(dic_Sockets.Count());
                }
            }
            else if (message.MessageType == Message.MessageTypes.CurrentTask)
            {
                Console.WriteLine(message);
                Message task = JsonConvert.DeserializeObject<Message>(message.Content);
                if (task.MessageType == Message.MessageTypes.None)
                {
                    Program.ServerMain.setClientState(clientUrl, "等待任务下发", ClientTask.Tasks.Count() - dic_Sockets[clientUrl].GetRemainTaskCount());
                    Console.WriteLine("客户端" + clientUrl + "完成任务" + dic_Sockets[clientUrl].currentTask.TaskMessage.ToString() + "完成");
                    await Task.Run(()=>dic_Sockets[clientUrl].currentTask.WaitForTaskFinished());
                    if (dic_Sockets[clientUrl].GetRemainTaskCount() != 0)
                    {
                        ClientTask clientTask = dic_Sockets[clientUrl].GetNextTask();
                        _ = socket.Send(
                            new Message
                            {
                                MessageType = Message.MessageTypes.CurrentTask,
                                Content = new CurrentTask { 
                                    describe = clientTask.Describe, 
                                    task = clientTask.TaskMessage.ToString() 
                                }.ToString()
                            }.ToString()                            
                            );
                    }
                }
                else
                {
                    Program.ServerMain.setClientState(dic_Sockets[clientUrl]);
                }
            }
            else if(message.MessageType == Message.MessageTypes.TaskTotal)
            {
                _ = socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.TaskTotal,
                    Content = ClientTask.Tasks.Count().ToString()
                }.ToString());
            }
            else
            {
                dic_Sockets[clientUrl].currentTask.HandleMessage(message, dic_Sockets[clientUrl]);
            }
        }
    }
}