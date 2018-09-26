using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.Model
{
    internal class Program
    {
        public string Name { get; set; }

        public List<ProgramZoneRunTime> RunTimes { get; }

        public Program()
        {
            RunTimes = new List<ProgramZoneRunTime>();
        }
    }
}
