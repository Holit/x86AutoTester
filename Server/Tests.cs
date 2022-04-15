using AutoTestMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Server.WebSocket;

namespace Server
{
    public class ClientTask
    {
        public static List<ClientTask> Tasks = new List<ClientTask> {
            new ClientTask(new Message { MessageType = Message.MessageTypes.TimeSync, Content = null} ,"RTC同步"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_Processor" } ,"CPU配置校验"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PhysicalMemory" },"内存配置校验"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_VideoController" } ,"显卡配置校验"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_DiskDrive" } ,"硬盘配置校验"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.PlayAudio, Content = null},"音频接口测试:输出"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PnPEntity" } ,"即插即用设备校验"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.USBWritingTest, Content = null} ,"USB写入测试"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.NetworkTest, Content = null},"网口数据测试"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_NetworkAdapterConfiguration"},"MAC地址测试"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.SerialTest, Content = null} ,"串口写入测试"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.StartGetClientCpuInfo , Content = null} ,"获取客户端温度和风扇信息"),
            new ClientTask(new Message { MessageType = Message.MessageTypes.DiskPressure, 
                    Content = "-b4K -F8 -r -o32 -W60 -d60"} ,"硬盘压力测试"),//4k块面积 8线程 32并发 预热60秒 测试60秒
                //发布版本：
                //  Content = "-b4K -F8 -r -o32 -W60 -d21600"},"硬盘压力测试") : null,
            new ClientTask(new Message { MessageType = Message.MessageTypes.TesterMessage, Content =
                    new TesterMessage{
                        data = {
                            { "operator" , "cpuTest" },
                            { "thread" , "auto" },
                            { "totalTime" , (2*60*1000).ToString() }
                            //发布
                        }
                    }.ToString()
                    },"CPU压力测试"),
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
            };
        private Message taskMessage;
        private ManualResetEvent manualEvent;
        private string describe;
        public Message TaskMessage { get => taskMessage; }
        public string Describe { get => describe; }

        public ClientTask(Message TaskMessage, string Describe, bool finished = false)
        {
            taskMessage = TaskMessage;
            manualEvent = new ManualResetEvent(finished);
            describe = Describe;
        }

        public void HandleMessage(Message message, Client client)
        {
            //配置校验
            if (message.MessageType == Message.MessageTypes.WMIMessage)
            {
                try
                {

                    object recv = Newtonsoft.Json.JsonConvert.DeserializeObject(message.Content, typeof(WMIMessage));
                    WMIMessage wmiMessage = recv as WMIMessage;
                    ConfigFile verifying = Program.configFile;

                    if (wmiMessage != null && wmiMessage.data != null)
                    {
                        if (wmiMessage.path == "Win32_Processor")
                        {
                            //test code, only for debugging.
                            foreach (Dictionary<string, string> _data in wmiMessage.data)
                            {
                                verifying.Processors.Remove((ConfigFile.Processor)
                                    (from items in verifying.Processors
                                     where (items.ProcessorId == _data["ProcessorId"]
                                         && items.Name == _data["Name"]
                                         && items.Manufacturer == _data["Manufacturer"]
                                         && items.Family == _data["Family"]
                                         && items.MaxClockSpeed == _data["MaxClockSpeed"])
                                     select items).GetEnumerator().Current);
                            }
                            if (verifying.Processors.Count > 0)
                            {
                                //result
                                client.log("处理器 校验失败：存在一个或多个未期许的硬件");
                                //client.log("DEBUGONLY:verifying.Processors.Count = " + verifying.Processors.Count.ToString());
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
                                client.log("处理器 校验通过");
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
                        else if (wmiMessage.path == "Win32_PhysicalMemory")
                        {
                            //test code, only for debugging.
                            foreach (Dictionary<string, string> _data in wmiMessage.data)
                            {
                                verifying.PhysicalMemorys.Remove((ConfigFile.PhysicalMemory)
                                    (from items in verifying.PhysicalMemorys
                                     where
                                     items.Manufacturer == _data["Manufacturer"] &&
                                     items.Capacity == _data["Capacity"] &&
                                     items.PartNumber == _data["PartNumber"] &&
                                     items.SerialNumber == _data["SerialNumber"] &&
                                     items.Speed == _data["Speed"]
                                     select items).GetEnumerator().Current);
                            }
                            if (verifying.PhysicalMemorys.Count > 0)
                            {
                                //result
                                client.log("物理内存设备 校验失败。存在一个或多个未期许的硬件");
                                client.log("DEBUGONLY:verifying.PhysicalMemorys.Count = " + verifying.PhysicalMemorys.Count.ToString());
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
                                client.log("物理内存设备 校验通过");
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
                        else if (wmiMessage.path == "Win32_VideoController")
                        {
                            //test code, only for debugging.
                            foreach (Dictionary<string, string> _data in wmiMessage.data)
                            {
                                verifying.VideoControllers.Remove((ConfigFile.VideoController)
                                    (from items in verifying.VideoControllers
                                     where
                                     items.AdapterCompatibility == _data["AdapterCompatibility"] &&
                                     items.AdapterRAM == _data["AdapterRAM"] &&
                                     items.Name == _data["Name"] &&
                                     items.VideoProcessor == _data["VideoProcessor"]
                                     select items).GetEnumerator().Current);
                            }
                            if (verifying.VideoControllers.Count > 0)
                            {
                                //result
                                client.log("显示适配器 校验失败。存在一个或多个未期许的硬件");
                                client.log("DEBUGONLY:verifying.VideoControllers.Count = " + verifying.VideoControllers.Count.ToString());
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
                                client.log("显示适配器 校验通过");
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
                        else if (wmiMessage.path == "Win32_DiskDrive")
                        {
                            //test code, only for debugging.
                            foreach (Dictionary<string, string> _data in wmiMessage.data)
                            {
                                verifying.Disks.Remove((ConfigFile.Disk)
                                    (from items in verifying.Disks
                                     where
                                     items.Manufacturer == _data["Manufacturer"] &&
                                     items.Model == _data["Model"] &&
                                     items.MediaType == _data["MediaType"] &&
                                     items.SerialNumber == _data["SerialNumber"] &&
                                     items.Size == _data["Size"]
                                     select items).GetEnumerator().Current);
                            }
                            if (verifying.Disks.Count > 0)
                            {
                                //result
                                client.log("磁盘驱动器 校验失败。存在一个或多个未期许的硬件");
                                client.log("DEBUGONLY:verifying.Disks.Count = " + verifying.Disks.Count.ToString());
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
                                client.log("磁盘驱动器 校验通过");
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
                        else if (wmiMessage.path == "Win32_NetworkAdapter")
                        {
                            //test code, only for debugging.
                            foreach (Dictionary<string, string> _data in wmiMessage.data)
                            {
                                verifying.NetworkAdapters.Remove((ConfigFile.NetworkAdapter)
                                    (from items in verifying.NetworkAdapters
                                     where
                                     items.Description == _data["Description"] &&
                                     items.GUID == _data["GUID"] &&
                                     items.Speed == _data["Speed"]
                                     select items).GetEnumerator().Current);
                            }
                            if (verifying.VideoControllers.Count > 0)
                            {
                                //result
                                client.log("网络适配器 校验失败。存在一个或多个未期许的硬件");
                                client.log("DEBUGONLY:verifying.NetworkAdapters.Count = " + verifying.NetworkAdapters.Count.ToString());
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
                                client.log("网络适配器 校验通过");
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
                        else if (wmiMessage.path == "Win32_NetworkAdapterConfiguration")
                        {
                            List<string> invaildNics = new List<string>();
                            foreach (Dictionary<string, string> mo in wmiMessage.data)
                            {

                                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                                {
                                    string macaddress = mo["MACAddress"].ToString();

                                    if (System.Text.RegularExpressions.
                                         Regex.Matches(macaddress, @"([A-Fa-f0-9]{2}[-,:]){5}[A-Fa-f0-9]{2}")
                                          .Count != 1)
                                    {
                                        invaildNics.Add(mo["name"]);
                                    };
                                }
                            }
                            if (invaildNics.Count() > 0)
                            {
                                client.log(client.currentTask.describe + "测试失败:" + Newtonsoft.Json.JsonConvert.SerializeObject(invaildNics));
                                client.Socket.Send(new Message
                                {
                                    MessageType = Message.MessageTypes.TaskResult,
                                    Content = new TaskResult
                                    {
                                        taskName = client.currentTask.describe,
                                        taskResult = "测试失败:" + Newtonsoft.Json.JsonConvert.SerializeObject(invaildNics)
                                    }.ToString()
                                }.ToString());
                            }
                            else
                            {
                                client.log(client.currentTask.describe + "测试通过");
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
                catch (Exception ex)
                {
                    Program.ReportError(ex, false, 0x8001EF00);
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
            //各类测试信息
            //包括CPU、内存测试
            else if (message.MessageType == Message.MessageTypes.TesterMessage)
            {
                int resutl = int.Parse(message.Content);
                if (resutl == ((int)TesterMessage.TestResult.SUCCESS))
                {
                    client.log(client.currentTask.describe + "测试通过");
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
                else if (resutl == (int)TesterMessage.TestResult.ARGS_ERROR)
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
                    client.log(client.currentTask.describe + "测试失败，exitCode:" + resutl);
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
            //硬盘测试
            else if (message.MessageType == Message.MessageTypes.ChkdskEvent)
            {
                Console.WriteLine(message.Content);
                ChkdskEvent results = Newtonsoft.Json.JsonConvert.DeserializeObject<ChkdskEvent>(message.Content);
                var faile = from result in results.result where result.Value != 0 select result;
                if (faile.Count() == 0)
                {
                    client.log(client.currentTask.describe + "测试通过");
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
                else
                {
                    client.log(client.currentTask.describe + "测试失败:" + Newtonsoft.Json.JsonConvert.SerializeObject(faile));
                    client.Socket.Send(new Message
                    {
                        MessageType = Message.MessageTypes.TaskResult,
                        Content = new TaskResult
                        {
                            taskName = client.currentTask.describe,
                            taskResult = "测试失败:" + Newtonsoft.Json.JsonConvert.SerializeObject(faile)
                        }.ToString()
                    }.ToString());
                }
            }
            else if (message.MessageType == Message.MessageTypes.PlayAudio)
            {
                if (message.Content.Equals("Success"))
                {
                    client.log(client.currentTask.describe + "测试通过");
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
                else if (message.Content.Equals("Fail"))
                {
                    client.log(client.currentTask.describe + "测试失败");
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
                    Console.WriteLine("未知的回复:" + message.Content);
                }
            }
            else if (message.MessageType == Message.MessageTypes.USBWritingTest)
            {
                if (message.Content.Equals("Success"))
                {
                    client.log(client.currentTask.describe + "测试通过");
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
                else
                {
                    client.log(client.currentTask.describe + "测试失败:"+message.Content);
                    client.Socket.Send(new Message
                    {
                        MessageType = Message.MessageTypes.TaskResult,
                        Content = new TaskResult
                        {
                            taskName = client.currentTask.describe,
                            taskResult = "测试失败:" + message.Content
                        }.ToString()
                    }.ToString());
                }
            }
            else if (message.MessageType == Message.MessageTypes.NetworkTest)
            {
                client.log(client.currentTask.describe + "测试通过");
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
            else if (message.MessageType == Message.MessageTypes.DiskPressure)
            {
                if (int.Parse(message.Content) == 0)
                {
                    client.log(client.currentTask.describe + "测试通过");
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
                else
                {
                    client.log(client.currentTask.describe + "测试失败");
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
            }
            else if (message.MessageType == Message.MessageTypes.StartGetClientCpuInfo)
            {
                client.log(client.currentTask.describe);
                client.Socket.Send(new Message
                {
                    MessageType = Message.MessageTypes.TaskResult,
                    Content = new TaskResult
                    {
                        taskName = client.currentTask.describe,
                        taskResult = "开始获取"
                    }.ToString()
                }.ToString());
            }
            else if (message.MessageType == Message.MessageTypes.SerialTest)
            {
                if (message.Content=="OK")
                {
                    client.log(client.currentTask.describe + "测试通过");
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
                else
                {
                    client.log(client.currentTask.describe + "测试失败");
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
            }
            manualEvent.Set();
        }
        public void WaitForTaskFinished()
        {
            manualEvent.WaitOne();
        }
    }
}
