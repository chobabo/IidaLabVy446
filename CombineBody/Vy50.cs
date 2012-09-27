
namespace CombineBody
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Vy50
    {
        #region fields

        /// <summary>
        /// 主変速レバーの位置（AD変換値）- buf[9]
        /// </summary>
        public int uc_MainPotentio { get; set; }

        /// <summary>
        /// Mac-Aiｒ（AD変換値）- buf[10]
        /// </summary>
        public int uc_MacAir { get; set; }

        /// <summary>
        /// フィン開度（AD変換値）- buf[11]
        /// </summary>
        public int uc_FinPos { get; set; }

        /// <summary>
        /// 前処理ポテンショ（AD変換値）- buf[12]
        /// </summary>
        public int uc_HeaderPos { get; set; }

        /// <summary>
        /// トランスミッション速度（m/s）- buf[13,14,15,16]
        /// </summary>
        public double d_Speed { get; set; }

        /// <summary>
        /// フィーダー搬送速度（m/s）- buf[17, 18, 19, 20]
        /// </summary>
        public double d_FeederSpd { get; set; }

        /// <summary>
        /// エンジン回転数（rpm）- buf[21,22,23,24]
        /// </summary>
        public double d_EngineRpm { get; set; }

        /// <summary>
        /// フィン指令値の受信データ - buf[25]
        /// </summary>
        public int uc_RcvFinPos { get; set; }

        /// <summary>
        /// 操向ポテンショ（AD変換値）- buf[26]
        /// </summary>
        public int uc_SteerPotentio { get; set; }

        /// <summary>
        /// 左右旋回関節の位置（AD変換値）- buf[27], buf[28]
        /// </summary>
        public int us_LRPos { get; set; }

        /// <summary>
        /// 上下旋回関節の位置（AD変換値）- buf[29], buf[30]
        /// </summary>
        public int us_UDPos { get; set; }

        /// <summary>
        /// 左右傾斜センサ（AD変換値）- buf[31, 32]
        /// </summary>
        public int us_AdSuihei { get; set; }

        /// <summary>
        /// 左シリンダポテンショ（AD変換値）- buf[33, 34]
        /// </summary>
        public int us_AdLeftCylinder { get; set; }

        /// <summary>
        /// 右シリンダポテンショ（AD変換値）- buf[35, 36]
        /// </summary>
        public int us_AdRightCylinder { get; set; }

        /// <summary>
        /// UTC時刻 - buf[37, 38, 39, 40]
        /// </summary>
        public int gps_Utc { get; set; }

        /// <summary>
        /// byte array to double using bitconverter
        /// </summary>
        private byte[] gps_bytes;

        /// <summary>
        /// 北緯[for latitude] - buf[41~48]
        /// </summary>
        public double gps_Latitude { get; set; }

        /// <summary>
        /// 東経[for longitude] - buf[49~56]
        /// </summary>
        public double gps_Longitude { get; set; }

        /// <summary>
        /// 高度[for altitude] - buf[57~64]
        /// </summary>
        public double gps_Altitude { get; set; }

        /// <summary>
        /// 方位[for heading] - buf[65~72]
        /// </summary>
        public double gps_Heading { get; set; }

        /// <summary>
        /// gps quality - buf[74]
        /// </summary>
        public int gps_Quality { get; set; }

        /// <summary>
        /// gps sv - bug[75]
        /// </summary>
        public int gps_Sv { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public Vy50() 
        {
            this.gps_bytes = new byte[8];
        }

        #endregion

        #region methods

        /// <summary>
        /// 関数： tokenData 
        /// 内容： 受信データを区切ってダイアログに表示する関数 
        /// 返値： 正常：0, 失敗：-1（int型）
        /// 引数： 受信データ(unsigned char型),33バイト
        /// </summary>
        /// <param name="data">buffered data</param>
        public bool TokenData(List<int> data)
        {
            bool rValue = false;

            if (data.Count == 82 && data[0] == 205 && data[data.Count - 1] == 10)
            {
                //------------------------------------------//
                //--ここにグレーンタンクスイッチ関係を記述--//
                //------------------------------------------//

                // 主変速レバーの位置（AD変換値）- buf[9]
                // uc_MainPotentio = (unsigned short)buf[9];
                this.uc_MainPotentio = data[9];

                // Mac-Aiｒ（AD変換値）- buf[10]
                // uc_MacAir = (unsigned short)buf[10];
                this.uc_MacAir = data[10];

                // フィン開度（AD変換値）- buf[11]
                // uc_FinPos = (unsigned short)buf[11];
                this.uc_FinPos = data[11];

                // 前処理ポテンショ（AD変換値）- buf[12]
                // uc_HeaderPos = (unsigned short)buf[12];
                this.uc_HeaderPos = data[12];

                // トランスミッション速度（m/s）- buf[13,14,15,16]
                int transSpeed = (((data[13] * 256 + data[14]) * 256 + data[15]) * 256 + data[16]);
                if (transSpeed != 0)
                {
                    this.d_Speed = (double)41153.0 / (double)transSpeed;
                }
                else
                {
                    this.d_Speed = 0.0;
                }

                // フィーダー搬送速度（m/s）- buf[17, 18, 19, 20]
                int feederSpeed = (((data[17] * 256 + data[18]) * 256 + data[19]) * 256 + data[20]);
                if (feederSpeed != 0)
                {
                    this.d_FeederSpd = (double)25172.0 / (double)feederSpeed;
                }
                else
                {
                    this.d_FeederSpd = 0.0;
                }

                // エンジン回転数（rpm）- buf[21,22,23,24]
                int engineRpm = (((data[21] * 256 + data[22]) * 256 + data[23]) * 256 + data[24]);
                if (engineRpm != 0)
                {
                    this.d_EngineRpm = (double)(300.0 * 100000.0) / (double)engineRpm;
                }
                else
                {
                    this.d_EngineRpm = 0.0;
                }

                // フィン指令値の受信データ - buf[25]
                // uc_RcvFinPos = (unsigned short)buf[25];
                this.uc_RcvFinPos = data[25];

                // 操向ポテンショ（AD変換値）- buf[26]
                // uc_SteerPotentio = (unsigned short)buf[26];
                this.uc_SteerPotentio = data[26];

                // 左右旋回関節の位置（AD変換値）- buf[27], buf[28]
                // us_LRPos = ((unsigned short)buf[27] << 8) + ((unsigned short)buf[28] & 0x00ff);
                this.us_LRPos = ((ushort)data[27] << 8) + ((ushort)data[28] & 0x00ff);

                // 上下旋回関節の位置（AD変換値）- buf[29], buf[30]
                // us_UDPos = ((unsigned short)buf[29] << 8) + ((unsigned short)buf[30] & 0x00ff);
                this.us_UDPos = ((ushort)data[29] << 8) + ((ushort)data[30] & 0x00ff);

                // 左右傾斜センサ（AD変換値）- buf[31, 32]
                // us_AdSuihei = ((unsigned short)buf[31] << 8) + ((unsigned short)buf[32] & 0x00ff);
                this.us_AdSuihei = ((ushort)data[31] << 8) + ((ushort)data[32] & 0x00ff);

                // 左シリンダポテンショ（AD変換値）- buf[33, 34]
                // us_AdLeftCylinder = ((unsigned short)buf[33] << 8) + ((unsigned short)buf[34] & 0x00ff);
                this.us_AdLeftCylinder = ((ushort)data[33] << 8) + ((ushort)data[34] & 0x00ff);

                // 右シリンダポテンショ（AD変換値）- buf[35, 36]
                // us_AdRightCylinder = ((unsigned short)buf[35] << 8) + ((unsigned short)buf[36] & 0x00ff);
                this.us_AdRightCylinder = ((ushort)data[35] << 8) + ((ushort)data[36] & 0x00ff);

                // UTC時刻 - buf[37, 38, 39, 40]
                this.gps_Utc = (((data[40] * 256 + data[39]) * 256 + data[38]) * 256 + data[37]);

                // 北緯[for latitude] - buf[41~48]
                // http://msdn.microsoft.com/en-us/library/bb384066.aspx
                this.gps_bytes.Initialize();
                this.gps_bytes[0] = Convert.ToByte(data[41]);
                this.gps_bytes[1] = Convert.ToByte(data[42]);
                this.gps_bytes[2] = Convert.ToByte(data[43]);
                this.gps_bytes[3] = Convert.ToByte(data[44]);
                this.gps_bytes[4] = Convert.ToByte(data[45]);
                this.gps_bytes[5] = Convert.ToByte(data[46]);
                this.gps_bytes[6] = Convert.ToByte(data[47]);
                this.gps_bytes[7] = Convert.ToByte(data[48]);

                this.gps_Latitude = BitConverter.ToDouble(this.gps_bytes, 0);

                // 東経[for longitude] - buf[49~56]
                this.gps_bytes.Initialize();
                this.gps_bytes[0] = Convert.ToByte(data[49]);
                this.gps_bytes[1] = Convert.ToByte(data[50]);
                this.gps_bytes[2] = Convert.ToByte(data[51]);
                this.gps_bytes[3] = Convert.ToByte(data[52]);
                this.gps_bytes[4] = Convert.ToByte(data[53]);
                this.gps_bytes[5] = Convert.ToByte(data[54]);
                this.gps_bytes[6] = Convert.ToByte(data[55]);
                this.gps_bytes[7] = Convert.ToByte(data[56]);

                this.gps_Longitude = BitConverter.ToDouble(this.gps_bytes, 0);

                // 高度[for altitude] - buf[57~64]
                this.gps_bytes.Initialize();
                this.gps_bytes[0] = Convert.ToByte(data[57]);
                this.gps_bytes[1] = Convert.ToByte(data[58]);
                this.gps_bytes[2] = Convert.ToByte(data[59]);
                this.gps_bytes[3] = Convert.ToByte(data[60]);
                this.gps_bytes[4] = Convert.ToByte(data[61]);
                this.gps_bytes[5] = Convert.ToByte(data[62]);
                this.gps_bytes[6] = Convert.ToByte(data[63]);
                this.gps_bytes[7] = Convert.ToByte(data[64]);

                this.gps_Altitude = BitConverter.ToDouble(this.gps_bytes, 0);

                // 方位[for heading] - buf[65~72]
                this.gps_bytes.Initialize();
                this.gps_bytes[0] = Convert.ToByte(data[65]);
                this.gps_bytes[1] = Convert.ToByte(data[66]);
                this.gps_bytes[2] = Convert.ToByte(data[67]);
                this.gps_bytes[3] = Convert.ToByte(data[68]);
                this.gps_bytes[4] = Convert.ToByte(data[69]);
                this.gps_bytes[5] = Convert.ToByte(data[70]);
                this.gps_bytes[6] = Convert.ToByte(data[71]);
                this.gps_bytes[7] = Convert.ToByte(data[72]);

                this.gps_Heading = BitConverter.ToDouble(this.gps_bytes, 0);

                // gps quality
                // gpsinfodata.qlty =  buf[74];
                this.gps_Quality = data[74];

                // gps sv
                // gpsinfodata.sv =  buf[75];
                this.gps_Sv = data[75];

                rValue = true;
            }
            else
            {
                rValue = false;
            }

            return rValue;
        }

        #endregion
    }
}
