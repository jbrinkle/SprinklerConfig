using SprinklerConfig.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SprinklerConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PropertyVM propertyVM;

        internal MainWindow(PropertyVM property)
        {
            InitializeComponent();

            propertyVM = property;
            propertyVM.SelectedIndex = 0;
            propertyVM.SelectedController.SelectedZoneIndex = 0;
            DataContext = propertyVM;
        }
    }
}
