using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using CrittercismSDK;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;

namespace WP8TestApp {
    public partial class EndUserflow : PhoneApplicationPage {
        public EndUserflow() {
            InitializeComponent();
            Crittercism.UserflowTimeOut += UserflowTimeOutHandler;
        }

        private void endUserflowClick(object sender,RoutedEventArgs e)
        {
            Crittercism.EndUserflow(Demo.userflowName);
            Demo.userflowName = null;
            GoBack();
        }

        private void failUserflowClick(object sender,RoutedEventArgs e) {
            Crittercism.FailUserflow(Demo.userflowName);
            Demo.userflowName = null;
            GoBack();
        }

        private void cancelUserflowClick(object sender,RoutedEventArgs e)
        {
            Crittercism.CancelUserflow(Demo.userflowName);
            Demo.userflowName = null;
            GoBack();
        }

        internal void GoBack() {
            Frame frame = Parent as Frame;
            frame.GoBack();
        }

        private void UserflowTimeOutHandler(object sender,EventArgs e) {
            Demo.UserflowTimeOutHandler(this,e);
        }
    }
}
