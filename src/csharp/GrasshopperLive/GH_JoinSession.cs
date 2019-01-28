using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperLive
{
    public class GH_JoinSession : GH_Component
    {
        //private static GrasshopperLive ghLive;
        //internal static GH_JoinSession Application;
        GrasshopperLive ghLive;

        public GH_JoinSession() : base("Join Session", "JoinSession", "Join " +
            "an existing GrasshopperLive session.", "Live", "Live")
        {
            //Application = this;
            //if (ghLive == null) {
            //    ghLive = new GrasshopperLive();
            //    ghLive.DataReceived += GhLive_DataReceived;
            //}
            ghLive = GrasshopperLive.Instance;
        }

        private void GhLive_DataReceived(object sender, GhLiveEventArgs e)
        {

            _messageLog.Add(e.TheObject.Message);
            //Grasshopper.Instances.DocumentEditor. //BeginInvoke(new Action(() => { GH_JoinSession.Application.ExpireSolution(true); }));
            //GH_JoinSession.Application.ExpireSolution(true);
        }

        public override Guid ComponentGuid
        {
            get
            {
                return new Guid("F1B0B8D3-1F30-4BC2-9108-9115977B9558");
            }
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            //TODO:
            //pManager.AddTextParameter("Session ID", "sID", "Session ID", GH_ParamAccess.item, "");
            //pManager.AddTextParameter("Message", "M", "Message", GH_ParamAccess.item, "");
            pManager.AddBooleanParameter("Connect", "C", "True to connect.", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Status", "S", "Status of connection.", GH_ParamAccess.item);
            //pManager.AddTextParameter("Connection", "C", "True = Connection established | False = No Connection", GH_ParamAccess.item);
        }

        List<string> _messageLog = new List<string>();

        public void SetupConnection()
        {
            ghLive.DataReceived += GhLive_DataReceived;
            ghLive.Connect();
        }

        //bool once = false;
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool connect = false;
            if (!DA.GetData(0, ref connect))
            {
                //ExpireSolution(false);
            }

            if (connect)
            {
                SetupConnection();
            }
            
            /*
            string sesssionID = string.Empty;
            string message = string.Empty;

            if (!DA.GetData(0, ref sesssionID)) {
                message = "Could not read session ID";
                DA.SetData(0, message);
                ExpireSolution(false);
            }

            // execute connection code
            */
            //DA.SetDataList(0, _messageLog);
            //this.Locked = true;
        }

    }
}
