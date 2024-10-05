using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class Message
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
