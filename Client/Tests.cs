using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
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
}
