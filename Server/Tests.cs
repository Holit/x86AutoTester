using AutoTestMessage;
using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ClientTask
    {
        public static List<ClientTask> Tasks = new List<ClientTask> {
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_OperatingSystem" }),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_Processor" }),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_PhysicalMemory" }),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_VideoController" }),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_DiskDrive" }),
                new ClientTask(new Message { MessageType = Message.MessageTypes.WMIMessage, Content = "Win32_NetworkAdapter" }),
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
                    }),
            };

        private Message taskMessage;
        private ManualResetEvent manualEvent;
        public Message TaskMessage { get => taskMessage; }

        public ClientTask(Message TaskMessage,bool finished=false)
        {
            taskMessage = TaskMessage;
            manualEvent = new ManualResetEvent(finished);
        }

        public void HandleMessage(Message message, IWebSocketConnection socket)
        {
            Console.WriteLine(message.ToString());
            manualEvent.Set();
        }
        public void WaitForTaskFinished()
        {
            manualEvent.WaitOne();
        }
    }
}
