using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.Model
{
    internal class Zone
    {
        public int ID { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Zone(int id, string name = null, string description = null)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
