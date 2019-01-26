using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperLive
{
    /// <summary>
    /// Class to deal with communication. Send/receive messages
    /// </summary>
    public class GrasshopperLive
    {
        public static readonly string ConnectAddress = "http://localhost:3000";


        public GrasshopperLive()
        {

        }

        public void CreateSession()
        {

        }

        public void JoinSession()
        {

        }

        Socket socket;
    public void Test()
        {
            socket = IO.Socket(ConnectAddress);

            socket.On(Socket.EVENT_CONNECT, () =>
            {

                socket.Emit("chat message" ,"hi from C#");
                Console.WriteLine("Connected!");

            });

            socket.On("hi", (data) =>
            {
                Console.WriteLine(data);
                //socket.Disconnect();
            });

            //socket.Connect();           
            
            
        }
    }
}
