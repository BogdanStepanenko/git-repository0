using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Расчет_Параметров_ГПП
{
    public partial class PDF_Reader : Form
    {
        public PDF_Reader()
        {
            InitializeComponent();
        }

        private void PDF_Reader_Load(object sender, EventArgs e)
        {
            string filename = Application.StartupPath;
            filename = Path.GetFullPath(
                Path.Combine(filename, "Manual Flexible PCB Designer.pdf"));
            webBrowser1.Navigate(filename);
            this.Close();
            
        }
    }
}
