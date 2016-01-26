using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrittercismSDK;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for EndUserflowDialog.xaml
    /// </summary>
    public partial class EndUserflowDialog : Window
    {
        // Dialog return value
        private string answer;
        public string Answer {
            get { return answer; }
        }
        public EndUserflowDialog()
        {
            InitializeComponent();
        }
        private void endUserflowClick(object sender,RoutedEventArgs e) {
            // Set dialog return value
            answer = "End Userflow";
            this.DialogResult = true;
        }
        private void failUserflowClick(object sender,RoutedEventArgs e) {
            // Set dialog return value
            answer = "Fail Userflow";
            this.DialogResult = true;
        }
        private void cancelUserflowClick(object sender,RoutedEventArgs e) {
            // Set dialog return value
            answer = "Cancel Userflow";
            this.DialogResult = true;
        }
        private void Window_Closed(object sender,EventArgs e) {
        }
    }
}
