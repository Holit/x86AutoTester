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
        /// <summary>
        /// 全局配置文件
        /// </summary>
        public static ConfigFile configFile = new ConfigFile();
        public static ServerMain ServerMain { get => serverMain; }

        public enum TestingStates {Stopped, Running, Paused};
        /// <summary>
        /// 标识当前服务器端下发的指令
        /// </summary>
        public static TestingStates CurrentState = TestingStates.Stopped;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Will listen port 6839
            var webSocket =WebSocket.GetInstance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            serverMain = new ServerMain();
            Application.Run(serverMain);
        }
    }
}
