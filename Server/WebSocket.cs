using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class WebSocket
    {
        private WebSocket()
        {
            _ = BoardServer();
        }
        private async Task BoardServer()
        {
            UdpClient udpClient = new UdpClient();
            await Task.Run(() =>
            {
                while (true)
                {
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 6839);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody thereA?");
                    udpClient.Send(sendBytes, sendBytes.Length, endpoint);
                }
            });
            udpClient.Close();
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