﻿using SprinklerConfig.ViewModel;
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
using System.Windows.Shapes;

namespace SprinklerConfig
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow(object dataContext)
        {
            InitializeComponent();

            this.DataContext = dataContext;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var vm = ((PropertyVM)DataContext).SelectedController;

            vm?.ZoneCountSet.Execute(int.Parse(ZoneCount.Text));
        }
    }
}
