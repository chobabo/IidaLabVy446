namespace IidaLabVy446
{
    partial class VisionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveAviCheckBox = new System.Windows.Forms.CheckBox();
            this.ReadAviCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IntervalTxtBox = new System.Windows.Forms.TextBox();
            this.MachineVisionTimer = new System.Windows.Forms.Timer(this.components);
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 23);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(95, 18);
            this.toolStripStatusLabel1.Text = "Elapsed Time: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(78, 18);
            this.toolStripStatusLabel2.Text = "milliseconds";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(108, 18);
            this.toolStripStatusLabel3.Text = "Debug Message: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(58, 18);
            this.toolStripStatusLabel4.Text = "Message";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pBoxIpl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 265);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // pBoxIpl1
            // 
            this.pBoxIpl1.Location = new System.Drawing.Point(6, 18);
            this.pBoxIpl1.Name = "pBoxIpl1";
            this.pBoxIpl1.Size = new System.Drawing.Size(320, 240);
            this.pBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxIpl1.TabIndex = 0;
            this.pBoxIpl1.TabStop = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(350, 225);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadAviCheckBox);
            this.groupBox2.Controls.Add(this.SaveAviCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(350, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 44);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File I/O";
            // 
            // SaveAviCheckBox
            // 
            this.SaveAviCheckBox.AutoSize = true;
            this.SaveAviCheckBox.Location = new System.Drawing.Point(6, 18);
            this.SaveAviCheckBox.Name = "SaveAviCheckBox";
            this.SaveAviCheckBox.Size = new System.Drawing.Size(49, 16);
            this.SaveAviCheckBox.TabIndex = 0;
            this.SaveAviCheckBox.Text = "Save";
            this.SaveAviCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReadAviCheckBox
            // 
            this.ReadAviCheckBox.AutoSize = true;
            this.ReadAviCheckBox.Location = new System.Drawing.Point(61, 18);
            this.ReadAviCheckBox.Name = "ReadAviCheckBox";
            this.ReadAviCheckBox.Size = new System.Drawing.Size(50, 16);
            this.ReadAviCheckBox.TabIndex = 1;
            this.ReadAviCheckBox.Text = "Read";
            this.ReadAviCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IntervalTxtBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(350, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 45);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval: ";
            // 
            // IntervalTxtBox
            // 
            this.IntervalTxtBox.Location = new System.Drawing.Point(61, 15);
            this.IntervalTxtBox.Name = "IntervalTxtBox";
            this.IntervalTxtBox.Size = new System.Drawing.Size(100, 19);
            this.IntervalTxtBox.TabIndex = 1;
            this.IntervalTxtBox.Text = "100";
            // 
            // MachineVisionTimer
            // 
            this.MachineVisionTimer.Tick += new System.EventHandler(this.MachineVisionTimer_Tick);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(431, 225);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 6;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(350, 254);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // VisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 338);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "VisionForm";
            this.Text = "VisionForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIpl1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private OpenCvSharp.UserInterface.PictureBoxIpl pBoxIpl1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ReadAviCheckBox;
        private System.Windows.Forms.CheckBox SaveAviCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox IntervalTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer MachineVisionTimer;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ExitButton;
    }
}