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
    internal class ProgramVM : ObservableObject
    {
        private readonly Program program;
        private ObservableCollection<ProgramZoneRunTime> runtimes;
        private int selectedRunTimeIndex;

        /// <summary>
        /// Gets the underlying controller model
        /// </summary>
        public Program Program => program;

        /// <summary>
        /// Gets or sets the name of the controller
        /// </summary>
        public string Name
        {
            get => program.Name;
            set
            {
                if (program.Name != value)
                {
                    program.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets the list of zones
        /// </summary>
        public ObservableCollection<ProgramZoneRunTime> RunTimes
        {
            get
            {
                if (runtimes == null) runtimes = new ObservableCollection<ProgramZoneRunTime>(program.RunTimes);
                return runtimes;
            }
        }
        
        /// <summary>
        /// Get or Set the current selected index of controller view models
        /// </summary>
        public int SelectedRunTimeIndex
        {
            get => selectedRunTimeIndex;
            set
            {
                if (value < -1 || value >= runtimes.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                selectedRunTimeIndex = value;

                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(SelectedZone));
            }
        }

        /// <summary>
        /// Gets the currently selected controller view model
        /// </summary>
        public ProgramZoneRunTime SelectedZone => selectedRunTimeIndex >= 0 ? RunTimes[selectedRunTimeIndex] : null;

        public ProgramVM() : this(new Program())
        { }

        public ProgramVM(Program model)
        {
            program = model;
        }
    }
}
