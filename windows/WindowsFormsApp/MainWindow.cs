using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrittercismSDK;

namespace WindowsFormsApp {
    public partial class MainWindow : Form {
        private static int ApplicationOpenFormsCount = 0;
        private static Random random = new Random();

        public MainWindow() {
            InitializeComponent();
            Program.UserflowEvent += UserflowEventHandler;
            ApplicationOpenFormsCount++;
        }

        protected override void OnLoad(EventArgs e) {
            Crittercism.LeaveBreadcrumb("OnLoad");
        }

        private void setUsername_Click(object sender,EventArgs e) {
            Random random=new Random();
            string[] names= { "Blue Jay","Chinchilla","Chipmunk","Gerbil","Hamster","Parrot","Robin","Squirrel","Turtle" };
            string name=names[random.Next(0,names.Length)];
            Crittercism.SetUsername("Critter "+name);
        }

        private void leaveBreadcrumb_Click(object sender,EventArgs e) {
            string[] names= { "Breadcrumb","Strawberry","Seed","Grape","Lettuce" };
            string name=names[random.Next(0,names.Length)];
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
        private void logNetworkRequest_Click(object sender,EventArgs e) {
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

        private void handledException_Click(object sender,EventArgs e) {
            try {
                ThrowException();
            } catch (Exception ex) {
                Crittercism.LogHandledException(ex);
            }
        }

        private void crash_Click(object sender,EventArgs e) {
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

        private void pictureBox1_Click(object sender,EventArgs e) {
            string username=Crittercism.Username();
            if (username==null) {
                username="User";
            }
            string response="";
            DialogResult result=MessageBox.Show(this,"Do you love Crittercism?","WindowsFormsApp",MessageBoxButtons.YesNo);
            switch (result) {
                case DialogResult.Yes:
                    response="loves Crittercism.";
                    break;
                case DialogResult.No:
                    response="doesn't love Crittercism.";
                    break;
            }
            Crittercism.LeaveBreadcrumb(username+" "+response);
        }

        private void MainWindow_FormClosed(object sender,FormClosedEventArgs e) {
            Crittercism.LeaveBreadcrumb("FormClosed");
            Program.UserflowEvent -= UserflowEventHandler;
            ApplicationOpenFormsCount--;
            if (ApplicationOpenFormsCount==0) {
                // Last window is closing.
                Crittercism.Shutdown();
                Application.Exit();
            }
        }

        private void newWindow_Click(object sender,EventArgs e) {
            (new MainWindow()).Show();
        }

        private const string beginUserflowLabel = "Begin Userflow";
        private const string endUserflowLabel = "End Userflow";
        private string[] userflowNames = new string[] { "Buy Critter Feed","Sing Critter Song","Write Critter Poem" };
        private void userflowButton_Click(object sender,EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                String label = button.Text;
                if (label == beginUserflowLabel) {
                    Program.userflowName = userflowNames[random.Next(0,userflowNames.Length)];
                    Crittercism.BeginUserflow(Program.userflowName);
                    // Broadcast UserflowEvent to all open windows. 
                    Program.OnUserflowEvent(EventArgs.Empty);
                } else if (label == endUserflowLabel) {
                    EndUserflowDialog dialog = new EndUserflowDialog();
                    dialog.Owner = this;
                    dialog.ShowDialog();
                    if (dialog.DialogResult == DialogResult.Yes) {
                        switch (dialog.Answer) {
                            case "End Userflow":
                                Crittercism.EndUserflow(Program.userflowName);
                                break;
                            case "Fail Userflow":
                                Crittercism.FailUserflow(Program.userflowName);
                                break;
                            case "Cancel Userflow":
                                Crittercism.CancelUserflow(Program.userflowName);
                                break;
                        };
                        Program.userflowName = null;
                        // Broadcast UserflowEvent to all open windows. 
                        Program.OnUserflowEvent(EventArgs.Empty);
                    }
                }
            }
        }
        private void UserflowTimeOutHandler(object sender,EventArgs e) {
            Debug.WriteLine("The userflow timed out.");
            // Execute this Action on the main UI thread.
            this.Invoke((MethodInvoker)delegate {
                userflowButton.Text = beginUserflowLabel;
                string name = ((CRUserflowEventArgs)e).Name;
                string message = String.Format("'{0}' Timed Out",name);
                MessageBox.Show(this,message,"WindowsFormsApp",MessageBoxButtons.OK);
            });
        }

        private void MainWindow_Layout(object sender,LayoutEventArgs e) {
            UserflowEventHandler(this,EventArgs.Empty);
        }

        private void UserflowEventHandler(object sender,EventArgs e) {
            // Update userflowButton ("Begin Userflow"/"End Userflow") in reaction to UserflowEvent .
            // Execute this Action on the main UI thread.
            this.Invoke((MethodInvoker)delegate {
                if (Program.userflowName == null) {
                    userflowButton.Text = beginUserflowLabel;
                } else {
                    userflowButton.Text = endUserflowLabel;
                }
            });
        }
    }
}
