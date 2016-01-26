using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrittercismSDK;

namespace WindowsFormsApp {
    static class Program {
        // The currently begun Crittercism userflow, if any.
        internal static string userflowName = null;

        #region Events
        public static event EventHandler UserflowEvent;
        #endregion
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Crittercism.Init("YOUR APP ID GOES HERE");
            (new MainWindow()).Show();
            Application.Run();
        }

        private static void UserflowTimeOutHandler(object sender,EventArgs e) {
            Debug.WriteLine("The userflow timed out.");
            // Execute this Action on the main UI thread.
            Application.OpenForms[0].Invoke((MethodInvoker)delegate {
                // Alert user with a MessageBox that the transaction timed out.
                string name = ((CRUserflowEventArgs)e).Name;
                string message = String.Format("'{0}' Timed Out",name);
                MessageBox.Show(message,"WindowsFormsApp",MessageBoxButtons.OK);
                // No more Crittercism userflow in progress.
                userflowName = null;
                // Broadcast UserflowEvent to all our open windows.
                OnUserflowEvent(e);
            });
        }

        internal static void OnUserflowEvent(EventArgs e) {
            EventHandler handler = UserflowEvent;
            if (handler != null) {
                handler(null,e);
            }
        }
    }
}
