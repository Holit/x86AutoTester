using System;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        private static ClientMain clientMain = null;

        public static ClientMain ClientMain { get => clientMain;}
        public static string serverUUID;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var webSocket = WebSocket.GetInstance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clientMain=new ClientMain();
            Application.Run(clientMain);
        }
    }
}
