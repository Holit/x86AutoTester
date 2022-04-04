

//public class infoClass
//{
//    public string messageType;
//    public Dictionary<string, string> message;
//    //这里还可以存些别的东西
//}
//class Program
//{
//    /*
//     * 一个简易的http服务端
//     * 用了Newtonsoft.Json和Fleck
//     * 这俩可以通过工具-NuGet包管理器-管理解决方案的NuGet包管理器里搜索这俩东西来安装
//     * 监听的是任意域名的任意地址 至于能不能虚拟host- -回头再讨论
//     * 这个我照 https://www.cnblogs.com/armyfai/p/13723264.html 抄的
//     */
//    public static void Main(string[] s)
//    {
//        //保存当前的所有建立的socket以便于服务器给客户端发送消息
//        IDictionary<string, IWebSocketConnection> dic_Sockets = new Dictionary<string, IWebSocketConnection>();
//
//        WebSocketServer server = new WebSocketServer("ws://0.0.0.0:30000");
//
//        server.Start(socket =>
//        {
//            socket.OnOpen = () =>   //连接建立事件
//            {
//                //获取客户端网页的url
//                string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
//                dic_Sockets.Add(clientUrl, socket);
//                Console.WriteLine(DateTime.Now.ToString() + "|服务器:和客户端网页:" + clientUrl + " 建立WebSock连接！");
//            };
//            socket.OnClose = () =>  //连接关闭事件
//            {
//                string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
//                //如果存在这个客户端,那么对这个socket进行移除
//                if (dic_Sockets.ContainsKey(clientUrl))
//                {
//                    dic_Sockets.Remove(clientUrl);
//                }
//                Console.WriteLine(DateTime.Now.ToString() + "|服务器:和客户端网页:" + clientUrl + " 断开WebSock连接！");
//            };
//            socket.OnMessage = message =>  //接受客户端网页消息事件
//            {
//                string clientUrl = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort;
//                Console.WriteLine(DateTime.Now.ToString() + "|服务器:【收到】来客户端网页:" + clientUrl + "的信息：\n" + message);
//
//                infoClass info = JsonConvert.DeserializeObject<infoClass>(message);
//                Console.WriteLine("messageType:" + info.messageType);
//            };
//        });
//        while (true)
//        {
//            System.Threading.Thread.Sleep(1000);
//        }
//        /*
//        infoClass info = new infoClass
//        {
//            messageType="test",
//            message=new Dictionary<string, string>
//            {
//                { "caption" , "Intel64 Family 6 Model 158 Stepping 10" },
//                { "manufacturer " , "GenuineIntel" },
//                { "maxClockSpeed" , "2304" },
//                { "name" , "Intel(R) Core(TM) i5-8300H CPU @ 2.30GHz" },
//                { "socketDesignation" , "U3E1" }
//            }
//        };
//
//        string json = JsonConvert.SerializeObject(info, Formatting.Indented);
//        Console.WriteLine(json);
//        infoClass info2 = JsonConvert.DeserializeObject<infoClass>(json);
//        Console.WriteLine(info2.message["socketDesignation"]);
//        */
//        return;
//    }
//}

using Microsoft.Management.Infrastructure;
using Newtonsoft.Json;

namespace messages
{
    public class InfoClass
    {
        public string messageType = "";
        public string message = "";
    }
    public class ComputerInfo
    {
        public List<Dictionary<string, string>> info = new List<Dictionary<string, string>>();
    }
}
class Component1
{
    static void Main(string[] s)
    {
        string json = 
            JsonConvert.SerializeObject(getCPUInfo(), Formatting.Indented)
            + JsonConvert.SerializeObject(getMemoryInfo(), Formatting.Indented)
            + JsonConvert.SerializeObject(getGPUInfo(), Formatting.Indented)
            + JsonConvert.SerializeObject(getDiskInfo(), Formatting.Indented);
        Console.WriteLine(json);
    }
    public static messages.ComputerInfo getCPUInfo()
    {
        return getInfo("Win32_Processor");
    }
    public static messages.ComputerInfo getMemoryInfo()
    {
        return getInfo("Win32_PhysicalMemory");
    }
    public static messages.ComputerInfo getGPUInfo()
    {
        return getInfo("Win32_VideoController");
    }
    public static messages.ComputerInfo getDiskInfo()
    {
        return getInfo("Win32_DiskDrive");
    }
    public static messages.ComputerInfo getInfo(string className)
    {
        CimSession session = CimSession.Create(null);
        IEnumerable<CimInstance> queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM " + className);
        messages.ComputerInfo computerInfo = new messages.ComputerInfo();
        foreach (CimInstance cimObj in queryInstance)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            foreach (var pro in cimObj.CimInstanceProperties)
            {
                if(pro!= null)
                {
                    if (pro.Value != null)
                    {
                        //Warning???
                        info[pro.Name] = pro.Value.ToString();
                    }
                }
            }
            computerInfo.info.Add(info);
        }
        return computerInfo;
    }
}