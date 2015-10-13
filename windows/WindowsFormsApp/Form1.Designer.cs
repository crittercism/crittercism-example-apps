using CrittercismSDK;

namespace WindowsFormsApp {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.setUsernameButton = new System.Windows.Forms.Button();
            this.leaveBreadcrumbButton = new System.Windows.Forms.Button();
            this.handledExceptionButton = new System.Windows.Forms.Button();
            this.crashButton = new System.Windows.Forms.Button();
            this.newWindowButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // setUsernameButton
            // 
            this.setUsernameButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setUsernameButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.setUsernameButton.Location = new System.Drawing.Point(95, 35);
            this.setUsernameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setUsernameButton.Name = "setUsernameButton";
            this.setUsernameButton.Size = new System.Drawing.Size(345, 75);
            this.setUsernameButton.TabIndex = 0;
            this.setUsernameButton.Text = "Set Username";
            this.setUsernameButton.UseVisualStyleBackColor = true;
            this.setUsernameButton.Click += new System.EventHandler(this.setUsername_Click);
            // 
            // leaveBreadcrumbButton
            // 
            this.leaveBreadcrumbButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveBreadcrumbButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.leaveBreadcrumbButton.Location = new System.Drawing.Point(95, 140);
            this.leaveBreadcrumbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leaveBreadcrumbButton.Name = "leaveBreadcrumbButton";
            this.leaveBreadcrumbButton.Size = new System.Drawing.Size(345, 75);
            this.leaveBreadcrumbButton.TabIndex = 1;
            this.leaveBreadcrumbButton.Text = "Leave Breadcrumb";
            this.leaveBreadcrumbButton.UseVisualStyleBackColor = true;
            this.leaveBreadcrumbButton.Click += new System.EventHandler(this.leaveBreadcrumb_Click);
            // 
            // handledExceptionButton
            // 
            this.handledExceptionButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handledExceptionButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.handledExceptionButton.Location = new System.Drawing.Point(95, 350);
            this.handledExceptionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.handledExceptionButton.Name = "handledExceptionButton";
            this.handledExceptionButton.Size = new System.Drawing.Size(345, 75);
            this.handledExceptionButton.TabIndex = 2;
            this.handledExceptionButton.Text = "Handled Exception";
            this.handledExceptionButton.UseVisualStyleBackColor = true;
            this.handledExceptionButton.Click += new System.EventHandler(this.handledException_Click);
            // 
            // crashButton
            // 
            this.crashButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crashButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.crashButton.Location = new System.Drawing.Point(95, 455);
            this.crashButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crashButton.Name = "crashButton";
            this.crashButton.Size = new System.Drawing.Size(345, 75);
            this.crashButton.TabIndex = 3;
            this.crashButton.Text = "Crash";
            this.crashButton.UseVisualStyleBackColor = true;
            this.crashButton.Click += new System.EventHandler(this.crash_Click);
            // 
            // newWindowButton
            // 
            this.newWindowButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWindowButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.newWindowButton.Location = new System.Drawing.Point(95, 560);
            this.newWindowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newWindowButton.Name = "newWindowButton";
            this.newWindowButton.Size = new System.Drawing.Size(345, 75);
            this.newWindowButton.TabIndex = 4;
            this.newWindowButton.Text = "New Window";
            this.newWindowButton.UseVisualStyleBackColor = true;
            this.newWindowButton.Click += new System.EventHandler(this.newWindow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(460, 560);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(545, 672);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.newWindowButton);
            this.Controls.Add(this.crashButton);
            this.Controls.Add(this.handledExceptionButton);
            this.Controls.Add(this.leaveBreadcrumbButton);
            this.Controls.Add(this.setUsernameButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "WindowsFormsApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
    }
}

