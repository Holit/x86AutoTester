using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Threading.Tasks;

namespace Client
{
    public class WMITest
    {

        private static Dictionary<string, ManagementObjectCollection> ListViewMap = new Dictionary<string, ManagementObjectCollection>();
        /// <summary>
        /// 使用WMI穷举属性更新lvDeatil的内容
        /// </summary>
        /// <param name="path">WMI查询路径</param>
        public static async Task<ManagementObjectCollection> GetDeatils(string path)
        {
            if (!ListViewMap.ContainsKey(path))
            {
                await Task.Run(() =>
                {
                    ManagementClass managementClass = new ManagementClass(path);
                    ManagementObjectCollection moCollection = managementClass.GetInstances();
                    ListViewMap[path] = moCollection;
                    managementClass.Dispose();
                }
                );
            }
            return ListViewMap[path];
        }
    }
    public class TesterTest
    {
        public static async Task<int> startTesterAsync(Dictionary<string, string> args)
        {
            //在此处添加监测温度、风扇转速的代码
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "Tester.exe";
            string argString = "";
            foreach (var i in args)
            {
                argString += " -" + i.Key + " " + i.Value;
            }
            processInfo.Arguments = argString;
            Process pro = new Process();
            pro.EnableRaisingEvents = true;
            pro.StartInfo = processInfo;
            pro.Exited += new EventHandler((obj, arg) =>
            {
                Console.WriteLine("exit");
                Console.WriteLine(pro.ExitCode);
            });
            pro.Start();
            await Task.Run(() => pro.WaitForExit());
            return pro.ExitCode;
        }
    }
    public class DiskTest
    {
        public static async Task<Dictionary<string, int>> startDiskTestAsync()
        {
            ManagementObjectCollection query = await WMITest.GetDeatils("Win32_LogicalDisk");
            Dictionary<string, int> exitCodes = new Dictionary<string, int>();
            foreach (var i in query)
            {
                if (i["DriveType"].ToString().Equals(((int)System.IO.DriveType.Fixed).ToString()))
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = "chkdsk";
                    processInfo.Arguments = i["DeviceID"].ToString();
                    Process pro = new Process();
                    pro.EnableRaisingEvents = true;
                    pro.StartInfo = processInfo;
                    pro.Exited += new EventHandler((obj, arg) =>
                    {
                        Console.WriteLine("exit");
                        Console.WriteLine(pro.ExitCode);
                    });
                    pro.Start();
                    await Task.Run(() => pro.WaitForExit());
                    exitCodes.Add(i["DeviceID"].ToString(), pro.ExitCode);
                }
            }
            return exitCodes;
        }
    }
}
