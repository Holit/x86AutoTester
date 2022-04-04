using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal static class Program
    {
        public static readonly string Uuid = Guid.NewGuid().ToString();
        private static ServerMain serverMain = null;

        public static ServerMain ServerMain { get => serverMain; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Will listen port 6839
            //Incorrect debugging result:
            /*
             * 引发的异常:“System.Net.Sockets.SocketException”(位于 System.dll 中)
             * 引发的异常:“System.TypeInitializationException”(位于 Server.exe 中)
             * “System.TypeInitializationException”类型的未经处理的异常在 Server.exe 中发生 
             * “Server.WebSocket”的类型初始值设定项引发异常。
             */
            var webSocket =WebSocket.GetInstance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            serverMain = new ServerMain();
            Application.Run(serverMain);
        }
    }
}
