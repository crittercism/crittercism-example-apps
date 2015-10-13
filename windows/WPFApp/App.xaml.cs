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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //// Call the Init of the unhandled managed class library "Crittercism"
            Crittercism.Init("YOUR APP ID GOES HERE");
            //CRFilter filter=CRFilter.FilterWithString("doYouLoveCrittercism");
            //Crittercism.AddFilter(filter);
            Crittercism.LeaveBreadcrumb("Application_Startup");
        }
    }
}
