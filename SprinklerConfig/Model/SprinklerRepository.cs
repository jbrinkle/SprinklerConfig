using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.Model
{
    internal interface ISprinklerRepository
    {
        IList<Controller> GetControllers();
    }

    internal class SprinklerRepository : ISprinklerRepository
    {
        private List<Controller> controllers = new List<Controller>();

        public SprinklerRepository()
        {

        }

        public IList<Controller> GetControllers()
        {
            if (controllers.Count == 0)
            {
                controllers.AddRange(GetDummyData());
            }

            return controllers;
        }

        private IList<Controller> GetDummyData()
        {
            var controllers = new List<Controller>();

            var c = new Controller { Name = "Front", Description = "Located in the garage, controlling some front zones" };
            c.Zones.AddRange(new[]
            {
                new Zone(1, "Strawberry garden"),
                new Zone(2, "Front, NW"),
                new Zone(3, "Front, SW")
            });
            controllers.Add(c);

            c = new Controller { Name = "Main", Description = "Located in the shed, controlling up to 32 zones" };
            c.Zones.AddRange(new[]
            {
                new Zone(1, "Backyard N"),
                new Zone(2, "Backyard Middle"),
                new Zone(3, "Backyard S")
            });
            controllers.Add(c);

            return controllers;
        }
    }
}
