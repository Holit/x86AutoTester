﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Threading.Tasks;
using static AutoTestMessage.TesterMessage;

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
                ///应该改为异步操作
                await Task.Run(() =>
                {
                    ManagementClass mProcessor = new ManagementClass(path);
                    ManagementObjectCollection moCollectionProcessor = mProcessor.GetInstances();
                    mProcessor.Dispose();
                    ListViewMap[path] = moCollectionProcessor;
                }
                );
            }
            return ListViewMap[path];
        }
    }
    public class TesterTest
    {
        public static async Task<TestResult> startTesterAsync(Dictionary<string,string> args)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "Tester.exe";
            string argString = "";
            foreach(var i in args){
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
            await Task.Run(()=>pro.WaitForExit());
            return (TestResult)pro.ExitCode;
        }
    }
}