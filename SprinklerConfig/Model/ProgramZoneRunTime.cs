using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.Model
{
    internal class ProgramZoneRunTime
    {
        public int ZoneID { get; set; }

        public string ZoneName { get; set; }

        public TimeSpan Runtime { get; set; }
    }
}
