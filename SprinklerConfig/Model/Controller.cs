using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.Model
{
    internal class Controller
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Zone> Zones { get; }

        public List<Program> Programs { get; }

        public Controller()
        {
            Zones = new List<Zone>();
            Programs = new List<Program>();
        }
    }
}
