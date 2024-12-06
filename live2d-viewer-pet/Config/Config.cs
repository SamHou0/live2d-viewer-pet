using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live2d_viewer_pet.Config
{
    internal class Config
    {
        /// <summary>
        /// All the data is stored at this path.
        /// </summary>
        public static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory + "\\data";
        public static readonly string TalkFilePath = BasePath + "\\talk.txt";
        public static readonly string ConfigPath = 
            BasePath+"\\config.ini";
        internal Config() {

        }
    }
}
