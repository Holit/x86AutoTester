using AutoTestMessage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                        string returnData = Encoding.UTF8.GetString(_recv);
                        AutoTestMessage.Message serverInfo = JsonConvert.DeserializeObject<AutoTestMessage.Message>(returnData);
                        ClientWebSocket webSocket = new ClientWebSocket();
                        CancellationToken cancellation = new CancellationToken();

                        await webSocket.ConnectAsync(new Uri("ws://" + endpoint.Address + ":2333"), cancellation);

                        AutoTestMessage.Message message = new AutoTestMessage.Message { MessageType = AutoTestMessage.Message.MessageTypes.ServerUuid };
                        byte[] bytesMessage = Encoding.UTF8.GetBytes(message.ToString());
                        await webSocket.SendAsync(new ArraySegment<byte>(bytesMessage), WebSocketMessageType.Text, true, cancellation);
                        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                        message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.UTF8.GetString(buffer, 0, result.Count));
                        if (message.Content == serverInfo.Content)
                        {
                            await webSocket.SendAsync(new ArraySegment<byte>(
                                Encoding.UTF8.GetBytes(
                                    new AutoTestMessage.Message
                                    {
                                        MessageType = AutoTestMessage.Message.MessageTypes.JoinServer,
                                        Content = serverInfo.Content
                                    }.ToString())), WebSocketMessageType.Text, true, cancellation);
                            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                            message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.UTF8.GetString(buffer, 0, result.Count));
                            if (message.MessageType == AutoTestMessage.Message.MessageTypes.JoinServer && message.Content == "OK")
                            {
                                serverWebSocket = webSocket;
                                Program.ClientMain.setServerIP(endpoint.Address.ToString());
                                Program.ClientMain.setServerUUID(Program.serverUUID = serverInfo.Content);
                                Console.WriteLine("加入服务器成功");
                                await webSocket.SendAsync(new ArraySegment<byte>(
                                    Encoding.UTF8.GetBytes(
                                        new AutoTestMessage.Message
                                        {
                                            MessageType = AutoTestMessage.Message.MessageTypes.TaskTotal
                                        }.ToString())), WebSocketMessageType.Text, true, cancellation);
                                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellation);
                                message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.UTF8.GetString(buffer, 0, result.Count));
                                Program.ClientMain.taskTotal = int.Parse(message.Content);
                                _ = webSocket.SendAsync(new ArraySegment<byte>(
                                    Encoding.UTF8.GetBytes(
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
                    catch (JsonReaderException exception)
                    {
                        Console.WriteLine("接收到不正确的消息");
                        Console.WriteLine(exception);
                    }
                    catch (WebSocketException exception)
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
                          AutoTestMessage.Message message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(Encoding.UTF8.GetString(buffer, 0, result.Count));
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
        private void HandleMessage(AutoTestMessage.Message message)
        {
            if (message.MessageType == AutoTestMessage.Message.MessageTypes.TaskResult)
            {
                ++Program.ClientMain.FinishedTask;
                Task.Run(async () =>
                {
                    TaskResult currentTask = JsonConvert.DeserializeObject<TaskResult>(message.Content);
                    Program.ClientMain.setTaskResult(currentTask.taskName, currentTask.taskResult);
                    await SendMessage(new AutoTestMessage.Message
                    {
                        MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                        Content = (task = new AutoTestMessage.Message { MessageType = AutoTestMessage.Message.MessageTypes.None }).ToString()
                    });
                });
            }
            else if (message.MessageType == AutoTestMessage.Message.MessageTypes.CurrentTask)
            {
                Task.Run(async () =>
                {
                    CurrentTask currentTask = JsonConvert.DeserializeObject<CurrentTask>(message.Content);
                    //解包
                    message = JsonConvert.DeserializeObject<AutoTestMessage.Message>(currentTask.task);
                    await SendMessage(new AutoTestMessage.Message
                    {
                        MessageType = AutoTestMessage.Message.MessageTypes.CurrentTask,
                        Content = (task = message).ToString()
                    });
                    Program.ClientMain.addTask(currentTask.describe);
                    if (message.MessageType == AutoTestMessage.Message.MessageTypes.WMIMessage)
                    {
                        await Task.Run(async () =>
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
                            await SendMessage(new AutoTestMessage.Message
                            {
                                MessageType = AutoTestMessage.Message.MessageTypes.WMIMessage,
                                Content = wmiMessage.ToString()
                            });
                        });
                    }
                    //执行测试
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.TesterMessage)
                    {
                        TesterMessage testerMessage = JsonConvert.DeserializeObject<TesterMessage>(message.Content);
                        await Task.Run(async () =>
                        {
                            int exitcode = await TesterTest.startTesterAsync(testerMessage.data);
                            await SendMessage(new AutoTestMessage.Message
                            {
                                MessageType = AutoTestMessage.Message.MessageTypes.TesterMessage,
                                Content = exitcode.ToString()
                            });
                        });
                    }
                    //接收配置文件并显示
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.ConfigFile)
                    {
                        ConfigFile configFile = JsonConvert.DeserializeObject<ConfigFile>(message.Content);
                        Program.ClientMain.UpdatetbConfigFileDetail(ClientMain.JsonFormat(message.Content));
                    }
                    //RTC校验
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.TimeSync)
                    {
                        AutoTestMessage.Message sending = new AutoTestMessage.Message();
                        sending.MessageType = AutoTestMessage.Message.MessageTypes.TimeSync;
                        sending.Content = JsonConvert.SerializeObject(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                        await SendMessage(sending);
                    }
                    //执行MAC地址校验
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.MACVerify)
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

                                if (System.Text.RegularExpressions.
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
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.USBWritingTest)
                    {
                        string[] dirs = Environment.GetLogicalDrives();
                        string callback = "";
                        foreach (string dir in dirs)
                        {
                            System.IO.DriveInfo Tdriver = new System.IO.DriveInfo(dir);
                            if (Tdriver.DriveType == System.IO.DriveType.Removable)
                            {
                                //未测试
                                //未就绪等待，自动循环等待3次，每次5秒。
                                int WaitingDuration = 2;

                                while (Tdriver.IsReady == false && WaitingDuration >= 0)
                                {
                                    //等待设备就绪
                                    await Task.Delay(5 * 1000);
                                    WaitingDuration--;
                                }
                                if(WaitingDuration < 0 && Tdriver.IsReady == false)
                                {
                                    callback += "设备" + Tdriver.Name + "未就绪：检测失败\r\n";
                                }

                            }
                        }
                        if(callback != "")
                        {
                            await SendMessage(new AutoTestMessage.Message
                            {
                                MessageType = AutoTestMessage.Message.MessageTypes.USBWritingTest,
                                Content = callback
                            });
                        }
                        else
                        {
                            await SendMessage(new AutoTestMessage.Message
                            {
                                MessageType = AutoTestMessage.Message.MessageTypes.USBWritingTest,
                                Content = "Success"
                            });
                        }
                    }
                    //执行串口测试
                    //未测试代码
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.SerialTest)
                    {
                        List<SerialPort> SerialPortsDevices = new List<SerialPort>();

                        string[] AllPorts = System.IO.Ports.SerialPort.GetPortNames();
                        foreach (string PortName in AllPorts)
                        {
                            SerialPort serial = new SerialPort();
                            serial.PortName = PortName;
                            serial.BaudRate = 9600;
                            serial.Parity = Parity.Odd;
                            serial.StopBits = StopBits.One;

                            SerialPortsDevices.Add(serial);
                            try
                            {
                                serial.Open();
                                if (serial.IsOpen == true)
                                {
                                    byte[] buffer = new byte[64];
                                    //发送模块
                                    buffer.SetValue(0, 0, buffer.Length);
                                    buffer = Program.strToHexByte("0123456789ABCDE");
                                    try
                                    {
                                        serial.WriteBufferSize = 64;
                                        serial.Write(buffer, 0, buffer.Length);
                                    }
                                    catch (Exception ex)
                                    {
                                        //此处为串口写入失败的反馈
                                    }
                                    finally
                                    {
                                        serial.Close();
                                    }

                                    //侦听模块
                                    buffer.SetValue(0, 0, buffer.Length);
                                    try
                                    {
                                        serial.ReadBufferSize = 64;
                                        serial.Read(buffer, 0, buffer.Length);

                                    }
                                    catch (Exception ex)
                                    {
                                        //此处为串口读入数据失败的反馈
                                    }
                                    finally
                                    {
                                        serial.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("无法向串口发送消息：启动失败", "测试串口 " + serial.PortName + " 异常");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "测试串口 " + serial.PortName + " 时出现严重错误");
                            }
                        }
                    }
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.PlayAudio)
                    {
                        System.Media.SystemSounds.Hand.Play();
                        DialogResult dr = MessageBox.Show("您听到声音了吗？", "提问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            Console.WriteLine("成功");
                            await SendMessage(new AutoTestMessage.Message
                            {
                                MessageType = AutoTestMessage.Message.MessageTypes.PlayAudio,
                                Content = "Success"
                            });
                        }
                        else
                        {
                            Console.WriteLine("失败");
                            await SendMessage(new AutoTestMessage.Message
                            {
                                MessageType = AutoTestMessage.Message.MessageTypes.PlayAudio,
                                Content = "Fail"
                            });
                        }
                    }
                    //执行CHKDSK
                    else if (message.MessageType == AutoTestMessage.Message.MessageTypes.ChkdskEvent)
                    {
                        AutoTestMessage.Message sending = new AutoTestMessage.Message();
                        sending.MessageType = AutoTestMessage.Message.MessageTypes.ChkdskEvent;
                        sending.Content = JsonConvert.SerializeObject(
                            new ChkdskEvent
                            {
                                result = await DiskTest.startDiskTestAsync()
                            });
                        await SendMessage(sending);
                    }
                    else
                    {
                        Console.WriteLine(message.MessageType.ToString() + message.Content);
                    }
                });
            }
            else
            {
                Console.WriteLine(message.MessageType.ToString() + message.Content);
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