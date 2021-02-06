using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

namespace PT1._0
{
    public partial class Triangle : Form
    {
        int L_SY = 15, L_H = 20, L_W = 200, PB_SY = 10, PB_H = 250, S_X = 15, PB_W = 775;
        double KRA = 0.4, KRB = 0.3, KXalf = 0.85, KXbet = 0.6, KYbet = 0.2;
        int count = 0;

        int Y = 15;
        Color C1 = Color.Blue, W1 = Color.Green, CU = Color.Red, C2 = Color.DarkGray, W2 = Color.Violet;
        String S_A = "\u03b1\u2081", S_B = "\u03B2\u2081";
        public Triangle()
        {
            InitializeComponent();
            PB_W = Width - 4 * S_X;

 

            for (int i = 0; i < P.GEAR; i++) {

                Construct(i);
            }

        }

        public void Draw_Gear_triangle(Graphics g, PictureBox PB, int G)
        {
            if (P.GEAR >= G+1)
            {
                g.Clear(Color.White);
                Pen p = new Pen(Color.Black, 2);
                Pen forC1 = new Pen(C1, 3);
                Pen forC2 = new Pen(C2, 3);
                Pen forW1 = new Pen(W1, 3);
                Pen forW2 = new Pen(W2, 3);
                Pen forU = new Pen(CU, 3);

                Point Start = new Point(PB.Width/ 2, PB.Height/5);
                g.DrawLine(new Pen(Color.Black, 1), 0, Start.Y, PB.Width, Start.Y);
                g.DrawLine(new Pen(Color.Black, 1), Start.X, 0, Start.X, PB.Height);
                Point A = new Point(Start.X - (int)(P.W1[G] * Math.Cos(P.betta1[G])), Start.Y + (int)(P.W1[G] * Math.Sin(P.betta1[G])));
                Point B = new Point(Start.X - (int)(P.C1[G] * Math.Cos(P.alfa1[G])), Start.Y + (int)(P.C1[G] * Math.Sin(P.alfa1[G])));
                Point U = new Point(A.X - (int)P.U[G], A.Y);
                Point AA = new Point(Start.X + (int)(P.W2[G] * Math.Cos(P.betta2[G])), Start.Y + (int)(P.W2[G] * Math.Sin(P.betta2[G])));
                Point BB = new Point(Start.X + (int)(P.C2[G] * Math.Cos(P.alfa2[G])), Start.Y + (int)(P.C2[G] * Math.Sin(P.alfa2[G])));
                Point U2 = new Point(AA.X - (int)P.U[G], AA.Y);
                Point Alfa = new Point((int)(Start.X - (Start.X - A.X) * KXalf), Start.Y);
                Point Betta = new Point((int)(Start.X - (Start.X - A.X) * KXbet), (int)(Start.Y + (A.Y - Start.Y) * KYbet));
                Font f = new Font("Microsoft Sans Serif", 10);
                SolidBrush b = new SolidBrush(Color.Black);

                p.CustomEndCap = new AdjustableArrowCap(6, 6);
                forC1.CustomEndCap = new AdjustableArrowCap(3, 6);
                forC2.CustomEndCap = new AdjustableArrowCap(3, 6);
                forW1.CustomEndCap = new AdjustableArrowCap(3, 6);
                forW2.CustomEndCap = new AdjustableArrowCap(3, 6);
                forU.CustomEndCap = new AdjustableArrowCap(3, 6);
                g.DrawLine(forC1, Start, A);
                g.DrawLine(forW1, Start, B);
                g.DrawLine(forU, A, U);

                g.DrawLine(forC2, Start, AA);
                g.DrawLine(forW2, Start, BB);
                g.DrawLine(forU, AA, U2);
                f = new Font("Microsoft Sans Serif", 12);
                Font fvector = new Font("Arial", 10);
                g.DrawString(S_A, f, b, Alfa);
                g.DrawString(S_B, f, b, Betta);
                g.DrawString("\u03B2\u2082", f, b, (int)(1.75*Start.X -0.75*Alfa.X), Alfa.Y);
                g.DrawString("\u03B1\u2082", f, b, (int)(1.5 *Start.X - 0.5*Betta.X), (int)(Betta.Y*1.25));
                int ra = (int)(B.Y * 3*KRA);
                int rb = (int)(A.Y * 3*KRB);

                g.DrawLine(forW1, 20, U.Y + 50, 20 + PB.Width/4, U.Y + 50);
                g.DrawLine(forC1, 20, U.Y + 75, 20 + PB.Width / 4, U.Y + 75);
                g.DrawLine(forC2, 40 + PB.Width / 4, U.Y + 50, 40 + PB.Width / 2, U.Y + 50);
                g.DrawLine(forW2, 40 + PB.Width / 4, U.Y + 75, 40 + PB.Width / 2, U.Y + 75);
                g.DrawLine(forU, 60 + PB.Width / 2, U.Y + 50, 60 + 3*PB.Width / 4, U.Y + 50);
                
                g.DrawString("C1="+Math.Round(P.C1[G])+" м/с", fvector, b, 20, U.Y + 35);
                g.DrawString("W1=" + Math.Round(P.W1[G]) + " м/с", fvector, b, 20, U.Y + 60);
                g.DrawString("W2=" + Math.Round(P.W2[G]) + " м/с", fvector, b, 40 + PB.Width / 4, U.Y + 35);
                g.DrawString("C2=" + Math.Abs(Math.Round(P.C2[G])) + " м/с", fvector, b, 40 + PB.Width / 4, U.Y + 60);
                g.DrawString("U=" + Math.Round(P.U[G]) + " м/с", fvector, b, 60 + PB.Width / 2, U.Y + 35);
                p.CustomStartCap = new AdjustableArrowCap(3, 3);
                p.CustomEndCap = new AdjustableArrowCap(3, 3);
                if (P.alfa2[G] < 0)
                {
                    g.DrawArc(p, Start.X - ra / 4, Start.Y - ra / 4, ra / 2, ra / 2, 0, 180 - Math.Abs((int)(P.alfa2[G] * 180 / Math.PI)));
                    g.DrawString(S_A + "=" + Math.Round((P.alfa1[G] * 180 / Math.PI)) + "\u00B0 " + S_B + "=" + Math.Round((P.betta1[G] * 180 / Math.PI)) + "\u00B0 \u03B1\u2082="
                        + Math.Round(180 - Math.Abs((P.alfa2[G] * 180 / Math.PI))) + "\u00B0 \u03B2\u2080=" + Math.Round((P.betta2[G] * 180 / Math.PI)) + "\u00B0", fvector, b, 60 + PB.Width / 2, U.Y + 65);
                }
                else
                {
                    g.DrawArc(p, Start.X - ra / 4, Start.Y - ra / 4, ra / 2, ra / 2, 0, (int)(P.alfa2[G] * 180 / Math.PI));
                    g.DrawString(S_A + "=" + Math.Round((P.alfa1[G] * 180 / Math.PI)) + "\u00B0 " + S_B + "=" + Math.Round((P.betta1[G] * 180 / Math.PI)) + "\u00B0 \u03B1\u2082="
                        + Math.Round(P.alfa2[G] * 180 / Math.PI) + "\u00B0 \u03B2\u2080=" + Math.Round((P.betta2[G] * 180 / Math.PI)) + "\u00B0", fvector, b, 60 + PB.Width / 2, U.Y + 65);
                }
                
                g.DrawArc(p, Start.X - ra/2, Start.Y - ra/2, ra, ra, 180 - (int)(P.alfa1[G] * 180 / Math.PI), (int) ( P.alfa1[G] * 180 / Math.PI));
                g.DrawArc(p, Start.X - rb/2, Start.Y - rb/2, rb, rb, 180 - (int)(P.betta1[G] * 180 / Math.PI), (int) ( P.betta1[G] * 180 / Math.PI));
                g.DrawArc(p, Start.X - rb / 2, Start.Y - rb / 2, rb, rb, 0, (int)(P.betta2[G] * 180 / Math.PI));
                if (U.Y+100 >= PB_H)
                {
                    PB_H += 100;
                    PB.Refresh();
                }

            }
        }

        public void Construct(int G)
        {
            PictureBox PB = new PictureBox();
            PB.Name = "PB" + count;
            Label l = new Label();
            Button b = new Button();
            b.Text = "Сохранить";
            b.Tag = count;
            b.Click += new EventHandler(Save);
            count++;
            l.Text = G + 1 + " ступень";
            l.SetBounds(S_X, Y, L_W, L_H);
            Font f = new Font("Microsoft Sans Serif", 12);
            l.Font = f;
            PB.SetBounds(S_X, l.Location.Y + L_H + PB_SY, PB_W, PB_H);
            b.SetBounds(PB.Location.X + PB.Width - 100, PB.Location.Y + PB.Height + 5, 100, 25);
            PB.Image = new Bitmap(PB.Width, PB.Height);
            PB.BorderStyle = BorderStyle.Fixed3D;
            Graphics g = Graphics.FromImage(PB.Image);
            Controls.Add(l);
            Controls.Add(PB);
            Controls.Add(b);
            Draw_Gear_triangle(g, PB, G);
            Y += (L_H + PB_SY + PB_H + L_SY);
        }

        void Save(Object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int s = (int)b.Tag;
            PictureBox PB = (PictureBox)Controls.Find("PB" + s, false)[0];
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

    }
}
