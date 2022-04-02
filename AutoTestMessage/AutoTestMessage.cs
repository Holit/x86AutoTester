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
    public class Message : BaseMessage
    {
        public enum MessageTypes { None, ServerUuid, JoinServer, WMIMessage, TesterMessage, CurrentTask }
        public MessageTypes MessageType = MessageTypes.None;
        public string Content = "";
    }
}
