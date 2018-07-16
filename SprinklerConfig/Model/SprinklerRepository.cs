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
                controllers.AddRange(new List<Controller>
                {
                    new Controller { Name = "Front", Description = "Located in the garage, controlling some front zones" },
                    new Controller { Name = "Main", Description = "Located in the shed, controlling up to 32 zones" }
                });
            }

            return controllers;
        }
    }
}
