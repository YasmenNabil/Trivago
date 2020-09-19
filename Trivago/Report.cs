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
    public partial class Report : Form
    {
        CR1 c;
        public Report()
        {
            InitializeComponent();
        }
        private void Report_Load(object sender, EventArgs e)
        {
            c = new CR1();
            crystalReportViewer1.ReportSource = c;
        }
    }
}
