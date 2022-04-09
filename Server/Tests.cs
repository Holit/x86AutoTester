using AutoTestMessage;
using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Server.WebSocket;

namespace Server
{
    public class ClientTask
    {
        public static List<ClientTask> Tasks = new List<ClientTask> {
                //new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_OperatingSystem" },"操作系统配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.TimeSync, Content = null},"RTC同步"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_Processor" },"CPU配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PhysicalMemory" },"内存配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_VideoController" },"显卡配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_DiskDrive" },"硬盘配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_NetworkAdapter" },"网卡配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PnPEntity" },"即插即用设备校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.PlayAudio, Content = null},"音频接口测试:输出"), 
                new ClientTask(new Message { MessageType = Message.MessageTypes.USBWritingTest, Content = null},"USB写入测试"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.SerialTest, Content = null},"串口写入测试"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.ChkdskEvent, Content = null},"磁盘测试"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.TesterMessage, Content =
                    new TesterMessage{
                        data = {
                            { "operator" , "memoryTest" },
                            { "reservedMemory" , (64L*1024*1024*1024).ToString() },//64G保留空间
                            { "memoryPerThread" , (1024*1024*512).ToString() },//512M每线程
                            { "totalTime" , (0).ToString() },//测试时间2分钟
                            { "sleepTime" , (60*1000).ToString() },//线程睡眠时间1分钟
                        }
                    }.ToString()
                    },"内存压力测试"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.TesterMessage, Content =
                    new TesterMessage{
                        data = {
                            { "operator" , "cpuTest" },
                            { "thread" , "auto" },
                            { "totalTime" , (0).ToString() }
                        }
                    }.ToString()
                    },"CPU压力测试"),
            };
        private Message taskMessage;
        private ManualResetEvent manualEvent;
        private string describe;
        public Message TaskMessage { get => taskMessage; }
        public string Describe { get => describe; }

        public ClientTask(Message TaskMessage,string Describe,bool finished=false)
        {
            taskMessage = TaskMessage;
            manualEvent = new ManualResetEvent(finished);
            describe = Describe;
        }

        public void HandleMessage(Message message, Client client)
        {
            if( message.MessageType == Message.MessageTypes.WMIMessage)
            {
                object recv = Newtonsoft.Json.JsonConvert.DeserializeObject(message.Content,typeof(WMIMessage));
                WMIMessage wmiMessage = recv as WMIMessage;
                ConfigFile verifying = Program.configFile;
                
                if(wmiMessage != null && wmiMessage.data != null)
                {
                    if(wmiMessage.path == "Win32_Processor")
                    {
                        //test code, only for debugging.
                        foreach (Dictionary<string,string> _data in wmiMessage.data)
                        {
                            verifying.Processors.Remove((ConfigFile.Processor)
                                (from items in verifying.Processors where (items.ProcessorId == _data["ProcessorId"] 
                                                                        && items.Name == _data["Name"]
                                                                        && items.Manufacturer == _data["Manufacturer"]
                                                                        && items.Family == _data["Family"]
                                                                        && items.MaxClockSpeed == _data["MaxClockSpeed"]) 
                                 select items).GetEnumerator().Current);
                        }
                        if (verifying.Processors.Count > 0)
                        {
                            //result
                            client.log("Win32_Processor 校验失败。存在一个或多个未期许的硬件");
                            client.log("DEBUGONLY:verifying.Processors.Count = " + verifying.Processors.Count.ToString());
                            client.Socket.Send(new Message{
                                MessageType = Message.MessageTypes.TaskResult,
                                Content = new TaskResult
                                    {
                                        taskName = client.currentTask.describe,
                                        taskResult = "测试失败"
                                    }.ToString()
                                }.ToString());
                        }
                        else
                        {
                            client.log("Win32_Processor 校验通过");
                            client.Socket.Send(new Message
                            {
                                MessageType = Message.MessageTypes.TaskResult,
                                Content = new TaskResult
                                {
                                    taskName = client.currentTask.describe,
                                    taskResult = "测试通过"
                                }.ToString()
                            }.ToString());
                        }
                    }
                    else if (wmiMessage.path == "Win32_PnPEntity")
                    {
                        if (wmiMessage.data.Count != verifying.outlet_pnp_count)
                        {
                            client.log("即插即用设备数量校验失败：预期值:" + verifying.outlet_pnp_count +
                                "当前值:" + wmiMessage.data.Count);
                            client.Socket.Send(new Message
                            {
                                MessageType = Message.MessageTypes.TaskResult,
                                Content = new TaskResult
                                {
                                    taskName = client.currentTask.describe,
                                    taskResult = "测试失败"
                                }.ToString()
                            }.ToString());
                        }
                        else
                        {
                            client.log("即插即用设备数量校验通过");
                            client.Socket.Send(new Message
                            {
                                MessageType = Message.MessageTypes.TaskResult,
                                Content = new TaskResult
                                {
                                    taskName = client.currentTask.describe,
                                    taskResult = "校验通过"
                                }.ToString()
                            }.ToString());
                        }
                    }
                    else
                    {
                        client.Socket.Send(new Message
                        {
                            MessageType = Message.MessageTypes.TaskResult,
                            Content = new TaskResult
                            {
                                taskName = client.currentTask.describe,
                                taskResult = "未知的测试"
                            }.ToString()
                        }.ToString());
                    }
                }
            }
            //时间同步
            //获取客户端时间，并做到毫秒级相减，然后看是否大于2s。
            //硬编码值可调
            else if (message.MessageType == Message.MessageTypes.TimeSync)
            {
                if (message.Content != null)
                {
                    long recvTimeStamp = Newtonsoft.Json.JsonConvert.DeserializeObject<long>(message.Content);
                    long delta = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - recvTimeStamp;
                    if (delta > 2 * 1000)
                    {
                        client.log("RTC 校验失败。时间差为" + delta);
                        client.Socket.Send(new Message
                        {
                            MessageType = Message.MessageTypes.TaskResult,
                            Content = new TaskResult
                            {
                                taskName = client.currentTask.describe,
                                taskResult = "校验失败,时间差为" + delta
                            }.ToString()
                        }.ToString());
                    }
                    else
                    {
                        client.log("RTC 校验成功。");
                        client.Socket.Send(new Message
                        {
                            MessageType = Message.MessageTypes.TaskResult,
                            Content = new TaskResult
                            {
                                taskName = client.currentTask.describe,
                                taskResult = "RTC 校验成功"
                            }.ToString()
                        }.ToString());
                    }
                }
                else
                {
                    client.log("RTC 校验失败，未知的客户端时间。");
                    client.Socket.Send(new Message
                    {
                        MessageType = Message.MessageTypes.TaskResult,
                        Content = new TaskResult
                        {
                            taskName = client.currentTask.describe,
                            taskResult = "RTC 校验失败，未知的客户端时间"
                        }.ToString()
                    }.ToString());
                }
            }
            else if (message.MessageType == Message.MessageTypes.MACVerify)
            {
                List<System.Management.ManagementObject> manageObjects =
                    (List<System.Management.ManagementObject>)
                    Newtonsoft.Json.JsonConvert.DeserializeObject(message.Content);
                if(manageObjects.Count > 0)
                {
                    
                    Console.WriteLine("存在下述网络适配器的MAC地址未通过校验");
                    foreach (System.Management.ManagementObject manageObject in manageObjects)
                    {
                        //能执行到这里也是真的绝了
                        Console.WriteLine("\r\n\t" + manageObject.Properties["Name"]);                    }
                }
            }
            else if(message.MessageType == Message.MessageTypes.TesterMessage)
            {
                int resutl = int.Parse(message.Content);
                if(resutl == ((int)TesterMessage.TestResult.SUCCESS))
                {
                    client.log(client.currentTask.describe+"测试通过");
                    client.Socket.Send(new Message
                    {
                        MessageType = Message.MessageTypes.TaskResult,
                        Content = new TaskResult
                        {
                            taskName = client.currentTask.describe,
                            taskResult = "测试通过"
                        }.ToString()
                    }.ToString());
                }
                else if(resutl == (int)TesterMessage.TestResult.ARGS_ERROR)
                {
                    client.log(client.currentTask.describe + "参数错误");
                    client.Socket.Send(new Message
                    {
                        MessageType = Message.MessageTypes.TaskResult,
                        Content = new TaskResult
                        {
                            taskName = client.currentTask.describe,
                            taskResult = "参数错误"
                        }.ToString()
                    }.ToString());
                }
                else
                {
                    client.log(client.currentTask.describe + "测试失败，exitCode:"+resutl);
                    client.Socket.Send(new Message
                    {
                        MessageType = Message.MessageTypes.TaskResult,
                        Content = new TaskResult
                        {
                            taskName = client.currentTask.describe,
                            taskResult = "测试失败，exitCode:" + resutl
                        }.ToString()
                    }.ToString());
                }
            }
            manualEvent.Set();
        }
        public void WaitForTaskFinished()
        {
            manualEvent.WaitOne();
        }
    }
}
