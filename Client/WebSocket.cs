using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class WebSocket
    {
        private WebSocket()
        {
            _ = GetServer();
        }
        private async Task GetServer()
        {
            await Task.Run(() =>
            {
                UdpClient udpClient = new UdpClient(6839);
                while (true)
                {
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] recData = udpClient.Receive(ref endpoint);
                    string returnData = Encoding.ASCII.GetString(recData);
                    Console.WriteLine(returnData);
                    Console.WriteLine(endpoint.Address);
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
    }
}