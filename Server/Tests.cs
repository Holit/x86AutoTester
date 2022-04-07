﻿using AutoTestMessage;
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
                new ClientTask(new Message { MessageType = Message.MessageTypes.TesterMessage, Content =
                    new TesterMessage{
                        data = {
                            { "operator" , "cpuTest" },
                            { "thread" , "auto" },
                            { "totalTime" , (2*60*1000).ToString() }
                        }
                    }.ToString()
                    },"CPU压力测试"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_OperatingSystem" },"操作系统配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_Processor" },"CPU配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PhysicalMemory" },"内存配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_VideoController" },"显卡配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_DiskDrive" },"硬盘配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_NetworkAdapter" },"网卡配置校验"),
                new ClientTask(new Message { MessageType = Message.MessageTypes.TesterMessage, Content =
                    new TesterMessage{
                        data = {
                            { "operator" , "memoyTest" },
                            { "reservedMemory" , (1024*1024*1024).ToString() },//1G保留空间
                            { "memoryPerThread" , (1024*1024*512).ToString() },//512M每线程
                            { "totalTime" , (2*60*1000).ToString() },//测试时间2分钟
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

        public ClientTask(Message TaskMessage,string Describe,bool finished=false)
        {
            taskMessage = TaskMessage;
            manualEvent = new ManualResetEvent(finished);
            describe = Describe;
        }

        public void HandleMessage(Message message, Client socket)
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
                        if(verifying.Processors.Count > 0)
                        {
                            //result
                            Console.WriteLine("Win32_Processor 校验失败。存在一个或多个未期许的硬件");
                            Console.WriteLine("DEBUGONLY:verifying.Processors.Count = " + verifying.Processors.Count.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Win32_Processor 校验通过");
                        }
                    }
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
