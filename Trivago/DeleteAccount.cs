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
    public partial class DeleteAccount : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string constr = "Data source=orcl;User Id=hr; Password=hr;";
        string cmdstr = "";
        public DeleteAccount()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmdstr = "DELETE REGISTER_USER where ssn = :s";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("x", textBox4.Text);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            MessageBox.Show("Deleted");
            textBox4.Text = "";
        }
        private void DeleteAccount_Load(object sender, EventArgs e)
        {

        }
        private void DeleteAccount_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void DeleteAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        
    }
}
