using CrittercismSDK;

namespace WindowsFormsApp {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.setUsernameButton = new System.Windows.Forms.Button();
            this.leaveBreadcrumbButton = new System.Windows.Forms.Button();
            this.handledExceptionButton = new System.Windows.Forms.Button();
            this.crashButton = new System.Windows.Forms.Button();
            this.newWindowButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logNetworkRequestButton = new System.Windows.Forms.Button();
            this.userflowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // setUsernameButton
            // 
            this.setUsernameButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setUsernameButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.setUsernameButton.Location = new System.Drawing.Point(79, 10);
            this.setUsernameButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.setUsernameButton.Name = "setUsernameButton";
            this.setUsernameButton.Size = new System.Drawing.Size(280, 58);
            this.setUsernameButton.TabIndex = 0;
            this.setUsernameButton.Text = "Set Username";
            this.setUsernameButton.UseVisualStyleBackColor = true;
            this.setUsernameButton.Click += new System.EventHandler(this.setUsername_Click);
            // 
            // leaveBreadcrumbButton
            // 
            this.leaveBreadcrumbButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveBreadcrumbButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.leaveBreadcrumbButton.Location = new System.Drawing.Point(79, 84);
            this.leaveBreadcrumbButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.leaveBreadcrumbButton.Name = "leaveBreadcrumbButton";
            this.leaveBreadcrumbButton.Size = new System.Drawing.Size(280, 58);
            this.leaveBreadcrumbButton.TabIndex = 1;
            this.leaveBreadcrumbButton.Text = "Leave Breadcrumb";
            this.leaveBreadcrumbButton.UseVisualStyleBackColor = true;
            this.leaveBreadcrumbButton.Click += new System.EventHandler(this.leaveBreadcrumb_Click);
            // 
            // handledExceptionButton
            // 
            this.handledExceptionButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handledExceptionButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.handledExceptionButton.Location = new System.Drawing.Point(79, 309);
            this.handledExceptionButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.handledExceptionButton.Name = "handledExceptionButton";
            this.handledExceptionButton.Size = new System.Drawing.Size(280, 58);
            this.handledExceptionButton.TabIndex = 2;
            this.handledExceptionButton.Text = "Handled Exception";
            this.handledExceptionButton.UseVisualStyleBackColor = true;
            this.handledExceptionButton.Click += new System.EventHandler(this.handledException_Click);
            // 
            // crashButton
            // 
            this.crashButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crashButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.crashButton.Location = new System.Drawing.Point(79, 383);
            this.crashButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.crashButton.Name = "crashButton";
            this.crashButton.Size = new System.Drawing.Size(280, 58);
            this.crashButton.TabIndex = 3;
            this.crashButton.Text = "Crash";
            this.crashButton.UseVisualStyleBackColor = true;
            this.crashButton.Click += new System.EventHandler(this.crash_Click);
            // 
            // newWindowButton
            // 
            this.newWindowButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWindowButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.newWindowButton.Location = new System.Drawing.Point(79, 458);
            this.newWindowButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.newWindowButton.Name = "newWindowButton";
            this.newWindowButton.Size = new System.Drawing.Size(280, 58);
            this.newWindowButton.TabIndex = 4;
            this.newWindowButton.Text = "New Window";
            this.newWindowButton.UseVisualStyleBackColor = true;
            this.newWindowButton.Click += new System.EventHandler(this.newWindow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(369, 409);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // logNetworkRequestButton
            // 
            this.logNetworkRequestButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logNetworkRequestButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.logNetworkRequestButton.Location = new System.Drawing.Point(79, 159);
            this.logNetworkRequestButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.logNetworkRequestButton.Name = "logNetworkRequestButton";
            this.logNetworkRequestButton.Size = new System.Drawing.Size(280, 58);
            this.logNetworkRequestButton.TabIndex = 6;
            this.logNetworkRequestButton.Text = "Log Network Request";
            this.logNetworkRequestButton.UseVisualStyleBackColor = true;
            this.logNetworkRequestButton.Click += new System.EventHandler(this.logNetworkRequest_Click);
            // 
            // userflowButton
            // 
            this.userflowButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userflowButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.userflowButton.Location = new System.Drawing.Point(77, 234);
            this.userflowButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.userflowButton.Name = "userflowButton";
            this.userflowButton.Size = new System.Drawing.Size(280, 58);
            this.userflowButton.TabIndex = 7;
            this.userflowButton.Text = "Begin Userflow";
            this.userflowButton.UseVisualStyleBackColor = true;
            this.userflowButton.Click += new System.EventHandler(this.userflowButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(435, 537);
            this.Controls.Add(this.userflowButton);
            this.Controls.Add(this.logNetworkRequestButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.newWindowButton);
            this.Controls.Add(this.crashButton);
            this.Controls.Add(this.handledExceptionButton);
            this.Controls.Add(this.leaveBreadcrumbButton);
            this.Controls.Add(this.setUsernameButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MainWindow";
            this.Text = "WindowsFormsApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.MainWindow_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setUsernameButton;
        private System.Windows.Forms.Button leaveBreadcrumbButton;
        private System.Windows.Forms.Button handledExceptionButton;
        private System.Windows.Forms.Button crashButton;
        private System.Windows.Forms.Button newWindowButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button logNetworkRequestButton;
        private System.Windows.Forms.Button userflowButton;
    }
}

