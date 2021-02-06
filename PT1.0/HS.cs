using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PT1._0
{
    public partial class HS : Form
    {

        VerticalLineAnnotation[] Hi;
        TextAnnotation[] RHi;
        int DHS = 50;
        bool once1 = true;
        int G;
        bool pp = true;
        public HS(int G)
        {
            InitializeComponent();
            button3.Enabled = false;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series.Add(new Series());
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.Series[1].IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisY.Minimum = 2000;
            chart1.ChartAreas[0].AxisY.Maximum = 4000;
            chart1.ChartAreas[0].AxisX.Minimum = 6000;
            chart1.ChartAreas[0].AxisX.Maximum = 8000;
            chart1.ChartAreas[0].AxisX.Title = "S, Дж/кгК";
            chart1.ChartAreas[0].AxisY.Title = "H, кДж/кг";
            comboBox1.Items.Add("Отсеке");
            comboBox1.SelectedIndex = 0;
            this.G = G;
            for(int i = 0; i<G; i++)
            {
                comboBox1.Items.Add(""+(i+1));
            }
            Hi = new VerticalLineAnnotation[G];
            RHi = new TextAnnotation[G];
            for(int i = 0; i < G; i++)
            {
                RHi[i] = new TextAnnotation();
                RHi[i].AxisX = chart1.ChartAreas[0].AxisX;
                RHi[i].AxisY = chart1.ChartAreas[0].AxisY;
                RHi[i].IsSizeAlwaysRelative = false;
                RHi[i].Text = "Hi" + (i+1);
                RHi[i].ForeColor = Color.Black;
                RHi[i].Font = new Font("Arial", 12);
                RHi[i].LineWidth = 2;


                Hi[i] = new VerticalLineAnnotation();
                Hi[i].AxisX = chart1.ChartAreas[0].AxisX;
                Hi[i].AxisY = chart1.ChartAreas[0].AxisY;
                Hi[i].IsSizeAlwaysRelative = false;

                Hi[i].StartCap = LineAnchorCapStyle.Arrow;
                Hi[i].EndCap = LineAnchorCapStyle.Arrow;
                Hi[i].IsInfinitive = false;
                Hi[i].ClipToChartArea = chart1.ChartAreas[0].Name;
                Hi[i].LineColor = Color.Black; Hi[i].LineWidth = 2;
            }
            Construct(G);
            
        }


        public void Construct(int G)
        {
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].IsVisibleInLegend = false;
            }
            chart1.Annotations.Clear();
            if (G > 0)
            {
                if (P.Z > 1)
                {
                    ILine(chart1, P.s0[0], P.i0[0] * 0.001, P.HS, Color.Black, 1);
                }
                else
                {
                    ILine(chart1, P.s0[0], P.i0[0]*0.001, P.H0[0], Color.Black, 1);
                }
                for (int i = 0; i < G; i++)
                {
                    ChartScale(i, false);
                    HLine(chart1, P.s0[i], P.i0[i] * 0.001, P.Hi[i], Color.Black, 1);
                    int y1 = (int)(P.i0[i]*0.001);
                    int y2 = (int)(Functions.wspHPS(P.p2k[i], P.s2k[i]) * 0.001);
                    chart1.Series[0].Points.AddXY(P.s0[i], y1);
                    chart1.Series[0].Points.AddXY(P.s2k[i], y2);

                    Izobara(chart1, P.s0[i], P.p0[i] * 100000, Color.Black, 1, "Изобара р = " + Math.Round(P.p0[i], 3)+ " бар");
                    Annotations(i, chart1);

                    if (i == P.Z - 1)
                    {
                            Izobara(chart1, P.s2k[i], P.p2k[i], Color.Black, 1, "Изобара р = " + Math.Round(P.p2k[i] * 0.00001, 3) + " бар");
                    }
                    else
                    {
                        chart1.Series[0].Points.AddXY(P.s2k[i], P.i2k_[i]);
                    }
                }
                if (P.Z != 1)
                {
                    Izobara(chart1, P.s2k[G - 1], P.Pk * 100000, Color.Green, 2, "Конечное давление " + Math.Round(P.Pk, 3) + " бар");
                }
            }
        }
        public void ConstructOne(int G)
        {
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].IsVisibleInLegend = false;
                
            }
            chart1.Annotations.Clear();
            ChartScale(G, true);
            double y1 = (P.i0[G] * 0.001);
            double y2 = (Functions.wspHPS(P.p2k[G], P.s2k[G]) * 0.001);
            if (G == 0)
            {
                Izobara(chart1, P.s0[G], P.p0[G] * 100000, Color.Black, 1, "Изобара р0 = " + Math.Round(P.p0[G], 2) + " бар");
                chart1.Series[0].Points.AddXY(P.s0[G], y1);
                Line(P.s0[G] - 60, y1, P.s0[G], y1, 1);//2
                Line(P.s0[G] - 60, y1, P.s0[G] - 60, Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, 2, "H0=" + Math.Round(P.H0[G], 3) + "кДж/кг", Color.Brown);//8
                Line(P.s0[G] - 75, P.i0[G] * 0.001, P.s0[G], P.i0[G] * 0.001, 1);//1
                Line(P.s0[G] - 75, P.i0[G] * 0.001, P.s0[G] - 75, Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, 2, "H0_=" + Math.Round(P.H0_[G], 3) + "кДж/кг", Color.Blue);//7
                Line(P.s0[G], y1, P.s0[G] + 45, y1, 1);//13
                Line(P.s0[G] + 45, y1, P.s0[G] + 45, Functions.wspHPS(P.p1t[G], P.s0[G]) * 0.001, 2, "H01_=" + Math.Round(P.H01_[G], 3) + "кДж/кг", Color.Black);//18
                Line(P.s0[G] + 30, y1, P.s0[G] + 30, Functions.wspHPS(P.p1t[G], P.s0[G]) * 0.001, 2, "H01=" + Math.Round(P.H01_[G], 3) + "кДж/кг", Color.ForestGreen);//17
            }
            else
            {
                Izobara(chart1, P.s0[G], P.p2k_[G - 1], Color.Black, 1, "Изобара р0_ = " + Math.Round(P.p2k_[G - 1] * 0.00001, 3) + " бар");
                chart1.Series[0].Points.AddXY(P.s0[G], P.i2k_[G - 1]);
                Izobara(chart1, P.s0[G], P.p0[G] * 100000, Color.Black, 1, "Изобара р0 = " + Math.Round(P.p0[G], 3) + " бар");
                chart1.Series[0].Points.AddXY(P.s0[G], y1);

                Line(P.s0[G] - 75, P.i2k_[G - 1], P.s0[G], P.i2k_[G - 1], 1);//1
                Line(P.s0[G] - 60, y1, P.s0[G], y1, 1);//2
                Line(P.s0[G] - 75, P.i2k_[G - 1], P.s0[G] - 75, Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, 2, "H0_=" + Math.Round(P.H0_[G], 3) + "кДж/кг", Color.Blue);//7
                Line(P.s0[G] - 60, y1, P.s0[G] - 60, Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, 2, "H0=" + Math.Round(P.H0[G], 3) + "кДж/кг", Color.Brown);//8
                Line(P.s0[G], P.i2k_[G - 1], P.s0[G] + 45, P.i2k_[G - 1], 1);//13
                Line(P.s0[G] + 45, P.i2k_[G - 1], P.s0[G] + 45, Functions.wspHPS(P.p1t[G], P.s0[G]) * 0.001, 2, "H01_=" + Math.Round(P.H01_[G],3)+"кДж/кг", Color.Black);//18
                Line(P.s0[G] + 30, y1, P.s0[G] + 30, Functions.wspHPS(P.p1t[G], P.s0[G]) * 0.001, 2, "H01=" + Math.Round(P.H01_[G] - (P.i2k_[G] - P.i2k[G]), 3) + "кДж/кг", Color.ForestGreen);//17
            }
            chart1.Series[0].Points.AddXY(P.s1[G], P.i1[G]);
            Izobara(chart1, P.s1[G], P.p1t[G], Color.Black, 1, "Изобара р1 = " + Math.Round(P.p1t[G] * 0.00001, 3) + " бар");
            Izobara(chart1, P.s1[G], P.p1_[G], Color.Black, 1, "Изобара р1_ = " + Math.Round(P.p1_[G] * 0.00001, 3) + " бар");

            chart1.Series[0].Points.AddXY(P.s2[G], P.i2[G]);
            Izobara(chart1, P.s2k[G], P.p2k[G], Color.Black, 1, "Изобара р2k = " + Math.Round(P.p2k[G] * 0.00001, 3) + " бар");

            chart1.Series[0].Points.AddXY(P.s2k[G], y2);
            Izobara(chart1, P.s2k[G], P.p2k_[G], Color.Black, 1, "Изобара р2k_ = " + Math.Round(P.p2k_[G] * 0.00001, 3) + " бар");
            chart1.Series[0].Points.AddXY(P.s2k[G], P.i2k_[G]);
            {
                Line(P.s0[G] - 45, Functions.wspHPS(P.p1_[G], P.s1[G]) * 0.001, P.s1[G], Functions.wspHPS(P.p1_[G], P.s1[G] ) * 0.001, 1); //3
                Line(P.s0[G] - 30, P.i1[G], P.s1[G], P.i1[G], 1); //4
                Line(P.s0[G] - 45, Functions.wspHPS(P.p2k[G], P.s1[G]) * 0.001, P.s1[G], Functions.wspHPS(P.p2k[G], P.s1[G] ) * 0.001, 1); //5
                Line(P.s0[G] - 75, Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, P.s0[G], Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, 1); //6
                Line(P.s0[G] - 45, Functions.wspHPS(P.p1_[G], P.s1[G] ) * 0.001, P.s0[G] - 45, Functions.wspHPS(P.p2k[G], P.s1[G] ) * 0.001, 2, "H02_="+Math.Round(P.H02_[G],3)+"кДж/кг",Color.DarkKhaki);//9
                Line(P.s0[G] - 30, P.i1[G], P.s0[G] - 30, Functions.wspHPS(P.p2k[G], P.s1[G]) * 0.001, 2, "H02="+Math.Round(P.H02[G],3)+"кДж/кг",Color.Chocolate);//10
                Line(P.s0[G], y1, P.s0[G], Functions.wspHPS(P.p2k[G], P.s0[G]) * 0.001, 1);//11
                Line(P.s1[G], P.i1[G], P.s1[G], Functions.wspHPS(P.p2k[G], P.s1[G] ) * 0.001, 1);//12
                Line(P.s0[G], y1, P.s0[G] + 30, y1, 1);//14
                Line(P.s0[G], Functions.wspHPS(P.p1t[G],P.s0[G])*0.001, P.s0[G] + 45, Functions.wspHPS(P.p1t[G], P.s0[G]) * 0.001, 1);//15
            }

        }
        public void ConstructP(int G)
        {
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
                chart1.Series[i].IsVisibleInLegend = false;

            }
            chart1.Annotations.Clear();
            double y1 = (P.i0[G] * 0.001);
            double y2 = (Functions.wspHPS(P.p2k[G], P.s2k[G]) * 0.001);
            ChartScale(P.s2[G], P.s2k[G], P.i2[G], P.i2k_[G]);
            chart1.Series[0].Points.AddXY(P.s0[G], y1);
            chart1.Series[0].Points.AddXY(P.s1[G], P.i1[G]);
            chart1.Series[0].Points.AddXY(P.s2[G], P.i2[G]);
            Line(P.s2[G], P.i2[G], Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G]) * 1000), P.i2[G] + P.delta_Htr[G], 3, "Потери от трения = " + Math.Round(P.delta_Htr[G], 3) + "кДж/кг", Color.Green);
            Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G]) * 1000), P.i2[G] + P.delta_Htr[G], Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G],3,"Потери от утечек = " + Math.Round(P.delta_Hut[G],3) + "кДж/кг",Color.Blue);
            if (P.delta_Hsep[G] > 0)
            {
                Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G], Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G] + P.delta_Hvl[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hvl[G] + P.delta_Hut[G], 3, "Потери от влажности = " + Math.Round(P.delta_Hvl[G], 3) + "кДж/кг", Color.Orange);
                Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G] + P.delta_Hvl[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hvl[G] + P.delta_Hut[G], Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G]+ P.delta_Hsep[G]+ P.delta_Hvl[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hvl[G] + P.delta_Hut[G] + P.delta_Hsep[G], 3, "Потери от сепарации = " + Math.Round(P.delta_Hsep[G], 3) + "кДж/кг", Color.Orange);
                Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G] + P.delta_Hsep[G] + P.delta_Hvl[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hvl[G] + P.delta_Hut[G] + P.delta_Hsep[G],P.s2k[G], y2, 3, "Потери от выходной скорости = " + Math.Round((1-P.X[G])*P.delta_Hvc[G], 3) + "кДж/кг", Color.Violet);
            }
            else
            {
                if (P.delta_Hvl[G] > 0)
                {
                    Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G], Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G] + P.delta_Hvl[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hvl[G] + P.delta_Hut[G], 3, "Потери от влажности = " + Math.Round(P.delta_Hvl[G], 3) + "кДж/кг", Color.Orange);
                    Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G] + P.delta_Hvl[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hvl[G] + P.delta_Hut[G], P.s2k[G], y2, 3, "Потери от выходной скорости = " + Math.Round((1 - P.X[G]) * P.delta_Hvc[G], 3) + "кДж/кг", Color.Violet);
                }
                else
                {
                    Line(Functions.wspSPH(P.p2k[G], (P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G]) * 1000), P.i2[G] + P.delta_Htr[G] + P.delta_Hut[G], P.s2k[G], y2, 3, "Потери от выходной скорости = " + Math.Round((1 - P.X[G]) * P.delta_Hvc[G], 3) + "кДж/кг", Color.Violet);
                }
            }
            if (G != P.Z) 
            {
                Line(P.s2k[G], y2, P.s2k[G], P.i2k_[G], 3, "Использование энергии выходной скорости = " + Math.Round((P.X[G]) * P.delta_Hvc[G], 3) + "кДж/кг", Color.Black);
            }
            Izobara(chart1, P.s2k[G], P.p2k[G], Color.Black, 1, "Изобара р2k = " + Math.Round(P.p2k[G] * 0.00001, 3) + " бар");
            Izobara(chart1, P.s2k[G], P.p2k_[G], Color.Black, 1, "Изобара р2k_ = " + Math.Round(P.p2k_[G] * 0.00001, 3) + " бар");
        }
        public void Izobara(Chart chart, double s, double p, Color c, int bw, String legend)
        {
            Series series = new Series();
            series.LegendText = legend;
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Color = c;
            series.BorderWidth = bw;
            int ds = 50;
            for(int ss = (int)s - ds; ss<=(int)s+ds; ss++)
            {
                series.Points.AddXY(ss, Functions.wspHPS(p, ss)*0.001);
            }
            chart.Series.Add(series);
        }
        public void ILine (Chart chart, double s, double i0, double HS, Color c, int bw)
        {
            Series series = new Series();
            series.IsVisibleInLegend = false;
            series.ChartType = SeriesChartType.Line;
            series.Color = c;
            series.BorderWidth = bw;
            int ds = 50;
            for (int i = (int)(i0-HS-ds); i <= (int)i0+ds; i++)
            {
                series.Points.AddXY(s, i);
            }
            chart.Series.Add(series);
            Series series1 = new Series();
            series1.IsVisibleInLegend = false;
            series1.ChartType = SeriesChartType.Line;
            series1.Color = c;
            series1.BorderWidth = bw;
            Series series2 = new Series();
            series2.IsVisibleInLegend = false;
            series2.ChartType = SeriesChartType.Line;
            series2.Color = c;
            series2.BorderWidth = bw;
            for(int i = (int)s - DHS; i<= (int)s; i++)
            {
                series1.Points.AddXY(i, i0);
                series2.Points.AddXY(i, i0-HS);
            }
            chart.Series.Add(series1);
            chart.Series.Add(series2);
        }
       public void ChartScale(double smin, double smax, double imin, double imax)
        {

                int dS = 2, dI = 5;
                chart1.ChartAreas[0].AxisX.Minimum = Math.Round(smin - dS);
                chart1.ChartAreas[0].AxisX.Maximum = Math.Round(smax + dS);
                chart1.ChartAreas[0].AxisY.Minimum = Math.Round(imin - dI);
                chart1.ChartAreas[0].AxisY.Maximum = Math.Round(imax + dI);
           
        }
        public void ChartScale(int i, bool onlyone)
        {
            if (!onlyone)
            {
                int dS = 100, dI = 50;
                chart1.ChartAreas[0].AxisX.Minimum = Math.Round(P.s0[0] - dS);
                chart1.ChartAreas[0].AxisX.Maximum = Math.Round(P.s2k[i] + dS);
                chart1.ChartAreas[0].AxisY.Minimum = Math.Round(P.i2k[i] - dI);
                chart1.ChartAreas[0].AxisY.Maximum = Math.Round(P.i0[0] * 0.001 + dI);
                if (i == P.Z - 1 && P.Z != 1)
                {
                    if (chart1.ChartAreas[0].AxisY.Minimum > Math.Round(Functions.wspHPS(P.Pk * 100000, P.s0[i]) * 0.001 - dI))
                    {
                        chart1.ChartAreas[0].AxisY.Minimum = Math.Round(Functions.wspHPS(P.Pk * 100000, P.s0[i]) * 0.001 - dI);
                    }
                }
                if (chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].AxisX.Minimum < chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum)
                {
                    chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Minimum + (chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum);
                }
            }
            else
            {
                int dS = 100, dI = 50;
                chart1.ChartAreas[0].AxisX.Minimum = Math.Round(P.s0[i] - dS);
                chart1.ChartAreas[0].AxisX.Maximum = Math.Round(P.s2k[i] + dS);
                chart1.ChartAreas[0].AxisY.Minimum = Math.Round(P.i2k[i] - dI);
                chart1.ChartAreas[0].AxisY.Maximum = Math.Round(P.i0[i] * 0.001 + dI);
                if (chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].AxisX.Minimum < chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum)
                {
                    chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Minimum + (chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum);
                }
            }

        }

        public void Annotations(int i, Chart chart1)
        {
            
            Hi[i].AnchorY = P.i0[i] * 0.001 - P.Hi[i];
            Hi[i].Height = P.Hi[i];
            Hi[i].AnchorX = P.s0[i] + DHS;
            RHi[i].AnchorX = Hi[i].AnchorX + 20;
            RHi[i].AnchorY = Hi[i].AnchorY + Hi[i].Height / 2;
            chart1.Annotations.Add(Hi[i]);
            chart1.Annotations.Add(RHi[i]);
            if (once1&&i==P.Z-1)
            {
                once1 = false;
                TextAnnotation annotation = new TextAnnotation();
                annotation.AxisX = chart1.ChartAreas[0].AxisX;
                annotation.AxisY = chart1.ChartAreas[0].AxisY;
                annotation.IsSizeAlwaysRelative = false;
                annotation.Text = "H0";
                annotation.ForeColor = Color.Black;
                annotation.Font = new Font("Arial", 12);
                annotation.LineWidth = 2;


                VerticalLineAnnotation ann = new VerticalLineAnnotation();
                ann.AxisX = chart1.ChartAreas[0].AxisX;
                ann.AxisY = chart1.ChartAreas[0].AxisY;
                ann.IsSizeAlwaysRelative = false;
                if (P.HS > 0)
                {
                    ann.AnchorY = P.i0[0] * 0.001 - P.HS;
                    ann.Height = P.HS;
                }
                else
                {
                    ann.AnchorY = P.i0[0] * 0.001 - P.H0[0];
                    ann.Height = P.H0[0];
                }
                ann.AnchorX = P.s0[0] - DHS;
                ann.StartCap = LineAnchorCapStyle.Arrow;
                ann.EndCap = LineAnchorCapStyle.Arrow;
                ann.IsInfinitive = false;
                ann.ClipToChartArea = chart1.ChartAreas[0].Name;
                ann.LineColor = Color.Black; ann.LineWidth = 2;

                annotation.AnchorX = ann.AnchorX - 15;
                annotation.AnchorY = ann.AnchorY + ann.Height/2;

                chart1.Annotations.Add(ann);
                chart1.Annotations.Add(annotation);
            }

        }
        public void HLine(Chart chart, double s, double i0, double Hi, Color c, int bw)
        {
            Series series1 = new Series();
            series1.IsVisibleInLegend = false;
            series1.ChartType = SeriesChartType.Line;
            series1.Color = c;
            series1.BorderWidth = bw;
            Series series2 = new Series();
            series2.IsVisibleInLegend = false;
            series2.ChartType = SeriesChartType.Line;
            series2.Color = c;
            series2.BorderWidth = bw;
            for (int ii = (int)s; ii <= (int)s+DHS; ii++)
            {
                series1.Points.AddXY(ii, i0);
                series2.Points.AddXY(ii, i0 - Hi);
            }
            chart.Series.Add(series1);
            chart.Series.Add(series2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить изображение как ...";
                sfd.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
                sfd.AddExtension = true;
                sfd.FileName = "graphicImage";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
                        case 2: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
                        case 3: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            once1 = true;
            for( int i = 1; i <= G; i++)
            {
                if (comboBox1.SelectedIndex == i)
                {
                    ConstructOne(i - 1);
                }
            }
            if (comboBox1.SelectedIndex == 0)
            {
                Construct(G);
            }
        }
        public void Line( double s1, double i1, double s2, double i2, int bw)
        {
            Series series = new Series();
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Color = Color.Black;
            series.BorderWidth = bw;
            series.Points.AddXY(s1, i1);
            series.Points.AddXY(s2, i2);
            series.IsVisibleInLegend = false;
            chart1.Series.Add(series);
        }
        public void Line(double s1, double i1, double s2, double i2, int bw, String legend, Color c)
        {
            Series series = new Series();
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Color = Color.Black;
            series.BorderWidth = bw;
            series.Points.AddXY(s1, i1);
            series.Points.AddXY(s2, i2);
            series.LegendText = legend;
            series.Color = c;
            chart1.Series.Add(series);
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (pp)
            {
                pp = false;
                button3.Text = "Процесс";
                ConstructP(comboBox1.SelectedIndex - 1);
            }
            else
            {
                pp = true;
                button3.Text = "Потери";
                if (comboBox1.SelectedIndex == 0)
                {
                    Construct(G);
                }
                else
                {
                    ConstructOne(comboBox1.SelectedIndex-1);
                }
               
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }
    }
}
