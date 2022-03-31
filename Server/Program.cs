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
            var webSocket=WebSocket.GetInstance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            serverMain = new ServerMain();
            Application.Run(serverMain);
        }
    }
}
