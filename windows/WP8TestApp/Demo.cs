using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Windows.UI.Core;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CrittercismSDK;

namespace WP8TestApp {
    class Demo {
        // Crittercism userflow name for this Crittercism demo.
        public static string userflowName = null;

        internal static void UserflowTimeOutHandler(Page page,EventArgs e) {
            // Userflow timed out.
            page.Dispatcher.BeginInvoke(new Action(() => {
                // This page is being shown?
                Frame frame = page.Parent as Frame;
                bool shown = ((frame != null) && (frame.Content == page));
                if (shown) {
                    // Show userflow "Timed Out" dialog.
                    UserflowTimeOutShowMessage(e);
                }
                if (page is CrashSim) {
                    // Change label of userflowButton back to "Begin Userflow".
                    CrashSim sectionPage = (CrashSim)page;
                    sectionPage.userflowButton.Content = "Begin Userflow";
                } else if (page is EndUserflow) {
                    if (shown) {
                        // We've found ourselves currently on the "End Userflow" Page .
                        EndUserflow sectionPage = (EndUserflow)page;
                        sectionPage.GoBack();
                    }
                };
            }));
        }
        private static void UserflowTimeOutShowMessage(EventArgs e) {
            // Show MessageBox routine for caller UserflowTimeOutHandler
            string name = ((CRUserflowEventArgs)e).Name;
            string message = String.Format("Userflow '{0}'\r\nTimed Out",name);
            Debug.WriteLine(message);
            MessageBox.Show(message,"WP8TestApp",MessageBoxButton.OK);
            userflowName = null;
        }
    }
}
