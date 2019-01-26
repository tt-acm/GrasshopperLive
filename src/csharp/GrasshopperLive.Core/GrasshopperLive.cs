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
    public class GrasshopperLive : IDisposable
    {
        //public static readonly string ConnectAddress = "http://localhost:3000";
        public static readonly string ConnectAddress = "https://gh-live.herokuapp.com";

        public event EventHandler<GhLiveEventArgs> DataReceived;

        public string SocketId
        {
            get
            {
                return socket.Io().EngineSocket.Id;
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            try
            {
                GhLiveMessage incomingObj = Newtonsoft.Json.JsonConvert.DeserializeObject<GhLiveMessage>(message);

                if (incomingObj.Sender != _id)
                {
                    GhLiveEventArgs e = new GhLiveEventArgs();
                    e.TheObject = incomingObj;
                    var handler = this.DataReceived;

                    if (handler != null)
                    {
                        handler(this, e);
                    }
                    //Console.WriteLine(incomingObj.Message);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        public void SendDeleteUpdateMessage(Guid customId)
        {
            SendUpdateMessage(Guid.Empty, customId, null, UpdateType.Delete);
        }

        public void SendMoveUpdateMessage(Guid customId, GhLivePoint position)
        {
            SendUpdateMessage(Guid.Empty, customId, position, UpdateType.Move);
        }

        public void SendAddUpdateMessage(Guid componentId, Guid customId, GhLivePoint position)
        {

            SendUpdateMessage(componentId, customId, position, UpdateType.Add);

        }

        public void SendUpdateMessage(Guid componentId, Guid customId, GhLivePoint position, UpdateType type)
        {

            GhLiveMessage messageObj = new GhLiveMessage();
            messageObj.ComponentId = componentId;
            messageObj.CustomId = customId;
            messageObj.Point = position;
            messageObj.UpdateType = type;
            messageObj.Sender = _id;

            string stuff = Newtonsoft.Json.JsonConvert.SerializeObject(messageObj);

            socket.Emit("update", stuff);
            
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

        string _id;

        public bool Connected
        {
            get; private set;
        }

        public void Connect()
        {
            socket = IO.Socket(ConnectAddress);
            this.Connected = true;

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
                OnMessageReceived(data.ToString());

                //GhLiveMessage incomingObj = Newtonsoft.Json.JsonConvert.DeserializeObject<GhLiveMessage>(data.ToString());

                //if (incomingObj.Sender != _id)
                //{
                //    Console.WriteLine(incomingObj.Message);
                //}

                //socket.Disconnect();
            });
            //socket.Connect();           


        }

        public void Dispose()
        {
            socket.Disconnect();
            socket = null;
            //bye..
        }
    }
}
