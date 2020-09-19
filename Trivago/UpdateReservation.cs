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
    public partial class UpdateReservation : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        int level;
        string address/* = "4-GIZA STREET"*/;
        public UpdateReservation()
        {
            InitializeComponent();
        }
        private void UpdateReservation_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            label10.Visible = false;
            label11.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            button1.Visible = false;
            label14.Visible = false;
            comboBox4.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select room_id from roomidmv where resident_id=:d";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("rid", int.Parse(textBox4.Text));
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0]);
            }
            dr.Close();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select  address from visited_byr where resident_id=:a";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("rid", Convert.ToInt32(textBox4.Text));
            OracleDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                address = dr1[0].ToString();
            }
            dr1.Close();

            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select  hotel_name from hotel where address=:a";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("add", address);
            OracleDataReader dr0 = cmd.ExecuteReader();
            while (dr0.Read())
            {
                textBox1.Text = dr0[0].ToString();
            }
            dr0.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GETAVAILROOM";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("add", address);
            cmd.Parameters.Add("sprice", Int32.Parse(textBox7.Text));
            cmd.Parameters.Add("eprice", Int32.Parse(textBox8.Text));
            cmd.Parameters.Add("ROOM_ID", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr0 = cmd.ExecuteReader();
            while (dr0.Read())
            {
                comboBox4.Items.Add(dr0["ROOM_ID"]);
            }
            dr0.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked = true)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update RESIDENT set FNAME=:a, LNAME=:b ,CHECK_IN=:c,CHECK_OUT=:d, ROOMID=:e where RESIDENT_ID=:f and ROOMID=:g";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("fname", textBox1.Text);
                cmd.Parameters.Add("lname", textBox2.Text);
                cmd.Parameters.Add("checkin", dateTimePicker1.Value.Date);
                cmd.Parameters.Add("checkout", dateTimePicker2.Value.Date);
                cmd.Parameters.Add("roomid", Int32.Parse(comboBox4.SelectedItem.ToString()));
                cmd.Parameters.Add("residentid", Int32.Parse(textBox4.Text));
                cmd.Parameters.Add("room", Int32.Parse(comboBox3.SelectedItem.ToString()));
                int x = cmd.ExecuteNonQuery();

                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "update ROOMIDMV set ROOM_ID=:a where RESIDENT_ID=:f and ROOM_ID=:g";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("roomid", Int32.Parse(comboBox4.SelectedItem.ToString()));
                cmd3.Parameters.Add("residentid", Int32.Parse(textBox4.Text));
                cmd3.Parameters.Add("room", Int32.Parse(comboBox3.SelectedItem.ToString()));
                int y = cmd3.ExecuteNonQuery();

                if (x != -1 && y != -1)
                {
                    MessageBox.Show("Done");
                }
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "UPDATEY";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("roomid", Convert.ToInt32(comboBox3.Text));
                cmd2.Parameters.Add("addr", address);
                cmd2.ExecuteNonQuery();

                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "UPDATEN";
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("roomid", Convert.ToInt32(comboBox4.Text));
                cmd1.Parameters.Add("addr", address);
                cmd1.ExecuteNonQuery();
            }
            else
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update RESIDENT set FNAME=:a, LNAME=:b ,CHECK_IN=:c,CHECK_OUT=:d where RESIDENT_ID=:f and ROOMID=:g";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("fname", textBox1.Text);
                cmd.Parameters.Add("lname", textBox2.Text);
                cmd.Parameters.Add("checkin", dateTimePicker1.Value.Date);
                cmd.Parameters.Add("checkout", dateTimePicker2.Value.Date);
                cmd.Parameters.Add("residentid", Int32.Parse(textBox4.Text));
                cmd.Parameters.Add("room", Int32.Parse(comboBox3.SelectedItem.ToString()));
                int x = cmd.ExecuteNonQuery();
                if (x != -1)
                {
                    MessageBox.Show("Done");
                }

            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label10.Visible = true;
                label11.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                button1.Visible = true;
                label14.Visible = true;
                comboBox4.Visible = true;
            }
        }
        private void UpdateReservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
        private void Search_Click(object sender, EventArgs e)
        {
           

            
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

       
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void city_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
