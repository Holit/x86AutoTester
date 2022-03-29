using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;

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
            List<IPAddress> iPAddresses = new List<IPAddress>();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    bool isLocal = false;
                    IPInterfaceProperties ip = adapter.GetIPProperties();
                    UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                    foreach (UnicastIPAddressInformation ipadd in ipCollection)
                    {
                        if(ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
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
                            iPAddresses.Add(ipadd.Address);
                        }
                    }
                }
            }

            UdpClient udpClient = new UdpClient();
            List<IPEndPoint> iPEndPoints = new List<IPEndPoint>(iPAddresses.Select(t => new IPEndPoint(t, 6839)));
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody thereA?");
            await Task.Run(() =>
            {
                while (true)
                {
                    iPEndPoints.ForEach(t => udpClient.Send(sendBytes, sendBytes.Length, t));
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