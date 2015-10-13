using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP8TestApp {
    public partial class Customers : PhoneApplicationPage {
        public Customers() {
            InitializeComponent();
        }

        private void backButtonClicked(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void nextButtonClicked(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/Crashes.xaml", UriKind.Relative));
        }


    }
}