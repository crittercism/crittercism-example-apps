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
    public partial class CrashSim : PhoneApplicationPage {
        private static Random random = new Random();

        public CrashSim() {
            InitializeComponent();
            Crittercism.UserflowTimeOut += UserflowTimeOutHandler;
        }

        private void setUsernameClick(object sender,RoutedEventArgs e) {
            Random random = new Random();
            string[] names = { "Blue Jay","Chinchilla","Chipmunk","Gerbil","Hamster","Parrot","Robin","Squirrel","Turtle" };
            string name = names[random.Next(0,names.Length)];
            Crittercism.SetUsername("Critter " + name);
        }

        private void leaveBreadcrumbClick(object sender,RoutedEventArgs e) {
            Random random = new Random();
            string[] names = { "Breadcrumb","Strawberry","Seed","Grape","Lettuce" };
            string name = names[random.Next(0,names.Length)];
            Crittercism.LeaveBreadcrumb(name);
        }

        private static string[] urls = new string[] {
            "http://www.mrscritter.com",
            "http://www.babycritter.com",
            "http://www.faithfulcritter.com",
            "http://www.nextdoorcritter.com",
            "http://www.karokecritter.com",
            "http://www.yogacritter.com",
            "http://www.secretagentcritter.com",
            "http://www.critterwebservice.com",
            "http://www.crittersearchengine.com",
            "http://www.critterdatingservice.com",
            "http://www.crittergourmetfood.com",
            "http://www.critterworldnews.com",
            "http://www.crittermoviereviews.com",
            "http://www.critterburrowdecor.com"
        };
        private static string[] urlPaths = new string[] {
            "",
            "",
            "/?ilove=critters",
            "/nutlovers",
            "/nutsandberries.htm",
            "/summerfun",
            "/starring=mrscritter",
            "?doYouLoveCrittercism=YES"
        };
        private string randomURLString() {
            return urls[random.Next(0,urls.Length)] + urlPaths[random.Next(0,urlPaths.Length)];
        }
        private void logNetworkRequestClick(object sender,RoutedEventArgs e) {
            Random random = new Random();
            string[] methods = new string[] { "GET","POST","HEAD","PUT" };
            string method = methods[random.Next(0,methods.Length)];
            string urlString = randomURLString();
            // latency in milliseconds
            long latency = (long)Math.Floor(4000.0 * random.NextDouble());
            long bytesRead = random.Next(0,10000);
            long bytesSent = random.Next(0,10000);
            long responseCode = 200;
            if (random.Next(0,5) == 0) {
                // Some common response other than 200 == OK .
                long[] responseCodes = new long[] { 301,308,400,401,402,403,404,405,408,500,502,503 };
                responseCode = responseCodes[random.Next(0,responseCodes.Length)];
            };
            WebExceptionStatus exceptionStatus = WebExceptionStatus.Success;
            if (random.Next(0,5) == 0) {
                // Simulate a network WebException was encountered.
                WebExceptionStatus[] exceptionStatuses = new WebExceptionStatus[] {
                    WebExceptionStatus.NameResolutionFailure,
                    WebExceptionStatus.ConnectFailure,
                    WebExceptionStatus.ReceiveFailure,
                    WebExceptionStatus.SendFailure,
                    WebExceptionStatus.ConnectionClosed,
                    WebExceptionStatus.TrustFailure,
                    WebExceptionStatus.KeepAliveFailure,
                    WebExceptionStatus.Timeout
                };
                exceptionStatus = exceptionStatuses[random.Next(0,exceptionStatuses.Length)];
                // We didn't receive a simulated response, after all.
                responseCode = 0;
            };
            Crittercism.LogNetworkRequest(
                method,
                urlString,
                latency,
                bytesRead,
                bytesSent,
                (HttpStatusCode)responseCode,
                WebExceptionStatus.Success);
        }

        private const string beginUserflowLabel = "Begin Userflow";
        private const string endUserflowLabel = "End Userflow";
        private string[] userflowNames = new string[] { "Buy Critter Feed","Sing Critter Song","Write Critter Poem" };
        private void userflowClick(object sender,RoutedEventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                Debug.Assert(button == userflowButton);
                String label = button.Content.ToString();
                if (label == beginUserflowLabel) {
                    Demo.userflowName = userflowNames[random.Next(0,userflowNames.Length)];
                    Crittercism.BeginUserflow(Demo.userflowName);
                    button.Content = endUserflowLabel;
                } else if (label == endUserflowLabel) {
                    NavigationService.Navigate(new Uri("/EndUserflow.xaml",UriKind.Relative));
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            if (Demo.userflowName == null) {
                userflowButton.Content = beginUserflowLabel;
            } else {
                userflowButton.Content = endUserflowLabel;
            };
        }

        private void UserflowTimeOutHandler(object sender,EventArgs e) {
            Demo.UserflowTimeOutHandler(this,e);
        }

        private void handledExceptionClick(object sender,RoutedEventArgs e) {
            try {
                ThrowException();
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }
        }

        private void handledUnthrownExceptionClick(object sender,RoutedEventArgs e) {
            Exception exception = new Exception("description");
            exception.Data.Add("MethodName","methodName");
            Crittercism.LogHandledException(exception);
        }

        private void crashClick(object sender,RoutedEventArgs e) {
            ThrowException();
        }

        private void DeepError(int n) {
            if (n == 0) {
                throw new Exception("Deep Error");
            } else {
                DeepError(n - 1);
            }
        }

        private void ThrowException() {
            DeepError(random.Next(0,4));
        }

        private void nextButtonClicked(object sender,RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/End.xaml",UriKind.Relative));
        }
    }
}
