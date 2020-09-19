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
    public partial class MasterDetail : Form
    {
        public MasterDetail()
        {
            InitializeComponent();
        }

        private void MasterDetail_Load(object sender, EventArgs e)
        {
            string constr = "Data source=orcl;User Id=hr; Password=hr;";
            DataSet ds = new DataSet();

            OracleDataAdapter adapter1 = new OracleDataAdapter("select * from hotel",constr);
            adapter1.Fill(ds, "hotel");

            OracleDataAdapter adapter2 = new OracleDataAdapter("select * from room", constr);
            adapter2.Fill(ds, "room");

            DataRelation r = new DataRelation("tr", ds.Tables[0].Columns["ADDRESS"], ds.Tables[1].Columns["ADDRESS"]);
            ds.Relations.Add(r);

            BindingSource master = new BindingSource(ds, "hotel");
            BindingSource child = new BindingSource(master, "tr");

            dataGridView1.DataSource = master;
            dataGridView2.DataSource = child;
        }
    }
}
