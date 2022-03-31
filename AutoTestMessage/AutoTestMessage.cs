using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class Message:BaseMessage
    {
        public enum MessageTypes { None,ServerUuid,JoinServer,WMIMessage }
        public MessageTypes MessageType = MessageTypes.None;
        public string Content="";
    }
}
