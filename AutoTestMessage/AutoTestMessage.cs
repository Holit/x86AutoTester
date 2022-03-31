using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestMessage
{

    public class Message
    {
        public enum MessageTypes { None,ServerUuid,JoinServer }
        public MessageTypes MessageType = MessageTypes.None;
        public string Content="";
    }
}
