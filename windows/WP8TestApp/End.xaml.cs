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
    public partial class End : PhoneApplicationPage {
        public End() {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}