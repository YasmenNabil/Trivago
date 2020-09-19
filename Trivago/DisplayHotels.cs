using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Trivago
{
    public partial class DisplayHotels : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string constr = "Data source=orcl;User Id=hr; Password=hr;";
        string cmdstr = "";
        public DisplayHotels()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmdstr = "select * from HOTEL";
            adapter = new OracleDataAdapter(cmdstr, constr);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void DisplayHotels_Load(object sender, EventArgs e)
        {

        }
    }
}
