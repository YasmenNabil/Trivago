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
    public partial class CancelReservation : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        string address;
        public CancelReservation()
        {
            InitializeComponent();
        }
        private void CancelReservation_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select  address from visited_byr where resident_id=:a";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("rid", Convert.ToInt32(textBox4.Text));
            OracleDataReader dr0 = cmd.ExecuteReader();
            while (dr0.Read())
            {
                address = dr0[0].ToString();
            }
            dr0.Close();

            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select  hotel_name from hotel where address=:a";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("add", address);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            dr.Close();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select room_id from roomidmv where resident_id=:d";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("rid", Convert.ToInt32(textBox4.Text));
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2[0]);
            }
            dr2.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE_RESERVATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("roomid", Convert.ToInt32(comboBox3.Text));
            cmd.Parameters.Add("ssn", Convert.ToInt32(textBox4.Text));
            cmd.ExecuteNonQuery();

            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "DELETE ROOMIDMV where ROOM_ID= :rid and RESIDENT_ID= :ssn";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("roomid", Convert.ToInt32(comboBox3.Text));
            cmd1.Parameters.Add("ssn", Convert.ToInt32(textBox4.Text));
            cmd1.ExecuteNonQuery();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "UPDATEY";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("roomid", Convert.ToInt32(comboBox3.Text));
            cmd2.Parameters.Add("addr", textBox1.Text);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Canceled");

        }
        private void CancelReservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
