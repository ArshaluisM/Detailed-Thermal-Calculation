using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT1._0
{
    public partial class PC : Form
    {
        Point S;
        double k = 0.5;
        int gear;
        Graphics g;
        Pen p;
        public PC(int G)
        {
            InitializeComponent();
            PB.Image = new Bitmap(PB.Width, PB.Height);
            PB.BorderStyle = BorderStyle.Fixed3D;
            g = Graphics.FromImage(PB.Image);
            g.Clear(Color.White);
            gear = G;
            S = new Point(PB.Width / 10, 4 * PB.Height / 5);
            p = new Pen(Color.Black, 2);
            trackBar1.Maximum = 10;
            trackBar1.Minimum = 2;
            trackBar1.Value = 5;
            DB.Columns.Add("gear", "Ступень");
            DB.Columns.Add("dk", "dk, мм");
            DB.Columns.Add("l1", "l1, мм");
            DB.Columns.Add("l2", "l2, мм");
            DB.Columns.Add("ppk", "\u0394к, мм");
            DB.Columns.Add("ppp", "\u0394п, мм");
            DB.Columns.Add("l1s", "l1`, мм");
            DB.Columns.Add("l2s", "l2`, мм");
            DB.Columns.Add("B1", "B1, мм");
            DB.Columns.Add("B2", "B2, мм");
            DB.Columns.Add("S1", "S1, мм");
            DB.Columns.Add("S2", "S2, мм");
            DB.Columns.Add("gamma", "\u03B3, град.");
            DB.Columns[0].FillWeight = 50;
            DB.ReadOnly = true;
            for (int i = 0; i<=G; i++)
            {
                DrawST(g, p, i);
                if (i == 0)
                {
                    DB.Rows.Add(new String[] { "" + (i+1), "" + Math.Round(P.dk[i]*1000, 3), "" + Math.Round(P.l1[i],3), "" + Math.Round(P.l2[i], 3), "" + Math.Round(P.PPk[i], 3), "" + Math.Round(P.PPp[i], 3),
                                            "" + Math.Round(P.l1[i], 3),"" + Math.Round(P.l2[i],3),"" + Math.Round(P.B1[i],3),"" + Math.Round(P.B2[i],3), "" + Math.Round(P.sd[i],3),
                                                "" + Math.Round(P.S2[i],3),"0"});
                }
                else
                {
                    DB.Rows.Add(new String[] { "" + (i+1), "" + Math.Round(P.dk[i]*1000, 3), "" + Math.Round(P.l1[i],3), "" + Math.Round(P.l2[i], 3), "" + Math.Round(P.PPk[i], 3), "" + Math.Round(P.PPp[i], 3),
                                            "" + Math.Round(P.l1shtrix[i], 3),"" + Math.Round(P.l2shtrix[i],3),"" + Math.Round(P.B1[i],3),"" + Math.Round(P.B2[i],3), "" + Math.Round(P.sd[i],3),
                                                "" + Math.Round(P.S2[i],3),"" + Math.Round((Math.Atan((P.l1[i]-P.l1shtrix[i])/P.B1[i])*180/Math.PI))});
                }
            }
            p.Color = Color.Red;
            if (G >= 0)
            {
                g.DrawLine(p, S.X, S.Y - (int)(k*P.l2[G] / 2), S.X - (int)(k*(P.B2[G] + P.S2[G] + P.B1[G] + P.sd[G])) *(G + 1), S.Y - (int)(k*P.l1[0] / 2));
            }
        }

        public void DrawST(Graphics g, Pen p, int G)
        {
            double B1, B2, l1, l2, sd, S2, l1shtrix, l2shtrix, PPk;
            p.Color = Color.Black;
            if (G == 0)
            {
                B1 = k * P.B1[G];
                B2 = k * P.B2[G];
                l1 = k * P.l1[G];
                l2 = k * P.l2[G];
                sd = k * P.sd[G];
                S2 = k * P.S2[G];
                //РР
                g.DrawLine(p, S.X, S.Y, (int)(S.X + B1), S.Y);
                g.DrawLine(p, S.X, S.Y, S.X, (int)(S.Y - l1));
                g.DrawLine(p, S.X, (int)(S.Y - l1), (int)(S.X + B1), (int)(S.Y - l1));
                g.DrawLine(p, (int)(S.X + B1), S.Y, (int)(S.X + B1), (int)(S.Y - l1));
                //СР
                S.X = S.X + (int)(B1 + sd);
                S.Y = S.Y - (int)((l1 - l2) / 2);
                g.DrawLine(p, S.X, S.Y, (int)(S.X + B2), S.Y);
                g.DrawLine(p, S.X, S.Y, S.X, (int)(S.Y - l2));
                g.DrawLine(p, S.X, (int)(S.Y - l2), (int)(S.X + B2), (int)(S.Y - l2));
                g.DrawLine(p, (int)(S.X + B2), S.Y, (int)(S.X + B2), (int)(S.Y - l2));
                S.X = S.X + (int)(B2 + S2);
                S.Y = S.Y + (int)((l1 - l2) / 2);
                
            }
            if (G > 0)
            {
                B1 = k * P.B1[G];
                B2 = k * P.B2[G];
                l1 = k * P.l1[G];
                l2 = k * P.l2[G];
                sd = k * P.sd[G];
                S2 = k * P.S2[G];
                l1shtrix = k * P.l1shtrix[G];
                l2shtrix = k * P.l2shtrix[G];
                PPk = k * P.PPk[G];
                //РР
                g.DrawLine(p, S.X + (int)(B1 / 8), S.Y, (int)(S.X + B1), S.Y);
                g.DrawLine(p, S.X, S.Y+(int)(B1/8), S.X, (int)(S.Y - l1shtrix));
                g.DrawLine(p, S.X, (int)(S.Y - l1shtrix), (int)(S.X + B1), (int)(S.Y - l1));
                g.DrawLine(p, (int)(S.X + B1), S.Y, (int)(S.X + B1), (int)(S.Y - l1));
                g.DrawArc(p, S.X, S.Y, (int)(B1 / 4), (int)(B1 / 4), 180, 90);

                //СР
                S.X = S.X + (int)(B1 + sd);
                S.Y = S.Y + (int)(PPk);
                g.DrawLine(p, S.X, S.Y, (int)(S.X + B2), S.Y);
                g.DrawLine(p, S.X, S.Y, S.X, (int)(S.Y - l2shtrix));
                g.DrawLine(p, S.X, (int)(S.Y - l2shtrix), (int)(S.X + B2), (int)(S.Y - l2));
                g.DrawLine(p, (int)(S.X + B2), S.Y, (int)(S.X + B2), (int)(S.Y - l2));
                S.X = S.X + (int)(B2 + S2);
                S.Y = S.Y - (int)(PPk);
                
            }
            p.Color = Color.Black;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            k = trackBar1.Value/10.0;
            g.Clear(Color.White);
            S = new Point(PB.Width / 10, 4 * PB.Height / 5);
            for (int i = 0; i <= gear; i++)
            {
                DrawST(g, p, i);
            }
            p.Color = Color.Red;
            if (gear >= 0)
            {
                g.DrawLine(p, S.X, S.Y - (int)(k * P.l2[gear] / 2), S.X - (int)(k * (P.B2[gear] + P.S2[gear] + P.B1[gear] + P.sd[gear])) * (gear + 1), S.Y - (int)(k * P.l1[0] / 2));
            }
            PB.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PB.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.JPG)|*.JPG";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PB.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PB_Resize(object sender, EventArgs e)
        {
            PB.Image = new Bitmap(PB.Width, PB.Height);
            PB.BorderStyle = BorderStyle.Fixed3D;
            g = Graphics.FromImage(PB.Image);
            g.Clear(Color.White);
            S = new Point(PB.Width / 10, 4 * PB.Height / 5);
            for (int i = 0; i <= gear; i++)
            {
                DrawST(g, p, i);
            }
        }

        private void PC_Resize(object sender, EventArgs e)
        {

        }
    }
}
