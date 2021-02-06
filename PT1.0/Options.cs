using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PT1._0
{
    public partial class Options : Form
    {
        public bool onetoone = false;
        public Options()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            groupBox3.Enabled = false;
            radioButton4.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox3.Enabled = false;
                radioButton4.Checked = true;
                onetoone = false;
            }
            else
            {
                groupBox3.Enabled = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                onetoone = false;
                label1.Text = "Полный ввод дополнительных данных\nпо всем ступеням сразу";
            }
            else
            {
                onetoone = true;
                label1.Text = "Ввод дополнительных данных\nперед каждой ступенью";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                onetoone = true;
                label1.Text = "Ввод дополнительных данных\nперед каждой ступенью";
            }
            else
            {
                onetoone = false;
                label1.Text = "Полный ввод дополнительных данных\nпо всем ступеням сразу";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
