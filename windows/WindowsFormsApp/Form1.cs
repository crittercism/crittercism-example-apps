using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrittercismSDK;

namespace WindowsFormsApp {
    public partial class Form1 : Form {
        private static int ApplicationOpenFormsCount = 0;

        public Form1() {
            InitializeComponent();
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
            Random random=new Random();
            string[] names= { "Breadcrumb","Strawberry","Seed","Grape","Lettuce" };
            string name=names[random.Next(0,names.Length)];
            Crittercism.LeaveBreadcrumb(name);
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

        private void pictureBox1_Click(object sender,EventArgs e) {
            
            string username=Crittercism.Username();
            if (username==null) {
                username="User";
            }
            string response="";
            DialogResult result=MessageBox.Show("Do you love Crittercism?","WindowsFormsApp",MessageBoxButtons.YesNo);
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

        private void Form1_FormClosed(object sender,FormClosedEventArgs e) {
            Crittercism.LeaveBreadcrumb("FormClosed");
            ApplicationOpenFormsCount--;
            if (ApplicationOpenFormsCount==0) {
                // Last window is closing.
                Crittercism.Shutdown();
                Application.Exit();
            }
        }

        private void newWindow_Click(object sender,EventArgs e) {
            (new Form1()).Show();
        }
    }
}
