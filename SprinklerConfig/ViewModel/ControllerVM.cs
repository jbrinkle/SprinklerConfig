using SprinklerConfig.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.ViewModel
{
    internal class ControllerVM : ObservableObject
    {
        private readonly Controller controller;

        public Controller Controller => controller;

        public ControllerVM()
        {
            controller = new Controller();
        }

        public ControllerVM(Controller model)
        {
            controller = model;
        }

        /// <summary>
        /// Gets or sets the name of the controller
        /// </summary>
        public string Name
        {
            get => controller.Name;
            set
            {
                if (controller.Name != value)
                {
                    controller.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the description of the controller
        /// </summary>
        public string Description
        {
            get => controller.Description;
            set
            {
                if (controller.Description != value)
                {
                    controller.Description = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
