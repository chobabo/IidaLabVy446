using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using SickLidar;
using ZedGraph;
using OpenCvSharp;
using MachineVision;
using CombineBody;

namespace IidaLabVy446
{

    public partial class IntegratedForm : Form
    {
        #region Laser Range Finder

        private SickLidar.Graph graph;
        private SickLidar.SickLidar sickLidar;
        private SickLidar.File lidarFile;

        //for read file
        private int readCount { get; set; }

        /// <summary>
        /// Initialize Lidar Sensor
        /// </summary>
        private void LidarConnect()
        {
            this.graph = new Graph();
            this.graph.CreateGraph(zg1);

            if (this.LidarReadCheckBox.Checked == false)
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.LidarHostTxtBox.Text,
                    Convert.ToInt32(this.LidarPortTxtBox.Text),
                    this.LidarSelectComboBox.SelectedIndex,
                    Convert.ToInt32(this.LidarScalingTxtBox.Text),
                    false
                    );

                if (this.LidarSaveCheckBox.Checked == true)
                {
                    this.lidarFile = new SickLidar.File(
                        this.LidarSaveCheckBox.Checked, 
                        this.LidarReadCheckBox.Checked
                        );
                }

            }
            else
            {
                this.sickLidar = new SickLidar.SickLidar(
                    this.LidarSelectComboBox.SelectedIndex,
                    Convert.ToInt32(this.LidarScalingTxtBox.Text)
                       );

                this.lidarFile = new SickLidar.File(
                    this.LidarSaveCheckBox.Checked, 
                    this.LidarReadCheckBox.Checked
                    );
            }
        }

        /// <summary>
        /// Play Lidar Sensor
        /// </summary>
        private void LidarPlay()
        {
            if (this.LidarReadCheckBox.Checked == false)
            {
                this.sickLidar.RequestScan();
                this.sickLidar.ConvertHexToPolar();
                this.sickLidar.ConvertPolarToCartesian();
                this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1);

                if (this.LidarSaveCheckBox.Checked == true)
                {
                    this.lidarFile.addDataForSave(this.sickLidar.orgList);
                }
            }
            else
            {
                if (this.lidarFile.readData.Length > this.readCount)
                {
                    this.sickLidar.ConvertReadDataToPolar(this.readCount, this.lidarFile.readData);
                    this.sickLidar.ConvertPolarToCartesian();
                    this.graph.UpdateGraph(this.sickLidar.cartesianList, zg1);
                    //this.readCount++;
                }
                else
                {
                    //this.SickTimer.Enabled = false;
                }
            }
        }
        
        #endregion

        #region Machine Vision

        private MachineVision.File mvFile;

        /// <summary>
        /// Machine Vision Connect
        /// </summary>
        private void MachineVisionConnect()
        {
            this.mvFile = new MachineVision.File(
               this.VisionSaveCheckBox.Checked,
               this.VisionReadCheckBox.Checked,
               Convert.ToInt32(this.TimerIntervalTxtBox.Text)
               );
        }

        /// <summary>
        /// Machine Vision Play
        /// </summary>
        private void MachineVisionPlay()
        {
            if (this.mvFile.cap.QueryFrame() != null)
            {
                if (this.VisionSaveCheckBox.Checked == true)
                {
                    this.mvFile.VideoWriter(this.mvFile.cap.QueryFrame(), this.readCount);
                }

                this.pBoxIpl1.ImageIpl = this.mvFile.cap.QueryFrame();
            }
            else
            {
                this.toolStripStatusLabel4.Text = "Cannot read image from QueryFrame";
                //this.MachineVisionTimer.Enabled = false;
                //this.mvFile.Dispose();
            }
        }

        #endregion

        #region Combine Body

        private CombineBody.SerialConnect _bodySerialConnect;
        private CombineBody.File _bodyFile;
        private CombineBody.Vy50 _vy50;
        private CombineBody.Vy446 _vy446;

        /// <summary>
        /// Connect Combine Body using RS-232C
        /// </summary>
        private void CombineBodyConnect()
        {
            if (this.BodyReadCheckBox.Checked == true)
            {
 
            }
            else
            {
                this._bodySerialConnect = new CombineBody.SerialConnect(
                    this.BodyPortTxtBox.Text,
                    Convert.ToInt32(this.BodyBaudRateTxtBox.Text),
                    Convert.ToInt32(this.BodyDatabitsTxtBox.Text)
                    );

                if (this.BodySaveCheckBox.Checked == true)
                {
                    this._bodyFile = new CombineBody.File(
                        this.BodySaveCheckBox.Checked,
                        this.BodyReadCheckBox.Checked
                        );
                }
            }

            if (this.BodyModelComboBox.SelectedIndex == 0)
            {
                this._vy50 = new CombineBody.Vy50();
            }

            if (this.BodyModelComboBox.SelectedIndex == 1)
            {
                this._vy446 = new CombineBody.Vy446();
            }
        }

        /// <summary>
        /// Combine body play
        /// </summary>
        private void CombineBodyPlay()
        {
            if (this.BodyReadCheckBox.Checked == true)
            { 

            }
            else
            {
                this._bodySerialConnect.DataReceived();

                if (this.BodySaveCheckBox.Checked == true)
                {
                    this._bodyFile.addDataForSave(this._bodySerialConnect.orgList, this.readCount);
                }

                if (this.BodyModelComboBox.SelectedIndex == 0)
                {
                    this.CombineVy50Info(this._bodySerialConnect.orgList);
                }

                if (this.BodyModelComboBox.SelectedIndex == 1)
                {
                    this.CombineVy446Info(this._bodySerialConnect.orgList);
                }
            }
        }

        /// <summary>
        /// Convert received data from body to infromation of combine VY446
        /// </summary>
        /// <param name="data">received data from combine body</param>
        private void CombineVy446Info(List<int> data)
        {
            bool isReceived = this._vy446.TokenData(data);

            if (isReceived == true)
            {
                // 傾斜センサ--ok
                this.Vy446_AD_SUI_K_TxtBox.Text = Convert.ToString(this._vy446.AD_SUI_K);

                // 左シリンダポテンショ--ok
                this.Vy446_AD_SUI_L_TxtBox.Text = Convert.ToString(this._vy446.AD_SUI_L);

                // 右シリンダポテンショ--ok
                this.Vy446_AD_SUI_R_TxtBox.Text = Convert.ToString(this._vy446.AD_SUI_R);

                // 主変速ポテンショ--ok
                this.Vy446_DT_HST_TxtBox.Text = Convert.ToString(this._vy446.AD_FEED_M);
                
                // 操向ポテンショ--ok
                this.Vy446_DT_SOKO_TxtBox.Text = Convert.ToString(this._vy446.AD_SOKO_A);

                // フィーダ回転数
                this.Vy446_feed_rpm_TxtBox.Text = Convert.ToString(this._vy446.feed_rpm);
                
                // エンジン回転数
                this.Vy446_rpm_TxtBox.Text = Convert.ToString(this._vy446.rpm);
                
                // ミッション速度
                this.Vy446_speed_TxtBox.Text = Convert.ToString(this._vy446.speed);

                // 排出オーガの左右旋回ポテンショ--ok
                this.Vy446_AUGER_MTR_TxtBox.Text = Convert.ToString(this._vy446.DT_AUG_MTR);

                // 排出オーガの上下旋回ポテンショ--ok
                this.Vy446_AUGER_CLD_TxtBox.Text = Convert.ToString(this._vy446.DT_AUG_CLD);

                // 刈高さポテンショ--ok
                this.Vy446_RESERVE_B_TxtBox.Text = Convert.ToString(this._vy446.AD_KARI_L);

                this.Vy446_avilability_TxtBox.Text = Convert.ToString(this._vy446.avilability);
                this.Vy446_compass_TxtBox.Text = Convert.ToString(this._vy446.compass);
                this.Vy446_gps_Altitude_TxtBox.Text = Convert.ToString(this._vy446.gps_Altitude);
                this.Vy446_gps_compass_TxtBox.Text = Convert.ToString(this._vy446.gps_Compass);
                this.Vy446_gps_Latitude_TxtBox.Text = Convert.ToString(this._vy446.gps_Latitude);
                this.Vy446_gps_Longitude_TxtBox.Text = Convert.ToString(this._vy446.gps_Longitude);
                this.Vy446_gps_Quality_TxtBox.Text = Convert.ToString(this._vy446.gps_Quality);
                this.Vy446_gps_Sv_TxtBox.Text = Convert.ToString(this._vy446.gps_Sv);
                this.Vy446_gps_Utc_TxtBox.Text = Convert.ToString(this._vy446.gps_Utc);
                this.Vy446_heading_TxtBox.Text = Convert.ToString(this._vy446.heading);
                this.Vy446_pitch_TxtBox.Text = Convert.ToString(this._vy446.pitch);
                this.Vy446_roll_TxtBox.Text = Convert.ToString(this._vy446.roll);
            }
        }


        /// <summary>
        /// Convert received data from body to infromation of combine VY50
        /// </summary>
        /// <param name="data">received data from combine body</param>
        private void CombineVy50Info(List<int> data)
        {
            bool isReveived = this._vy50.TokenData(data);

            if (isReveived == true)
            {
                this.Vy50_ReadCnt_TxtBox.Text = Convert.ToString(this.readCount);

                this.Vy50_d_EngineRpm_TxtBox.Text = Convert.ToString(this._vy50.d_EngineRpm);
                this.Vy50_d_FeederSpd_TxtBox.Text = Convert.ToString(this._vy50.d_FeederSpd);
                this.Vy50_d_Speed_TxtBox.Text = Convert.ToString(this._vy50.d_Speed);

                this.Vy50_gps_Altitude_TxtBox.Text = Convert.ToString(this._vy50.gps_Altitude);
                this.Vy50_gps_Heading_TxtBox.Text = Convert.ToString(this._vy50.gps_Heading);
                this.Vy50_gps_Latitude_TxtBox.Text = Convert.ToString(this._vy50.gps_Latitude);
                this.Vy50_gps_Longitude_TxtBox.Text = Convert.ToString(this._vy50.gps_Longitude);
                this.Vy50_gps_Quality_TxtBox.Text = Convert.ToString(this._vy50.gps_Quality);
                this.Vy50_gps_Sv_TxtBox.Text = Convert.ToString(this._vy50.gps_Sv);
                this.Vy50_gps_Utc_TxtBox.Text = Convert.ToString(this._vy50.gps_Utc);

                this.Vy50_uc_FinPos_TxtBox.Text = Convert.ToString(this._vy50.uc_FinPos);
                this.Vy50_uc_HeaderPos_TxtBox.Text = Convert.ToString(this._vy50.uc_HeaderPos);
                this.Vy50_uc_MacAir_TxtBox.Text = Convert.ToString(this._vy50.uc_MacAir);
                this.Vy50_uc_MainPotentio_TxtBox.Text = Convert.ToString(this._vy50.uc_MainPotentio);
                this.Vy50_uc_RcvFinPos_TxtBox.Text = Convert.ToString(this._vy50.uc_RcvFinPos);
                this.Vy50_uc_SteerPotentio_TxtBox.Text = Convert.ToString(this._vy50.uc_SteerPotentio);
                this.Vy50_us_AdLeftCylinder_TxtBox.Text = Convert.ToString(this._vy50.us_AdLeftCylinder);
                this.Vy50_us_AdRightCylinder_TxtBox.Text = Convert.ToString(this._vy50.us_AdRightCylinder);
                this.Vy50_us_AdSuihei_TxtBox.Text = Convert.ToString(this._vy50.us_AdSuihei);
                this.Vy50_us_LRPos_TxtBox.Text = Convert.ToString(this._vy50.us_LRPos);
                this.Vy50_us_UDPos_TxtBox.Text = Convert.ToString(this._vy50.us_UDPos);
            }
        }

        #endregion

        #region Constructor

        public IntegratedForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.readCount = 0;

            if (this.LidarAvailableCheckBox.Checked == true)
            {
                this.LidarConnect();
            }

            if (this.BodyAvailableCheckBox.Checked == true)
            {
                this.CombineBodyConnect();
            }

            if (this.VisionAvailableCheckBox.Checked == true)
            {
                this.MachineVisionConnect();
            }

            this.IntegratedTimer.Interval = Convert.ToInt32(this.TimerIntervalTxtBox.Text);
            this.IntegratedTimer.Enabled = true;
        }

        /// <summary>
        /// disconnect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (this.IntegratedTimer.Enabled == true)
            {
                this.IntegratedTimer.Enabled = false;

                if (this.LidarAvailableCheckBox.Checked == true)
                {
                    if (this.LidarReadCheckBox.Checked == false)
                    {
                        if (this.LidarSaveCheckBox.Checked == true)
                        {
                            this.lidarFile.closeSave();
                        }

                        this.sickLidar.DisconnectSocket();
                    }
                }

                if (this.VisionAvailableCheckBox.Checked == true)
                {
                    this.mvFile.Dispose();
                }

                if (this.BodyAvailableCheckBox.Checked == true)
                {
                    if (this.BodySaveCheckBox.Checked == true)
                    {
                        this._bodyFile.closeSave();
                    }

                    this._bodySerialConnect.Dispose();
                }

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

        /// <summary>
        /// Timer Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntegratedTimer_Tick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (this.VisionAvailableCheckBox.Checked == true)
            {
                this.MachineVisionPlay();
            }

            if (this.LidarAvailableCheckBox.Checked == true)
            {
                this.LidarPlay();
            }

            if (this.BodyAvailableCheckBox.Checked == true)
            {
                this.CombineBodyPlay();
            }

            this.readCount++;

            watch.Stop();
            this.toolStripStatusLabel2.Text =
                Convert.ToString(watch.Elapsed.TotalMilliseconds) + " milliseconds";
            this.toolStripStatusLabel4.Text = Convert.ToString(this.readCount);
        }

        #endregion

    }
}
