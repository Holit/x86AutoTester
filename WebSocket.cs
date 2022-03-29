using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class WebSocket
    {
        private WebSocket() {
            _ = GetServerIP();
        }
        private async Task GetServerIP() {
            await Task.Run(() =>
            {
                UdpClient udpClient = new UdpClient(6839);
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine(returnData);
                    Console.WriteLine(RemoteIpEndPoint);
                }
            }
            );
            return;
        }
        private static WebSocket webSocket = null;
        private static object webSocket_Lock = new object();
        public static WebSocket GetInstance()
        {
            lock (webSocket_Lock)
            {
                if (webSocket == null)
                {
                    webSocket = new WebSocket();
                }
            }
            return webSocket;
        }
    }
}
