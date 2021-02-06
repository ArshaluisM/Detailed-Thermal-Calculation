using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PT1._0
{
    public partial class DH : Form
    {
        double delta_H0;
        double H0all;
        Form1 form;
        int GEAR;
        public DH(int GEAR, Form1 f)
        {
            InitializeComponent();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[0].Color = Color.Red;
            chart1.Series.Add(new Series());
            chart1.ChartAreas[0].AxisY.Minimum = 2000;
            chart1.ChartAreas[0].AxisY.Maximum = 4000;
            chart1.ChartAreas[0].AxisX.Minimum = 6000;
            chart1.ChartAreas[0].AxisX.Maximum = 8000;
            chart1.ChartAreas[0].AxisX.Title = "S, Дж/кгК";
            chart1.ChartAreas[0].AxisY.Title = "H, кДж/кг";
            DB.ReadOnly = true;
            form = f;
            this.GEAR = GEAR;
            Construct(GEAR);
            Populate(GEAR);
            Colibrate(GEAR);
            
        }
        public void Construct(int G)
        {

            if (G > 0)
            {
                for (int i = 0; i < G; i++)
                {
                    ChartScale(i);
                    int hk1 = (int)(Functions.wspHPS(P.p2k[i], P.s0[i]) * 0.001);
                    int hk2 = (int)(Functions.wspHPS(P.p2k[i], P.s2k[i]) * 0.001);
                    int y1 = (int)(P.i0[i] * 0.001);
                    int y2 = (int)(Functions.wspHPS(P.p2k[i], P.s2k[i]) * 0.001 /*P.i2k[i]*/);
                    chart1.Series[0].Points.AddXY(P.s0[i], y1);
                    chart1.Series[0].Points.AddXY(P.s2k[i], y2);
                    Izobara(chart1, P.s0[i], P.p0[i] * 100000, Color.Black, 1, "Изобара р = " + Math.Round(P.p0[i], 3) + " бар");
                    if (i == P.Z - 1)
                    {
                        Izobara(chart1, P.s2k[i], P.p2k[i], Color.Blue, 2, "Изобара р = " + Math.Round(P.p2k[i] * 0.00001, 3) + " бар");
                    }
                }
                Izobara(chart1, P.s2k[G - 1], P.Pk * 100000, Color.Green, 2, "Конечное давление " + Math.Round(P.Pk, 3) + " бар");

            }
        }
        public void Izobara(Chart chart, double s, double p, Color c, int bw, String legend)
        {
            Series series = new Series();
            //series.LegendText = legend;
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Color = c;
            series.BorderWidth = bw;
            int ds = 50;
            for (int ss = (int)s - ds; ss <= (int)s + ds; ss++)
            {
                series.Points.AddXY(ss, Functions.wspHPS(p, ss) * 0.001);
            }
            chart.Series.Add(series);
        }

        public void ChartScale(int i)
        {
            int dS = 100, dI = 50;
            chart1.ChartAreas[0].AxisX.Minimum = Math.Round(P.s0[0] - dS);
            chart1.ChartAreas[0].AxisX.Maximum = Math.Round(P.s2k[i] + dS);
            chart1.ChartAreas[0].AxisY.Minimum = Math.Round(P.i2k[i] - dI);
            chart1.ChartAreas[0].AxisY.Maximum = Math.Round(P.i0[0] * 0.001 + dI);
            if (i == P.Z - 1)
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

        public void Populate(int G)
        {
            DB.Columns.Add("value", "Тепловой перепад / Ступени");
            DB.Columns.Add("si", "-");
            DB.Columns[0].ReadOnly = true;
            DB.Columns[1].ReadOnly = true;
            DB.Columns[0].Width = 225;
            DB.Columns[1].Width = 50;
            DB.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < G; i++)
            {
                DB.Columns.Add("" + i, "№" + (i + 1));
                DB.Columns[i + 2].Width = 50;
                DB.Columns[i + 2].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            DB.Rows.Add("Распологаемый теплоперепад ступени H0`", "кДж/кг");
            DB.Rows.Add("Изменение теплоперепада \u0394H0", "кДж/кг");
            DB.Rows.Add("Уточненный теплоперепад H0", "кДж/кг");
            for (int i = 0; i < G; i++)
            {
                DB.Rows[0].Cells[2 + i].Value = Math.Round(P.H0[i],3);

            }

        }
        public void Colibrate(int G)
        {
            delta_H0 = (Functions.wspHPS(P.p2k[P.Z - 1], P.s0[P.Z - 1]) - Functions.wspHPS(P.Pk * 100000, P.s0[P.Z - 1])) * 0.001;
            H0all = 0;
            label6.Text = "Расчетное Давление P2k = " + (Math.Round(P.p2k[P.Z - 1] * 0.00001, 3))+ " бар";
            label5.Text = "Исходное давление Pk = " + P.Pk + " бар";
            double H0new=0;
            for(int i =0; i <P.Z; i++)
            {
                H0all += P.H0[i];
            }
            if (delta_H0 > 0)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Конечное давление ниже чем давление после рабочих решеток в последней ступени!";
            }
            if (delta_H0 < 0)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Конечное давление выше чем давление после рабочих решеток в последней ступени!";
            }
            if(Math.Round(delta_H0) == 0)
            {
                label4.ForeColor = Color.Green;
                label4.Text = "Конечное давление равно давлению после рабочих решеток в последней ступени";
            }
            for (int i = 0; i < G; i++)
            {
                DB.Rows[1].Cells[2 + i].Value = Math.Round(P.H0[i]*delta_H0/(H0all),3);
                DB.Rows[2].Cells[2 + i].Value = Math.Round(P.H0[i] + (P.H0[i] * delta_H0 /(H0all)),3);
                H0new += P.H0[i] + (P.H0[i] * delta_H0 / (H0all));
            }

            P.HS = H0new;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < P.Z; i++)
            {
                P.h0[i] = P.H0[i] + (P.H0[i] * delta_H0 / (H0all));
            }
            form.Renew(P.Z);
            DB.Rows.Clear();
            DB.Columns.Clear();
            for(int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
            }
            chart1.Series.Add(new Series());
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[0].Color = Color.Red;
            chart1.Series.Add(new Series());
            chart1.ChartAreas[0].AxisY.Minimum = 2000;
            chart1.ChartAreas[0].AxisY.Maximum = 4000;
            chart1.ChartAreas[0].AxisX.Minimum = 6000;
            chart1.ChartAreas[0].AxisX.Maximum = 8000;
            chart1.ChartAreas[0].AxisX.Title = "S, Дж/кгК";
            chart1.ChartAreas[0].AxisY.Title = "H, кДж/кг";
            Construct(GEAR);
            Populate(GEAR);
            Colibrate(GEAR);
            //Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
