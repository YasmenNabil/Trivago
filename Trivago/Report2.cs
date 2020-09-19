using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivago
{
    public partial class Report2 : Form
    {
        CR2 f;
        public Report2()
        {
            InitializeComponent();
        }
        private void Report2_Load(object sender, EventArgs e)
        {
            f = new CR2();
            crystalReportViewer1.ReportSource = f;
        }
    }
}
