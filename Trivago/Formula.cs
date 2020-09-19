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
    public partial class Formula : Form
    {
        CR3 c;
        public Formula()
        {
            InitializeComponent();
        }
        private void Formula_Load(object sender, EventArgs e)
        {
            c = new CR3();
            crystalReportViewer1.ReportSource = c;
        }
    }
}
