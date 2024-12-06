using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live2d_viewer_pet.Api
{
    internal abstract class Message
    {
        required public int msg { get; set; }
        required public int msgId { get; set; }
        public override string ToString() { 
            return "[Id: "+msgId+"] ";
        }
    }
    internal class TextMessage:Message
    {
        required public TextMessageData data { get; set; }
        public override string ToString()
        {
            return base.ToString() + data.ToString();
        }
    }
}
