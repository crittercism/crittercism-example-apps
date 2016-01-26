using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CrittercismSDK;
using WPFApp;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // The currently begun Crittercism userflow, if any.
        internal static string userflowName = null;

        #region Events
        public static event EventHandler UserflowEvent;
        #endregion

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //// Call the Init of the unhandled managed class library "Crittercism"
            Crittercism.Init("YOUR APP ID GOES HERE");
            //CRFilter filter=CRFilter.FilterWithString("doYouLoveCrittercism");
            //Crittercism.AddFilter(filter);
            Crittercism.LeaveBreadcrumb("Application_Startup");
            Crittercism.UserflowTimeOut += UserflowTimeOutHandler;
        }

        private void UserflowTimeOutHandler(object sender,EventArgs e) {
            Debug.WriteLine("The userflow timed out.");
            // Execute this Action on the main UI thread.
            Dispatcher.Invoke(new Action(() => {
                // Alert user with a MessageBox that the transaction timed out.
                string name = ((CRUserflowEventArgs)e).Name;
                string message = String.Format("'{0}' Timed Out",name);
                MessageBox.Show(message,"WPFApp",MessageBoxButton.OK);
                // No more Crittercism userflow in progress.
                userflowName = null;
                // Broadcast UserflowEvent to all our open windows.
                OnUserflowEvent(e);
            }));
        }

        internal static void OnUserflowEvent(EventArgs e) {
            EventHandler handler = UserflowEvent;
            if (handler != null) {
                handler(null,e);
            }
        }
    }
}
