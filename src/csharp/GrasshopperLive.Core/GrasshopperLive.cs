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

        public void SendChatMessage(string message)
        {
            GhLiveMessage messageObj = new GhLiveMessage();
            messageObj.Sender = _id;
            messageObj.Message = message;

            string stuff = Newtonsoft.Json.JsonConvert.SerializeObject(messageObj);

            socket.Emit("chat message", stuff);
        }

        Socket socket;


        public class GhLiveMessage
        {
            public string Sender { get; set; }
            public string Message { get; set; }
        }

        string _id;
        public void Test()
        {
            socket = IO.Socket(ConnectAddress);

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                _id = socket.Io().EngineSocket.Id;
                //socket.Emit("chat message" , "hi from C#");
                Console.WriteLine("Connected!");

            });

            socket.On("hi", (data) =>
            {
                Console.WriteLine(data);
                //socket.Disconnect();
            });

            socket.On("chat message", (data) =>
            {
                GhLiveMessage incomingObj = Newtonsoft.Json.JsonConvert.DeserializeObject<GhLiveMessage>(data.ToString());

                if (incomingObj.Sender != _id)
                {
                    Console.WriteLine(incomingObj.Message);
                }

                //socket.Disconnect();
            });
            //socket.Connect();           


        }
    }
}
