using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        private static ClientMain clientMain = null;

        public static ClientMain ClientMain { get => clientMain; }
        public static string serverUUID;
        /// <summary>
        /// 指示CPU的信息结构
        /// </summary>
        public struct CpuInfoOfTempFan
        {

            public float? Max;
            public float? Min;
            //当前温度，可以为空
            public float? Value;
            //当前CPU的名称，例如i9 12500K
            public string HardwareIdentifier;
            //当前CPU的索引名称，例如CPU#1，其中编号为die的序号。其中CPU Package代表整块CPU的温度
            public string Name;
        };
        /// <summary>
        /// 获取当前计算机CPU的温度
        /// </summary>
        /// <returns>包含当前计算机所有处理器温度的有序结构列表。为空代表当前不支持获取温度</returns>
        public static List<CpuInfoOfTempFan?> GetCurrentCPUTemperature()
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
            List<CpuInfoOfTempFan?> result = new List<CpuInfoOfTempFan?>();
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
        public static List<CpuInfoOfTempFan?> GetCurrentCPUFanSpeed()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.Accept(updateVisitor);
            List<CpuInfoOfTempFan?> result = new List<CpuInfoOfTempFan?>();
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
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var webSocket = WebSocket.GetInstance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clientMain = new ClientMain();
            Application.Run(clientMain);
        }
    }
}
