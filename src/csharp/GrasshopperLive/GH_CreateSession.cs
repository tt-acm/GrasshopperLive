using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperLive
{
    public class GH_CreateSession : GH_Component
    {
        public GH_CreateSession() :base("Create Session", "CreateSession", "Create " +
            "a new GrasshopperLive session.", "Live", "Live")
        {

        }

        public override Guid ComponentGuid
        {
            get
            {
                return new Guid("4F96C8EB-4862-454A-A3F8-33ACED66F37D");
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
