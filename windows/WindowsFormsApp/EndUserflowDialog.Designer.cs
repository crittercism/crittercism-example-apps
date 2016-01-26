namespace WindowsFormsApp {
    partial class EndUserflowDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndUserflowDialog));
            this.successButton = new System.Windows.Forms.Button();
            this.failButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // successButton
            // 
            this.successButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.successButton.Location = new System.Drawing.Point(40, 27);
            this.successButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.successButton.Name = "successButton";
            this.successButton.Size = new System.Drawing.Size(420, 90);
            this.successButton.TabIndex = 1;
            this.successButton.Text = "Success";
            this.successButton.UseVisualStyleBackColor = true;
            this.successButton.Click += new System.EventHandler(this.successButton_Click);
            // 
            // failButton
            // 
            this.failButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.failButton.Location = new System.Drawing.Point(41, 152);
            this.failButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.failButton.Name = "failButton";
            this.failButton.Size = new System.Drawing.Size(420, 90);
            this.failButton.TabIndex = 2;
            this.failButton.Text = "Fail";
            this.failButton.UseVisualStyleBackColor = true;
            this.failButton.Click += new System.EventHandler(this.failButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.cancelButton.Location = new System.Drawing.Point(41, 283);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(420, 90);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EndUserflowDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(503, 404);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.failButton);
            this.Controls.Add(this.successButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EndUserflowDialog";
            this.Text = "EndUserflowDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button successButton;
        private System.Windows.Forms.Button failButton;
        private System.Windows.Forms.Button cancelButton;
    }
}