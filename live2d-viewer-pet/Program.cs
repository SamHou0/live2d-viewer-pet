using live2d_viewer_pet.Api;
using live2d_viewer_pet.Chat;

namespace live2d_viewer_pet
{
    internal class Program
    {
        public static Model Model { get; set; }
        static async Task Main(string[] args)
        {
            Model = new Model();
            await Model.Connect();
            Model.StartReceiveAsync();
            Talking talking = new Talking();
            await Model.SendMessageAsync("Live2d Viewer Pet Started!");
            while (true)
            {
                talking.SendRandomTalk();
                Thread.Sleep(60000);
            }
        }
    }
}
