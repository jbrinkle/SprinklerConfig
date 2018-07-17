using SprinklerConfig.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SprinklerConfig.ViewModel
{
    internal class ControllerVM : ObservableObject
    {
        private readonly Controller controller;
        private readonly ICommand zoneCountIncrement;
        private readonly ICommand zoneCountDecrement;
        private readonly ICommand zoneCountSet;

        public Controller Controller => controller;

        public ControllerVM() : this(new Controller())
        { }

        public ControllerVM(Controller model)
        {
            controller = model;

            zoneCountIncrement = new DelegateCommand(() => SetZoneCount(1, true));
            zoneCountDecrement = new DelegateCommand(() => SetZoneCount(-1, true));
            zoneCountSet = new DelegateCommand<int>(i => SetZoneCount(i, false));
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

        private ObservableCollection<Zone> zones;

        /// <summary>
        /// Gets the list of zones
        /// </summary>
        public ObservableCollection<Zone> Zones
        {
            get
            {
                if (zones == null) zones = new ObservableCollection<Zone>(controller.Zones);
                return zones;
            }
        }

        public ICommand ZoneCountIncrementCommand => zoneCountIncrement;
        public ICommand ZoneCountDecrementCommand => zoneCountDecrement;
        public ICommand ZoneCountSetCommand => zoneCountSet;

        private void SetZoneCount(int count, bool isRelative = false)
        {
            Action<int> addZone = (int id) =>
            {
                var newZ = new Zone(id, "New zone");
                controller.Zones.Add(newZ);
            };

            // make adjustments
            if (isRelative)
            {
                var nextId = Zones.Count;
                var i = 0;
                while (i != count)
                {
                    if (count > 0)
                    {
                        addZone(nextId + 1);
                        nextId++;
                        i++;
                    }
                    else
                    {
                        controller.Zones.RemoveAt(nextId - 1);
                        nextId--;
                        i--;
                    }
                }
            }
            else if (count < 1) throw new IndexOutOfRangeException("A minimum of 1 zone is required");
            else
            {
                var zonesToKeep = controller.Zones.Take(count);
                while (zonesToKeep.Count() < count)
                {
                    addZone(zonesToKeep.Count() + 1);
                }
                if (count < controller.Zones.Count) controller.Zones.RemoveRange(count, controller.Zones.Count - count);
            }

            // sync changes to VM collection
            var newzones = controller.Zones.Except(zones).ToList();
            var oldzones = zones.Except(controller.Zones).ToList();
            foreach (var z in newzones) zones.Add(z);
            foreach (var z in oldzones) zones.Remove(z);
        }
    }
}
