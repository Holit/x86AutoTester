using Newtonsoft.Json;
using System.Collections.Generic;

namespace AutoTestMessage
{
    public abstract class BaseMessage
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class WMIMessage : BaseMessage
    {
        public string path;
        public List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
    }
    public class TesterMessage : BaseMessage
    {
        public enum TestResult { SUCCESS = 0, ARGS_ERROR = -1, FAIL_PASS_TEST = -2 }
        public Dictionary<string, string> data = new Dictionary<string, string>();
    }
    public class TaskResult : BaseMessage
    {
        public string taskName;
        public string taskResult;
    }
    public class CurrentTask : BaseMessage
    {
        public string describe;
        public string task;
    }
    public class ChkdskEvent : BaseMessage
    {
        public Dictionary<string, int> result;
    }
    /// <summary>
    /// 指示CPU的信息结构
    /// </summary>
    public class CpuInfoOfTempFan : BaseMessage
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
    public class Message : BaseMessage
    {
        /// <summary>
        /// 指定消息的类型
        /// </summary>
        public enum MessageTypes
        {
            /// <summary>
            /// 无类型
            /// </summary>
            None,
            /// <summary>
            /// 获取/返回服务器UUID
            /// </summary>
            ServerUuid,
            /// <summary>
            /// 加入服务器
            /// </summary>
            JoinServer,
            /// <summary>
            /// 退出服务器
            /// </summary>
            QuitServer,
            /// <summary>
            /// 获取WMI配置数据，指定path
            /// </summary>
            WMIMessage,
            /// <summary>
            /// 指定测试端执行测试器
            /// </summary>
            TesterMessage,
            /// <summary>
            /// 获取当前任务
            /// </summary>
            CurrentTask,
            /// <summary>
            /// 获取/下发配置文件
            /// </summary>
            ConfigFile,
            /// <summary>
            /// RTC同步
            /// </summary>
            TimeSync,
            /// <summary>
            /// 播放声音
            /// </summary>
            PlayAudio,
            /// <summary>
            /// 测试串口
            /// </summary>
            SerialTest,
            /// <summary>
            /// USB写入测试
            /// </summary>
            USBWritingTest,
            /// <summary>
            /// 硬盘坏道检测
            /// </summary>
            ChkdskEvent,
            /// <summary>
            /// 测试结果
            /// </summary>
            TestResult,
            /// <summary>
            /// 任务总数
            /// </summary>
            TaskTotal,
            /// <summary>
            /// 任务结果
            /// </summary>
            TaskResult,
            /// <summary>
            /// 网口测试
            /// </summary>
            NetworkTest,
            /// <summary>
            /// 硬盘压力测试
            /// </summary>
            DiskPressure,
            /// <summary>
            /// CPU温度
            /// </summary>
            CPUTemperyture,
            /// <summary>
            /// CPU风扇
            /// </summary>
            CPUFan,
            /// <summary>
            /// 开始获取温度和风扇信息
            /// </summary>
            StartGetClientCpuInfo,
            /// <summary>
            /// 报告错误
            /// </summary>
            ReportError
        }
        public MessageTypes MessageType = MessageTypes.None;
        public string Content = "";
    }
}
