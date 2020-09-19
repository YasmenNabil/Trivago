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
using System.Threading;


namespace Trivago
{
    public partial class Interface : Form
    {
        Thread th;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;"; 
        OracleConnection conn;
        bool found ;
        public Interface()
        {
            InitializeComponent();
        }
        private void Interface_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

        }
        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Interface i = new Interface();
            i.Dispose();
            New n = new New();
            n.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * from REGISTER_USER";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if ((string.Equals(dr[0].ToString(), password.Text)) && (string.Equals(dr[1].ToString(), username.Text)))
                {
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }
            dr.Close();
            if (found == true)
            {
                LogIn l = new LogIn();
                l.Show();
                username.Text = "";
                password.Text = "";
            }
            else
            {
                MessageBox.Show("Error, username & password Not Found");
                username.Text = "";
                password.Text = "";
            }
        }

        private void Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }  
    }
}
