using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombineBody
{
    public class Vy446
    {
        #region fields

        /// <summary>
        /// AD_KARI_L - buf[2,3]
        /// </summary>
        public int AD_KARI_L { get; set; }

        /// <summary>
        /// AD_KARI_D - buf[4,5]
        /// </summary>
        public int AD_KARI_D { get; set; }

        /// <summary>
        /// AD_KARI_S - buf[6,7]
        /// </summary>
        public int AD_KARI_S { get; set; }

        /// <summary>
        /// SW_KARITAKA - buf[8]
        /// </summary>
        public int SW_KARITAKA { get; set; }

        /// <summary>
        /// AD_FEED_M - buf[8,9]
        /// </summary>
        public int AD_FEED_M { get; set; }

        /// <summary>
        /// AD_FEED_P - buf[8, 11]
        /// </summary>
        public int AD_FEED_P { get; set; }

        /// <summary>
        /// SW_FEED - buf[13]
        /// </summary>
        public int SW_FEED { get; set; }

        /// <summary>
        /// SW_KOGI - buf[14]
        /// </summary>
        public int SW_KOGI { get; set; }

        /// <summary>
        /// RV_FEED - buf[15~18]
        /// </summary>
        public ulong RV_FEED { get; set; }

        /// <summary>
        /// DT_FEED - buf[19]
        /// </summary>
        public int DT_FEED { get; set; }

        /// <summary>
        /// feed_rpm
        /// </summary>
        public double feed_rpm { get; set; }

        /// <summary>
        /// AD_SEN_D - buf[20,21]
        /// </summary>
        public int AD_SEN_D { get; set; }

        /// <summary>
        /// AD_SEN_A - buf[22,23]
        /// </summary>
        public int AD_SEN_A { get; set; }

        /// <summary>
        /// AD_SEN_FIN - buf[24,25]
        /// </summary>
        public int AD_SEN_FIN { get; set; }

        /// <summary>
        /// SW_SENBETSU - buf[26]
        /// </summary>
        public int SW_SENBETSU { get; set; }

        /// <summary>
        /// SW_CLUTCH - buf[27]
        /// </summary>
        public int SW_CLUTCH { get; set; }

        /// <summary>
        /// AD_AUG_MTR - buf[28,29]
        /// </summary>
        public int AD_AUG_MTR { get; set; }

        /// <summary>
        /// AD_AUG_CLD - buf[30, 31]
        /// </summary>
        public int AD_AUG_CLD { get; set; }

        /// <summary>
        /// SW_AUGER - buf[32]
        /// </summary>
        public int SW_AUGER { get; set; }

        /// <summary>
        /// AD_SOKO_A - buf[33, 34]
        /// </summary>
        public int AD_SOKO_A { get; set; }

        /// <summary>
        /// AD_SOKO_K - buf[35, 36]
        /// </summary>
        public int AD_SOKO_K { get; set; }

        /// <summary>
        /// DT_SOKO - buf[37, 38]
        /// </summary>
        public int DT_SOKO { get; set; }

        /// <summary>
        /// SW_SOKO - buf[39]
        /// </summary>
        public int SW_SOKO { get; set; }

        /// <summary>
        /// RV_ENGINE - buf[40~43]
        /// </summary>
        public ulong RV_ENGINE { get; set; }

        /// <summary>
        /// DT_ENGINE - buf[44]
        /// </summary>
        public int DT_ENGINE { get; set; }

        /// <summary>
        /// engine rpm
        /// </summary>
        public double rpm { get; set; }

        /// <summary>
        /// RV_MISSION - buf[45~48]
        /// </summary>
        public ulong RV_MISSION { get; set; }

        /// <summary>
        /// OD_MISSION - buf[49,50]
        /// </summary>
        public int OD_MISSION { get; set; }

        /// <summary>
        /// DT_MISSION - buf[51]
        /// </summary>
        public int DT_MISSION { get; set; }

        /// <summary>
        /// Vehicle speed
        /// </summary>
        public double speed { get; set; }

        /// <summary>
        /// AD_SUI_K - buf[52,53]
        /// </summary>
        public int AD_SUI_K { get; set; }

        /// <summary>
        /// AD_SUI_R - buf[54,55]
        /// </summary>
        public int AD_SUI_R { get; set; }

        /// <summary>
        /// AD_SUI_L - buf[56,57]
        /// </summary>
        public int AD_SUI_L { get; set; }

        /// <summary>
        /// SW_SUIHEI - buf[58]
        /// </summary>
        public int SW_SUIHEI { get; set; }

        /// <summary>
        /// DT_ECODE - buf[59,60]
        /// </summary>
        public int DT_ECODE { get; set; }

        /// <summary>
        /// DT_CHK_E - buf[61,62]
        /// </summary>
        public int DT_CHK_E { get; set; }

        /// <summary>
        /// SW_WARNING - buf[63]
        /// </summary>
        public int SW_WARNING { get; set; }

        /// <summary>
        /// SW_WR_MOMI - buf[64]
        /// </summary>
        public int SW_WR_MOMI { get; set; }

        /// <summary>
        /// DT_STEER - buf[65,66]
        /// </summary>
        public int DT_STEER { get; set; }

        /// <summary>
        /// DT_ROBOT_A0 - buf[67]
        /// </summary>
        public int DT_ROBOT_A0 { get; set; }

        /// <summary>
        /// DT_ROBOT_A1 - buf[68]
        /// </summary>
        public int DT_ROBOT_A1 { get; set; }

        /// <summary>
        /// DT_HST - buf[69,70]
        /// </summary>
        public int DT_HST { get; set; }

        /// <summary>
        /// DT_PATLITE - buf[71]
        /// </summary>
        public int DT_PATLITE { get; set; }

        /// <summary>
        /// DT_SW_KILL - buf[72]
        /// </summary>
        public int DT_SW_KILL { get; set; }

        /// <summary>
        /// DT_AUG_MTR - buf[73,74]
        /// </summary>
        public int DT_AUG_MTR { get; set; }

        /// <summary>
        /// DT_AUG_CLD - buf[75,76]
        /// </summary>
        public int DT_AUG_CLD { get; set; }

        /// <summary>
        /// RESERVE_B - buf[77,78]
        /// </summary>
        public int RESERVE_B { get; set; }

        /// <summary>
        /// DT_ROBOT_B0 - buf[79]
        /// </summary>
        public int DT_ROBOT_B0 { get; set; }

        /// <summary>
        /// DT_ROBOT_B1 - buf[80]
        /// </summary>
        public int DT_ROBOT_B1 { get; set; }

        /// <summary>
        /// byte array to double using bitconverter
        /// </summary>
        private byte[] gps_eight_bytes;

        /// <summary>
        /// byte array to double using bitconverter
        /// </summary>
        private byte[] gps_four_bytes;

        /// <summary>
        /// Degree to Radian
        /// </summary>
        private double DEG2RAD { get; set; }

        /// <summary>
        /// UTC - buf[81~84]
        /// </summary>
        public double gps_Utc { get; set; }

        /// <summary>
        /// Latitude - buf[85~92]
        /// </summary>
        public double gps_Latitude { get; set; }

        /// <summary>
        /// Longitude - buf[93~100]
        /// </summary>
        public double gps_Longitude { get; set; }

        /// <summary>
        /// Altitude - buf[101~108]
        /// </summary>
        public double gps_Altitude { get; set; }

        /// <summary>
        /// 基準点 - buf[109]
        /// </summary>
        public int gps_Zone { get; set; }

        /// <summary>
        /// 品質 - buf[110]
        /// </summary>
        public int gps_Quality { get; set; }

        /// <summary>
        /// GPS compass
        /// </summary>
        public double gps_Compass { get; set; }

        /// <summary>
        /// コンバインの進行方向角[度],±180度の範囲
        /// 真東を0度，反時計回りを＋にとる。
        /// </summary>
        public double gps_hdg { get; set; }

        /// <summary>
        /// 衛星数 - buf[111]
        /// </summary>
        public int gps_Sv { get; set; }

        /// <summary>
        /// FO出力データ処理, speed - buf[112~115]
        /// </summary>
        public double Fo_Speed { get; set; }

        /// <summary>
        /// pitch
        /// </summary>
        public double pitch { get; set; }

        /// <summary>
        /// roll
        /// </summary>
        public double roll { get; set; }

        /// <summary>
        /// heading
        /// </summary>
        public double heading { get; set; }

        /// <summary>
        /// compass
        /// </summary>
        public double compass { get; set; }

        /// <summary>
        /// Avilability
        /// </summary>
        public int avilability { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// basic constructor
        /// </summary>
        public Vy446()
        {
            this.gps_eight_bytes = new byte[8];
            this.gps_four_bytes = new byte[4];
            this.DEG2RAD = Math.PI / 180.0;
        }
        
        #endregion

        #region methods

        /// <summary>
        /// RS-232Cポートから受信したコンバイン（VY446）データを各パラメータに代入。
        /// </summary>
        /// <param name="data">buffered data</param>
        /// <returns></returns>
        public bool TokenData(List<int> data)
        {
            bool rValue = false;

            if (data.Count == 142 && data[0] == 205 && data[data.Count - 1] == 10)
            {
                // AD_KARI_L
                // vy446rcvdata.AD_KARI_L = ((unsigned short)buf[3] << 8) + (unsigned short)buf[2];
                this.AD_KARI_L = ((ushort)data[3] << 8) + (ushort)data[2];

                // AD_KARI_D
                // vy446rcvdata.AD_KARI_D = ((unsigned short)buf[5] << 8) + (unsigned short)buf[4];
                this.AD_KARI_D = ((ushort)data[5] << 8) + (ushort)data[4];

                // AD_KARI_S
                // vy446rcvdata.AD_KARI_S = ((unsigned short)buf[7] << 8) + (unsigned short)buf[6];
                this.AD_KARI_S = ((ushort)data[7] << 8) + (ushort)data[6];

                // SW_KARITAKA
                // vy446rcvdata.SW_KARITAKA = (unsigned char)buf[8];
                this.SW_KARITAKA = data[8];

                // AD_FEED_M
                // vy446rcvdata.AD_FEED_M = ((unsigned short)buf[10] << 8) + (unsigned short)buf[9];
                this.AD_FEED_M = ((ushort)data[10] << 8) + (ushort)data[9];

                // AD_FEED_P
                // vy446rcvdata.AD_FEED_P = ((unsigned short)buf[12] << 8) + (unsigned short)buf[11];
                this.AD_FEED_P = ((ushort)data[12] << 8) + (ushort)data[11];

                // SW_FEED
                // vy446rcvdata.SW_FEED = (unsigned char)buf[13];
                this.SW_FEED = data[13];

                // SW_KOGI
                // vy446rcvdata.SW_KOGI = (unsigned char)buf[14];
                this.SW_KOGI = data[14];

                // RV_FEED
                this.RV_FEED = ((ulong)data[15] << 0) +
                    ((ulong)data[16] << 8) +
                    ((ulong)data[17] << 16) +
                    ((ulong)data[18] << 24);
                
                // DT_FEED
                // vy446rcvdata.DT_FEED = (unsigned char)buf[19];
                this.DT_FEED = data[19];

                // Calculate Feed RPM
                if ((this.DT_FEED & 0x01) == 0x01)
                {
                    this.feed_rpm = (ushort)((double)1000000.0 * 60.0 / (double)this.RV_FEED);
                }
                else
                {
                    this.feed_rpm = 0;
                }

                // AD_SEN_D
                // vy446rcvdata.AD_SEN_D = ((unsigned short)buf[21] << 8) + (unsigned short)buf[20];
                this.AD_SEN_D = ((ushort)data[21] << 8) + (ushort)data[20];

                // AD_SEN_A 
                // vy446rcvdata.AD_SEN_A = ((unsigned short)buf[23] << 8) + (unsigned short)buf[22];
                this.AD_SEN_A = ((ushort)data[23] << 8) + (ushort)data[22];

                // AD_SEN_FIN
                // vy446rcvdata.AD_SEN_FIN = ((unsigned short)buf[25] << 8) + (unsigned short)buf[24];
                this.AD_SEN_FIN = ((ushort)data[25] << 8) + (ushort)data[24];

                // SW_SENBETSU
                // vy446rcvdata.SW_SENBETSU = (unsigned char)buf[26];
                this.SW_SENBETSU = data[26];

                // SW_CLUTCH
                // vy446rcvdata.SW_CLUTCH = (unsigned char)buf[27];
                this.SW_CLUTCH = data[27];

                // AD_AUG_MTR
                // vy446rcvdata.AD_AUG_MTR = ((unsigned short)buf[29] << 8) + (unsigned short)buf[28];
                this.AD_AUG_MTR = ((ushort)data[29] << 8) + (ushort)data[28];

                // AD_AUG_CLD
                // vy446rcvdata.AD_AUG_CLD = ((unsigned short)buf[31] << 8) + (unsigned short)buf[30];
                this.AD_AUG_CLD = ((ushort)data[31] << 8) + (ushort)data[30];

                // SW_AUGER
                // vy446rcvdata.SW_AUGER = (unsigned char)buf[32];
                this.SW_AUGER = data[32];

                // AD_SOKO_A
                // vy446rcvdata.AD_SOKO_A = ((unsigned short)buf[34] << 8) + (unsigned short)buf[33];
                this.AD_SOKO_A = ((ushort)data[34] << 8) + (ushort)data[33];

                // AD_SOKO_K
                // vy446rcvdata.AD_SOKO_K = ((unsigned short)buf[36] << 8) + (unsigned short)buf[35];
                this.AD_SOKO_K = ((ushort)data[36] << 8) + (ushort)data[35];

                // DT_SOKO
                // vy446rcvdata.DT_SOKO = ((unsigned short)buf[38] << 8) + (unsigned short)buf[37];
                this.DT_SOKO = ((ushort)data[38] << 8) + (ushort)data[37];

                // SW_SOKO
                // vy446rcvdata.SW_SOKO = (unsigned char)buf[39];
                this.SW_SOKO = data[39];

                // RV_ENGINE
                this.RV_ENGINE = ((ulong)data[40] << 0) +
                    ((ulong)data[41] << 8) +
                    ((ulong)data[42] << 16) +
                    ((ulong)data[43] << 24);

                // DT_ENGINE
                // vy446rcvdata.DT_ENGINE = (unsigned char)buf[44];
                this.DT_ENGINE = data[44];

                // Calculate Engine RPM
                if ((this.DT_ENGINE & 0x02) != 0x02)
                {
                    this.rpm = (ushort)((double)1000000.0 * 60.0 / (double)this.RV_ENGINE);
                }
                else
                {
                    this.rpm = 0;
                }

                // RV_MISSION
                this.RV_MISSION = ((ulong)data[45] << 0) +
                    ((ulong)data[46] << 8) +
                    ((ulong)data[47] << 16) +
                    ((ulong)data[48] << 24);

                // OD_MISSION
                //vy446rcvdata.OD_MISSION = ((unsigned short)buf[50] << 8) + (unsigned short)buf[49];
                this.OD_MISSION = ((ushort)data[50] << 8) + (ushort)data[49];

                // DT_MISSION
                // vy446rcvdata.DT_MISSION = (unsigned char)buf[51];
                this.DT_MISSION = data[51];

                // Calculate speed
                if ((this.DT_MISSION & 0x01) == 0x01)
                {
                    this.speed = ((double)1000000.0 * 60.0 * 1.251) / ((double)this.RV_MISSION * 1140.0);
                }
                else
                {
                    this.speed = 0.0;
                }

                int HST_Neutral = 1405;
                if ((this.AD_FEED_M << 2) < (HST_Neutral - 20) && speed != 0.0)
                { 
                    speed = -speed; 
                }

                // AD_SUI_K
                // vy446rcvdata.AD_SUI_K = ((unsigned short)buf[53] << 8) + (unsigned short)buf[52];
                this.AD_SUI_K = ((ushort)data[53] << 8) + (ushort)data[52];

                // AD_SUI_R
                // vy446rcvdata.AD_SUI_R = ((unsigned short)buf[55] << 8) + (unsigned short)buf[54];
                this.AD_SUI_R = ((ushort)data[55] << 8) + (ushort)data[54];

                // AD_SUI_L
                // vy446rcvdata.AD_SUI_L = ((unsigned short)buf[57] << 8) + (unsigned short)buf[56];
                this.AD_SUI_L = ((ushort)data[57] << 8) + (ushort)data[56];

                // SW_SUIHEI
                // vy446rcvdata.SW_SUIHEI = (unsigned char)buf[58];
                this.SW_SUIHEI = data[58];

                // DT_ECODE
                // vy446rcvdata.DT_ECODE = ((unsigned short)buf[60] << 8) + (unsigned short)buf[59];
                this.DT_ECODE = ((ushort)data[60] << 8) + (ushort)data[59];

                // DT_CHK_E
                // vy446rcvdata.DT_CHK_E = ((unsigned short)buf[62] << 8) + (unsigned short)buf[61];
                this.DT_CHK_E = ((ushort)data[62] << 8) + (ushort)data[61];

                // SW_WARNING
                // vy446rcvdata.SW_WARNING = (unsigned char)buf[63];
                this.SW_WARNING = data[63];

                // SW_WR_MOMI
                // vy446rcvdata.SW_WR_MOMI = (unsigned char)buf[64];
                this.SW_WR_MOMI = data[64];

                // DT_STEER
                // vy446rcvdata.DT_STEER = ((unsigned short)buf[66] << 8) + (unsigned short)buf[65];
                this.DT_STEER = ((ushort)data[66] << 8) + (ushort)data[65];

                // DT_ROBOT_A0
                // vy446rcvdata.DT_ROBOT_A0 = (unsigned char)buf[67];
                this.DT_ROBOT_A0 = data[67];

                // DT_ROBOT_A1
                // vy446rcvdata.DT_ROBOT_A1 = (unsigned char)buf[68];
                this.DT_ROBOT_A1 = data[68];

                // DT_HST
                // vy446rcvdata.DT_HST = ((unsigned short)buf[70] << 8) + (unsigned short)buf[69];
                this.DT_HST = ((ushort)data[70] << 8) + (ushort)data[69];

                // DT_PATLITE
                // vy446rcvdata.DT_PATLITE = (unsigned char)buf[71];
                this.DT_PATLITE = data[71];

                // DT_SW_KILL
                // vy446rcvdata.DT_SW_KILL = (unsigned char)buf[72];
                this.DT_SW_KILL = data[72];

                // DT_AUG_MTR
                // vy446rcvdata.DT_AUG_MTR = ((unsigned short)buf[74] << 8) + (unsigned short)buf[73];
                this.DT_AUG_MTR = ((ushort)data[74] << 8) + (ushort)data[73];

                // DT_AUG_CLD
                // vy446rcvdata.DT_AUG_CLD = ((unsigned short)buf[76] << 8) + (unsigned short)buf[75];
                this.DT_AUG_CLD = ((ushort)data[76] << 8) + (ushort)data[75];

                // RESERVE_B
                // vy446rcvdata.DT_KARITAKA = ((unsigned short)buf[78] << 8) + (unsigned short)buf[77];
                this.RESERVE_B = ((ushort)data[78] << 8) + (ushort)data[77];

                // DT_ROBOT_B0
	            // vy446rcvdata.DT_ROBOT_B0 = (unsigned char)buf[79];
                this.DT_ROBOT_B0 = data[79];

	            // DT_ROBOT_B1
	            // vy446rcvdata.DT_ROBOT_B1 = (unsigned char)buf[80];
                this.DT_ROBOT_B1 = data[80];

                // ----------------- //
                // GGA出力データ処理 //
                // ----------------- //

                // UTC
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[81]);
                this.gps_four_bytes[1] = Convert.ToByte(data[82]);
                this.gps_four_bytes[2] = Convert.ToByte(data[83]);
                this.gps_four_bytes[3] = Convert.ToByte(data[84]);

                // 前進と後退の方向が反対のため。
                this.gps_Utc = BitConverter.ToSingle(this.gps_four_bytes, 0) * 0.1;

                // Latitude
                this.gps_eight_bytes.Initialize();
                this.gps_eight_bytes[0] = Convert.ToByte(data[85]);
                this.gps_eight_bytes[1] = Convert.ToByte(data[86]);
                this.gps_eight_bytes[2] = Convert.ToByte(data[87]);
                this.gps_eight_bytes[3] = Convert.ToByte(data[88]);
                this.gps_eight_bytes[4] = Convert.ToByte(data[89]);
                this.gps_eight_bytes[5] = Convert.ToByte(data[90]);
                this.gps_eight_bytes[6] = Convert.ToByte(data[91]);
                this.gps_eight_bytes[7] = Convert.ToByte(data[92]);

                double tmpLat = BitConverter.ToDouble(this.gps_eight_bytes, 0);
                this.gps_Latitude = this.DDMMSSToDecimalDegrees(tmpLat);

                // Longitude
                this.gps_eight_bytes.Initialize();
                this.gps_eight_bytes[0] = Convert.ToByte(data[93]);
                this.gps_eight_bytes[1] = Convert.ToByte(data[94]);
                this.gps_eight_bytes[2] = Convert.ToByte(data[95]);
                this.gps_eight_bytes[3] = Convert.ToByte(data[96]);
                this.gps_eight_bytes[4] = Convert.ToByte(data[97]);
                this.gps_eight_bytes[5] = Convert.ToByte(data[98]);
                this.gps_eight_bytes[6] = Convert.ToByte(data[99]);
                this.gps_eight_bytes[7] = Convert.ToByte(data[100]);

                double tmpLong = BitConverter.ToDouble(this.gps_eight_bytes, 0);
                this.gps_Longitude = this.DDMMSSToDecimalDegrees(tmpLong);

                // Altitude
                this.gps_eight_bytes.Initialize();
                this.gps_eight_bytes[0] = Convert.ToByte(data[101]);
                this.gps_eight_bytes[1] = Convert.ToByte(data[102]);
                this.gps_eight_bytes[2] = Convert.ToByte(data[103]);
                this.gps_eight_bytes[3] = Convert.ToByte(data[104]);
                this.gps_eight_bytes[4] = Convert.ToByte(data[105]);
                this.gps_eight_bytes[5] = Convert.ToByte(data[106]);
                this.gps_eight_bytes[6] = Convert.ToByte(data[107]);
                this.gps_eight_bytes[7] = Convert.ToByte(data[108]);

                double tmpAlt = BitConverter.ToDouble(this.gps_eight_bytes, 0);
                this.gps_Altitude = this.DDMMSSToDecimalDegrees(tmpAlt);

                // 基準点
                //gpsinfodata.zone = buf[109];
                this.gps_Zone = data[109];

                // 品質
                //gpsinfodata.qlty = buf[110];
                this.gps_Quality = data[110];

                // 衛星数
                //gpsinfodata.sv = buf[111]; 
                this.gps_Sv = data[111];

                // FO出力データ処理
                // Speed
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[112]);
                this.gps_four_bytes[1] = Convert.ToByte(data[113]);
                this.gps_four_bytes[2] = Convert.ToByte(data[114]);
                this.gps_four_bytes[3] = Convert.ToByte(data[115]);

                this.Fo_Speed = BitConverter.ToSingle(this.gps_four_bytes, 0);

                // Pitch
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[116]);
                this.gps_four_bytes[1] = Convert.ToByte(data[117]);
                this.gps_four_bytes[2] = Convert.ToByte(data[118]);
                this.gps_four_bytes[3] = Convert.ToByte(data[119]);

                this.pitch = BitConverter.ToSingle(this.gps_four_bytes, 0);

                // Roll
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[120]);
                this.gps_four_bytes[1] = Convert.ToByte(data[121]);
                this.gps_four_bytes[2] = Convert.ToByte(data[122]);
                this.gps_four_bytes[3] = Convert.ToByte(data[123]);

                this.roll = BitConverter.ToSingle(this.gps_four_bytes, 0);

                // Heading
                // 初期化したときの進行方向が0°，時計回りが+，-180°～+180°出力
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[124]);
                this.gps_four_bytes[1] = Convert.ToByte(data[125]);
                this.gps_four_bytes[2] = Convert.ToByte(data[126]);
                this.gps_four_bytes[3] = Convert.ToByte(data[127]);

                this.heading = BitConverter.ToSingle(this.gps_four_bytes, 0);

                // compass
                // 真北が0°，時計回りが+，-180°～+180°出力
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[128]);
                this.gps_four_bytes[1] = Convert.ToByte(data[129]);
                this.gps_four_bytes[2] = Convert.ToByte(data[130]);
                this.gps_four_bytes[3] = Convert.ToByte(data[131]);

                this.compass = BitConverter.ToSingle(this.gps_four_bytes, 0);

                // Avail
                this.avilability = data[132];

                // GPS compass
                // 真北が0°，時計回りが+，-180°～+180°出力
                this.gps_four_bytes.Initialize();
                this.gps_four_bytes[0] = Convert.ToByte(data[134]);
                this.gps_four_bytes[1] = Convert.ToByte(data[135]);
                this.gps_four_bytes[2] = Convert.ToByte(data[136]);
                this.gps_four_bytes[3] = Convert.ToByte(data[137]);

                double tmpCompass = BitConverter.ToSingle(this.gps_four_bytes, 0);

                // コンバインの方位[度],0-360度の範囲
                // 真北を0度，時計回りを＋にとる。
                if ((tmpCompass) >= 0.0 && (tmpCompass) <= 90.0)
                {
                    this.gps_Compass = (tmpCompass) + 270.0;
                }
                else
                {
                    this.gps_Compass = (tmpCompass) - 90.0;
                }

                // コンバインの進行方向角[度],±180度の範囲
                // 真東を0度，反時計回りを＋にとる。
                //gpsinfodata.hdg = 180.0 - (*fdata);
                this.gps_hdg = 180.0 - tmpCompass;

                rValue = true;
            }
            else
            {
                rValue = false;
            }

            return rValue;
        }

        /// <summary>
        /// convert GPGGA data to Latitude and Longitude of double type
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double DDMMSSToDecimalDegrees(double data)
        {
            var ddmmss = (Convert.ToDouble(data) / 100);

            var degrees = (int)ddmmss;

            var minutesseconds = ((ddmmss - degrees) * 100) / 60.0;

            return degrees + minutesseconds;
        }

        #endregion
    }
}
