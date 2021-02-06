using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace PT1._0
{
    public partial class Form1 : Form
    {
        bool Visoti = false;
        bool wrong = false, once = true, onetoone = false;
        Calc Calc = new Calc();
        Total total;
        int ii = 0;
        Profiles Pr = new Profiles();


        public Form1()
        {
            tabControl1 = new TabControl();

            InitializeComponent();
          
            label34.Text = "Коэффициент использования\nэнергии выходной скорости \u03A70";
            label67.Text = "Отношение давлений \u03B5 1";
            label69.Text = "Коэффициент расхода \u03BC 1";
            label78.Text = "Эффективный угол выхода\nпотока из решетки \u03b1 1э";
            label79.Text = "Угол выхода потока из решекти \u03b1 1";
            label80.Text = "Угол отклонения потока\nв косом срезе решетки \u03B4 1";
            label82.Text = "Угол в критическом\nсечении решетки \u03b1 *";
            label89.Text = "Угол установки (\u03B1y)T";
            label96.Text = "Коэффициент расхода \u03BC 1";
            label106.Text = "Угол поворота потока в\nсопловой решетке \u0394\u03B1";
            label109.Text = "Коэффициент потерь энергии\nбез учета поправок \u03B60";
            label118.Text = "Суммарный коэффициент потерь\nэнергии для перегретого пара \u03B61пп";
            label120.Text = "Суммарный коэффициент потерь\nэнергии для влажного пара \u03B61вл";
            label122.Text = "Коэффициент скорости\nсопловой решетки \u03C6";
            label126.Text = "Угол направления относительной\nскорости входа потока пара\nна рабочие лопатки \u03B21";
            label134.Text = "Кинетическая энергия пара на\nвходе в рабочую решетку \u0394Hвх";
            label137.Text = "Потеря энергии в сопловой\nрешетке \u0394H1";

            label130.Text = "Коэффициент расхода \u03BC 2";
            label181.Text = "Отношение давлений \u03B5 2";
            label166.Text = "Эффективный угол выхода\nпотока из решетки \u03b2 2э";
            label167.Text = "Угол выхода потока из решекти \u03b2 2";
            label168.Text = "Угол отклонения потока\nв косом срезе решетки \u03B4 2";
            label182.Text = "Угол в критическом\nсечении решетки \u03b2 *";
            label208.Text = "Угол установки (\u03B2y)T";
            label201.Text = "Коэффициент расхода \u03BC 2";
            label226.Text = "Угол поворота потока в\nрабочей решетке \u0394\u03B2";
            label223.Text = "Коэффициент потерь энергии\nбез учета поправок \u03B60";
            label215.Text = "Суммарный коэффициент потерь\nэнергии для перегретого пара \u03B62пп";
            label213.Text = "Суммарный коэффициент потерь\nэнергии для влажного пара \u03B62вл";
            label211.Text = "Коэффициент скорости\nрабочей решетки \u03C8";
            label198.Text = "Угол направления абсолютной\nскорости выхода потока пара\nиз рабочей решетки \u03B1 2";
            Visoti = true;
            button6.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            button8.Enabled = false;
            button10.Enabled = false;
            comboBox1.Enabled = false;
            comboBox1.SelectedIndex = 0;
            textBox5.Enabled = false;
            label1.Enabled = false;
            total = new Total(dataGridView1, label20);
            button11.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GearParam GP = new GearParam(P.GEAR);
            GP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Triangle T = new Triangle();
            T.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Visoti = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Visoti = false;
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void button2_Click(object sender, EventArgs e)
        {
            //ПРОТОЧНАЯ ЧАСТЬ
            PC pc = new PC(P.GEAR-1);
            pc.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HS hs = new HS(P.GEAR);
            hs.ShowDialog();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 1)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            DH dh = new DH(P.GEAR, this);
            dh.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            wrong = false;
            try
            {
                if (once)
                {
                    P.p0[P.GEAR] = Convert.ToDouble(textBox1.Text);
                    P.t0[P.GEAR] = Convert.ToDouble(textBox2.Text);
                    if (textBox3.Enabled)
                    {
                        P.Pk = Convert.ToDouble(textBox3.Text);
                        P.HS = Convert.ToDouble(textBox4.Text);
                    }
                    P.G[P.GEAR] = Convert.ToDouble(textBox12.Text);
                    P.n = Convert.ToDouble(textBox13.Text);
                    P.Z = (int)numericUpDown1.Value;
                    if (checkBox1.Checked)
                    {
                        if (comboBox1.SelectedIndex == 0 && Convert.ToDouble(textBox5.Text)<1)
                        {
                            P.y0[P.GEAR] = 1 - Convert.ToDouble(textBox5.Text);
                        }
                        if (comboBox1.SelectedIndex == 1)
                        {
                            P.i0[P.GEAR] = Convert.ToDouble(textBox5.Text)*1000;
                        }
                        if (comboBox1.SelectedIndex == 2)
                        {
                            P.s0[P.GEAR] = Convert.ToDouble(textBox5.Text)*1000;
                        }
                    }
                    
                }

            }
            catch (Exception)
            {
                
                wrong = true;
                label56.Text = "Неправильно введены начальные данные";
            }
            if (!wrong)
            {

                if (P.GEAR != P.Z)
                {
                    label56.Text = "";
                    int CONTINUE = 0;
                    PopupALL pp = new PopupALL(P.Z, Visoti);
                    pp.ShowDialog();
                    CONTINUE = pp.CONTINUE;
                    if (onetoone && CONTINUE>0)
                    {
                        once = false;
                        try
                        {
                            ii = 0;
                            Calc.CALCULATE_ALL_PARAM(for_p0, for_t0, for_h0, for_i0, for_v0, for_y0, for_s0, for_xi0, for_U, for_Cf, for_H0_,
                                                     for_H01_, for_i1t, for_p1t, for_t1t, for_v1t, for_y1t, for_C1t, for_a1t, for_M1t, for_eps1, Rezhim_m1t, Visoti, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_Rezhim_M(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_GEOM_S(for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CHECK_NU1(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_POTERI(for_delta_alfa, for_zetta0, for_km, for_ka, for_kre, for_zetta1pp, for_zetta1vl, for_phi, for_C1, for_betta1, for_W1, for_delta_Hvx, for_delta_H1, for_i1, for_t1, for_v1, for_y1, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_ALL_PARAM_RAB(for_p1_, for_t1_, for_i1_, for_s1_, for_v1_, for_y1_, for_H02, for_H02_, for_i2t, for_p2t, for_t2t, for_v2t, for_y2t, for_W2t, for_a2t, for_M2t, for_eps2, for_nu2, Rezhim_m2t, Visoti, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_Rezhim_M_RAB(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, Visoti, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_GEOM_R(for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CHECK_NU2(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, Visoti, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_POTERI_RAB(for_delta_BETTA, for_zetta0r, for_kmR, for_kb, for_kreR, for_zetta1ppr, for_zetta1vlr, for_psi, for_W2, for_alfa2, for_C2, for_delta_Hvc, for_delta_H2, for_i2, for_t2, for_y2, for_v2, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_DOP_POTERI_KPD(for_E0_1, for_eta_ol_1n, for_eta_ol_pr, for_vcr, for_Reu, for_s0_kpd, for_ktr, for_xi_tr,
                                                             for_xi_v, for_xi_c, for_xi_vl, for_d1y, for_sigma1y, for_F1y, for_z1y, for_ky, for_nu1y,
                                                             for_xi_du, for_Rop, for_sigmaa, for_sigmar, for_z2y, for_sigmaekv, for_sigmaekv_bez, for_xi_pu,
                                                             for_F2y, for_eta_oi, for_delta_Htr, for_delta_Hp, for_delta_Hut, for_delta_Hvl, for_Ntr, for_Nv, for_Hi,
                                                             for_SEP, for_delta_y,  for_delta_Gshtrix,  for_delta_Gshtrix2,  for_Gsep, for_y2kshtrix, for_i2kshtrix, P.VLAZH, P.GEAR);
                            ii++;
                            Calc.CALCULATE_NEXT_GEAR(for_Xi, for_h2k, for_delta_Hsep, for_p2k, for_t2k, for_s2k, for_v2k, for_y2k, for_h2k_,
                                                     for_p2k_, for_t2k_, for_v2k_, for_y2k_, for_p0_k, for_t0_k, for_i0_k, for_s0_k, for_v0_k, for_y0_k,
                                                     for_p0_k_, for_t0_k_, for_i0_k_, for_s0_k_, for_v0_k_, for_y0_k_, P.VLAZH, P.GEAR);
                            total.Populate();
                            label33.Text = "" + (P.GEAR + 1) + "ая ступень";
                            label107.Text = "" + (P.GEAR + 1) + "ая ступень";
                            label209.Text = "" + (P.GEAR + 1) + "ая ступень";
                            label237.Text = "" + (P.GEAR + 1) + "ая ступень";
                            P.GEAR++;
                            
                            tabControl1.SelectedTab = tabPage2;
                            tabControl2.SelectedTab = tabPage3;
                            button6.Enabled = true;
                            button2.Enabled = true;
                            button11.Enabled = true;
                            if (P.GEAR > 1)
                            {
                                button8.Enabled = true;
                            }
                            numericUpDown1.Enabled = false;

                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox12.Enabled = false;
                            textBox13.Enabled = false;
                            groupBox2.Enabled = false;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка в расчете, проверьте правильность введенных данных №");
                        }
                        if (P.GEAR == P.Z)
                        {
                            button10.Enabled = true;
                            if (P.Z == 1)
                            {
                                button10.Enabled = false;
                            }
                        }
                    }
                    if (!onetoone && CONTINUE > 0)
                    {
                        for(int i = 0; i < P.Z; i++)
                        {
                            once = false;
                            try
                            {
                                ii = 0;
                                Calc.CALCULATE_ALL_PARAM(for_p0, for_t0, for_h0, for_i0, for_v0, for_y0, for_s0, for_xi0, for_U, for_Cf, for_H0_,
                                                         for_H01_, for_i1t, for_p1t, for_t1t, for_v1t, for_y1t, for_C1t, for_a1t, for_M1t, for_eps1, Rezhim_m1t, Visoti, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_Rezhim_M(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_GEOM_S(for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CHECK_NU1(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_POTERI(for_delta_alfa, for_zetta0, for_km, for_ka, for_kre, for_zetta1pp, for_zetta1vl, for_phi, for_C1, for_betta1, for_W1, for_delta_Hvx, for_delta_H1, for_i1, for_t1, for_v1, for_y1, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_ALL_PARAM_RAB(for_p1_, for_t1_, for_i1_, for_s1_, for_v1_, for_y1_, for_H02, for_H02_, for_i2t, for_p2t, for_t2t, for_v2t, for_y2t, for_W2t, for_a2t, for_M2t, for_eps2, for_nu2, Rezhim_m2t, Visoti, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_Rezhim_M_RAB(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, Visoti, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_GEOM_R(for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CHECK_NU2(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, Visoti, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_POTERI_RAB(for_delta_BETTA, for_zetta0r, for_kmR, for_kb, for_kreR, for_zetta1ppr, for_zetta1vlr, for_psi, for_W2, for_alfa2, for_C2, for_delta_Hvc, for_delta_H2, for_i2, for_t2, for_y2, for_v2, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_DOP_POTERI_KPD(for_E0_1, for_eta_ol_1n, for_eta_ol_pr, for_vcr, for_Reu, for_s0_kpd, for_ktr, for_xi_tr,
                                                                 for_xi_v, for_xi_c, for_xi_vl, for_d1y, for_sigma1y, for_F1y, for_z1y, for_ky, for_nu1y,
                                                                 for_xi_du, for_Rop, for_sigmaa, for_sigmar, for_z2y, for_sigmaekv, for_sigmaekv_bez, for_xi_pu,
                                                                 for_F2y, for_eta_oi, for_delta_Htr, for_delta_Hp, for_delta_Hut, for_delta_Hvl, for_Ntr, for_Nv, for_Hi,
                                                                 for_SEP, for_delta_y, for_delta_Gshtrix, for_delta_Gshtrix2, for_Gsep, for_y2kshtrix, for_i2kshtrix, P.VLAZH, P.GEAR);
                                ii++;
                                Calc.CALCULATE_NEXT_GEAR(for_Xi, for_h2k, for_delta_Hsep, for_p2k, for_t2k, for_s2k, for_v2k, for_y2k, for_h2k_,
                                                         for_p2k_, for_t2k_, for_v2k_, for_y2k_, for_p0_k, for_t0_k, for_i0_k, for_s0_k, for_v0_k, for_y0_k,
                                                         for_p0_k_, for_t0_k_, for_i0_k_, for_s0_k_, for_v0_k_, for_y0_k_, P.VLAZH, P.GEAR);
                                total.Populate();
                                label33.Text = "" + (P.GEAR + 1) + "ая ступень";
                                label107.Text = "" + (P.GEAR + 1) + "ая ступень";
                                label209.Text = "" + (P.GEAR + 1) + "ая ступень";
                                label237.Text = "" + (P.GEAR + 1) + "ая ступень";
                                P.GEAR++;
                                
                                tabControl1.SelectedTab = tabPage2;
                                tabControl2.SelectedTab = tabPage3;
                                button6.Enabled = true;
                                button2.Enabled = true;
                                numericUpDown1.Enabled = false;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка в расчете, проверьте правильность введенных данных №" );
                            }
                            if(i == P.Z - 1)
                            {
                                button10.Enabled = true;
                                if (P.Z == 1)
                                {
                                    button10.Enabled = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Расчет закончен. "+(P.GEAR)+" из "+P.Z+" ступеней.");
                }
                
            }
        }

        private void новыйРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calc.NEW_CALC(new Label[] { for_p0, for_t0, for_h0, for_i0, for_v0, for_y0, for_s0, for_xi0, for_U, for_Cf, for_H0_,for_H01_, for_i1t, for_p1t, for_t1t, for_v1t, for_y1t, for_C1t,
                for_a1t, for_M1t, for_eps1, Rezhim_m1t,for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1,
                for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1,for_delta_alfa, for_zetta0, for_km, for_ka, for_kre, for_zetta1pp, for_zetta1vl, for_phi, for_C1, for_betta1, for_W1, for_delta_Hvx, for_delta_H1, for_i1, for_t1, for_v1, for_y1,
                for_p1_, for_t1_, for_i1_, for_s1_, for_v1_, for_y1_, for_H02, for_H02_, for_i2t, for_p2t, for_t2t, for_v2t, for_y2t, for_W2t, for_a2t, for_M2t, for_eps2, for_nu2, Rezhim_m2t,
                for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2,for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2,
                for_delta_BETTA, for_zetta0r, for_kmR, for_kb, for_kreR, for_zetta1ppr, for_zetta1vlr, for_psi, for_W2, for_alfa2, for_C2, for_delta_Hvc, for_delta_H2, for_i2, for_t2, for_y2, for_v2,
                for_E0_1, for_eta_ol_1n, for_eta_ol_pr, for_vcr, for_Reu, for_s0_kpd, for_ktr, for_xi_tr,
                for_xi_v, for_xi_c, for_xi_vl, for_d1y, for_sigma1y, for_F1y, for_z1y, for_ky, for_nu1y,
                for_xi_du, for_Rop, for_sigmaa, for_sigmar, for_z2y, for_sigmaekv, for_sigmaekv_bez, for_xi_pu,
                for_F2y, for_eta_oi, for_delta_Htr, for_delta_Hp, for_delta_Hut, for_delta_Hvl, for_Ntr, for_Nv, for_Hi,
                for_Xi, for_h2k, for_delta_Hsep, for_p2k, for_t2k, for_s2k, for_v2k, for_y2k, for_h2k_,
                for_p2k_, for_t2k_, for_v2k_, for_y2k_, for_p0_k, for_t0_k, for_i0_k, for_s0_k, for_v0_k, for_y0_k,
                for_SEP, for_delta_y,  for_delta_Gshtrix,  for_delta_Gshtrix2,  for_Gsep, for_y2kshtrix, for_i2kshtrix,
                for_p0_k_, for_t0_k_, for_i0_k_, for_s0_k_, for_v0_k_, for_y0_k_,mc_or_n});
            Visoti = true;
            button6.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            button10.Enabled = false;
            tabControl1.SelectedTab = tabPage1;
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 1;
            numericUpDown1.Enabled = true;
            textBox3.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox4.Text = "";
            once = true;
            total.Clear();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            groupBox2.Enabled = true;
            button11.Enabled = false;

        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, "Help.chm");
            }
            catch (Exception)
            {
                MessageBox.Show("Не найден файл Help.chm");
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.ShowDialog();
            onetoone = opt.onetoone;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (P.GEAR <=1)
            {
                button8.Enabled = false;
            }
            else
            {
                P.GEAR-=2;
                try
                {
                    ii = 0;
                    Calc.CALCULATE_ALL_PARAM(for_p0, for_t0, for_h0, for_i0, for_v0, for_y0, for_s0, for_xi0, for_U, for_Cf, for_H0_,
                                             for_H01_, for_i1t, for_p1t, for_t1t, for_v1t, for_y1t, for_C1t, for_a1t, for_M1t, for_eps1, Rezhim_m1t, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_Rezhim_M(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_GEOM_S(for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CHECK_NU1(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_POTERI(for_delta_alfa, for_zetta0, for_km, for_ka, for_kre, for_zetta1pp, for_zetta1vl, for_phi, for_C1, for_betta1, for_W1, for_delta_Hvx, for_delta_H1, for_i1, for_t1, for_v1, for_y1, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_ALL_PARAM_RAB(for_p1_, for_t1_, for_i1_, for_s1_, for_v1_, for_y1_, for_H02, for_H02_, for_i2t, for_p2t, for_t2t, for_v2t, for_y2t, for_W2t, for_a2t, for_M2t, for_eps2, for_nu2, Rezhim_m2t, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_Rezhim_M_RAB(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_GEOM_R(for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CHECK_NU2(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_POTERI_RAB(for_delta_BETTA, for_zetta0r, for_kmR, for_kb, for_kreR, for_zetta1ppr, for_zetta1vlr, for_psi, for_W2, for_alfa2, for_C2, for_delta_Hvc, for_delta_H2, for_i2, for_t2, for_y2, for_v2, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_DOP_POTERI_KPD(for_E0_1, for_eta_ol_1n, for_eta_ol_pr, for_vcr, for_Reu, for_s0_kpd, for_ktr, for_xi_tr,
                                                     for_xi_v, for_xi_c, for_xi_vl, for_d1y, for_sigma1y, for_F1y, for_z1y, for_ky, for_nu1y,
                                                     for_xi_du, for_Rop, for_sigmaa, for_sigmar, for_z2y, for_sigmaekv, for_sigmaekv_bez, for_xi_pu,
                                                     for_F2y, for_eta_oi, for_delta_Htr, for_delta_Hp, for_delta_Hut, for_delta_Hvl, for_Ntr, for_Nv, for_Hi,
                                                     for_SEP, for_delta_y, for_delta_Gshtrix, for_delta_Gshtrix2, for_Gsep, for_y2kshtrix, for_i2kshtrix, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_NEXT_GEAR(for_Xi, for_h2k, for_delta_Hsep, for_p2k, for_t2k, for_s2k, for_v2k, for_y2k, for_h2k_,
                                             for_p2k_, for_t2k_, for_v2k_, for_y2k_, for_p0_k, for_t0_k, for_i0_k, for_s0_k, for_v0_k, for_y0_k,
                                             for_p0_k_, for_t0_k_, for_i0_k_, for_s0_k_, for_v0_k_, for_y0_k_, P.VLAZH, P.GEAR);
                    total.Populate();
                    label33.Text = "" + (P.GEAR + 1) + "ая ступень";
                    label107.Text = "" + (P.GEAR + 1) + "ая ступень";
                    label209.Text = "" + (P.GEAR + 1) + "ая ступень";
                    label237.Text = "" + (P.GEAR + 1) + "ая ступень";
                    P.GEAR++;
                    
                    tabControl1.SelectedTab = tabPage2;
                    tabControl2.SelectedTab = tabPage3;
                    button6.Enabled = true;
                    button11.Enabled = true;
                    button2.Enabled = true;
                    if (P.GEAR <= 1)
                    {
                        button8.Enabled = false;
                    }
                    numericUpDown1.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка в расчете, проверьте правильность введенных данных №");
                }
                MessageBox.Show("Выполнен расчет " + (P.GEAR) + " ступени.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PopupEXTRA ppe = new PopupEXTRA(P.Z, Visoti, this);
            ppe.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = true;
                comboBox1.SelectedIndex = 0;
                textBox5.Enabled = true;
                label1.Enabled = true;
                label1.Text = "-";
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedIndex = 0;
                textBox5.Enabled = false;
                label1.Enabled = false;
                label1.Text = "-";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "-";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = "кДж/кг";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label1.Text = "кДж/кгК";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Excel File 97-2003 Worksheet (*.xls)|*.xls";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK && sfd.FileName != "")
            {
                if (Path.GetExtension(sfd.FileName) == ".xls")
                {
                    ExcelLibrary.SpreadSheet.Worksheet worksheet = new ExcelLibrary.SpreadSheet.Worksheet("Итоговые результаты");
                    ExcelLibrary.SpreadSheet.Workbook workbook = new ExcelLibrary.SpreadSheet.Workbook();
                    string[] columnsName = new string[] { "№ ступени:", "H0, кДж/кг", "G, кг/с", "КПДoi", "N, МВт" };
                    for (int i = 0; i < columnsName.Length; i++)
                    {
                        worksheet.Cells[0, i] = new ExcelLibrary.SpreadSheet.Cell(columnsName[i]);
                    }
                    for (int i = 0; i <= P.Z; i++)
                    {
                        for(int k = 0; k < 5; k++)
                        {
                            worksheet.Cells[i + 1, k] = new ExcelLibrary.SpreadSheet.Cell((String)dataGridView1.Rows[i].Cells[k].Value);
                        }

                    }
                    workbook.Worksheets.Add(worksheet);
                    workbook.Save(sfd.FileName);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Word file (*.docx)|*.docx";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                if (Path.GetExtension(sfd.FileName) == ".docx")
                {
                    DocX doc = DocX.Create(sfd.FileName);
                    Paragraph p1 = doc.InsertParagraph();
                    p1.AppendLine("Итоговые результаты расчета").FontSize(14);
                    p1.AppendLine();
                    Table t = doc.AddTable(P.Z+2, 5);
                    t.Alignment = Alignment.center;
                    t.Rows[0].Cells[0].Paragraphs.First().Append("№ ступени:").FontSize(12);
                    t.Rows[0].Cells[1].Paragraphs.First().Append("H0, кДж / кг").FontSize(12);
                    t.Rows[0].Cells[2].Paragraphs.First().Append("G, кг/с").FontSize(12);
                    t.Rows[0].Cells[3].Paragraphs.First().Append("\u03b7oi").FontSize(12);
                    t.Rows[0].Cells[4].Paragraphs.First().Append("N, МВт").FontSize(12);
                    for (int i = 0; i <= P.Z; i++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            t.Rows[i+1].Cells[k].Paragraphs.First().Append("" + (String)dataGridView1.Rows[i].Cells[k].Value);

                        }
                    }
                    doc.InsertTable(t);
                    doc.Save();
                }
            }
        }
    

        private void button6_Click(object sender, EventArgs e)
        {
            if (P.GEAR != P.Z)
            {
               int CONTINUE = 0;
                    try
                    {
                        ii = 0;
                        Calc.CALCULATE_ALL_PARAM(for_p0, for_t0, for_h0, for_i0, for_v0, for_y0, for_s0, for_xi0, for_U, for_Cf, for_H0_,
                                                 for_H01_, for_i1t, for_p1t, for_t1t, for_v1t, for_y1t, for_C1t, for_a1t, for_M1t, for_eps1, Rezhim_m1t, Visoti, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_Rezhim_M(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_GEOM_S(for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CHECK_NU1(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_POTERI(for_delta_alfa, for_zetta0, for_km, for_ka, for_kre, for_zetta1pp, for_zetta1vl, for_phi, for_C1, for_betta1, for_W1, for_delta_Hvx, for_delta_H1, for_i1, for_t1, for_v1, for_y1, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_ALL_PARAM_RAB(for_p1_, for_t1_, for_i1_, for_s1_, for_v1_, for_y1_, for_H02, for_H02_, for_i2t, for_p2t, for_t2t, for_v2t, for_y2t, for_W2t, for_a2t, for_M2t, for_eps2, for_nu2, Rezhim_m2t, Visoti, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_Rezhim_M_RAB(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, Visoti, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_GEOM_R(for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CHECK_NU2(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, Visoti, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_POTERI_RAB(for_delta_BETTA, for_zetta0r, for_kmR, for_kb, for_kreR, for_zetta1ppr, for_zetta1vlr, for_psi, for_W2, for_alfa2, for_C2, for_delta_Hvc, for_delta_H2, for_i2, for_t2, for_y2, for_v2, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_DOP_POTERI_KPD(for_E0_1, for_eta_ol_1n, for_eta_ol_pr, for_vcr, for_Reu, for_s0_kpd, for_ktr, for_xi_tr,
                                                         for_xi_v, for_xi_c, for_xi_vl, for_d1y, for_sigma1y, for_F1y, for_z1y, for_ky, for_nu1y,
                                                         for_xi_du, for_Rop, for_sigmaa, for_sigmar, for_z2y, for_sigmaekv, for_sigmaekv_bez, for_xi_pu,
                                                         for_F2y, for_eta_oi, for_delta_Htr, for_delta_Hp, for_delta_Hut, for_delta_Hvl, for_Ntr, for_Nv, for_Hi,
                                                         for_SEP, for_delta_y, for_delta_Gshtrix, for_delta_Gshtrix2, for_Gsep, for_y2kshtrix, for_i2kshtrix, P.VLAZH, P.GEAR);
                        ii++;
                        Calc.CALCULATE_NEXT_GEAR(for_Xi, for_h2k, for_delta_Hsep, for_p2k, for_t2k, for_s2k, for_v2k, for_y2k, for_h2k_,
                                                 for_p2k_, for_t2k_, for_v2k_, for_y2k_, for_p0_k, for_t0_k, for_i0_k, for_s0_k, for_v0_k, for_y0_k,
                                                 for_p0_k_, for_t0_k_, for_i0_k_, for_s0_k_, for_v0_k_, for_y0_k_, P.VLAZH, P.GEAR);
                        total.Populate();
                        label33.Text = "" + (P.GEAR + 1) + "ая ступень";
                        label107.Text = "" + (P.GEAR + 1) + "ая ступень";
                        label209.Text = "" + (P.GEAR + 1) + "ая ступень";
                        label237.Text = "" + (P.GEAR + 1) + "ая ступень";
                        P.GEAR++;
                        tabControl1.SelectedTab = tabPage2;
                        tabControl2.SelectedTab = tabPage3;
                        button6.Enabled = true;
                        button2.Enabled = true;
                        button11.Enabled = true;
                    if (P.GEAR > 1)
                    {
                        button8.Enabled = true;
                    }
                    numericUpDown1.Enabled = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка в расчете, проверьте правильность введенных данных №");
                    }
                    if (P.GEAR == P.Z)
                    {
                        button10.Enabled = true;
                        if (P.Z == 1)
                        {
                            button10.Enabled = false;
                        }
                    }
                if (CONTINUE == 2)
                {

                }
                MessageBox.Show("Выполнен расчет " + (P.GEAR) + " ступени.");
            }
            else
            {
                MessageBox.Show("Расчет закончен. " + (P.GEAR) + " из " + P.Z + " ступеней.");
            }
        }

        public void Renew(int end)
        {
            P.GEAR = 0;
            P.VLAZH = 0;
            for (int i = 0; i < end; i++)
            {
                try
                {
                    ii = 0;
                    Calc.CALCULATE_ALL_PARAM(for_p0, for_t0, for_h0, for_i0, for_v0, for_y0, for_s0, for_xi0, for_U, for_Cf, for_H0_,
                                             for_H01_, for_i1t, for_p1t, for_t1t, for_v1t, for_y1t, for_C1t, for_a1t, for_M1t, for_eps1, Rezhim_m1t, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_Rezhim_M(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_GEOM_S(for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CHECK_NU1(for_nu1, for_l1, for_F1, for_Fzv, for_Czv_f1, for_alfa1e, for_alfa1, for_delta1, for_alfazv1, Czv_or_f1, for_profile, for_alfay, for_topt, for_t1geom, for_z1, for_b1geom, for_B1, for_O1, for_new_nu, for_delta_nu1, mc_or_n, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_POTERI(for_delta_alfa, for_zetta0, for_km, for_ka, for_kre, for_zetta1pp, for_zetta1vl, for_phi, for_C1, for_betta1, for_W1, for_delta_Hvx, for_delta_H1, for_i1, for_t1, for_v1, for_y1, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_ALL_PARAM_RAB(for_p1_, for_t1_, for_i1_, for_s1_, for_v1_, for_y1_, for_H02, for_H02_, for_i2t, for_p2t, for_t2t, for_v2t, for_y2t, for_W2t, for_a2t, for_M2t, for_eps2, for_nu2, Rezhim_m2t, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_Rezhim_M_RAB(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_GEOM_R(for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CHECK_NU2(for_nu2, for_l2, for_F2, for_F2zv, for_Wzv_f2, for_betta2e, for_betta2, for_delta2, for_bettazv, Wzv_or_f2, for_profile_r, for_bettay, for_t2opt, for_t2geom, for_z2, for_b2geom, for_B2, for_O2, for_new_nu2, for_delta_nu2, Visoti, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_POTERI_RAB(for_delta_BETTA, for_zetta0r, for_kmR, for_kb, for_kreR, for_zetta1ppr, for_zetta1vlr, for_psi, for_W2, for_alfa2, for_C2, for_delta_Hvc, for_delta_H2, for_i2, for_t2, for_y2, for_v2, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_DOP_POTERI_KPD(for_E0_1, for_eta_ol_1n, for_eta_ol_pr, for_vcr, for_Reu, for_s0_kpd, for_ktr, for_xi_tr,
                                                     for_xi_v, for_xi_c, for_xi_vl, for_d1y, for_sigma1y, for_F1y, for_z1y, for_ky, for_nu1y,
                                                     for_xi_du, for_Rop, for_sigmaa, for_sigmar, for_z2y, for_sigmaekv, for_sigmaekv_bez, for_xi_pu,
                                                     for_F2y, for_eta_oi, for_delta_Htr, for_delta_Hp, for_delta_Hut, for_delta_Hvl, for_Ntr, for_Nv, for_Hi,
                                                     for_SEP, for_delta_y, for_delta_Gshtrix, for_delta_Gshtrix2, for_Gsep, for_y2kshtrix, for_i2kshtrix, P.VLAZH, P.GEAR);
                    ii++;
                    Calc.CALCULATE_NEXT_GEAR(for_Xi, for_h2k, for_delta_Hsep, for_p2k, for_t2k, for_s2k, for_v2k, for_y2k, for_h2k_,
                                             for_p2k_, for_t2k_, for_v2k_, for_y2k_, for_p0_k, for_t0_k, for_i0_k, for_s0_k, for_v0_k, for_y0_k,
                                             for_p0_k_, for_t0_k_, for_i0_k_, for_s0_k_, for_v0_k_, for_y0_k_, P.VLAZH, P.GEAR);
                    total.Populate();
                    label33.Text = "" + (P.GEAR + 1) + "ая ступень";
                    label107.Text = "" + (P.GEAR + 1) + "ая ступень";
                    label209.Text = "" + (P.GEAR + 1) + "ая ступень";
                    label237.Text = "" + (P.GEAR + 1) + "ая ступень";
                    P.GEAR++;
                    tabControl1.SelectedTab = tabPage2;
                    tabControl2.SelectedTab = tabPage3;
                    button6.Enabled = true;
                    button2.Enabled = true;
                    numericUpDown1.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка в расчете, проверьте правильность введенных данных №");
                }
                if (i == P.Z - 1)
                {
                    button10.Enabled = true;
                }
            }
        
    }
    }
}
