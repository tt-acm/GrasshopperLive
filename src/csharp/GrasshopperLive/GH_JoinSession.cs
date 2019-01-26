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
        public GH_JoinSession() :base("Join Session", "JoinSession", "Join " +
            "an existing GrasshopperLive session.", "Live", "Live")
        {
            
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

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

        }
    }
}
