using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using CrazyCalculator.View;
using CrazyCalculator.ViewModel;

namespace CrazyCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new MainWindowView
            {
                DataContext = new MainViewModel()
            };

            mw.Show();
        }
    }
}
