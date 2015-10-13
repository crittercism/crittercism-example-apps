using CrittercismSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP8TestApp
{
    public partial class Loads : PhoneApplicationPage
    {
        public Loads()
        {
            InitializeComponent();
        }

        private void backButtonClick(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/CrashSim.xaml", UriKind.Relative));
        }

        private void nextButtonClick(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/End.xaml", UriKind.Relative));
        }
    }
}