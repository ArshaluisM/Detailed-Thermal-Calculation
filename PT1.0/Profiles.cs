using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PT1._0
{
    public class Profiles
    {
         public int INDEX_rezhim = 0;
         public int INDEX_name = 1;
        
         int INDEX_alfa1_opt_N = 3;
         int INDEX_alfa1_opt_K = 4;
         int INDEX_alfa0_opt_N = 5;
         int INDEX_alfa0_opt_K = 6;
         int INDEX_t_opt_N = 7;
         int INDEX_t_opt_K = 8;
        // НОВЫЕ
        ArrayList С9009A = new ArrayList() { 1, "С9009A", 60.6, 7.0, 11.0, 70.0, 120.0, 0.72, 0.85 };
        ArrayList С9012A = new ArrayList() { 1, "С9012A", 62.5, 10.0, 14.0, 70.0, 120.0, 0.72, 0.87 };
        ArrayList С9015A = new ArrayList() { 1, "С9015A", 51.5, 13.0, 17.0, 70.0, 120.0, 0.70, 0.85 };
        ArrayList С9018A = new ArrayList() { 1, "С9018A", 47.1, 15.0, 20.0, 70.0, 120.0, 0.70, 0.8 };
        ArrayList С9022A = new ArrayList() { 1, "С9022A", 45.0, 20.0, 24.0, 70.0, 120.0, 0.70, 0.8 };
        ArrayList С9027A = new ArrayList() { 1, "С9027A", 45.0, 24.0, 30.0, 70.0, 120.0, 0.65, 0.75 };
        ArrayList С9033A = new ArrayList() { 1, "С9033A", 45.0, 30.0, 36.0, 70.0, 120.0, 0.62, 0.75 };
        ArrayList С9038A = new ArrayList() { 1, "С9038A", 45.0, 35.0, 42.0, 70.0, 120.0, 0.60, 0.73 };
        ArrayList С5515A = new ArrayList() { 1, "С5515A", 45.0, 12.0, 18.0, 45.0, 75.0, 0.72, 0.87 };
        ArrayList С5520A = new ArrayList() { 1, "С5520A", 45.0, 17.0, 23.0, 45.0, 75.0, 0.70, 0.85 };
        ArrayList С4525A = new ArrayList() { 1, "С4525A", 45.8, 21.0, 26.0, 35.0, 65.0, 0.60, 0.75 };
        ArrayList С6030A = new ArrayList() { 1, "С6030A", 34.56, 27.0, 34.0, 45.0, 85.0, 0.52, 0.70 };
        ArrayList С6035A = new ArrayList() { 1, "С6035A", 45.0, 32.0, 38.0, 45.0, 85.0, 0.42, 0.65 };
        ArrayList С6520A = new ArrayList() { 1, "С6520A", 45.0, 17.0, 23.0, 50.0, 85.0, 0.60, 0.70 };
        ArrayList С7025A = new ArrayList() { 1, "С7025A", 45.0, 22.0, 28.0, 55.0, 90.0, 0.50, 0.67 };
        ArrayList С9012Б = new ArrayList() { 2, "С9012Б", 56.6, 10.0, 14.0, 70.0, 120.0, 0.78, 0.81 };
        ArrayList С9015Б = new ArrayList() { 2, "С9015Б", 52.0, 13.0, 17.0, 70.0, 120.0, 0.70, 0.85 };
        ArrayList С9018Б = new ArrayList() { 2, "С9018Б", 47.1, 16.0, 20.0, 70.0, 120.0, 0.70, 0.80 };
        ArrayList С9008Р = new ArrayList() { 3, "С9008Р", 64.6, 7.0, 10.0, 70.0, 120.0, 0.60, 0.70 };
        ArrayList С9012Р = new ArrayList() { 3, "С9012Р", 40.9, 10.0, 14.0, 70.0, 120.0, 0.58, 0.68 };
        ArrayList С9015Р = new ArrayList() { 3, "С9015Р", 42.0, 13.0, 17.0, 70.0, 120.0, 0.55, 0.65 };
        ArrayList С9022Р = new ArrayList() { 3, "С9022Р", 38.7, 18.0, 24.0, 70.0, 120.0, 0.55, 0.65 };

        // b alfa1e[n, k] alfa0[n, k] topt[n, k]

        ArrayList Р2314А = new ArrayList() { 1, "Р2314А", 25.9, 12.0, 16.0, 20.0, 30.0, 0.60, 0.75 };
        ArrayList Р2617А = new ArrayList() { 1, "Р2617А", 25.7, 15.0, 19.0, 25.0, 35.0, 0.60, 0.75 };
        ArrayList Р3021А = new ArrayList() { 1, "Р3021А", 25.6, 19.0, 24.0, 25.0, 40.0, 0.58, 0.68 };
        ArrayList Р3525А = new ArrayList() { 1, "Р3525А", 25.4, 22.0, 28.0, 30.0, 55.0, 0.55, 0.65 };
        ArrayList Р4629А = new ArrayList() { 1, "Р4629А", 25.6, 25.0, 32.0, 44.0, 60.0, 0.45, 0.58 };
        ArrayList Р5033А = new ArrayList() { 1, "Р5033А", 25.6, 30.0, 36.0, 47.0, 65.0, 0.43, 0.55 };
        ArrayList Р5535А = new ArrayList() { 1, "Р5535А", 25.7, 32.0, 38.0, 50.0, 70.0, 0.42, 0.52 };
        ArrayList Р6038А = new ArrayList() { 1, "Р6038А", 26.1, 35.0, 42.0, 55.0, 75.0, 0.41, 0.51 };
        ArrayList Р16017А = new ArrayList() { 1, "Р16017А", 122.0, 15.0, 20.0, 135.0, 162.0, 0.8, 1.0 };
        ArrayList Р2717Б = new ArrayList() { 2, "Р2717Б", 25.4, 15.0, 19.0, 23.0, 45.0, 0.57, 0.65 };
        ArrayList Р3021Б = new ArrayList() { 2, "Р3021Б", 20.1, 19.0, 24.0, 25.0, 40.0, 0.55, 0.65 };
        ArrayList Р3525Б = new ArrayList() { 2, "Р3525Б", 25.2, 22.0, 28.0, 30.0, 50.0, 0.55, 0.65 };
        ArrayList Р4629Б = new ArrayList() { 2, "Р4629Б", 25.0, 25.0, 32.0, 44.0, 60.0, 0.53, 0.62 };
        ArrayList Р2723Б = new ArrayList() { 2, "Р2723Б", 117, 26.0, 33.0, 25.0, 35.0, 0.42, 0.5 };
        ArrayList Р5530Б = new ArrayList() { 2, "Р5530Б", 105, 26.0, 34.0, 40.0, 65.0, 0.5, 0.7 };
        ArrayList Р9025Б = new ArrayList() { 2, "Р9025Б", 115, 22.0, 28.0, 70.0, 120.0, 0.55, 0.72 };
        ArrayList Р16017Б = new ArrayList() { 2, "Р16017Б", 116, 16.0, 20.0, 130.0, 162.0, 0.8, 0.95 };
        ArrayList Р2118Р = new ArrayList() { 3, "Р2118Р", 20.0, 16.0, 20.0, 19.0, 24.0, 0.6, 0.7 };
        ArrayList Р2522Р = new ArrayList() { 3, "Р2522Р", 20.0, 20.0, 24.0, 23.0, 27.0, 0.54, 0.65 };
        ArrayList Р2926Р = new ArrayList() { 3, "Р2926Р", 25.0, 23.0, 27.0, 26.0, 32.0, 0.53, 0.63 };
        ArrayList Р3330Р = new ArrayList() { 3, "Р3330Р", 25.0, 28.0, 32.0, 30.0, 36.0, 0.51, 0.61 };
        ArrayList Р3025Р = new ArrayList() { 3, "Р3025Р", 20.0, 23.0, 27.0, 28.0, 36.0, 0.48, 0.58 };
        ArrayList Р14520Р = new ArrayList() { 3, "Р14520Р", 36.0, 17.0, 23.0, 125.0, 160.0, 0.65, 0.9 };
        ArrayList Р16017Р = new ArrayList() { 3, "Р16017Р", 125.0, 15.0, 20.0, 135.0, 162.0, 0.85 ,1.0 };
        //b betta2e[n, k] b2[n, k] topt[n, k]

        public ArrayList PROFILES = new ArrayList();
        public ArrayList PROFILES_R = new ArrayList();

        public ArrayList PS = new ArrayList();
        public ArrayList PR = new ArrayList();
        public Profiles()
        {
            PS.Add(С9009A);
            PS.Add(С9012A);
            PS.Add(С9015A);
            PS.Add(С9018A);
            PS.Add(С9022A);
            PS.Add(С9027A);
            PS.Add(С9033A);
            PS.Add(С9038A);
            PS.Add(С5515A);
            PS.Add(С5520A);
            PS.Add(С4525A);
            PS.Add(С6030A);
            PS.Add(С6035A);
            PS.Add(С6520A);
            PS.Add(С7025A);
            PS.Add(С9012Б);
            PS.Add(С9015Б);
            PS.Add(С9018Б);
            PS.Add(С9008Р);
            PS.Add(С9012Р);
            PS.Add(С9015Р);
            PS.Add(С9022Р);

            PR.Add(Р2314А);
            PR.Add(Р2617А);
            PR.Add(Р3021А);
            PR.Add(Р3525А);
            PR.Add(Р4629А);
            PR.Add(Р5033А);
            PR.Add(Р5535А);
            PR.Add(Р6038А);
            PR.Add(Р16017А);
            PR.Add(Р2717Б);
            PR.Add(Р3021Б);
            PR.Add(Р3525Б);
            PR.Add(Р4629Б);
            PR.Add(Р2723Б);
            PR.Add(Р5530Б);
            PR.Add(Р9025Б);
            PR.Add(Р16017Б);
            PR.Add(Р2118Р);
            PR.Add(Р2522Р);
            PR.Add(Р2926Р);
            PR.Add(Р3330Р);
            PR.Add(Р3025Р);
            PR.Add(Р14520Р);
            PR.Add(Р16017Р);

        }

        public ArrayList findProfile(double M1t, double alfa1e, double alfa0)
        {
            ArrayList a = null;
            int r = 0;
            if (M1t < 1)
            {
                r = 1;
            }
            if (M1t>= 1 && M1t <= 1.35)
            {
                r = 2;
            }
            if (M1t > 1.35)
            {
                r = 3;
            }

            foreach(ArrayList o in PS)
            {
                if ((int)o[INDEX_rezhim] == r)
                {

                    if (alfa1e >= (double)o[INDEX_alfa1_opt_N] && alfa1e<= (double)o[INDEX_alfa1_opt_K]
                        && alfa0 >= (double)o[INDEX_alfa0_opt_N] && alfa0 <= (double)o[INDEX_alfa0_opt_K])
                    {
                        a = (ArrayList)o;
                        break;
                        
                    }

                }
            }

            if (a == null)
            {

                a = findProfile_Near(M1t, alfa1e, alfa0, r, PS, 1);
            }
            return a;
        }

        public ArrayList findProfile_R(double M2t, double betta2e, double betta1)
        {
            ArrayList a = null;

            int r = 0;
            if (M2t < 1)
            {
                r = 1;
            }
            if (M2t >= 1 && M2t <= 1.35)
            {
                r = 2;
            }
            if (M2t > 1.35)
            {
                r = 3;
            }
            foreach (ArrayList o in PR)
            {
                if ((int)o[INDEX_rezhim] == r)
                {
                    if (betta2e >= (double)o[INDEX_alfa1_opt_N] && betta2e <= (double)o[INDEX_alfa1_opt_K]
                        && betta1 >= (double)o[INDEX_alfa0_opt_N] && betta1 <= (double)o[INDEX_alfa0_opt_K])
                    {
                        a = (ArrayList)o;
                        break;
                    }

                }
            }

            if (a == null)
            {

                a = findProfile_Near(M2t, betta2e, betta1, r, PR, 2);
            }
            return a;
        }

        public ArrayList findProfile_Near(double M2t, double betta2e, double betta1, int r, ArrayList P, int S_R)
        {
            bool finded = true;
            ArrayList a = null;
            double da0 = 100, dak = 100, dan = 100, dae = 100, daek = 100, daen = 100;
            double da = 100, DA0 = 100, DAK = 100, DAN = 100, DAE = 100, DAEK = 100, DAEN = 100;
            String name = "";
            double ik = 0;
            double ddd = 1000;
            String nnn = "";
            foreach (ArrayList k in P)
            {
                if (!((betta1 < (double)k[INDEX_alfa0_opt_N] || betta1 > (double)k[INDEX_alfa0_opt_K]) && (betta2e < (double)k[INDEX_alfa1_opt_N] || betta2e > (double)k[INDEX_alfa1_opt_K])))
                {
                    finded = false;
                }
                if (finded)
                {
                    foreach (ArrayList u in P)
                    {
                        if (betta2e < (double)u[INDEX_alfa1_opt_N] || betta2e > (double)u[INDEX_alfa1_opt_K])
                        {
                            ik = Math.Min(Math.Abs(betta2e - (double)u[INDEX_alfa1_opt_K]), Math.Abs(betta2e - (double)u[INDEX_alfa1_opt_N]));
                            if (ik < ddd)
                            {
                                ddd = ik;
                                nnn = (String)u[INDEX_name];
                            }
                        }
                    }
                    foreach (ArrayList u in P)
                    {
                        if ((String)u[INDEX_name] == nnn)
                        {
                            if (betta2e - (double)u[INDEX_alfa1_opt_K] < 0)
                            {
                                betta2e += ddd;
                            }
                            else
                            {
                                betta2e -= ddd;
                            }
                        }
                    }
                }

            }
            foreach (ArrayList o in P)
            {
                da0 = 100; dae = 100;
                if ((int)o[INDEX_rezhim] == r)
                {
                    
                    if (betta2e >= (double)o[INDEX_alfa1_opt_N] && betta2e <= (double)o[INDEX_alfa1_opt_K] && (betta1 < (double)o[INDEX_alfa0_opt_N] || betta1 > (double)o[INDEX_alfa0_opt_K]))
                    {
                        dak = betta1 - (double)o[INDEX_alfa0_opt_K];
                        dan = betta1 - (double)o[INDEX_alfa0_opt_N];
                        da0 = Math.Min(Math.Abs(dak), Math.Abs(dan));
                    }
                    if (betta1 >= (double)o[INDEX_alfa0_opt_N] && betta1 <= (double)o[INDEX_alfa0_opt_K] && (betta2e < (double)o[INDEX_alfa1_opt_N] || betta2e > (double)o[INDEX_alfa1_opt_K]))
                    {
                        daek = betta2e - (double)o[INDEX_alfa1_opt_K];
                        daen = betta2e - (double)o[INDEX_alfa1_opt_N];
                        dae = Math.Min(Math.Abs(daek), Math.Abs(daen));
                    }


                    if (da0 < dae)
                    {
                        if (da0 < da)
                        {
                            da = da0;
                            name = (String)o[INDEX_name];
                            DAK = dak; DA0 = da0; DAN = dan; DAE = dae; DAEK = daek; DAEN = daen;
                        }
                    }
                    if(dae < da0)
                    {
                        if (dae < da)
                        {
                            da = dae;
                            name = (String)o[INDEX_name];
                            DAK = dak; DA0 = da0; DAN = dan; DAE = dae; DAEK = daek; DAEN = daen;
                        }
                    }

                }
            }

            foreach (ArrayList o in P)
            {
               
                 {
                    if ((String)o[INDEX_name] == name)
                    {
                        if (S_R == 1)
                        {
                            if (da == Math.Abs(DAK))
                            {
                                a = findProfile(M2t, betta2e, betta1 - DAK);

                            }
                            if (da == Math.Abs(DAN))
                            {
                                a = findProfile(M2t, betta2e, betta1 - DAN);

                            }
                            if (da == Math.Abs(DAEK))
                            {
                                a = findProfile(M2t, betta2e - DAEK, betta1);

                            }
                            if (da == Math.Abs(DAEN))
                            {
                                a = findProfile(M2t, betta2e - DAEN, betta1);

                            }
                        }
                        if (S_R == 2)
                        {
                            if (da == Math.Abs(DAK))
                            {
                                a = findProfile_R(M2t, betta2e, betta1 - DAK);


                            }
                            if (da == Math.Abs(DAN))
                            {
                                a = findProfile_R(M2t, betta2e, betta1 - DAN);

                            }
                            if (da == Math.Abs(DAEK))
                            {
                                a = findProfile_R(M2t, betta2e - DAEK, betta1);
   
                            }
                            if (da == Math.Abs(DAEN))
                            {
                                a = findProfile_R(M2t, betta2e - DAEN, betta1);


                            }
                        }
                    }

                }
            }
            return a;
        }

        public double returnALFAy(ArrayList a)
        {
            double d = 0;
            if((String)a[INDEX_name] == "С9009A")
            {
                d = 0.667 * P.alfa1e[P.GEAR] - 8 * returnTopt(a) + 29.4;
            }
            if ((String)a[INDEX_name] == "С9012A")
            {
                d = 0.667 * P.alfa1e[P.GEAR] - 9.33 * returnTopt(a) + 32;
            }
            if ((String)a[INDEX_name] == "С9015A")
            {
                d = 1.057 * P.alfa1e[P.GEAR] - 15.1 * returnTopt(a) + 33.1;
            }
            if ((String)a[INDEX_name] == "С9018A")
            {
                d = P.alfa1e[P.GEAR] - 16 * returnTopt(a) + 36.2;
            }
            if ((String)a[INDEX_name] == "С9022A")
            {
                d = 0.835 * P.alfa1e[P.GEAR] - 10 * returnTopt(a) + 34.5;
            }
            if ((String)a[INDEX_name] == "С9027A")
            {
                d = 0.5 * P.alfa1e[P.GEAR] - 7.5 * returnTopt(a) + 40.5;
            }
            if ((String)a[INDEX_name] == "С9033A")
            {
                d = P.alfa1e[P.GEAR] - 14 * returnTopt(a) + 35.5;
            }
            if ((String)a[INDEX_name] == "С9038A")
            {
                d = (P.alfa1e[P.GEAR] + 11 * returnTopt(a) + 22.1)/(0.39*returnTopt(a)+0.81);
            }
            if ((String)a[INDEX_name] == "С5515A")
            {
                d = 1.04*P.alfa1e[P.GEAR] - 15.2 * returnTopt(a) + 39.8;
            }
            if ((String)a[INDEX_name] == "С5520A")
            {
                d = 1.19 * P.alfa1e[P.GEAR] - 18.2 * returnTopt(a) + 46.5;
            }
            if ((String)a[INDEX_name] == "С4525A")
            {
                d = 0.86 * P.alfa1e[P.GEAR] - 10.8 * returnTopt(a) + 32.3;
            }
            if ((String)a[INDEX_name] == "С6030A")
            {
                d = 1.26 * P.alfa1e[P.GEAR] - 21.8 * returnTopt(a) + 42.5;
            }
            if ((String)a[INDEX_name] == "С6035A")
            {
                d = 2.12 * P.alfa1e[P.GEAR] - 37.6* returnTopt(a) + 14.1;
            }
            if ((String)a[INDEX_name] == "С6520A")
            {
                d = 0.92 * P.alfa1e[P.GEAR] - 7.6 * returnTopt(a) + 39.1;
            }
            if ((String)a[INDEX_name] == "С7025A")
            {
                d =  P.alfa1e[P.GEAR] - 23 * returnTopt(a) + 48.3;
            }
            if ((String)a[INDEX_name] == "С9012Б")
            {
                d = P.alfa1e[P.GEAR] - 12 * returnTopt(a) + 30;
            }
            if ((String)a[INDEX_name] == "С9015Б")
            {
                d = P.alfa1e[P.GEAR] - 16 * returnTopt(a) + 34.6;
            }
            if ((String)a[INDEX_name] == "С9018Б")
            {
                d =  P.alfa1e[P.GEAR] - 20 * returnTopt(a) + 37.5;
            }
            if ((String)a[INDEX_name] == "С9008Р")
            {
                d = P.alfa1e[P.GEAR] - (7.927 * Math.Log(returnTopt(a)) + 10.42) + 28;
            }
            if ((String)a[INDEX_name] == "С9012Р")
            {
                d = P.alfa1e[P.GEAR] - (12.14 * Math.Log(returnTopt(a)) + 14.92) + 38;
            }
            if ((String)a[INDEX_name] == "С9015Р")
            {
                d = P.alfa1e[P.GEAR] - (10.93 * Math.Log(returnTopt(a)) + 20) + 42;
            }
            if ((String)a[INDEX_name] == "С9022Р")
            {
                d = P.alfa1e[P.GEAR] - (18.14 * Math.Log(returnTopt(a)) + 33.63) + 53;
            }
            //рабочие
            if ((String)a[INDEX_name] == "Р2314А")
            {
                d = P.betta2e[P.GEAR] - 2 * returnTopt(a) + 65.3;
            }
            if ((String)a[INDEX_name] == "Р2617А")
            {
                d = P.betta2e[P.GEAR] - 20 * returnTopt(a) + 71.8;
            }
            if ((String)a[INDEX_name] == "Р3021А")
            {
                d = 1.25 * P.betta2e[P.GEAR] - 20 * returnTopt(a) + 65.3;
            }
            if ((String)a[INDEX_name] == "Р3525А")
            {
                d =  P.betta2e[P.GEAR] - 12 * returnTopt(a) + 62.4;
            }
            if ((String)a[INDEX_name] == "Р4629А")
            {
                d = 1.25 * P.betta2e[P.GEAR] - 27.5 * returnTopt(a) + 56;
            }
            if ((String)a[INDEX_name] == "Р5033А")
            {
                d =  P.betta2e[P.GEAR] - 20 * returnTopt(a) + 55.7;
            }
            if ((String)a[INDEX_name] == "Р5535А")
            {
                d =   P.betta2e[P.GEAR] - 16.1 * returnTopt(a) + 61.7;
            }
            if ((String)a[INDEX_name] == "Р6038А")
            {
                d = 1.11 * P.betta2e[P.GEAR] - 17.8 * returnTopt(a) + 42.3;
            }
            if ((String)a[INDEX_name] == "Р16017А")
            {
                d =  P.betta2e[P.GEAR] - 13.16 * Math.Exp(0.435*returnTopt(a)) + 23;
            }
            if ((String)a[INDEX_name] == "Р2717Б")
            {
                d = 1.25 * P.betta2e[P.GEAR] - 25 * returnTopt(a) + 73.9;
            }
            if ((String)a[INDEX_name] == "Р3021Б")
            {
                d = P.betta2e[P.GEAR] - 22 * returnTopt(a) + 74.8;
            }
            if ((String)a[INDEX_name] == "Р3525Б")
            {
                d =  P.betta2e[P.GEAR] - 16 * returnTopt(a) + 67.8;
            }
            if ((String)a[INDEX_name] == "Р4629Б")
            {
                d =  P.betta2e[P.GEAR] - 16.4 * returnTopt(a) + 67.2;
            }
            if ((String)a[INDEX_name] == "Р2729Б")
            {
                d = P.betta2e[P.GEAR] - 22.81 * Math.Exp(0.588*returnTopt(a)) + 90;
            }
            if ((String)a[INDEX_name] == "Р5530Б")
            {
                d = 1.1 * P.betta2e[P.GEAR] - 16 * returnTopt(a) + 38.6;
            }
            if ((String)a[INDEX_name] == "Р9025Б")
            {
                d = 0.4 * P.betta2e[P.GEAR] - 10 * returnTopt(a) + 28.4;
            }
            if ((String)a[INDEX_name] == "Р16017Б")
            {
                d = P.betta2e[P.GEAR] * (-0.012*P.betta2e[P.GEAR]+1.35) - (20 - 13.67 * returnTopt(a) -53.49 * Math.Pow(returnTopt(a),2) + 49.14 * Math.Pow(returnTopt(a),3)) + 17;
            }
            if ((String)a[INDEX_name] == "Р2118Р")
            {
                d =   P.betta2e[P.GEAR] - 6 * returnTopt(a) + 73.4;
            }
            if ((String)a[INDEX_name] == "Р2522Р")
            {
                d = 2*P.betta2e[P.GEAR] - 30 * returnTopt(a) + 57.6;
            }
            if ((String)a[INDEX_name] == "Р2926Р")
            {
                d = 1.1 * P.betta2e[P.GEAR] - 14.7 * returnTopt(a) + 69.44;
            }
            if ((String)a[INDEX_name] == "Р3330Р")
            {
                d = 1.17 * P.betta2e[P.GEAR] - 17.4 * returnTopt(a) + 64.9;
            }
            if ((String)a[INDEX_name] == "Р3025Р")
            {
                d = 0.82 * P.betta2e[P.GEAR] - 21.4 * returnTopt(a) + 84.1;
            }
            if ((String)a[INDEX_name] == "Р14520Р")
            {
                d = P.betta2e[P.GEAR] - 7.79 * Math.Exp(1.64*returnTopt(a)) + 33;
            }
            if ((String)a[INDEX_name] == "Р16017Р")
            {
                d = P.betta2e[P.GEAR] - 13.04 * Math.Exp(0.432 * returnTopt(a)) + 21;
            }
            return d;
        }
        public double returnTopt(ArrayList a)
        {
            double d = 0;
            d = ((double)a[INDEX_t_opt_N] + (double)a[INDEX_t_opt_K]) / 2;
            return d;
        }



    }
}
