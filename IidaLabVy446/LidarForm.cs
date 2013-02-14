using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SickLidar;
using System.Diagnostics;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace IidaLabVy446
{
    public partial class LidarForm : Form
    {
        #region fields

        private SickLidar.Graph graph;
        private SickLidar.SickLidar sickLidar;
        private SickLidar.File lidarFile;

        /// <summary>
        /// for debug of count
        /// </summary>
        private int readLidarCount { get; set; }

        /// <summary>
        /// is openGL load
        /// </summary>
        private bool glLoaded { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public LidarForm()
        {
            this.graph = new Graph();
            InitializeComponent();
            this.graph.CreateGraph(zg1);
        }

        #endregion

        #region event

        /// <summary>
        /// connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (this.ReadCheckBox.Checked == false)
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.HostTxtBox.Text,
                    Convert.ToInt32(this.PortTxtBox.Text),
                    this.SelectDeviceComBox.SelectedIndex,
                    Convert.ToInt32(this.ScalingFactorTxtBox.Text),
                    false
                    );

                if (this.SaveCheckBox.Checked == true)
                {
                    this.lidarFile = new File(this.SaveCheckBox.Checked, this.ReadCheckBox.Checked);
                }

            }
            else
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.SelectDeviceComBox.SelectedIndex,
                    Convert.ToInt32(this.ScalingFactorTxtBox.Text)
                       );

                this.lidarFile = new File(this.SaveCheckBox.Checked, this.ReadCheckBox.Checked);
            }

            this.SickTimer.Interval = Convert.ToInt32(this.IntervalTxtBox.Text);
            this.SickTimer.Enabled = true;
        }

        /// <summary>
        /// timer event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SickTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (this.ReadCheckBox.Checked == false)
            {
                this.sickLidar.RequestScan();
                this.sickLidar.ConvertHexToPolar();
                this.sickLidar.ConvertPolarToCartesian();
                this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, false);

                if (this.SaveCheckBox.Checked == true)
                {
                    this.lidarFile.addDataForSave(this.sickLidar.orgList);
                }
            }
            else
            {
                if (this.lidarFile.readData.Length > this.readLidarCount)
                {
                    this.sickLidar.ConvertReadDataToPolar(this.readLidarCount, this.lidarFile.readData);
                    this.sickLidar.ConvertPolarToCartesian();
                    this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1, false);
                    this.readLidarCount++;
                }
                else
                {
                    this.SickTimer.Enabled = false;
                }
            }

            watch.Stop();
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
        }

        /// <summary>
        /// disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.ReadCheckBox.Checked == false)
            {
                if (this.SaveCheckBox.Checked == true)
                {
                    this.lidarFile.closeSave();
                }
                this.SickTimer.Enabled = false;
                this.sickLidar.DisconnectSocket();
            }
            else
            {
                this.SickTimer.Enabled = false;
            }
        }

        /// <summary>
        /// exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region OpenGL

        /// <summary>
        /// gl control load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl1_Load(object sender, EventArgs e)
        {
            this.glLoaded = true;
            
            // GLコントロールを複数使うときはこれでカレントを指定します
            glControl1.MakeCurrent();

            // Yey! .NET Colors can be used directly!
            GL.ClearColor(Color.Black);

            // Setup View Port
            this.SetupViewport();
        }

        /// <summary>
        /// Setup View Port
        /// </summary>
        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Bottom-left corner pixel has coordinate (0, 0)
            GL.Ortho(0, 200, 0, 200, -1, 1);

            // Use all of the glControl painting area
            GL.Viewport(0, 0, w, h); 
        }

        /// <summary>
        /// openGL paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!this.glLoaded) // Play nice
                return;

            glControl1.MakeCurrent(); ////GLコントロールを複数使うときはこれでカレントを指定します
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Color3(Color.Yellow);
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(10, 20);
            GL.Vertex2(100, 20);
            GL.Vertex2(100, 50);
            GL.End();
            glControl1.SwapBuffers();
        }

        #endregion


    }
}
