using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFc_fw
{
    internal class Message
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Message(string content)
        {
            Content = content;
            Date = DateTime.Now;
        }
    }
}