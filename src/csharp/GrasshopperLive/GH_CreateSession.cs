using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperLive {
    public class GH_CreateSession : GH_Component {
        public GH_CreateSession() : base("Create Session", "CreateSession", "Create " +
            "a new GrasshopperLive session.", "Live", "Live") {

        }

        public override Guid ComponentGuid {
            get {
                return new Guid("4F96C8EB-4862-454A-A3F8-33ACED66F37D");
            }
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddBooleanParameter("Activate", "A", "True = Create session", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddTextParameter("Session ID", "sID", "Session ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA) {
            bool activate = false;
            string sessionID = string.Empty;

            if(!DA.GetData(0,ref activate)) 
                ExpireSolution(false);

            if (activate == false)
                ExpireSolution(false);

            // execute create session code here


            DA.SetData(0, sessionID);
        }
    }
}
