using System;
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

        public enum TestingStates { Stopped, Running, Paused };
        /// <summary>
        /// 标识当前服务器端下发的指令
        /// </summary>
        public static TestingStates CurrentState = TestingStates.Stopped;

        /// <summary>
        /// 产生错误提示框
        /// </summary>
        /// <param name="exception">发生的具体错误</param>
        /// <param name="isQuit">是否退出程序</param>
        /// <param name="ErrorCode">错误的错误码</param>
        public static void ReportError(Exception exception, bool isQuit, uint ErrorCode,string Title = "发生异常",bool ShowStackTrace = true)
        {
            DialogResult res =  MessageBox.Show(ServerMain,
                exception.Message + "\n-------\n" +
                (ShowStackTrace == true ?  exception.StackTrace : "") + "\n-------\n错误代码：0x"  +
                ErrorCode.ToString("X8"),
                Title,
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Abort)
            {
                Environment.Exit((int)ErrorCode);
            }
            if (isQuit)
            {
                //在此处添加错误恢复代码
                Environment.Exit((int)ErrorCode);
            }
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\AutoTestMessage.dll") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\Fleck.dll") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\Newtonsoft.Json.dll")
                   )
                {
                    throw new System.DllNotFoundException("未发现合法的依赖文件");
                }
                if(!System.IO.File.Exists(Environment.CurrentDirectory + @"\Newtonsoft.Json.xml"))
                {
                    throw new System.IO.FileNotFoundException("配置支持文件“Newtonsoft.Json.xml”未找到");
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                var webSocket = WebSocket.GetInstance;

                serverMain = new ServerMain();
                Application.Run(serverMain);
            }
            catch (Exception ex)
            {
                ReportError(ex, true, 0x00000000,ShowStackTrace:true,Title:"初始化失败");
            }
        }
    }
}
