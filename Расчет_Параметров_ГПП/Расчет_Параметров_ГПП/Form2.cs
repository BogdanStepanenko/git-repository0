using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расчет_Параметров_ГПП
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\Landing_page\Landing_Text.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\Landing_page\LandingPage.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
           
            timer1.Interval = 4000;
            timer1.Tick += new EventHandler(onTick);
            timer1.Enabled = true;
        }
        void onTick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
