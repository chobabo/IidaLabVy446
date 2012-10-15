using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FieldMap
{
    public class Wgs84ToCartesian
    {
        #region constructor

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="_zone"></param>
        /// <param name="_param"></param>
        public Wgs84ToCartesian(int _zone, int _param) 
        {
            this.zone = _zone;
            this.parameter = _param;

            this.InitializeConstValue();
        }

        #endregion

        #region fields

        /// <summary>
        /// Cartesian Coordinates
        /// </summary>
        public struct Cartesian
        {
            public double x;
            public double y;
            public double z;

            public Cartesian(double _x, double _y, double _z)
            {
                this.x = _x;
                this.y = _y;
                this.z = _z;
            }
        }

        /// <summary>
        /// Gps data
        /// </summary>
        public struct Gps
        {
            public double latitude;
            public double longitude;
            public double altitude;

            public Gps(double _lat, double _lon, double _alt)
            {
                this.latitude = _lat;
                this.longitude = _lon;
                this.altitude = _alt;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private double a { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double a84 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double f84 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double f_tokyo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double e2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double e12 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double m0 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int zone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int parameter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int datum { get; set; }

        /// <summary>
        /// coefficient for equation#1
        /// </summary>
        private double[] A_coef;

        /// <summary>
        /// coefficient for equation#2
        /// </summary>
        private double[] B_coef;

        /// <summary>
        /// coefficient for equation#3
        /// </summary>
        private double[] C_coef;

        /// <summary>
        /// zone origin for latitude
        /// </summary>
        private double[] B_origin;

        /// <summary>
        /// zone origin for longitude
        /// </summary>
        private double[] L_origin;

        /// <summary>
        /// result of Cartesian coordinates
        /// </summary>
        public Cartesian result;

        #endregion

        #region methods 

        /// <summary>
        /// Wgs84 to Cartesian coordinates
        /// STEP 1 : WGS-84 to XYZ
        /// STEP 2 : WGS-84 to TOKYO
        /// STEP 3 : XYZ to LAT_LON_ALT
        /// </summary>
        /// <param name="_lat">latitude of wgs84 type</param>
        /// <param name="_lon">longitude of wgs84 type</param>
        /// <param name="_alt">altitude of wgs84 type</param>
        public void Wgs84ToXyh(double _lat, double _lon, double _alt)
        {
            // STEP 1 : WGS-84 to XYZ
            this.datum = 1;
            Cartesian c = this.DmsToXyz(_lat, _lon, _alt);

            // STEP 2 : WGS-84 to TOKYO
            Cartesian t = this.Wgs84ToTokyo(c);

            // STEP 3 : XYZ to LAT_LON_ALT
            this.datum = 2;
            Gps g = this.CartesianToGps(t);
            this.result.z = g.altitude;

            // Result
            Cartesian r = this.GpsToCartesian(g);
            this.result.x = r.x;
            this.result.y = r.y;
        }

        /// <summary>
        /// Initialize Constant Value
        /// </summary>
        private void InitializeConstValue()
        {
            // 東京測地系に変換するためのパラメータ
            this.a = 6377397.155;
            this.a84 = 6378137.0;
            this.f84 = 0.00335281066474748;
            this.f_tokyo = 0.00334277318;
            this.e2 = 0.006674372231;
            this.e12 = 0.006719218798;
            this.m0 = 0.9999;

            this.A_coef = new double[]
            {
                6366742.52024116306,     -15988.6385238568588,
                16.7299538817284,        -0.0217848007897,
                0.0000307730631,         -0.0000000453374,
		        0.0000000000685,         -0.0000000000001
            };

            this.B_coef = new double[]
            {
                -64.7467764,         217.0549893,
                -283.3714576,        210.1702756,
		        -156.901395,        -637.6283903,
		         8326.0282307,      -39421.8126979,
		         81936.0763069,      9950730.8889188
            };

            this.C_coef = new double[]
            {
                -0.00000203933504,   0.00000254941046,
                 0.00001390414031,  -0.00008117092029,
		         0.000372749204,    -0.001796898478,
		         0.006708984087,    -0.01313066154,
		         1.578708908847
            };

            this.B_origin = new double[]
            {
                33, 33, 36, 33, 36, 36,
                36, 36, 36, 40, 44, 44,
			    44, 26, 26, 26, 26
            };

            this.L_origin = new double[]
            {
                129.5,              131,                132.166666666667, 
                133.5,              134.333333333333,   136, 
                137.166666666667,   138.5,              139.833333333333, 
                140.833333333333,   140.25,             142.25, 
                144.25,             142,                127.5, 
                124,                131
            };
        }

        /// <summary>
        /// STEP 1 : WGS-84 to XYZ
        /// </summary>
        /// <param name="_lat">latitude</param>
        /// <param name="_lon">longitude</param>
        /// <param name="_alt">altidute</param>
        /// <returns>Cartesian coordinates</returns>
        private Cartesian DmsToXyz(double _lat, double _lon, double _alt)
        {
            Cartesian c;

            double e_square = 0.0;
            double N = 0.0;
            double f = 0.0;
            double adms = 0.0;

            switch (this.datum)
            {
                case 1:
                    // WGS-84
                    adms = this.a84;
                    f = this.f84;
                    break;

                case 2:
                    // tokyo datum
                    adms = this.a;
                    f = this.f_tokyo;
                    break;
            }

            e_square = f * (2.0 - f);
            N = adms / Math.Sqrt(1.0 - e_square * Math.Pow(Math.Sin(_lat), 2.0));

            c.x = (N + _alt) * Math.Cos(_lat) * Math.Cos(_lon);
            c.y = (N + _alt) * Math.Cos(_lat) * Math.Sin(_lon);
            c.z = (N * (1.0 - e_square) + _alt) * Math.Sin(_lat);

            return c;
        }

        /// <summary>
        /// STEP 2 : WGS-84 to TOKYO
        /// </summary>
        /// <param name="c">cartesian coordinates</param>
        /// <returns>cartesian coordinates</returns>
        private Cartesian Wgs84ToTokyo(Cartesian c)
        {
            Cartesian result;
            result.x = 0.0;
            result.y = 0.0;
            result.z = 0.0;

            switch (this.parameter)
            { 
                case 1:
                    // new parameter
                    result.x = c.x + 147.54;
                    result.y = c.y - 507.26;
                    result.z = c.z - 680.47;
                    break;

                case 2:
                    // old parameter
                    result.x = c.x + 146.43;
                    result.y = c.y - 507.89;
                    result.z = c.z - 681.46;
                    break;
            }

            return result;
        }
        
        /// <summary>
        /// STEP 3 : XYZ to LAT_LON_ALT
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private Gps CartesianToGps(Cartesian c)
        {
            Gps g;
            g.altitude = 0.0;
            g.latitude = 0.0;
            g.longitude = 0.0;

            double b_dash = 0.0;
            double P = 0.0;
            double theta = 0.0;
            double E_square = 0.0;
            double E_square_dash = 0.0;
            double neu = 0.0;
            double f = 0.0;
            double adms = 0.0;

            switch (this.datum)
            {
                case 1:
                    // WGS-84
                    adms = this.a84;
                    f = this.f84;
                    break;

                case 2:
                    // tokyo datum
                    adms = this.a;
                    f = f_tokyo;
                    break;
            }

            b_dash = adms * (1.0 - f);
            P = Math.Sqrt(Math.Pow(c.x, 2.0) + Math.Pow(c.y, 2.0));
            theta = Math.Atan((c.z * adms) / (P * b_dash));
            E_square = (adms * adms - b_dash * b_dash) / (adms * adms);
            E_square_dash = (adms * adms - b_dash * b_dash) / (b_dash * b_dash);

            g.latitude =
                Math.Atan((c.z + E_square_dash * b_dash * Math.Pow(Math.Sin(theta), 3.0))
                / (P - E_square * adms * Math.Pow(Math.Cos(theta), 3.0)));

            g.longitude = Math.Atan(c.y / c.x) + Math.PI;
            
            neu = adms / Math.Sqrt(1.0 - E_square * Math.Pow(Math.Sin(g.latitude), 2.0));
            g.altitude = P / Math.Cos(g.latitude) - neu;

            return g;
        }

        /// <summary>
        /// Convert Gps data to Cartesian coordinates
        /// </summary>
        /// <param name="g">gps data</param>
        /// <returns>cartesian coordinates</returns>
        private Cartesian GpsToCartesian(Gps g)
        {
            Cartesian result;
            result.x = 0.0;
            result.y = 0.0;
            result.z = 0.0;

            double dl, dx, mx0;
            double et2, w, N, tn2;
            double x2, x4, x6, x8, y1, y3, y5, y7;
            double B0, L0;
            double sinb, cosb, tanb;
            double M, m;

            B0 = this.B_origin[this.zone] * Math.PI / 180.0;
            L0 = this.L_origin[this.zone] * Math.PI / 180.0;
            dl = g.longitude - L0;

            cosb = Math.Cos(g.latitude);
            sinb = Math.Sin(g.latitude);
            tanb = Math.Tan(g.latitude);
            mx0 = this.mx(B0);
            dx = mx(g.latitude) - mx0;

            et2 = e12 * Math.Pow(cosb, 2.0);
            w = 1.0 - e2 * Math.Pow(sinb, 2.0);
            N = a / Math.Pow(w, 0.5);
            M = N * (1.0 - e2) / w;
            tn2 = Math.Pow(tanb, 2.0);

            x2 = N * sinb * cosb * Math.Pow(dl, 2.0) / 2.0;
            x4 = N * sinb * Math.Pow(cosb, 3.0) *
                (5.0 - tn2 + 9.0 * et2 + 4.0 * Math.Pow(et2, 2.0)) * Math.Pow(dl, 4.0) / 24.0;
            x6 = N * sinb * Math.Pow(cosb, 5.0) *
                (61.0 - 58.0 * tn2 + Math.Pow(tn2, 2.0) + 270.0 * et2 - 330.0 * tn2 * et2) *
                Math.Pow(dl, 6.0) / 720.0;
            x8 = N * sinb * Math.Pow(cosb, 7.0) *
                (1385.0 - 3111.0 * tn2 + 543.0 * Math.Pow(tn2, 2.0) - Math.Pow(tn2, 3.0)) *
                Math.Pow(dl, 8.0) / 40320.0;
            result.x = m0 * (x8 + x6 + x4 + x2 + dx);

            y1 = N * cosb * dl;
            y3 = N * Math.Pow(cosb, 3.0) * (1.0 - tn2 + et2) * Math.Pow(dl, 3.0) / 6.0;
            y5 = N * Math.Pow(cosb, 5.0) *
                (5.0 - 18.0 * tn2 + Math.Pow(tn2, 2.0) + 14.0 * et2 - 58.0 * tn2 * et2) *
                Math.Pow(dl, 5.0) / 120.0;
            y7 = N * Math.Pow(cosb, 7.0) *
                (61.0 - 479.0 * tn2 + 179.0 * Math.Pow(tn2, 2.0) - Math.Pow(tn2, 3.0)) *
                Math.Pow(dl, 7.0) / 5040.0;
            result.y = m0 * (y7 + y5 + y3 + y1);

            result.z = (sinb * dl + sinb * Math.Pow(cosb, 2.0) *
                (1.0 + 3.0 * et2) * Math.Pow(dl, 3.0) / 3.0);

            m = 1 + Math.Pow(cosb, 2.0) * (1.0 + Math.Sqrt(e12) * Math.Pow(cosb, 2.0)) *
                Math.Pow(dl, 2.0) / 2.0 + Math.Pow(cosb, 4.0) * (5.0 - Math.Pow(tanb, 2.0)) * Math.Pow(dl, 4.0) / 24;

            return result;
        }

        /// <summary>
        /// mx
        /// </summary>
        /// <param name="phi"></param>
        /// <returns></returns>
        private double mx(double phi)
        {
            double m = 0.0;

            m = this.A_coef[0] * phi;

            for (int i = 1; i < 8; i++)
            {
                m = m + this.A_coef[i] * Math.Sin(2.0 * phi * i);
            }

            return m;
        }

        #endregion
    }
}
