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
    public partial class Reserve : Form
    {
        string address;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        int level;
        public Reserve()
        {
            InitializeComponent();
        }
        private void Reserve_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GET_CITY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("CITY", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                comboBox1.Items.Add(drc["CITY"]);
            }
            drc.Close();

        }
        private void Search_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (radioButton1.Checked)
            {
                level = 1;
            }
            else if (radioButton2.Checked)
            {
                level = 2;
            }
            else if (radioButton3.Checked)
            {
                level = 3;
            }
            else if (radioButton4.Checked)
            {
                level = 4;
            }
            else if (radioButton5.Checked)
            {
                level = 5;
            }
            cmd.CommandText = "select hotel_name from hotel  where city=:c and accommadation =:l ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("c", comboBox1.SelectedItem.ToString());
            cmd.Parameters.Add("l", level.ToString());
            OracleDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["HOTEL_NAME"]);
            }
            dr1.Close();
        }
        private void Reserve_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ADD_RESIDENT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("a", Int32.Parse(textBox4.Text));
            cmd.Parameters.Add("b", textBox1.Text);
            cmd.Parameters.Add("c", textBox2.Text);
            cmd.Parameters.Add("d", dateTimePicker1.Value.Date);
            cmd.Parameters.Add("e", dateTimePicker2.Value.Date);
            cmd.Parameters.Add("f", Int32.Parse(textBox3.Text));
            cmd.Parameters.Add("g", Int32.Parse(comboBox3.Text));
            cmd.ExecuteNonQuery();

            OracleCommand cmd0 = new OracleCommand();
            cmd0.Connection = conn;
            cmd0.CommandText = "insert  into VISITED_BYR (RESIDENT_ID, ADDRESS) values(:a,:b)";
            cmd0.CommandType = CommandType.Text;
            cmd0.Parameters.Add("a", Int32.Parse(textBox4.Text));
            cmd0.Parameters.Add("b", address);
            cmd0.ExecuteNonQuery();

            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = "insert  into ROOMIDMV (ROOM_ID,RESIDENT_ID) values(:a,:b)";
            cmd3.CommandType = CommandType.Text;
            cmd3.Parameters.Add("b", Int32.Parse(comboBox3.Text));
            cmd3.Parameters.Add("a", Int32.Parse(textBox4.Text));
            cmd3.ExecuteNonQuery();


            
                MessageBox.Show("Reserved");

                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "UPDATEN";
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("id", Int32.Parse(comboBox3.Text));
                cmd1.Parameters.Add("add", address);
                cmd1.ExecuteNonQuery();

                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into NATIONALITYMV (RESIDENT_ID,NATIONALITY) values (:id,:nationality)";
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("ssn", Int32.Parse(textBox4.Text));
                cmd2.Parameters.Add("nation", textBox6.Text);
                cmd2.ExecuteNonQuery();

                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "insert into PHONEMV (RESIDENT_ID,PHONE_NUMBER) values (:id,:phone)";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("ssn", Convert.ToInt32(textBox4.Text));
                cmd3.Parameters.Add("phone", Convert.ToInt32(textBox9.Text));
                cmd3.ExecuteNonQuery();

                comboBox2.Items.Clear();
                comboBox2.DisplayMember = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                dateTimePicker1.ResetText();
                dateTimePicker2.ResetText();
            
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_address";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("hotel", comboBox2.Text);
            cmd.Parameters.Add("k", OracleDbType.RefCursor, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            OracleDataReader dr0 = cmd.ExecuteReader();
            while (dr0.Read())
            {
                address = dr0[0].ToString();
            }
            dr0.Close();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
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
                comboBox3.Items.Add(dr0["ROOM_ID"]);
            }
            dr0.Close();
        }
        private void Reserve_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
