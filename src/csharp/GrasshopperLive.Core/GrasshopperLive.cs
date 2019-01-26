using SocketIOClient;
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

        private Client socket;

        public void Test()
        {
            socket = new Client("http://localhost:3000"); // url to nodejs 
            socket.Opened += SocketOpened;
            socket.Message += SocketMessage;
            socket.SocketConnectionClosed += SocketConnectionClosed;
            socket.Error += SocketError;


            // register for 'connect' event with io server
            //socket.Connect();
            //return;

            socket.On("connect", (fn) =>
            {

                // emit Json Serializable object, anonymous types, or strings
                //string newPart = "some data";
                //Part newPart = new Part()
                //{ PartNumber = "K4P2G324EC", Code = "DDR2", Level = 1 };
                Console.WriteLine("Connected");
                //socket.Emit("partInfo", newPart);
            });

            // register for 'update' events - message is a json 'Part' object
            socket.On("update", (data) =>
            {
                Console.WriteLine("Update");
                //Console.WriteLine("recv [socket].[update] event");
                //Console.WriteLine("  raw message:      {0}", data.RawMessage);
                //Console.WriteLine("  string message:   {0}", data.MessageText);
                //Console.WriteLine("  json data string: {0}", data.Json.ToJsonString());
                //Console.WriteLine("  json raw:         {0}", data.Json.Args[0]);

                // cast message as Part - use type cast helper
                //Part part = data.Json.GetFirstArgAs<Part>();
                //Console.WriteLine(" Part Level:   {0}\r\n", part.Level);
            });

            // make the socket.io connection
            socket.Connect();

        }

        private void SocketError(object sender, ErrorEventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine(string.Format("{0}: {1}:", nameof(SocketError),
                e.Message));
        }

        private void SocketConnectionClosed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine(nameof(SocketConnectionClosed));
        }

        private void SocketMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(nameof(SocketMessage));
            //throw new NotImplementedException();
        }

        private void SocketOpened(object sender, EventArgs e)
        {
            Console.WriteLine(nameof(SocketOpened));
            //throw new NotImplementedException();
        }
    }
}
