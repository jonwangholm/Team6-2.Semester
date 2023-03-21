using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }

        public int ReportId { get; set; }

        public Message(string content, DateTime sendTime)
        {
            Content = content;
            SendTime = sendTime;
        }
    }
}
