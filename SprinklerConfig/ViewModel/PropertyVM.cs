using SprinklerConfig.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerConfig.ViewModel
{
    internal class PropertyVM : ObservableObject
    {
        private readonly ISprinklerRepository sprinklerRepo;
        private readonly ObservableCollection<ControllerVM> controllers;
        private int selectedIndex = -1;

        /// <summary>
        /// Gets an observable collection of Controller view models
        /// </summary>
        public ObservableCollection<ControllerVM> Controllers => controllers;

        /// <summary>
        /// Get or Set the current selected index of controller view models
        /// </summary>
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value < -1 || value >= controllers.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                selectedIndex = value;

                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(SelectedController));
            }
        }

        /// <summary>
        /// Gets the currently selected controller view model
        /// </summary>
        public ControllerVM SelectedController => selectedIndex >= 0 ? Controllers[selectedIndex] : null;

        public PropertyVM(ISprinklerRepository repository)
        {
            sprinklerRepo = repository;

            controllers = new ObservableCollection<ControllerVM>();

            foreach (var controller in sprinklerRepo.GetControllers())
            {
                controllers.Add(new ControllerVM(controller));
            }
        }
    }
}
