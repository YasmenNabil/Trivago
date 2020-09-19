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
    public partial class New : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public New()
        {
            InitializeComponent();
        }
        private void New_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void register_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into  REGISTER_USER values(:password,:username)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("password", password.Text);
            cmd.Parameters.Add("username", username.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Registeration Succeded");
                this.Close();
                Interface f = new Interface();
                f.Show();
            }
            else
            {
                MessageBox.Show("Data is used ");

            }
        }
        private void New_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

        
