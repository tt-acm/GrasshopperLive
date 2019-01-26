using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasshopperLive
{
    /// <summary>
    /// Update message which could be either add, delete or move.
    /// </summary>
    public class GhLiveMessage
    {
        /// <summary>
        /// Custom Id defined by us..
        /// </summary>
        public Guid CustomId { get; set; }

        /// <summary>
        /// Corresponds to the CLASS (not the instance!)
        /// </summary>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Defines: 1. added location or updated location
        /// </summary>
        public GhLivePoint Point { get; set; }

        /// <summary>
        /// Type of update..
        /// </summary>
        public UpdateType UpdateType { get; set; }

        /// <summary>
        /// Sender Id
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Extra message 
        /// </summary>
        public string Message { get; set; }
    }
}
