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
    public partial class Popup : Form
    {
        bool wrong = false;
        public int CONTINUE = 0;
        bool V_U = true;
        int G = 0;
        public Popup(int GEAR, bool V_U)
        {
            this.V_U = V_U;
            InitializeComponent();
            G = GEAR;
            label20.Text = "";
            pictureBox1.Image = Image.FromFile(@"images\labirint.jpg");
            label1.Text = "Дополнительные данные для ступени №" + (GEAR+1);
            label25.Text = "Реакция ступени на среднем диаметре \u03C1 ср";
            label30.Text = "Эффективный угол выхода \nпотока из решетки \u03b1 1э";
            label72.Text = "Разность углов \u0394\u03B2";
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            if (V_U)
            {
                textBox17.Enabled = false;
                textBox19.Enabled = false;
                groupBox4.Text = "Вариант расчета: по высотам";
                
            }
            if (!V_U)
            {
                textBox18.Enabled = false;
                textBox20.Enabled = false;
                groupBox4.Text = "Вариант расчета: по углам";
            }
            textBox7.Enabled = false;
            textBox10.Text = "" + 1;
            textBox10.Enabled = false;
            checkBox2.Checked = true;
            textBox10.Text = "" + 1;
            textBox10.Enabled = false;
            textBox23.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            wrong = false;
            try
            {
                P.d1y[G] = Convert.ToDouble(textBox1.Text);
                P.sigma1y[G] = Convert.ToDouble(textBox2.Text)/1000;
                P.z1y[G] = Convert.ToInt16(textBox3.Text);
                P.sigmaa[G] = Convert.ToDouble(textBox6.Text);
                P.sigmar[G] = Convert.ToDouble(textBox5.Text);
                P.z2y[G] = Convert.ToDouble(textBox4.Text);
                P.sd[G] = Convert.ToDouble(textBox8.Text);
                P.S2[G] = Convert.ToDouble(textBox21.Text);
                if (textBox7.Enabled)
                {
                    P.SEP[G] = Convert.ToDouble(textBox7.Text);
                }
                P.delta_greben[G] = Convert.ToDouble(textBox9.Text);
                if (V_U)
                {
                    P.l1[G] = Convert.ToDouble(textBox20.Text);
                    P.l2[G] = Convert.ToDouble(textBox18.Text);
                    
                }
                if (!V_U)
                {
                    P.alfa1e[G] = Convert.ToDouble(textBox19.Text) * Math.PI / 180;
                    P.deltabetta[G] = Convert.ToDouble(textBox17.Text) * Math.PI / 180;
                    
                }
                P.h0[G] = Convert.ToDouble(textBox15.Text);
                P.dcr[G] = Convert.ToDouble(textBox14.Text);
                P.Rocr[G] = Convert.ToDouble(textBox13.Text);
                P.xf[G] = Convert.ToDouble(textBox12.Text);
                P.B1[G] = Convert.ToDouble(textBox11.Text);
                P.B2[G] = Convert.ToDouble(textBox16.Text);
                P.Parc[G] = Convert.ToDouble(textBox10.Text);
                if (!checkBox2.Checked)
                {
                    P.m[G] = Convert.ToInt32(textBox23.Text);
                }

                if (radioButton1.Checked)
                {
                    P.bandazh[G] = 1;
                }
                if (radioButton2.Checked)
                {
                    P.bandazh[G] = 0;
                }
                if (radioButton3.Checked)
                {
                    P.TYPE_LABIRINT[G] = 1;
                }
                if (radioButton4.Checked)
                {
                    P.TYPE_LABIRINT[G] = 2;
                }
                if (radioButton5.Checked)
                {
                    P.TYPE_LABIRINT[G] = 3;
                }
                if (radioButton6.Checked)
                {
                    P.TYPE_LABIRINT[G] = 5;
                }
                if (radioButton7.Checked)
                {
                    P.TYPE_LABIRINT[G] = 6;
                }
                if (radioButton8.Checked)
                {
                    P.TYPE_LABIRINT[G] = 7;
                }
                if (radioButton9.Checked)
                {
                    P.TYPE_LABIRINT[G] = 4;
                }
                CONTINUE = 1;
            }
            catch (Exception)
            {

                wrong = true;
                CONTINUE = 1;
                label20.Text = "Неправильно введены начальные данные";
            }
            if (!wrong)
            {
                Close();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox7.Enabled = true;
            }
            else
            {
                textBox7.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CONTINUE = 0;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "" + 1;
            textBox2.Text = "" + 1;
            textBox3.Text = "" + 1;
            textBox4.Text = "" + 1;
            textBox5.Text = "" + 1;
            textBox6.Text = "" + 1;
            textBox21.Text = "" + 1;
            textBox8.Text = "" + 1;
            textBox9.Text = "" + 1;
            textBox15.Text = "" + 60;
            textBox14.Text = "" + 1.2;
            textBox13.Text = "" + 0.1;
            textBox12.Text = "" + 0.543;
            textBox11.Text = "" + 60;
            textBox10.Text = "" + 1;
            textBox16.Text = "" + 80;
            if (V_U)
            {
                textBox20.Text = "" + (120 + G * 20);
                textBox18.Text = "" + (130 + G * 20);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox10.Text = "" + 1;
                textBox10.Enabled = false;
                textBox23.Enabled = false;

                textBox23.Text = "";

            }
            else
            {
                textBox10.Enabled = true;
                textBox10.Text = "";
                textBox23.Enabled = true;

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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}
