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
    public partial class Disconnected : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Disconnected()
        {
            InitializeComponent();
        }
        private void Disconnected_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            label2.Visible = true;
            comboBox1.Visible = true;
            button4.Visible = true;
            label8.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="UserName")
            {
                label3.Visible = false;
                textBox4.Visible = false;
                label4.Visible = true;
                textBox3.Visible = true;
                button3.Visible=true;
            }
            else if(comboBox1.SelectedItem.ToString()=="Passward")
            {
                label4.Visible = false;
                textBox3.Visible = false;
                label3.Visible = true;
                textBox4.Visible = true;
                button3.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "Both")
            {
                label4.Visible = true;
                textBox3.Visible = true;
                label3.Visible = true;
                textBox4.Visible = true;
                button3.Visible = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "Data source=orcl;User Id=hr; Password=hr;";
            string cmdstr = "";
            if (comboBox1.SelectedItem.ToString() == "UserName")
            {
                cmdstr = "update REGISTER_USER set USERNAME=:x where USERNAME=:y and SSN=:z";
                adapter = new OracleDataAdapter(cmdstr, constr);
                adapter.SelectCommand.Parameters.Add("x", textBox3.Text);
                adapter.SelectCommand.Parameters.Add("y", textBox1.Text);
                adapter.SelectCommand.Parameters.Add("z", Int32.Parse(textBox2.Text));
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            }
            else if (comboBox1.SelectedItem.ToString() == "Passward")
            {
                cmdstr = "update REGISTER_USER set SSN=:x where USERNAME=:y and SSN=:z";
                adapter = new OracleDataAdapter(cmdstr, constr);
                adapter.SelectCommand.Parameters.Add("x", Int32.Parse(textBox4.Text));
                adapter.SelectCommand.Parameters.Add("y", textBox1.Text);
                adapter.SelectCommand.Parameters.Add("z", Int32.Parse(textBox2.Text));
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            }
            else if (comboBox1.SelectedItem.ToString() == "Both")
            {
                cmdstr = "update REGISTER_USER set USERNAME=:w,SSN=:x where USERNAME=:y and SSN=:z";
                adapter = new OracleDataAdapter(cmdstr, constr);
                adapter.SelectCommand.Parameters.Add("w", textBox3.Text);
                adapter.SelectCommand.Parameters.Add("x", Int32.Parse(textBox4.Text));
                adapter.SelectCommand.Parameters.Add("y", textBox1.Text);
                adapter.SelectCommand.Parameters.Add("z", Int32.Parse(textBox2.Text));
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            }
        }
    }
}
