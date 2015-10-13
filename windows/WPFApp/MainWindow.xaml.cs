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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void setUsernameClick(object sender,RoutedEventArgs e) {
            Random random=new Random();
            string[] names= { "Blue Jay","Chinchilla","Chipmunk","Gerbil","Hamster","Parrot","Robin","Squirrel","Turtle" };
            string name=names[random.Next(0,names.Length)];
            Crittercism.SetUsername("Critter "+name);
        }

        private void leaveBreadcrumbClick(object sender,RoutedEventArgs e) {
            Random random=new Random();
            string[] names= { "Breadcrumb","Strawberry","Seed","Grape","Lettuce" };
            string name=names[random.Next(0,names.Length)];
            Crittercism.LeaveBreadcrumb(name);
        }

        private void handledExceptionClick(object sender,RoutedEventArgs e) {
            try {
                ThrowException();
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }
        }
        
        private void handledUnthrownExceptionClick(object sender,RoutedEventArgs e) {
            Exception exception=new Exception("description");
            exception.Data.Add("MethodName","methodName");
            Crittercism.LogHandledException(exception);
        }

        private void testCrashClick(object sender,RoutedEventArgs e) {
            ThrowException();
        }

        private void DeepError(int n) {
            if (n==0) {
                throw new Exception("Deep Inner Exception");
            } else {
                DeepError(n-1);
            }
        }

        private void ThrowException() {
            try {
                DeepError(4);
            } catch (Exception ie) {
                throw new Exception("Outer Exception",ie);
            }
        }

        private void testNewWindowClick(object sender,RoutedEventArgs e) {
            (new MainWindow()).Show();
        }

        private void critterClick(object sender,RoutedEventArgs e) {
            string username=Crittercism.Username();
            if (username==null) {
                username="User";
            }
            string response="";
            MessageBoxResult result=MessageBox.Show("Do you love Crittercism?","WPFApp",MessageBoxButton.YesNo);
            switch (result) {
                case MessageBoxResult.Yes:
                    response="loves Crittercism.";
                    break;
                case MessageBoxResult.No:
                    response="doesn't love Crittercism.";
                    break;
            }
            Crittercism.LeaveBreadcrumb(username+" "+response);
        }

        private void Window_Closed(object sender,EventArgs e) {
            Crittercism.LeaveBreadcrumb("Closed");
            if (Application.Current.Windows.Count==0) {
                // Last window is closing.
                Crittercism.Shutdown();
                Application.Current.Shutdown();
            }
        }
    }
}
