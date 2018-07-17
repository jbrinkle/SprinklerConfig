using SprinklerConfig.Model;
using SprinklerConfig.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SprinklerConfig
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //StartupUri = new Uri("/SprinklerConfig;component/MainWindow.xaml", UriKind.Relative);
            var sprinklerRepository = new SprinklerRepository();
            var propertyVM = new PropertyVM(sprinklerRepository);

            var w = new MainWindow(propertyVM);
            //var w = new TestWindow(propertyVM);
            w.Show();
        }
    }
}
