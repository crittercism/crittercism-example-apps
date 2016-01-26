using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using CrittercismSDK;

namespace WP8TestApp {
    public partial class End : PhoneApplicationPage {
        public End() {
            InitializeComponent();
            Crittercism.UserflowTimeOut += UserflowTimeOutHandler;
        }

        private void Hyperlink_Click(object sender,RoutedEventArgs e) {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://docs.crittercism.com/windows/windows.html");
            webBrowserTask.Show();
        }

        private void UserflowTimeOutHandler(object sender,EventArgs e) {
            Demo.UserflowTimeOutHandler(this,e);
        }
    }
}