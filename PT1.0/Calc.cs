using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT1._0
{
    class Calc
    {
        Approximate A = new Approximate();
        Profiles Pr = new Profiles();
        public void CheckVLAZH(double y)
        {
            if (y > 0)
            {
                P.VLAZH = 1;
            }
            if (y == 0)
            {
                P.VLAZH = 0;
            }
        }

        public void CALCULATE_ALL_PARAM(Label for_p0, Label for_t0, Label for_h0, Label for_i0, Label for_v0, Label for_y0, Label for_s0,Label for_xi0,Label for_U, Label for_Cf, Label for_H0_, 
            Label for_H01_, Label for_i1t,Label for_p1t, Label for_t1t, Label for_v1t, Label for_y1t, Label for_C1t, Label for_a1t, Label for_M1t, Label for_eps1, Label Rezhim_m1t, bool V_U, int VLAZH, int GEAR)
        {
            
            if (GEAR == 0)
            {
                P.Xi0[GEAR] = 0;
                if (P.i0[GEAR] == 0)
                {
                    if (P.y0[GEAR] == 0)
                    {
                        P.i0[GEAR] = Functions.wspHPT(P.p0[GEAR] * Math.Pow(10, 5), P.t0[GEAR] + 273.15);
                    }
                    else
                    {
                        P.i0[GEAR] = Functions.wspHSTX(P.t0[GEAR] + 273.15, 1 - P.y0[GEAR]);
                    }
                }

                //y0 = Functions.wspXPH(p0 * Math.Pow(10, 5), i0);
                if (P.s0[GEAR] == 0)
                {
                    if (P.y0[GEAR] == 0)
                    {
                        P.s0[GEAR] = Functions.wspSPH(P.p0[GEAR] * Math.Pow(10, 5), P.i0[GEAR]);
                    }
                    else
                    {
                        P.s0[GEAR] = Functions.wspSPH(P.p0[GEAR] * Math.Pow(10, 5), P.i0[GEAR]);
                    }
                }
                P.v0[GEAR] = Functions.wspVHS(P.i0[GEAR], P.s0[GEAR]);
                P.y0[GEAR] = 1 - Math.Abs(Functions.wspXHS(P.i0[GEAR], P.s0[GEAR]));
                CheckVLAZH(P.y0[GEAR]);
                P.H0[GEAR] = P.h0[GEAR];
                P.y0_[GEAR] = P.y0[GEAR];
                P.p0_[GEAR] = P.p0[GEAR];
                P.t0_[GEAR] = P.t0[GEAR];
                P.v0_[GEAR] = P.v0[GEAR];
                P.H0_[GEAR] = P.H0[GEAR];
            }
            else
            {
                P.p0[GEAR] = P.p2k[GEAR - 1]/100000;
                P.t0[GEAR] = P.t2k[GEAR - 1];
                P.i0[GEAR] = P.i2k[GEAR - 1] * 1000;// Дж/кг
                P.v0[GEAR] = P.v2k[GEAR - 1];
                P.s0[GEAR] = P.s2k[GEAR - 1];
                P.y0[GEAR] = P.y2k[GEAR - 1];
                CheckVLAZH(P.y0[GEAR]);
                P.y0_[GEAR] = P.y2k_[GEAR - 1];
                P.H0[GEAR] = P.h0[GEAR];
                P.Xi0[GEAR] = P.X[GEAR-1];
                P.H0_[GEAR] = P.H0[GEAR] + P.Xi0[GEAR] * P.delta_Hvc[GEAR-1]; // кДж/кг
            }
            if (V_U)
            {
                P.dk[GEAR] = P.dcr[GEAR] - P.l1[GEAR]*0.001;
            }
            P.U[GEAR] = Math.PI * P.dcr[GEAR] * P.n;
            P.Cf[GEAR] = P.U[GEAR] / P.xf[GEAR];
            P.H01_[GEAR] = (1 - P.Rocr[GEAR]) * P.H0_[GEAR];
            P.i1t[GEAR] = P.i0[GEAR] - P.H01_[GEAR] * 1000; // Дж/кг
            
            double k = 1.135;
            double eps = 0.557;
            if (VLAZH == 0)
            {
                k = 1.3;
                eps = 0.546;
            }
            P.p1t[GEAR] = Functions.wspPHS(P.i1t[GEAR], P.s0[GEAR]);
            P.t1t[GEAR] = Functions.wspTHS(P.i1t[GEAR], P.s0[GEAR]);
            P.v1t[GEAR] = Functions.wspVHS(P.i1t[GEAR], P.s0[GEAR]);
            P.y1t[GEAR] = 1 - Math.Abs(Functions.wspXHS(P.i1t[GEAR], P.s0[GEAR]));
            CheckVLAZH(P.y1t[GEAR]);
            P.C1t[GEAR] = Math.Sqrt(2 * 1000 * P.H01_[GEAR]);
            P.a1t[GEAR] = Math.Sqrt(k * P.p1t[GEAR] * P.v1t[GEAR]);
            P.M1t[GEAR] = P.C1t[GEAR] / P.a1t[GEAR];
            P.eps1[GEAR] = P.p1t[GEAR] / (P.p0[GEAR]*100000);
            P.p1zv[GEAR] = P.p0[GEAR] * eps;
            P.v1zv[GEAR] = Functions.wspVPS(P.p1zv[GEAR] * Math.Pow(10, 5), P.s0[GEAR]);
            P.i1zv[GEAR] = Functions.wspHPS(P.p1zv[GEAR] * Math.Pow(10, 5), P.s0[GEAR]) * 0.001;
            P.t1zv[GEAR] = Functions.wspTPS(P.p1zv[GEAR] * Math.Pow(10, 5), P.s0[GEAR]) - 273.15;
            if (VLAZH==0)
            {
                P.nu1[GEAR] = 0.97;
            }
            else
            {
                P.nu1[GEAR] = 1;
            }


            for_p0.Text = "" + Math.Round(P.p0[GEAR], 3);
            for_t0.Text = "" + Math.Round(P.t0[GEAR], 3);
            for_h0.Text = "" + Math.Round(P.h0[GEAR], 3);
            for_i0.Text = "" + Math.Round(P.i0[GEAR] * 0.001, 3);
            for_s0.Text = "" + Math.Round(P.s0[GEAR] * 0.001, 3);
            for_v0.Text = "" + Math.Round(P.v0[GEAR], 3);
            for_y0.Text = "" + Math.Round(P.y0[GEAR], 3);
            for_xi0.Text = "" + Math.Round(P.Xi0[GEAR], 3);
            for_U.Text = "" + Math.Round(P.U[GEAR], 3);
            for_Cf.Text = "" + Math.Round(P.Cf[GEAR], 3);
            for_H0_.Text = "" + Math.Round(P.H0_[GEAR], 3);
            for_H01_.Text = "" + Math.Round(P.H01_[GEAR], 3);
            for_i1t.Text = "" + Math.Round(P.i1t[GEAR] * 0.001, 3);
            for_p1t.Text = "" + Math.Round(P.p1t[GEAR] * 0.00001, 3);
            for_t1t.Text = "" + Math.Round(P.t1t[GEAR] - 273.15, 3);
            for_v1t.Text = "" + Math.Round(P.v1t[GEAR], 3);
            for_y1t.Text = "" + Math.Round(P.y1t[GEAR], 5);
            for_C1t.Text = "" + Math.Round(P.C1t[GEAR], 3);
            for_a1t.Text = "" + Math.Round(P.a1t[GEAR], 3);
            for_M1t.Text = "" + Math.Round(P.M1t[GEAR], 3);
            for_eps1.Text = "" + Math.Round(P.eps1[GEAR], 3);

            if (P.M1t[GEAR] < 1)
            {
                Rezhim_m1t.Text = "Докритический режим (M1t<1)";
            }
            if (P.M1t[GEAR] >= 1 && P.M1t[GEAR] <= 1.35)
            {
                Rezhim_m1t.Text = "Околокритический режим (1<M1t<1.35)";
            }
            if (P.M1t[GEAR] > 1.35)
            {
                Rezhim_m1t.Text = "Сверхкритический режим (M1t>1.35)";
            }

        }

        public void CALCULATE_Rezhim_M(Label for_nu1, Label for_l1, Label for_F1, Label for_Fzv, Label for_C1zv_f1, Label for_alfa1e, Label for_alfa1, Label for_delta1, Label for_alfazv1, Label C1zv_or_f1, Label mc_or_n, bool V_U, int Vlazh, int GEAR)
        {
            double xi1 = 0.667;
            double xi2 = 1.064;
            if (Vlazh != 0)
            {
                xi1 = 0.635;
                xi2 = 1.032;
            }
            if (P.M1t[GEAR] < 1)
            {
                P.F1[GEAR] = P.G[GEAR] * P.v1t[GEAR] / (P.nu1[GEAR] * P.C1t[GEAR]);
                if (!V_U)
                {
                    P.l1[GEAR] = P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.alfa1e[GEAR]));
                    P.dk[GEAR] = P.dcr[GEAR] - P.l1[GEAR] * 0.001;
                }
                if (V_U)
                {
                    P.alfa1e[GEAR] = Math.Asin(P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.l1[GEAR] * P.Parc[GEAR]));
                }
                P.alfa1[GEAR] = P.alfa1e[GEAR];
                P.delta1[GEAR] = 0;
            }
            if (P.M1t[GEAR] >= 1 && P.M1t[GEAR] <= 1.35)
            {
                C1zv_or_f1.Text = "Критическая скорость истечения С*";
                P.Fzv1[GEAR] = P.G[GEAR] / (P.nu1[GEAR] * xi1 * Math.Sqrt(P.p0[GEAR] / P.v0[GEAR]));
                P.F1[GEAR] = P.Fzv1[GEAR];
                if (!V_U)
                {
                    P.l1[GEAR] = P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.alfa1e[GEAR]));
                    P.dk[GEAR] = P.dcr[GEAR] - P.l1[GEAR] * 0.001;
                }
                P.Czv[GEAR] = xi2 * Math.Sqrt(P.p0[GEAR] * P.v0[GEAR]);
                if (V_U)
                {
                    P.alfa1e[GEAR] = Math.Asin(P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.l1[GEAR] * P.Parc[GEAR]));
                }
                P.alfa1[GEAR] = Math.Asin(Math.Sin(P.alfa1e[GEAR]) * P.Czv[GEAR] * P.v1t[GEAR] / (P.C1t[GEAR] * P.v1zv[GEAR]));
                P.delta1[GEAR] = P.alfa1[GEAR] - P.alfa1e[GEAR];
                for_C1zv_f1.Text = "" + Math.Round(P.Czv[GEAR], 3);
                if (P.delta1[GEAR] >= 1.5)
                {
                    C1zv_or_f1.Text = "Степень расширения канала сопла f1";
                    P.F1[GEAR] = P.G[GEAR] * P.v1t[GEAR] / (P.nu1[GEAR] * P.C1t[GEAR]);
                    if (!V_U)
                    {
                        P.l1[GEAR] = P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.alfa1e[GEAR]));
                    }
                    P.f1[GEAR] = P.F1[GEAR] / P.Fzv1[GEAR];
                    P.alfa1[GEAR] = P.alfa1e[GEAR];
                    P.delta1[GEAR] = 0;
                    P.alfazv1[GEAR] = Math.Asin(Math.Sin(P.alfa1e[GEAR]) / P.f1[GEAR]);
                    for_C1zv_f1.Text = "" + Math.Round(P.f1[GEAR], 3);
                    mc_or_n.Text = "м/с";
                }
            }
            if (P.M1t[GEAR] > 1.35)
            {
                C1zv_or_f1.Text = "Степень расширения канала сопла f1";
                P.Fzv1[GEAR] = P.G[GEAR] / (P.nu1[GEAR] * xi1 * Math.Sqrt(P.p0[GEAR] / P.v0[GEAR]));
                P.F1[GEAR] = P.G[GEAR] * P.v1t[GEAR] / (P.nu1[GEAR] * P.C1t[GEAR]);
                if (!V_U)
                {
                    P.l1[GEAR] = P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.alfa1e[GEAR]));
                    P.dk[GEAR] = P.dcr[GEAR] - P.l1[GEAR] * 0.001;
                }
                if (V_U)
                {
                    P.alfa1e[GEAR] = Math.Asin(P.F1[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.l1[GEAR] * P.Parc[GEAR]));
                }
                P.f1[GEAR] = P.F1[GEAR] / P.Fzv1[GEAR];
                P.alfa1[GEAR] = P.alfa1e[GEAR];
                P.delta1[GEAR] = 0;
                P.alfazv1[GEAR] = Math.Asin(Math.Sin(P.alfa1e[GEAR]) / P.f1[GEAR]);
                for_C1zv_f1.Text = "" + Math.Round(P.f1[GEAR], 3);
                mc_or_n.Text = "";
                for_alfazv1.Text = "" + Math.Round(P.alfazv1[GEAR] * 180 / Math.PI, 3);
            }
            for_nu1.Text = "" + Math.Round(P.nu1[GEAR], 3);
            for_l1.Text = "" + Math.Round(P.l1[GEAR],3);
            for_F1.Text = "" + Math.Round(P.F1[GEAR], 3);
            for_Fzv.Text = "" + Math.Round(P.Fzv1[GEAR], 3);
            for_alfa1e.Text = "" + Math.Round(P.alfa1e[GEAR]*180/Math.PI, 3);
            for_alfa1.Text = "" + Math.Round(P.alfa1[GEAR] * 180 / Math.PI, 3);
            for_delta1.Text = "" + Math.Round(P.delta1[GEAR] * 180 / Math.PI, 3);


        }

        public void CALCULATE_GEOM_S(Label for_profile, Label for_alfay, Label for_topt, Label for_t1, Label for_z1, Label for_b1geom, Label for_B1, Label for_O1, Label for_new_nu, Label for_delta_nu1, int  Vlazh, int G)
        {
            if (G == 0)
            {
                P.alfa0[G] = 90;
            }
            if (G > 0)
            {
                P.alfa0[G] = 180 - Math.Abs(P.alfa2[G - 1] * 180 / Math.PI);
            }
            P.alfay[G] = Pr.returnALFAy(Pr.findProfile(P.M1t[G], P.alfa1e[G] * 180 / Math.PI, P.alfa0[G]));
            P.topt[G] = Pr.returnTopt(Pr.findProfile(P.M1t[G], P.alfa1e[G] * 180 / Math.PI, P.alfa0[G]));

            P.b1shtrix[G] = P.B1[G] / Math.Sin(P.alfay[G] * Math.PI / 180);
            P.t1_geom[G] = P.topt[G] * P.b1shtrix[G];
            P.z1[G] = Math.PI * P.dcr[G] * 1000 * P.Parc[G] / P.t1_geom[G];
            P.z1[G] = Math.Round(P.z1[G]);
            P.t1_geom[G] = Math.PI * P.dcr[G] * 1000 * P.Parc[G] / P.z1[G];
            P.b1[G] = P.t1_geom[G] / P.topt[G];
            P.B1[G] = P.b1[G] * Math.Sin(P.alfay[G] * Math.PI / 180);
            P.O1[G] = P.t1_geom[G] * Math.Sin(P.alfa1e[G]);
            double nu1_shtrih = P.nu1[G];
            P.nu1[G] = A.nu1(Vlazh, P.y1t[G] * 100, P.Rocr[G], P.b1[G]/ P.l1[G], 0, 0);
            P.delta_nu1 = Math.Abs(P.nu1[G] - nu1_shtrih) / (Math.Max(P.nu1[G], nu1_shtrih))*100;
            P.v1kin[G] = Functions.wspDYNVISHS(P.i1t[G], P.s0[G]) * P.v1t[G];
             if (G > 0) {
                P.PPp[G] = A.returnPPp(P.l1[G - 1]);
                P.PPk[G] = A.returnPPk(P.l1[G]);
                P.l1shtrix[G] = P.l2[G - 1] + A.returnPPp(P.l1[G - 1]);
                P.l2shtrix[G] = P.l1[G] + A.returnPPp(P.l1[G]) + A.returnPPk(P.l1[G]);
             }
            P.P_S[G] = (String)(Pr.findProfile(P.M1t[G], P.alfa1e[G] * 180 / Math.PI, P.alfa0[G])[Pr.INDEX_name]);
            for_profile.Text = "Тип профиля : "+(String)(Pr.findProfile(P.M1t[G], P.alfa1e[G] * 180 / Math.PI, P.alfa0[G])[Pr.INDEX_name]);
            for_alfay.Text = "" + Math.Round(P.alfay[G], 3);
            for_topt.Text = "" + Math.Round(P.topt[G], 3);
            for_t1.Text = "" + Math.Round(P.t1_geom[G], 3);
            for_z1.Text = "" + Math.Round(P.z1[G]);
            for_b1geom.Text = "" + Math.Round(P.b1[G], 3);
            for_B1.Text = "" + Math.Round(P.B1[G], 3);
            for_O1.Text = "" + Math.Round(P.O1[G], 3);
            for_new_nu.Text = "" + Math.Round(P.nu1[G], 3);
            for_delta_nu1.Text = "" + Math.Round(P.delta_nu1, 3);
        }

        public void CHECK_NU1(Label for_nu1, Label for_l1, Label for_F1, Label for_Fzv, Label for_C1zv_f1, Label for_alfa1e, Label for_alfa1, Label for_delta1, Label for_alfazv1, Label C1zv_or_f1,
                                Label for_profile, Label for_alfay, Label for_topt, Label for_t1, Label for_z1, Label for_b1geom, Label for_B1, Label for_O1, Label for_new_nu, Label for_delta_nu1, Label mc_or_n, bool V_U, int Vlazh, int GEAR)
        {

            while (P.delta_nu1 > 1)
            {
                CALCULATE_Rezhim_M(for_nu1, for_l1, for_F1, for_Fzv, for_C1zv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, C1zv_or_f1, mc_or_n, V_U, Vlazh, GEAR);
                CALCULATE_GEOM_S(for_profile, for_alfay, for_topt, for_t1, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, Vlazh, GEAR);
            }
        }

        public void CALCULATE_POTERI(Label for_delta_alfa, Label for_zetta0, Label for_km, Label for_ka, Label for_kre, Label for_zetta1pp, Label for_zetta1vl, Label for_phi, Label for_C1,
                                        Label for_betta1, Label for_W1, Label for_delta_Hvx, Label for_delta_H1, Label for_i1, Label for_t1, Label for_v1, Label for_y1, int V, int G)
        {
            P.delta_alfa[G] = 180 - (P.alfa0[G] + P.alfa1[G] * 180 / Math.PI);
            P.zetta0[G] = A.zetta0(P.delta_alfa[G], P.b1[G] / P.l1[G]);
            P.km[G] = A.km(P.M1t[G]);
            P.ka[G] = A.ka(P.alfa1e[G] * 180 / Math.PI);
            P.kre[G] = 1; //Число рейнольдса
            P.zetta1pp[G] = P.zetta0[G] * P.km[G] * P.ka[G] * P.kre[G];
            P.zetta1[G] = P.zetta1pp[G];
            if (V != 0)
            {
                P.zetta1vl[G] = P.zetta1pp[G] + P.y0[G]*P.xf[G];
                P.zetta1[G] = P.zetta1vl[G];
            }
            P.phi[G] = Math.Sqrt(1 - P.zetta1[G]);
            P.C1[G] = P.phi[G] * P.C1t[G];
            P.betta1[G] = Math.Atan(Math.Sin(P.alfa1[G]) / (Math.Cos(P.alfa1[G]) - (P.U[G] / P.C1[G])));
            P.W1[G] = P.C1[G] * Math.Sin(P.alfa1[G]) / Math.Sin(P.betta1[G]);
            P.delta_Hvx[G] = Math.Pow(P.W1[G], 2) / 2000;
            P.delta_H1[G] = P.zetta1[G] * P.H01_[G];
            P.i1[G] = P.i1t[G]*0.001 + P.delta_H1[G];
            P.t1[G] = Functions.wspTPH(P.p1t[G], P.i1[G] * 1000) - 273.15;
            P.v1[G] = Functions.wspVPH(P.p1t[G], P.i1[G] * 1000);
            P.y1[G] = 1 - Math.Abs(Functions.wspXPH(P.p1t[G], P.i1[G] * 1000));
            CheckVLAZH(P.y1[G]);
            P.s1[G] = Functions.wspSPH(P.p1t[G], P.i1[G] * 1000);

            for_delta_alfa.Text = "" + Math.Round(P.delta_alfa[G], 3);
            for_zetta0.Text = "" + Math.Round(P.zetta0[G], 3);
            for_km.Text = "" + Math.Round(P.km[G], 3);
            for_ka.Text = "" + Math.Round(P.ka[G], 3);
            for_kre.Text = "" + Math.Round(P.kre[G], 3);
            for_zetta1pp.Text = "" + Math.Round(P.zetta1pp[G], 3);
            if(V == 1)
            {
                for_zetta1vl.Text = "" + Math.Round(P.zetta1vl[G], 3);
            }
            for_phi.Text = "" + Math.Round(P.phi[G], 3);
            for_C1.Text = "" + Math.Round(P.C1[G], 3);
            for_betta1.Text = "" + Math.Round(P.betta1[G] * 180/Math.PI, 3);
            for_W1.Text = "" + Math.Round(P.W1[G], 3);
            for_delta_Hvx.Text = "" + Math.Round(P.delta_Hvx[G], 3);
            for_delta_H1.Text = "" + Math.Round(P.delta_H1[G], 3);
            for_i1.Text = "" + Math.Round(P.i1[G], 3);
            for_t1.Text = "" + Math.Round(P.t1[G], 3);
            for_v1.Text = "" + Math.Round(P.v1[G], 3);
            for_y1.Text = "" + Math.Round(P.y1[G], 3);
 
        }

        public void CALCULATE_ALL_PARAM_RAB(Label for_p1_, Label for_t1_, Label for_i1_, Label for_s1_, Label for_v1_, Label for_y1_, Label for_H02, Label for_H02_, Label for_i2t,
                                                Label for_p2t, Label for_t2t, Label for_v2t, Label for_y2t, Label for_W2t, Label for_a2t, Label for_M2t, Label for_eps2, Label for_nu2, Label Rezhim_m2t, bool V_U, int V, int G)
        {
            P.i1_[G] = P.i1[G] + P.delta_Hvx[G]; //кДж/кг
            P.p1_[G] = Functions.wspPHS(P.i1_[G] * 1000, P.s1[G]);
            P.t1_[G] = Functions.wspTHS(P.i1_[G] * 1000, P.s1[G]);
            P.v1_[G] = Functions.wspVHS(P.i1_[G] * 1000, P.s1[G]);
            P.y1_[G] = 1 - Math.Abs(Functions.wspXHS(P.i1_[G] * 1000, P.s1[G]));
            P.H02[G] = P.Rocr[G] * P.H0_[G]; //кДж/кг
            P.H02_[G] = P.H02[G] + P.delta_Hvx[G];
            P.i2t[G] = P.i1_[G] - P.H02_[G];
            P.p2t[G] = Functions.wspPHS(P.i2t[G] * 1000, P.s1[G]);
            P.t2t[G] = Functions.wspTHS(P.i2t[G] * 1000, P.s1[G]);
            P.v2t[G] = Functions.wspVHS(P.i2t[G] * 1000, P.s1[G]);
            P.y2t[G] = 1 - Math.Abs(Functions.wspXHS(P.i2t[G] * 1000, P.s1[G]));
            CheckVLAZH(P.y2t[G]);
            double k = 1.3;
            double eps = 0.546;
            if (V != 0)
            {
                k = 1.135;
                eps = 0.557;
            }
            P.W2t[G] = Math.Sqrt(P.H02_[G] * 2000);
            P.a2t[G] = Math.Sqrt(k * P.p2t[G] * P.v2t[G]);
            P.M2t[G] = P.W2t[G] / P.a2t[G];
            P.eps2[G] = P.p2t[G] / P.p1_[G];
            if (V == 0)
            {
                P.nu2[G] = 0.95;
            }
            else
            {
                P.nu2[G] = 0.98;
            }
            P.p2zv[G] = P.p1_[G] * eps;
            P.v2zv[G] = Functions.wspVPS(P.p2zv[G], P.s1[G]);
            P.i2zv[G] = Functions.wspHPS(P.p2zv[G], P.s1[G]);
            P.t2zv[G] = Functions.wspTPS(P.p2zv[G], P.s1[G]);

            for_p1_.Text = "" + Math.Round(P.p1_[G] * 0.00001, 3);
            for_t1_.Text = "" + Math.Round(P.t1_[G] - 273.15, 3);
            for_i1_.Text = "" + Math.Round(P.i1_[G], 3);
            for_s1_.Text = "" + Math.Round(P.s1[G] * 0.001, 3);
            for_v1_.Text = "" + Math.Round(P.v1_[G], 3);
            for_y1_.Text = "" + Math.Round(P.y1_[G], 3);
            for_H02.Text = "" + Math.Round(P.H02[G], 3);
            for_H02_.Text = "" + Math.Round(P.H02_[G], 3);
            for_i2t.Text = "" + Math.Round(P.i2t[G], 3);
            for_p2t.Text = "" + Math.Round(P.p2t[G] * 0.00001, 3);
            for_t2t.Text = "" + Math.Round(P.t2t[G] - 273.15, 3);
            for_v2t.Text = "" + Math.Round(P.v2t[G], 3);
            for_y2t.Text = "" + Math.Round(P.y2t[G], 3);
            for_W2t.Text = "" + Math.Round(P.W2t[G], 3);
            for_a2t.Text = "" + Math.Round(P.a2t[G], 3);
            for_M2t.Text = "" + Math.Round(P.M2t[G], 3);
            for_eps2.Text = "" + Math.Round(P.eps2[G], 3);
            for_nu2.Text = "" + Math.Round(P.nu2[G], 3);

            if (P.M2t[G] < 1)
            {
                Rezhim_m2t.Text = "Докритический режим (M1t<1)";
            }
            if (P.M1t[G] >= 1 && P.M1t[G] <= 1.35)
            {
                Rezhim_m2t.Text = "Околокритический режим (1<M1t<1.35)";
            }
            if (P.M1t[G] > 1.35)
            {
                Rezhim_m2t.Text = "Сверхкритический режим (M1t>1.35)";
            }

        }

        public void CALCULATE_Rezhim_M_RAB(Label for_nu2, Label for_l2, Label for_F2, Label for_F2zv, Label for_Wzv_f2, Label for_betta2e, Label for_betta2, Label for_delta2, Label for_bettazv, Label W2zv_or_f2, bool V_U, int Vlazh, int GEAR)
        {
            double xi1 = 0.667;
            double xi2 = 1.064;
            if (Vlazh == 1)
            {
                xi1 = 0.635;
                xi2 = 1.032;
            }
            if (P.M2t[GEAR] < 1)
            {
                P.F2[GEAR] = P.G[GEAR] * P.v2t[GEAR] / (P.nu2[GEAR] * P.W2t[GEAR]);
                if (!V_U)
                {
                    P.betta2e[GEAR] = P.betta1[GEAR] - P.deltabetta[GEAR];
                    P.l2[GEAR] = P.F2[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.betta2e[GEAR]));
                }
                if (V_U)
                {
                    P.betta2e[GEAR] = Math.Asin(P.F2[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.l2[GEAR] * P.Parc[GEAR]));
                }
                P.betta2[GEAR] = P.betta2e[GEAR];
                P.delta2[GEAR] = 0;
            }
            if (P.M2t[GEAR] >= 1 && P.M2t[GEAR] <= 1.35)
            {
                W2zv_or_f2.Text = "Критическая скорость истечения С*";
                P.F2zv[GEAR] = P.G[GEAR] / (P.nu2[GEAR] * xi1 * Math.Sqrt(P.p1_[GEAR] / P.v1_[GEAR]));
                P.F2[GEAR] = P.F2zv[GEAR];
                if (!V_U)
                {
                    P.betta2e[GEAR] = P.betta1[GEAR] - P.deltabetta[GEAR];
                    P.l2[GEAR] = P.F2[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.betta2e[GEAR]));
                }
                P.Wzv[GEAR] = xi2 * Math.Sqrt(P.p1_[GEAR] * P.v1_[GEAR]);
                if (V_U)
                {
                    P.betta2e[GEAR] = Math.Asin(P.F2[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.l2[GEAR] * P.Parc[GEAR]));
                }
                P.betta2[GEAR] = Math.Asin(Math.Sin(P.betta2e[GEAR]) * P.Wzv[GEAR] * P.v2t[GEAR] / (P.W2t[GEAR] * P.v2zv[GEAR]));
                for_Wzv_f2.Text = "" + Math.Round(P.Wzv[GEAR], 3);
            }
            if (P.M2t[GEAR] > 1.35)
            {
                W2zv_or_f2.Text = "Степень расширения канала сопла f1";
                P.F2zv[GEAR] = P.G[GEAR] / (P.nu2[GEAR] * xi1 * Math.Sqrt(P.p1_[GEAR] / P.v1_[GEAR]));
                P.F2[GEAR] = P.G[GEAR] * P.v2t[GEAR] / (P.nu2[GEAR] * P.W2t[GEAR]);
                if (!V_U)
                {
                    P.betta2e[GEAR] = P.betta1[GEAR] - P.deltabetta[GEAR];
                    P.l2[GEAR] = P.F2[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.Parc[GEAR] * Math.Sin(P.betta2e[GEAR]));
                }
                if (V_U)
                {
                    P.betta2e[GEAR] = Math.Asin(P.F2[GEAR] * 1000 / (Math.PI * P.dcr[GEAR] * P.l2[GEAR] * P.Parc[GEAR]));
                }
                P.f2[GEAR] = P.F2[GEAR] / P.F2zv[GEAR];
                P.betta2[GEAR] = P.betta2e[GEAR];
                P.delta2[GEAR] = 0;
                P.bettazv[GEAR] = Math.Asin(Math.Sin(P.betta2[GEAR]) / P.f2[GEAR]);
                for_Wzv_f2.Text = "" + Math.Round(P.f1[GEAR], 3);
                for_bettazv.Text = "" + Math.Round(P.bettazv[GEAR] * 180 / Math.PI, 3);
            }

            for_nu2.Text = "" + Math.Round(P.nu2[GEAR], 3);
            for_l2.Text = "" + Math.Round(P.l2[GEAR], 3);
            for_F2.Text = "" + Math.Round(P.F2[GEAR], 3);
            for_F2zv.Text = "" + Math.Round(P.F2zv[GEAR], 3);
            for_betta2e.Text = "" + Math.Round(P.betta2e[GEAR] * 180 / Math.PI, 3);
            for_betta2.Text = "" + Math.Round(P.betta2[GEAR] * 180 / Math.PI, 3);
            for_delta2.Text = "" + Math.Round(P.delta2[GEAR] * 180 / Math.PI, 3);

        }

        public void CALCULATE_GEOM_R(Label for_profile_r, Label for_bettay, Label for_t2opt, Label for_t2, Label for_z2, Label for_b2geom, Label for_B2, Label for_O2, Label for_new_nu2, Label for_delta_nu2, int Vlazh, int G)
        {

            P.bettay[G] = Pr.returnALFAy(Pr.findProfile_R(P.M2t[G], P.betta2e[G] * 180 / Math.PI, P.betta1[G] * 180 / Math.PI));
            P.topt2[G] = Pr.returnTopt(Pr.findProfile_R(P.M2t[G], P.betta2e[G] * 180 / Math.PI, P.betta1[G] * 180 / Math.PI));

            P.b2shtrix[G] = P.B2[G] / Math.Sin(P.bettay[G] * Math.PI / 180);
            P.t2_geom[G] = P.topt2[G] * P.b2shtrix[G];
            P.z2[G] = Math.PI * P.dcr[G] * 1000 * P.Parc[G] / P.t2_geom[G];
            P.z2[G] = Math.Round(P.z2[G]);
            P.t2_geom[G] = Math.PI * P.dcr[G] * 1000 * P.Parc[G] / P.z2[G];
            P.b2[G] = P.t2_geom[G] / P.topt2[G];
            P.B2[G] = P.b2[G] * Math.Sin(P.bettay[G] * Math.PI / 180);
            P.O2[G] = P.t2_geom[G] * Math.Sin(P.betta2e[G]);
            double nu2_shtrih = P.nu2[G];
            P.nu2[G] = A.nu1(Vlazh, P.y2t[G] * 100, P.Rocr[G], P.b2[G] / P.l2[G], 180 - ((P.betta1[G] + P.betta2[G])* 180 / Math.PI), 1);
            P.delta_nu2 = Math.Abs(P.nu2[G] - nu2_shtrih) / (Math.Max(P.nu2[G], nu2_shtrih)) * 100;
            P.v2kin[G] = Functions.wspDYNVISHS(P.i2t[G]*1000, P.s1[G]) * P.v2t[G];
            P.P_R[G] = (String)(Pr.findProfile_R(P.M2t[G], P.betta2e[G] * 180 / Math.PI, P.betta1[G] * 180 / Math.PI)[Pr.INDEX_name]);

            for_profile_r.Text = "Тип профиля : " + (String)(Pr.findProfile_R(P.M2t[G], P.betta2e[G] * 180 / Math.PI, P.betta1[G] * 180 / Math.PI)[Pr.INDEX_name]);
            for_bettay.Text = "" + Math.Round(P.bettay[G], 3);
            for_t2opt.Text = "" + Math.Round(P.topt2[G], 3);
            for_t2.Text = "" + Math.Round(P.t2_geom[G], 3);
            for_z2.Text = "" + Math.Round(P.z2[G]);
            for_b2geom.Text = "" + Math.Round(P.b2[G], 3);
            for_B2.Text = "" + Math.Round(P.B2[G], 3);
            for_O2.Text = "" + Math.Round(P.O2[G], 3);
            for_new_nu2.Text = "" + Math.Round(P.nu2[G], 3);
            for_delta_nu2.Text = "" + Math.Round(P.delta_nu2, 3);
        }

        public void CHECK_NU2(Label for_nu2, Label for_l2, Label for_F2, Label for_F2zv, Label for_C2zv_f2, Label for_betta2e, Label for_betta2, Label for_delta2, Label for_bettazv, Label C2zv_or_f2,
                                Label for_profile_r, Label for_bettay, Label for_t2opt, Label for_t2, Label for_z2, Label for_b2geom, Label for_B2, Label for_O2, Label for_new_nu2, Label for_delta_nu2, bool V_U, int Vlazh, int GEAR)
        {

            while (P.delta_nu2 > 1)
            {
                CALCULATE_Rezhim_M_RAB(for_nu2, for_l2,  for_F2,  for_F2zv,  for_C2zv_f2,  for_betta2e,  for_betta2,  for_delta2,  for_bettazv,  C2zv_or_f2, V_U, Vlazh, GEAR);
                CALCULATE_GEOM_R( for_profile_r,  for_bettay,  for_t2opt,  for_t2,  for_z2,  for_b2geom,  for_B2,  for_O2,  for_new_nu2,  for_delta_nu2,  Vlazh,  GEAR);
            }
        }

        public void CALCULATE_POTERI_RAB(Label for_delta_BETTA, Label for_zetta0r, Label for_kmR, Label for_kb, Label for_kreR, Label for_zetta1ppr, Label for_zetta1vlr, Label for_psi, Label for_W2,
                                       Label for_alfa2, Label for_C2, Label for_delta_Hvc, Label for_delta_H2, Label for_i2, Label for_t2, Label for_y2, Label for_v2, int V, int G)
        {
            P.delta_BETTA[G] = 180 - (P.betta1[G] + P.betta2[G]) * 180 / Math.PI;
            P.zetta0r[G] = A.zetta0(P.delta_BETTA[G], P.b2[G] / P.l2[G]);
            P.kmR[G] = A.km(P.M2t[G]);
            P.kb[G] = A.ka(P.betta2e[G] * 180 / Math.PI);
            P.kreR[G] = 1; //Число рейнольдса
            P.zetta1ppr[G] = P.zetta0r[G] * P.kmR[G] * P.kb[G] * P.kreR[G];
            P.zetta2[G] = P.zetta1ppr[G];
            if (V != 0)
            {
                P.zetta1vlr[G] = P.zetta1ppr[G] + P.y1[G] * P.xf[G];
                P.zetta2[G] = P.zetta1vlr[G];
            }
            P.psi[G] = Math.Sqrt(1 - P.zetta2[G]);
            P.W2[G] = P.psi[G] * P.W2t[G];
            P.alfa2[G] = Math.Atan(Math.Sin(P.betta2[G]) / (Math.Cos(P.betta2[G]) - (P.U[G] / P.W2[G])));
            P.C2[G] = P.W2[G] * Math.Sin(P.betta2[G]) / Math.Sin(P.alfa2[G]);
            P.delta_Hvc[G] = Math.Pow(Math.Abs(P.C2[G]), 2) / 2000;
            P.delta_H2[G] = P.zetta2[G] * P.H02_[G];
            P.i2[G] = P.i2t[G] + P.delta_H2[G];
            P.t2[G] = Functions.wspTPH(P.p2t[G], P.i2[G] * 1000) - 273.15;
            P.v2[G] = Functions.wspVPH(P.p2t[G], P.i2[G] * 1000);
            P.y2[G] = 1 - Math.Abs(Functions.wspXPH(P.p2t[G], P.i1[G] * 1000));
            CheckVLAZH(P.y2[G]);
            P.s2[G] = Functions.wspSPH(P.p2t[G], P.i2[G] * 1000);

            for_delta_BETTA.Text = "" + Math.Round(P.delta_BETTA[G], 3);
            for_zetta0r.Text = "" + Math.Round(P.zetta0r[G], 3);
            for_kmR.Text = "" + Math.Round(P.kmR[G], 3);
            for_kb.Text = "" + Math.Round(P.kb[G], 3);
            for_kreR.Text = "" + Math.Round(P.kreR[G], 3);
            for_zetta1ppr.Text = "" + Math.Round(P.zetta1ppr[G], 3);
            if (V != 0)
            {
                for_zetta1vlr.Text = "" + Math.Round(P.zetta1vlr[G], 3);
            }
            for_psi.Text = "" + Math.Round(P.psi[G], 3);
            for_W2.Text = "" + Math.Round(P.W2[G], 3);
            if (P.alfa2[G] < 0)
            {
                for_alfa2.Text = "" + Math.Round(180 - Math.Abs(P.alfa2[G] * 180 / Math.PI), 3);
            }
            else
            {
                for_alfa2.Text = "" + Math.Round(P.alfa2[G] * 180 / Math.PI, 3);
            }
            for_C2.Text = "" + Math.Round(Math.Abs(P.C2[G]), 3);
            for_delta_Hvc.Text = "" + Math.Round(P.delta_Hvc[G], 3);
            for_delta_H2.Text = "" + Math.Round(P.delta_H2[G], 3);
            for_i2.Text = "" + Math.Round(P.i2[G], 3);
            for_t2.Text = "" + Math.Round(P.t2[G], 3);
            for_v2.Text = "" + Math.Round(P.v2[G], 3);
            for_y2.Text = "" + Math.Round(P.y2[G], 3);
        }

        public void CALCULATE_DOP_POTERI_KPD(Label for_E0_1, Label for_eta_ol_1n, Label for_eta_ol_pr, Label for_vcr, Label for_Reu, Label for_s0_kpd, Label for_ktr, Label for_xi_tr,
                                                Label for_xi_v, Label for_xi_c, Label for_xi_vl, Label for_d1y, Label for_sigma1y, Label for_F1y, Label for_z1y, Label for_ky, Label for_nu1y,
                                                Label for_xi_du, Label for_Rop, Label for_sigmaa, Label for_sigmar, Label for_z2y, Label for_sigmaekv, Label for_sigmaekv_bez, Label for_xi_pu,
                                                Label for_F2y, Label for_eta_oi, Label for_delta_Htr, Label for_delta_Hp, Label for_delta_Hut, Label for_delta_Hvl, Label for_Ntr, Label for_Nv, Label for_Hi,
                                                Label for_SEP, Label for_delta_y, Label for_delta_Gshtrix, Label for_delta_Gshtrix2, Label for_Gsep, Label for_y2kshtrix, Label for_i2kshtrix,
                                                int V, int G)
        {
            P.X[G] = Math.Pow(Math.Sin(P.alfa2[G]), 2);
            if (G < P.Z-1)
            {
                P.G[G + 1] = P.G[G];
            }

            if (G == 0)
            {
                P.E0[G] = P.H0[G] - P.X[G] * P.delta_Hvc[G]; // кДж/кг
                P.eta_ol[G] = (P.E0[G] - P.delta_H1[G] - P.delta_H2[G]) / P.E0[G]; // кДж/кг
            }
            if(G!=0 && G < P.Z-1)
            {
                P.E0[G] = P.H0_[G] - P.X[G] * P.delta_Hvc[G]; // кДж/кг
                P.eta_ol[G] = (P.E0[G] - P.delta_H1[G] - P.delta_H2[G] - P.delta_Hvc[G]*(1-P.X[G])) / P.E0[G]; // кДж/кг
            }
            if (G == P.Z-1)
            {
                P.E0[G] = P.H0_[G];
                P.eta_ol[G] = (P.E0[G] - P.delta_H1[G] - P.delta_H2[G] - P.delta_Hvc[G]) / P.E0[G];
            }
            P.eta_ol_pr[G] = P.U[G] * (P.W1[G] * Math.Cos(P.betta1[G]) + P.W2[G] * Math.Cos(P.betta2[G])) / (P.E0[G] * 1000);
            P.delta_eta[G] = Math.Abs(P.eta_ol[G] - P.eta_ol_pr[G]) * 100 / (Math.Max(P.eta_ol_pr[G], P.eta_ol[G])); // % д.б. <= 0.2%
            P.vkin[G] = (P.v1kin[G] + P.v2kin[G]) / 2;
            P.Reu[G] = P.U[G] * P.dcr[G] / (2 * P.vkin[G]);
            P.ktr[G] = 2.5 * 0.01 * Math.Pow(((2 * 0.001 * P.sd[G]) / (P.dcr[G] - P.l2[G] * 0.001)), 0.1) * Math.Pow(P.Reu[G], -0.2);
            P.xi_tr[G] = P.ktr[G] * Math.Pow(P.U[G] / P.Cf[G], 3) * Math.Pow(P.dcr[G], 2) / P.F1[G];
            if (P.Parc[G] == 1)
            {
                P.xi_v[G] = 0;
                P.xi_c[G] = 0;
            }
            else
            {
                P.xi_v[G] = 0.065 * Math.Pow((P.U[G] / P.Cf[G]), 3) * (1 - P.Parc[G] - 0.5 * 0.8 * (1 - P.Parc[G])) * P.m[G] / (Math.Sin(P.alfa1e[G] * P.Parc[G]));
                P.xi_c[G] = 0.25 * P.B2[G] * P.l2[G] * P.U[G] * P.eta_ol[G] * P.m[G] / (P.F1[G] * 1000000 * P.Cf[G]);
            }
            P.F1y[G] = Math.PI * P.d1y[G] * P.sigma1y[G];
            P.ky[G] = A.Ky(P.z1y[G], 0.02);
            P.nu1y[G] = A.nu1y(P.sigma1y[G]/P.delta_greben[G], P.TYPE_LABIRINT[G]);
            P.xi_du[G] = (P.ky[G] * P.nu1y[G] * P.F1y[G] * P.eta_ol[G]) / (P.nu1[G] * P.F1[G] * Math.Sqrt(P.z1y[G]));
            P.Rop[G] = 1 - (1 - P.Rocr[G]) * (1 - 1.8 * P.l2[G] * 0.001 / P.dcr[G]);
            P.sigmaekv[G] = 1 / (Math.Sqrt((4 / Math.Pow(P.sigmaa[G], 2)) + (1.57 * P.z2y[G] / Math.Pow(P.sigmar[G], 2))));
            P.sigmaekv_bez[G] = 0.75 * P.sigmar[G];
            double ekvsigma = P.sigmaekv[G];
            if(P.bandazh[G] == 0){
                    ekvsigma = P.sigmaekv_bez[G];
            }

            P.xi_pu[G] = P.eta_ol[G] * Math.Sqrt(P.Rop[G] / (1 - P.Rocr[G])) * (Math.PI * ekvsigma * 0.001 * (P.dcr[G] + P.l2[G] * 0.001)) / (P.F1[G] * P.nu1[G]);
            P.F2y[G] = Math.PI * (P.dcr[G] + P.l2[G] * 0.001) * P.sigmar[G] * 0.001;
            if (V == 0)
            {
                P.xi_vl[G] = 0;
            }
            else
            {
                P.xi_vl[G] = 2 * (0.9 * P.y0_[G] + 0.35*(P.y2[G] - P.y0_[G])) * P.xf[G];
            }
            P.eta_oi[G] = P.eta_ol[G] - P.xi_tr[G] - P.xi_v[G] - P.xi_c[G] - P.xi_du[G] - P.xi_pu[G] - P.xi_vl[G];

            P.delta_Htr[G] = P.xi_tr[G] * P.E0[G];
            P.delta_Hp[G] = (P.xi_v[G] + P.xi_c[G]) * P.E0[G];
            P.delta_Hut[G] = (P.xi_du[G] + P.xi_pu[G]) * P.E0[G];
            P.delta_Hvl[G] = P.xi_vl[G] * P.E0[G];
            P.Ntr[G] = P.delta_Htr[G] * P.G[G];
            P.Nv[G] = P.xi_v[G] * P.E0[G] * P.G[G];
            P.Hi[G] = P.E0[G] * P.eta_oi[G];

            if (P.SEP[G] > 0 && P.y0[G]>=0.03)
            {
                P.delta_y[G] = P.y0[G] * P.SEP[G] * 100;
                P.delta_Gshtrix[G] = P.delta_y[G] * P.G[G] / 100;
                P.delta_Gshtrix2[G] = 0.005 * P.G[G];
                // УМЕНЬШИТЬ РАСХОД ЧЕРЕЗ СЛЕД СТУПЕНЬ.
                if (G < P.Z-1)
                {
                    P.G[G + 1] -= (P.delta_Gshtrix[G] + P.delta_Gshtrix2[G]);
                }
                P.y2kshtrix[G] = P.y2[G] - P.delta_y[G] / 100;
                P.h2kshtrix[G] = Functions.wspHSTX(Functions.wspTSP(P.p2t[G]), 1 - P.y2kshtrix[G])*0.001;

                for_SEP.Text = "" + P.SEP[G];
                for_delta_y.Text = "" + Math.Round(P.delta_y[G], 3);
                for_delta_Gshtrix.Text = "" + Math.Round(P.delta_Gshtrix[G], 3);
                for_delta_Gshtrix2.Text = "" + Math.Round(P.delta_Gshtrix2[G], 3);
                for_Gsep.Text = "" + Math.Round((P.delta_Gshtrix[G] + P.delta_Gshtrix2[G]), 3);
                for_y2kshtrix.Text = "" + Math.Round(P.y2kshtrix[G], 3);
                for_i2kshtrix.Text = "" + Math.Round(P.h2kshtrix[G], 3);
            }
            if (G < P.Z-1)
            {
                P.G[G + 1] -= P.G[G] * (P.xi_du[G] + P.xi_pu[G]) / P.eta_ol[G];
            }


            for_E0_1.Text = "" + Math.Round(P.E0[G], 3);
            for_eta_ol_1n.Text = "" + Math.Round(P.eta_ol[G], 3);
            for_eta_ol_pr.Text = "" + Math.Round(P.eta_ol_pr[G], 3);
            for_vcr.Text = "" + Math.Round(P.vkin[G], 8);
            for_Reu.Text = "" + Math.Round(P.Reu[G], 0);
            for_s0_kpd.Text = "" + Math.Round(P.sd[G], 3);
            for_ktr.Text = "" + Math.Round(P.ktr[G], 4);
            for_xi_tr.Text = "" + Math.Round(P.xi_tr[G], 4);
            for_xi_v.Text = "" + Math.Round(P.xi_v[G], 3);
            for_xi_c.Text = "" + Math.Round(P.xi_c[G], 3);
            for_d1y.Text = "" + Math.Round(P.d1y[G], 3);
            for_sigma1y.Text = "" + Math.Round(P.sigma1y[G]*1000, 3);
            for_F1y.Text = "" + Math.Round(P.F1y[G], 4);
            for_z1y.Text = "" + Math.Round(P.z1y[G], 3);
            for_ky.Text = "" + Math.Round(P.ky[G], 3);
            for_nu1y.Text = "" + Math.Round(P.nu1y[G], 3);
            for_xi_du.Text = "" + Math.Round(P.xi_du[G], 3);
            for_Rop.Text = "" + Math.Round(P.Rop[G], 3);
            for_sigmaa.Text = "" + Math.Round(P.sigmaa[G], 3);
            for_sigmar.Text = "" + Math.Round(P.sigmar[G], 3);
            for_z2y.Text = "" + Math.Round(P.z2y[G], 3);
            for_sigmaekv.Text = "" + Math.Round(P.sigmaekv[G], 3);
            for_sigmaekv_bez.Text = "" + Math.Round(P.sigmaekv_bez[G], 3);
            for_xi_pu.Text = "" + Math.Round(P.xi_pu[G], 3);
            for_F2y.Text = "" + Math.Round(P.F2y[G], 3);
            for_xi_vl.Text = "" + Math.Round(P.xi_vl[G], 3);
            for_eta_oi.Text = "" + Math.Round(P.eta_oi[G], 3);
            for_delta_Htr.Text = "" + Math.Round(P.delta_Htr[G], 3);
            for_delta_Hp.Text = "" + Math.Round(P.delta_Hp[G], 3);
            for_delta_Hut.Text = "" + Math.Round(P.delta_Hut[G], 3);
            for_delta_Hvl.Text = "" + Math.Round(P.delta_Hvl[G], 3);
            for_Ntr.Text = "" + Math.Round(P.Ntr[G], 3);
            for_Nv.Text = "" + Math.Round(P.Nv[G], 3);
            for_Hi.Text = "" + Math.Round(P.Hi[G], 3);
        }

        public void CALCULATE_NEXT_GEAR(Label for_Xi, Label for_h2k, Label for_delta_Hsep, Label for_p2k, Label for_t2k, Label for_s2k, Label for_v2k, Label for_y2k, Label for_h2k_,
                                        Label for_p2k_, Label for_t2k_, Label for_v2k_, Label for_y2k_, Label for_p0_k, Label for_t0_k, Label for_i0_k, Label for_s0_k, Label for_v0_k, Label for_y0_k,
                                        Label for_p0_k_, Label for_t0_k_, Label for_i0_k_, Label for_s0_k_, Label for_v0_k_, Label for_y0_k_, int V, int G)
        {
            // ЕСЛИ ЭТО ПОСЛЕДНЯЯ СТУПЕНЬ ТО P.X = 0
            if (G == P.Z - 1 && P.Z!=1)
            {
                P.X[G] = 0;
            }
            P.i2k[G] = P.i2[G] + P.delta_Htr[G] + P.delta_Hp[G] + P.delta_Hut[G] + P.delta_Hvl[G] + (1 - P.X[G]) * P.delta_Hvc[G];
            P.delta_Hsep[G] = 0;
            if (P.SEP[G] > 0 && P.y0[G] >= 0.03)
            {
                P.delta_Hsep[G] = P.h2kshtrix[G] - P.i2k[G]; // кДж/кг
                if (P.delta_Hsep[G] > 0)
                {
                    P.i2k[G] = P.h2kshtrix[G];
                }
            }
                P.t2k[G] = Functions.wspTPH(P.p2t[G], P.i2k[G] * 1000) - 273.15;
                P.s2k[G] = Functions.wspSPH(P.p2t[G], P.i2k[G] * 1000);
                P.v2k[G] = Functions.wspVPH(P.p2t[G], P.i2k[G] * 1000);
                P.y2k[G] = 1 - Math.Abs(Functions.wspXPH(P.p2t[G], P.i2k[G] * 1000));
                CheckVLAZH(P.y2k[G]);
                P.p2k[G] = P.p2t[G];
                // ЕСЛИ ЭТО ПОСЛЕДНЯЯ СТУПЕНЬ ТО P.i2k_ = P.i2k
                P.i2k_[G] = P.i2k[G] + P.X[G] * P.delta_Hvc[G];
                P.p2k_[G] = Functions.wspPHS(P.i2k_[G] * 1000, P.s2k[G]);
                P.t2k_[G] = Functions.wspTHS(P.i2k_[G] * 1000, P.s2k[G]) - 273.15;
                P.v2k_[G] = Functions.wspVHS(P.i2k_[G] * 1000, P.s2k[G]);
                P.y2k_[G] = 1 - Math.Abs(Functions.wspXHS(P.i2k_[G] * 1000, P.s2k[G]));

                for_Xi.Text = "" + Math.Round(P.X[G], 4);
                for_h2k.Text = "" + Math.Round(P.i2k[G], 3);
                for_delta_Hsep.Text = "" + Math.Round(P.delta_Hsep[G], 3);

                for_p2k.Text = "" + Math.Round(P.p2k[G] * 0.00001, 3);
                for_t2k.Text = "" + Math.Round(P.t2k[G], 3);
                for_v2k.Text = "" + Math.Round(P.v2k[G], 3);
                for_y2k.Text = "" + Math.Round(P.y2k[G], 3);
                for_s2k.Text = "" + Math.Round(P.s2k[G] * 0.001, 3);

                for_h2k_.Text = "" + Math.Round(P.i2k_[G], 3);
                for_p2k_.Text = "" + Math.Round(P.p2k_[G] * 0.00001, 3);
                for_t2k_.Text = "" + Math.Round(P.t2k_[G], 3);
                for_v2k_.Text = "" + Math.Round(P.v2k_[G], 3);
                for_y2k_.Text = "" + Math.Round(P.y2k_[G], 3);

                for_p0_k.Text = "" + Math.Round(P.p2k[G] * 0.00001, 3);
                for_t0_k.Text = "" + Math.Round(P.t2k[G], 3);
                for_v0_k.Text = "" + Math.Round(P.v2k[G], 3);
                for_y0_k.Text = "" + Math.Round(P.y2k[G], 3);
                for_s0_k.Text = "" + Math.Round(P.s2k[G] * 0.001, 3);
                for_i0_k.Text = "" + Math.Round(P.i2k[G], 3);

                for_i0_k_.Text = "" + Math.Round(P.i2k_[G], 3);
                for_p0_k_.Text = "" + Math.Round(P.p2k_[G] * 0.00001, 3);
                for_t0_k_.Text = "" + Math.Round(P.t2k_[G], 3);
                for_v0_k_.Text = "" + Math.Round(P.v2k_[G], 3);
                for_y0_k_.Text = "" + Math.Round(P.y2k_[G], 3);
                for_s0_k_.Text = "" + Math.Round(P.s2k[G] * 0.001, 3);
            
        }

        public void NEW_CALC(Label[] labels)
        {
            for(int i = 0; i<labels.Count(); i++)
            {
                labels[i].Text = "-";
            }
            P.GEAR = 0;
            P.VLAZH = 0;
            P.y0[0] = 0;
            P.i0[0] = 0;
            P.s0[0] = 0;
        }
    }
    
}
