using AutoTestMessage;
using Fleck;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class WebSocket
    {
        public class Client
        {
            public IWebSocketConnection Socket;
            private string clientUrl;
            private ManualResetEvent isTaskStart=new ManualResetEvent(true);
            public string ClientUrl { get => clientUrl; }
            public ClientTask currentTask = new ClientTask(new Message { MessageType = Message.MessageTypes.None }, "", true);
            private List<ClientTask> Task = new List<ClientTask>(ClientTask.Tasks);

            private List<KeyValuePair<DateTime, string>> logs = new List<KeyValuePair<DateTime, string>>();

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
                logs.Add(new KeyValuePair<DateTime, string>(DateTime.Now, log));
            }
            public void SaveLogsAsTxt()
            {
                using (FileStream fileStream = File.Create(logsDir + "/" + ClientUrl.Replace(':', '_') + ".txt"))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        foreach(KeyValuePair<DateTime,string> log in logs)
                        {
                            streamWriter.WriteLine(log.Key.ToString("[HH:mm:ss.fffff] ") + log.Value);
                        }
                    }
                }
            }
            public void WaitForStart()
            {
                isTaskStart.WaitOne();
            }
            public void PauseTask()
            {
                isTaskStart.Reset();
            }
            public void StartTask()
            {
                isTaskStart.Set();
            }
        }
        private IDictionary<string, Client> dic_Sockets = new Dictionary<string, Client>();
        private WebSocketServer server;
        private static readonly string logsDir= @"./" + DateTime.Now.ToString("yyyy-MM-dd HH-mm");
        private WebSocket()
        {
            _ = BoardServer();
            ListenClient();
            Directory.CreateDirectory(logsDir);
        }
        private async Task BoardServer()
        {
            try
            {
                List<IPAddress> IPAddresses = new List<IPAddress>();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                //生成IPAddresses
                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up
                        && adapter.Speed >= 1)
                    {
                        bool isVirtualDevice = false;
                        string[] macs = {   "005056", "001C14", "000C29", "000569", //VMware
                                        "080027", //VirtualBox
                                        "00155D" //Hyper-V
                                        };
                        foreach (string mac in macs)
                        {
                            //Contains可能不安全，建议改为substr方法
                            if (adapter.GetPhysicalAddress().ToString().Contains(mac))
                            {
                                isVirtualDevice = true;
                                break;
                            }
                        }
                        if (isVirtualDevice) continue;
                        if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.AsymmetricDsl ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.BasicIsdn ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet3Megabit ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.FastEthernetFx ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.FastEthernetT ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Fddi ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Isdn ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.MultiRateSymmetricDsl ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.PrimaryIsdn ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.RateAdaptDsl ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.SymmetricDsl ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Tunnel ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.VeryHighSpeedDsl ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Wman ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Wwanpp ||
                            adapter.NetworkInterfaceType == NetworkInterfaceType.Wwanpp2

                            )
                        {
                            bool isLocal = false;
                            IPInterfaceProperties ip = adapter.GetIPProperties();
                            UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                            foreach (UnicastIPAddressInformation ipadd in ipCollection)
                            {
                                if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
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
                                    for (int i = 0; i < ipBytes.Length; ++i)
                                    {
                                        broadBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
                                    }
                                    IPAddresses.Add(new IPAddress(broadBytes));
                                }
                            }
                        }
                    }
                }

                UdpClient udpClient = new UdpClient();
                List<IPEndPoint> IPEndPoints = new List<IPEndPoint>(IPAddresses.Select(t => new IPEndPoint(t, 6839)));
                Message info = new Message { MessageType = Message.MessageTypes.ServerUuid, Content = Program.Uuid.ToString() };
                Byte[] sendBytes = Encoding.ASCII.GetBytes(info.ToString());
                await Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            IPEndPoints.ForEach(t => udpClient.Send(sendBytes, sendBytes.Length, t));
                        }
                        catch (Exception ex)
                        {
                            Program.ReportError(ex, true, 0x8000AE02);
                        }
                        Thread.Sleep(1000);
                    }
                });
                udpClient.Close();
                return;
            }
            catch (Exception ex)
            {
                Program.ReportError(ex, true, 0x8000AE01);
            }
        }
        private void ListenClient()
        {
            try
            {
                server = new WebSocketServer("ws://0.0.0.0:2333");
                server.Start(socket =>
                {
                    try
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
                            dic_Sockets[clientUrl].SaveLogsAsTxt();
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
                            catch (JsonReaderException exception)
                            {
                                Console.WriteLine("接收到不正确的消息" + exception.Message);
                            }
                        };
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("堆栈描述\r\n" + ex.StackTrace
                            + "\r\n错误详情:\r\n" + ex.Message, "启动侦听线程时遇到错误");
                    }
                });
            }
            catch (Exception ex)
            {
                Program.ReportError(ex, true, 0x8000AE03);
            }
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
            //获取服务器UUID
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
                    await Task.Run(() => dic_Sockets[clientUrl].WaitForStart());
                    await Task.Run(() => dic_Sockets[clientUrl].currentTask.WaitForTaskFinished());
                    if (dic_Sockets[clientUrl].GetRemainTaskCount() != 0)
                    {
                        ClientTask clientTask = dic_Sockets[clientUrl].GetNextTask();
                        _ = socket.Send(
                            new Message
                            {
                                MessageType = Message.MessageTypes.CurrentTask,
                                Content = new CurrentTask
                                {
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
            else if (message.MessageType == Message.MessageTypes.TaskTotal)
            {
                _ = socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.TaskTotal,
                    Content = ClientTask.Tasks.Count().ToString()
                }.ToString());
            }
            else if (message.MessageType == Message.MessageTypes.CPUTemperyture)
            {
                List<CpuInfoOfTempFan> cpuInfoOfTempFans = JsonConvert.DeserializeObject<List<CpuInfoOfTempFan>>(message.Content);
                if (cpuInfoOfTempFans.Count() == 0 && cpuInfoOfTempFans.Any(cpuInfoOfTempFan => cpuInfoOfTempFan.Value != null))
                {
                    dic_Sockets[clientUrl].log("客户端无温度信息");
                }
                else
                {
                    List<CpuInfoOfTempFan> temperture=cpuInfoOfTempFans.FindAll(cpuInfoOfTempFan => cpuInfoOfTempFan.Value != null && cpuInfoOfTempFan.Value > 90);
                    if (temperture.Count() == 0)
                    {
                        dic_Sockets[clientUrl].log("客户端CPU温度正常");
                    }
                    else
                    {
                        foreach(CpuInfoOfTempFan i in temperture)
                        {
                            dic_Sockets[clientUrl].log(i.HardwareIdentifier+"温度超标:"+(int)i.Value);
                        }
                    }
                }
            }
            else if (message.MessageType == Message.MessageTypes.CPUFan)
            {
                List<CpuInfoOfTempFan> cpuInfoOfTempFans = JsonConvert.DeserializeObject<List<CpuInfoOfTempFan>>(message.Content);
                if (cpuInfoOfTempFans.Count() == 0 || cpuInfoOfTempFans.Any(cpuInfoOfTempFan => cpuInfoOfTempFan.Value != null))
                {
                    dic_Sockets[clientUrl].log("客户端无风扇信息");
                }
                else
                {
                    foreach (CpuInfoOfTempFan i in cpuInfoOfTempFans)
                    {
                        dic_Sockets[clientUrl].log(i.HardwareIdentifier + "风扇转速:" + (int)i.Value);
                    }
                }
            }
            else
            {
                dic_Sockets[clientUrl].currentTask.HandleMessage(message, dic_Sockets[clientUrl]);
            }
        }
    }
}