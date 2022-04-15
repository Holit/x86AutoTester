using AutoTestMessage;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        private static ClientMain clientMain = null;

        public static ClientMain ClientMain { get => clientMain; }
        public static string serverUUID;

        /// <summary>
        /// 产生错误提示框
        /// </summary>
        /// <param name="exception">发生的具体错误</param>
        /// <param name="isQuit">是否退出程序</param>
        /// <param name="ErrorCode">错误的错误码</param>
        public static void ReportError(Exception exception, 
            bool isQuit, 
            uint ErrorCode, 
            string Title = "发生异常", 
            bool ShowStackTrace = true,
            string AdditionalInformation = "")
        {
            DialogResult res = MessageBox.Show(ClientMain,
                exception.Message + "\n-------\n" +
                (ShowStackTrace == true ? exception.StackTrace : "") + "\n-------\n错误代码：0x" +
                ErrorCode.ToString("X8") + "\n" + AdditionalInformation,
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
        /// 获取当前计算机CPU的温度
        /// </summary>
        /// <returns>包含当前计算机所有处理器温度的有序结构列表。为空代表当前不支持获取温度</returns>
        public static List<CpuInfoOfTempFan> GetCurrentCPUTemperature()
        {
            //执行注册
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            //执行实例
            computer.Open();
            //获取CPU的数据，同样的，也可以获取显卡的数据
            computer.CPUEnabled = true;
            //调用遍历函数，执行遍历获取所有硬件
            computer.Accept(updateVisitor);
            List<CpuInfoOfTempFan> result = new List<CpuInfoOfTempFan>();
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            CpuInfoOfTempFan info = new CpuInfoOfTempFan();
                            info.Max = computer.Hardware[i].Sensors[j].Max;
                            info.Value = computer.Hardware[i].Sensors[j].Value;
                            info.Min = computer.Hardware[i].Sensors[j].Min;
                            info.Name = computer.Hardware[i].Sensors[j].Name;
                            info.HardwareIdentifier = computer.Hardware[i].Sensors[j].Hardware.Name;
                            result.Add(info);
                        }
                    }
                }
            }
            computer.Close();
            return result;
        }
        /// <summary>
        /// 获取当前计算机CPU风扇转速
        /// </summary>
        /// <returns>包含当前计算机所有处理器风扇转速的有序结构列表。为空代表当前不支持获取风扇转速</returns>
        public static List<CpuInfoOfTempFan> GetCurrentCPUFanSpeed()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.Accept(updateVisitor);
            List<CpuInfoOfTempFan> result = new List<CpuInfoOfTempFan>();
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Fan)
                        {
                            CpuInfoOfTempFan info = new CpuInfoOfTempFan();
                            info.Max = computer.Hardware[i].Sensors[j].Max;
                            info.Value = computer.Hardware[i].Sensors[j].Value;
                            info.Min = computer.Hardware[i].Sensors[j].Min;
                            info.Name = computer.Hardware[i].Sensors[j].Name;
                            info.HardwareIdentifier = computer.Hardware[i].Sensors[j].Hardware.Name;
                            result.Add(info);
                        }
                    }
                }
            }
            computer.Close();
            return result;
        }

        /// <summary>
        /// 16进制编码
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            if (
                args.Length == 1 && args[0] == "INSTALLER")
            {
                Process.Start(Application.ExecutablePath);
                return;
            }
            try
            {
                if (
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\AutoTestMessage.dll") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\Tester.exe") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\Fleck.dll") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\diskspd.exe") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\OpenHardwareMonitorLib.dll") ||
                    !System.IO.File.Exists(Environment.CurrentDirectory + @"\Newtonsoft.Json.dll")
                   )
                {
                    throw new System.DllNotFoundException("未发现合法的依赖文件");
                }
                if (!System.IO.File.Exists(Environment.CurrentDirectory + @"\Newtonsoft.Json.xml"))
                {
                    throw new System.IO.FileNotFoundException("配置支持文件“Newtonsoft.Json.xml”未找到");
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var webSocket = WebSocket.GetInstance;

                clientMain = new ClientMain();
                Application.Run(clientMain);
            }
            catch (Exception ex)
            {
                ReportError(ex, true, 0x00000000, ShowStackTrace: true, Title: "初始化失败");
            }
        }
    }
}
