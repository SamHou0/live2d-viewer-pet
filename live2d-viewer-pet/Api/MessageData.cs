using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live2d_viewer_pet.Api
{
    /// <summary>
    /// Construct Data on sending pop-up messages.
    /// </summary>
    internal class TextMessageData
    {
        public int id { get; set; } = 0;
        required public string text { get; set; }
        /// <summary>
        /// Provide buttons for choosing. Nothing will return if this is empty.
        /// </summary>
        required public string[] choices { get; set; }
        public int textFrameColor { get; set; } = 0x000000;
        public int textColor { get; set; } = 0xFFFFF;
        public int duration { get; set; } = 5000;
        public override string ToString()
        {
            return "Text: "+text+" Choices: "+choices;
        }
    }
    /// <summary>
    /// Data class for return of choices.
    /// </summary>
    internal class ReturnMessageData
    {
            public int msg { get; set; }
            public int msgId { get; set; }
            public int data { get; set; }

    }
}
