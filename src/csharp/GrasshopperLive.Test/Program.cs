using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperLive.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GrasshopperLive ghlive = new GrasshopperLive();
            ghlive.DataReceived += Ghlive_DataReceived;

            ghlive.Connect();

            while (true)
            {
                string message = Console.ReadLine();
                ghlive.SendChatMessage(message);
            }
            

        }

        private static void Ghlive_DataReceived(object sender, GhLiveEventArgs e)
        {
            Console.WriteLine(e.TheObject.Message);
        }
    }
}
