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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"images\logo.png");
            pictureBox1.Width = pictureBox1.Image.Size.Width;
            pictureBox1.Height = pictureBox1.Image.Size.Height;
        }
    }
}
