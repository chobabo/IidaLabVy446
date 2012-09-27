
namespace IidaLabVy446
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using OpenCvSharp;
    using MachineVision;
    using System.Diagnostics;

    public partial class VisionForm : Form
    {
        private MachineVision.File mvFile;

        /// <summary>
        /// basic constructor
        /// </summary>
        public VisionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// timer event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MachineVisionTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            if (this.mvFile.cap.QueryFrame() != null)
            {
                if (this.SaveAviCheckBox.Checked == true)
                {
                    this.mvFile.writer.WriteFrame(this.mvFile.cap.QueryFrame());
                }

                this.pBoxIpl1.ImageIpl = this.mvFile.cap.QueryFrame();
            }
            else
            {
                this.toolStripStatusLabel4.Text = "Cannot read image from QueryFrame";
                this.MachineVisionTimer.Enabled = false;
                this.mvFile.Dispose();
            }

            watch.Stop();
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
        }

        /// <summary>
        /// connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.mvFile = new MachineVision.File(
                this.SaveAviCheckBox.Checked,
                this.ReadAviCheckBox.Checked,
                Convert.ToInt32(this.IntervalTxtBox.Text)
                );

            this.MachineVisionTimer.Interval = Convert.ToInt32(this.IntervalTxtBox.Text);
            this.MachineVisionTimer.Enabled = true;
        }

        /// <summary>
        /// disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.MachineVisionTimer.Enabled == true)
            {
                this.MachineVisionTimer.Enabled = false;
                this.mvFile.Dispose();
            }
        }

        /// <summary>
        /// Exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
