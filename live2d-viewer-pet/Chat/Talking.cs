using live2d_viewer_pet.Api;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace live2d_viewer_pet.Chat
{
    internal class Talking
    {
        string[] talks;
        public Talking() {
            talks=File.ReadAllLines(Config.Config.TalkFilePath);
        }
        public async void SendRandomTalk()
        {
            Random random = new Random();
            int index= random.Next(talks.Length);
            await Program.Model.SendMessageAsync(talks[index]);
        }
    }
}
