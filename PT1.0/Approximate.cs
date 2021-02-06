using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT1._0
{

    class Approximate
    {
        double Sa = 0.9842, Sb = 6 * Math.Pow(10, -3);
        double A1 = 1.001204081632646, A2 = -4.489795918366757 * Math.Pow(10, -4);
        double B1 = -0.0531365, B2 = 7.6075 * Math.Pow(10, -4), B3 = -3.29 * Math.Pow(10, -6);
        double n1 = 1.0000690138, n2 = 9.4639132794 * Math.Pow(10, -4), n3 = 1.0212596821 * Math.Pow(10, -4), n4 = 0.0242908155, n5 = -0.0243161388;
        double n6 = -1.1658340334 * Math.Pow(10, -4), n7 = 4.1843678352 * Math.Pow(10, -3), n8 = -3.8347857082 * Math.Pow(10, -3);
        double n9 = 2.1071486193 * Math.Pow(10, -5), n10 = -9.9021574169 * Math.Pow(10, -4), n11 = 6.4262805456 * Math.Pow(10, -4), n12 = -1.4462650526 * Math.Pow(10, -6);
        double n13 = 7.4270466426 * Math.Pow(10, -5), n14 = -1.8892763814 * Math.Pow(10, -5), n15 = 4.2429546068 * Math.Pow(10, -8), n16 = -2.4885486018 * Math.Pow(10, -6);
        double n17 = -7.0642642523 * Math.Pow(10, -7), n18 = -4.3745349 * Math.Pow(10, -10), n19 = 3.1937181 * Math.Pow(10, -8), n20 = 3.0781041 * Math.Pow(10, -8);
        double sn1 = 0.00001500, sn2 = -0.00067075, sn3 = 0.01047392, sn4 = 0.99930143;

        double a1 = -0.0105802099;
        double a2 = 5.2914055287 * Math.Pow(10, -4);
        double a3 = 0.7595464534;
        double a4 = -0.0309941492;
        double a5 = 4.6203729626 * Math.Pow(10, -4);
        double a6 = -2.9217992057 * Math.Pow(10, -6);
        double a7 = 6.7806217566 * Math.Pow(10, -9);
        double c0 = -1.1113011;
        double c1 = 17.2945233;
        double c2 = -47.9903187;
        double c3 = 62.3874753;
        double c4 = -41.4154483;
        double c5 = 13.6937465;
        double c6 = -1.7932637;
        double z0 = 46.3809530183;
        double z1 = -0.473009434;
        double z2 = 0.9939961423;
        double b0 = 1.3591691758;
        double b1 = -0.6045418637;
        double b2 = 0.9840719584;
        double[] Xx = new double[13] { 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150 };
        double[] Xy = new double[13] { 0.29, 0.4, 0.58, 0.76, 0.89, 0.95, 1, 0.96, 0.9, 0.78, 0.6, 0.42, 0.3 };
        double z10 = 0.16, z11 = -1.205, z12 = 0.684;
        double z20 = 0.178, z21 = -1.319, z22 = 0.691;
        double z30 = 0.166, z31 = -0.823, z32 = 0.721;
        double z40 = 0.181, z41 = -0.762, z42 = 0.726;
        double z50 = 0.985, z51 = -0.036;
        double z60 = 0.991, z61 = -0.024;

        double[] l1 = new double[6] { 0.065, 0.13, 0.185, 0.24, 0.29, 0.35 };
        double[] l2 = new double[6] { 0.02, 0.08, 0.14, 0.2, 0.26, 0.32 };
        double[] l3 = new double[6] { 0, 0.025, 0.09, 0.16, 0.23, 0.29 };
        double[] l4 = new double[6] { 0, 0, 0.03, 0.11, 0.18, 0.26 };
        double[] l5 = new double[6] { 0, 0, 0, 0.04, 0.12, 0.2 };
        double[] l6 = new double[6] { 0, 0, 0, 0, 0.045, 0.14 };
        double[] l7 = new double[6] { 0, 0, 0, 0, 0, 0.07 };

        double kp004 = 1, kp01 = 0.9, kp04 = 0.78, kp06 = 0.74, kp1 = 0.68, kp4 = 0.54, kp6 = 0.52, kp10 = 0.46, kp40 = 0.34;

        
        /*
         * ВЫЧИСЛЕНИЕ КОЭФФИЦИЕНТА РАСХОДА ДЛЯ СОПЛОВЫХ И РАБОЧИХ РЕШЕТОК|
         *                                                               V
         */
        public double S(double lb)
        {
            double res = Sa - Sb * lb;
            return res;
        }
        public double A(double alfa)
        {
            double res = A1 + A2 * alfa;
            return res;
        }
        public double B(double alfa, double lb)
        {
            double res = (B1 + B2 * alfa + B3 * Math.Pow(alfa, 2)) * lb;
            return res;
        }
        public double Vlazh(double vl, double Ro)
        {
            double res = n1 + n2 * Ro + (n3 + n4 * Ro + n5 * Math.Pow(Ro, 2)) * vl + (n6 + n7 * Ro + n8 * Math.Pow(Ro, 2)) * Math.Pow(vl, 2) + (n9 + n10 * Ro + n11 * Math.Pow(Ro, 2)) * Math.Pow(vl, 3) +
               +(n12 + n13 * Ro + n14 * Math.Pow(Ro, 2)) * Math.Pow(vl, 4) + (n15 + n16 * Ro + n17 * Math.Pow(Ro, 2)) * Math.Pow(vl, 5) + (n18 + n19 * Ro + n20 * Math.Pow(Ro, 2)) * Math.Pow(vl, 6);
            return res;
        }
        public double Vlazh_S(double vl)
        {
            double res = sn1 * Math.Pow(vl, 3) + sn2 * Math.Pow(vl, 2) + sn3 * vl + sn4;
            return res;
        }
        public double nu1(int VLAZH, double vl, double Ro, double lb, double alfa, int R_S)
        {
            //R_S = 1 - рабочая, = 0 сопловая 
            //VLAZH = 0 или 1
            double res = 0;
            if (R_S == 0)
            {
                if (VLAZH == 0)
                {
                    res = S(lb);
                }
                if (VLAZH == 1)
                {
                    res = S(lb) * Vlazh_S(vl);
                }
            }
            if (R_S == 1)
            {
                if (VLAZH == 0)
                {
                    res = A(alfa) + B(alfa, lb);
                }
                if(VLAZH == 1)
                {
                    res = (A(alfa) + B(alfa, lb)) * Vlazh(vl, Ro);
                }
            }
            return res;
        }
        public double nu1(double lb, double alfa, int R_S)
        {
            //R_S = 1 - рабочая, = 0 сопловая 
            double res = 0;
            if (R_S == 0)
            {
                res = S(lb);
            }
            if (R_S == 1)
            {
                res = A(alfa) + B(alfa, lb);
            }
            return res;
        }


        /*
         * ВЫЧИСЛЕНИЕ КОЭФФИЦИЕНТА ПОТЕРЬ И ПОПРАВОК ДЛЯ СОПЛОВЫХ И РАБОЧИХ РЕШЕТОК|
         *                                                                         V
         */
        public double zetta0(double alfa, double bl)
        {
            // угол альфа в град!!
            double res = (a1 + alfa * a2) + bl * (a3 + a4 * alfa + a5 * Math.Pow(alfa, 2) + a6 * Math.Pow(alfa, 3) + a7 * Math.Pow(alfa, 4));
            return res;
        }
        public double km(double M)
        {
            double res = c0 + c1 * M + c2 * Math.Pow(M, 2) + c3 * Math.Pow(M, 3) + c4 * Math.Pow(M, 4) + c5 * Math.Pow(M, 5) + c6 * Math.Pow(M, 6);
            return res;
        }
        public double ka(double alfaE)
        {
            // угол альфа в град!!
            double res = z0 * Math.Exp(z1 * alfaE) + z2;
            return res;
        }
        public double kre(double Re)
        {
            double res = b0 * Math.Exp(b1 * Re) + b2;
            return res;
        }
        /*
        * ВЫЧИСЛЕНИЕ КОЭФФИЦИЕНТА ПОТЕРЬ ДЛЯ СОПЛОВЫХ И РАБОЧИХ РЕШЕТОК С ПОПРАВКОЙ НА ВЛАЖНОСТЬ |
        *                                                                                        V
        */

        public double Lambda(int VZ, int Z)
        {
            double l = 0;
            int dZ = P.Z - Z;
            if (dZ <= 5)
            {
                if (VZ == 1)
                {
                    l = l1[5 - dZ];
                }
                if (VZ == 2)
                {                   
                        l = l2[5 - dZ];
                }
                if (VZ == 3)
                {                  
                        l = l3[5 - dZ];                    
                }
                if (VZ == 4)
                {                    
                        l = l4[5 - dZ];                    
                }
                if (VZ == 5)
                {                   
                        l = l5[5 - dZ];                   
                }
                if (VZ == 6)
                {                   
                        l = l6[5 - dZ];
                }
                if (VZ == 7)
                {                   
                        l = l7[5 - dZ];                   
                }
            }

            return l;
        }

        public double kp(double p)
        {
            // p - в барах
            double kp = 1;
            if(p>=0.04&& p <= 0.1)
            {
                kp = (kp004 - kp01) * (p - 0.04) / (0.04 - 0.1) + kp004;
            }
            if (p >= 0.1 && p <= 0.4)
            {
                kp = (kp01 - kp04) * (p - 0.1) / (0.1 - 0.4) + kp01;
            }
            if (p >= 0.4 && p <= 0.6)
            {
                kp = (kp04 - kp06) * (p - 0.4) / (0.4 - 0.6) + kp04;
            }
            if (p >= 0.6 && p <= 1)
            {
                kp = (kp06 - kp1) * (p - 0.6) / (0.6 - 1) + kp06;
            }
            if (p >= 1 && p <= 4)
            {
                kp = (kp1 - kp4) * (p - 1) / (1 - 4) + kp1;
            }
            if (p >= 4 && p <= 6)
            {
                kp = (kp4 - kp6) * (p - 4) / (4 - 6) + kp4;
            }
            if (p >= 6 && p <= 10)
            {
                kp = (kp6 - kp10) * (p - 6) / (6 - 10) + kp6;
            }
            if (p >= 10 && p <= 40)
            {
                kp = (kp10 - kp40) * (p - 10) / (10 - 40) + kp10;
            }
            if (p > 40)
            {
                kp = 0.2;
            }
            return kp;
        }



        /*
        *  ВЫЧИСЛЕНИЕ КОЭФФИЦИЕНТА ИСПОЛЬЗОВАНИЯ СТУПЕНИ Х |
        *                                                  V
        *
        */

        public double X(double alfa2)
        {
            double x = 1;
            if (alfa2 <= 30 || alfa2 >= 150)
            {
                x = 0.3;
            }
            else
            {
                for (int i = 0; i < 13; i++)
                {
                    if (alfa2 <= Xx[i] && (Xx[i] - alfa2) < 20)
                    {
                        x = (Xy[i] - Xy[i - 1]) * (Xx[i] - alfa2) / (Xx[i] - Xx[i - 1]) + Xy[i - 1];
                    }
                }

              
            }
            return x;
        }

        /*
         * ТАБЛИЦА П.1.2 ГЕОМЕТРИЧЕСКИЕ ХАРАКТЕРИСТИКИ |
         *                                             V
         * 
         */

        public double returnS1(bool O_M, int INDEX_TYPE, bool vlazh)
        {
            double S1 = 0;
            // O_M = true если одноцилиедр. турбина
            // INDEX_TYPE = : 0 - ЦВД; 1 - ЦСД; 2 - ЦНД
            if (O_M)
            {
                S1 = 4;
            }
            else
            {
                if (INDEX_TYPE == 0)
                {
                    S1 = 4;
                }
                if (INDEX_TYPE == 1)
                {
                    S1 = 5;
                }
                if (INDEX_TYPE == 2)
                {
                    S1 = 10;
                    if (vlazh)
                    {
                        S1 = 20;
                    }
                }
            }
            return S1;
        }

        public double returnS2(bool O_M, int INDEX_TYPE, bool vlazh)
        {
            double S2 = 0;
            // O_M = true если одноцилиедр. турбина
            // INDEX_TYPE = : 0 - ЦВД; 1 - ЦСД; 2 - ЦНД
            if (O_M)
            {
                S2 = 5;
            }
            else
            {
                if (INDEX_TYPE == 0)
                {
                    S2 = 5;
                }
                if (INDEX_TYPE == 1)
                {
                    S2 = 6;
                }
                if (INDEX_TYPE == 2)
                {
                    S2 = 8;
                    if (vlazh)
                    {
                        S2 = 15; // 150?
                    }
                }
            }
            return S2;
        }

        public double sigmaR(bool O_M, int INDEX_TYPE, bool vlazh)
        {
            double sigmaR = 0;
            // O_M = true если одноцилиедр. турбина
            // INDEX_TYPE = : 0 - ЦВД; 1 - ЦСД; 2 - ЦНД
            if (O_M)
            {
                sigmaR = 1;
            }
            else
            {
                if (INDEX_TYPE == 0)
                {
                    sigmaR = 1;
                }
                if (INDEX_TYPE == 1)
                {
                    sigmaR = 1.5;
                }
                if (INDEX_TYPE == 2)
                {
                    sigmaR = 5;
                    if (vlazh)
                    {
                        sigmaR = 5; 
                    }
                }
            }
            return sigmaR;
        }

        public double sigmaA(bool O_M, int INDEX_TYPE, bool vlazh)
        {
            double sigmaA = 0;
            // O_M = true если одноцилиедр. турбина
            // INDEX_TYPE = : 0 - ЦВД; 1 - ЦСД; 2 - ЦНД
            if (O_M)
            {
                sigmaA = 1.5;
            }
            else
            {
                if (INDEX_TYPE == 0)
                {
                    sigmaA = 1.5;
                }
                if (INDEX_TYPE == 1)
                {
                    sigmaA = 2.5;
                }
                if (INDEX_TYPE == 2)
                {
                    sigmaA = 5;
                    if (vlazh)
                    {
                        sigmaA = 5; 
                    }
                }
            }
            return sigmaA;
        }

        public double z1y(bool O_M, int INDEX_TYPE, bool vlazh)
        {
            double z1y = 0;
            // O_M = true если одноцилиедр. турбина
            // INDEX_TYPE = : 0 - ЦВД; 1 - ЦСД; 2 - ЦНД
            if (O_M)
            {
                z1y = 2;
            }
            else
            {
                if (INDEX_TYPE == 0)
                {
                    z1y = 4;
                }
                if (INDEX_TYPE == 1)
                {
                    z1y = 4;
                }
                if (INDEX_TYPE == 2)
                {
                    z1y = 4;
                    if (vlazh)
                    {
                        z1y = 4;
                    }
                }
            }
            return z1y;
        }

        public double z2y(bool O_M, int INDEX_TYPE, bool vlazh)
        {
            double z2y = 0;
            // O_M = true если одноцилиедр. турбина
            // INDEX_TYPE = : 0 - ЦВД; 1 - ЦСД; 2 - ЦНД
            if (O_M)
            {
                z2y = 2;
            }
            else
            {
                if (INDEX_TYPE == 0)
                {
                    z2y = 2;
                }
                if (INDEX_TYPE == 1)
                {
                    z2y = 2;
                }
                if (INDEX_TYPE == 2)
                {
                    z2y = 2;
                    if (vlazh)
                    {
                        z2y = 2;
                    }
                }
            }
            return z2y;
        }
        /*
         * ПОПРАВОЧНЫЙ КОЭФФИЦИЕНТ ky                  |
         *                                             V
         * 
         */

        public double getA(double Z)
        {
            double res = -0.9347193 + 1.1405807 * Z - 0.2161517 * Math.Pow(Z, 2) + 0.0165807 * Math.Pow(Z, 3) - 4.1655792 * Math.Pow(10, -4) * Math.Pow(Z, 4);
            return res;
        }

        public double getB(double Z)
        {
            double res = 1.4814728 - 1.3708032 * Z + 0.2782475 * Math.Pow(Z, 2) - 0.015301 * Math.Pow(Z, 3);
            return res;
        }
        public double getC(double Z)
        {
            double res = -1.1554178 + 0.9826604 * Z - 0.2406294 * Z * Z + 0.0201046 * Z * Z * Z - 5.2126641 * Math.Pow(10, -4) * Math.Pow(Z, 4);
            return res;
        }
        public double getQ(double Z)
        {
            double res = -2.3099855 * Math.Exp(-1.7437766 * Math.Pow(10, -3) * Math.Pow((Z + 4.2627223), 2)) + 1.6826902;
            return res;
        }
        public double getG(double Z)
        {
            double res = 1.5118825 * Math.Exp(-5.3212797 * Math.Pow(10, -3) * Math.Pow((Z - 8.0991061), 2)) + 0.0247408;
            return res;
        }

        public double Ky(double Z, double sigma_na_S)
        {
            double Y = 1;
            double d = sigma_na_S * 10;
            if (Z <= 10)
            {
                double A = getA(Z);
                double B = getB(Z);
                double C = getC(Z);
                Y = 1 + A * d + B * d * d + C * d * d * d;
            }
            if (Z > 10)
            {
                double Q = getQ(Z);
                double G = getG(Z);
                Y = 1 + Q * d + G * Math.Log(d + 1);
            }
            return Y;
        }

        /*
       * КОЭФФИЦИЕНТ РАСХОДА ДЛЯ ЛАБИРИНТНЫХ УПЛОТНЕНИЙ NU1y       |
       *                                                           V
       * 
       */

        public double nu1y(double X, int TYPE)
        {
            double Y = 1;
            if (TYPE == 1 )
            {
                Y = z10 * Math.Exp(z11 * X) + z12;

            }
            if (TYPE == 2 || TYPE == 3)
            {
                Y = z20 * Math.Exp(z21 * X) + z22;
            }
            if (TYPE == 4)
            {
                Y = z30 * Math.Exp(z31 * X) + z32;
            }
            if (TYPE == 5)
            {
                Y = z40 * Math.Exp(z41 * X) + z42;
            }
            if (TYPE == 6)
            {
                Y = z50 + z51 * X;
            }
            if (TYPE == 7)
            {
                Y = z60 + z61 * X;
            }

            return Y;
        }

        /*
       *                       ***********        ПЕРЕКРЫШКИ       |
       *                                                           V
       * 
       */

        public double returnPPk(double l1)
        {
            double ppk = 1;
            if (l1 >= 35 && l1 < 55)
            {
                ppk = 1;
            }
            if (l1 >= 55 && l1 < 150)
            {
                ppk = 2;
            }
            if (l1 >= 150 && l1 < 300)
            {
                ppk = 3;
            }
            if (l1 >= 300 && l1 < 400)
            {
                ppk = 5;
            }
            if (l1 >= 400 && l1 < 625)
            {
                ppk = 8;
            }
            if (l1 >= 625)
            {
                ppk = 10;
            }
            return ppk;
        }

        public double returnPPp(double l1)
        {
            double ppp = 1;
            if (l1 >= 35 && l1 < 55)
            {
                ppp = 2;
            }
            if (l1 >= 55 && l1 < 150)
            {
                ppp = 3;
            }
            if (l1 >= 150 && l1 < 300)
            {
                ppp = 4;
            }
            if (l1 >= 300 && l1 < 400)
            {
                ppp = 7;
            }
            if (l1 >= 400 && l1 < 625)
            {
                ppp = 8;
            }
            if (l1 >= 625)
            {
                ppp = 10;
            }
            return ppp;
        }
    }
}
