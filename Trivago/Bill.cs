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
    public partial class Bill : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        int bill;
        string constr = "Data source=orcl;User Id=hr; Password=hr;";
        string cmdstr = "";
        public Bill()
        {
            InitializeComponent();
        }
        private void Bill_Load(object sender, EventArgs e)
        {
            //textBox4.Visible = false;
            textBox5.Visible = false;
            textBox1.Text = DateTime.Now.ToString();
            cmdstr = "select MAX(bill_id)from bill";
            adapter = new OracleDataAdapter(cmdstr, constr);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            textBox5.Text =(ds.Tables[0].Rows[0][0]).ToString();
            bill = Int32.Parse(textBox5.Text) + 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr1 = "";
            comboBox1.Items.Clear();
            cmdstr = "select room_id from roomidmv where resident_id=:d";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("d", Int32.Parse(textBox2.Text));
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = (ds.Tables[0]);
            comboBox1.ValueMember = "room_id";

            cmdstr1 = "select VISITED_HOTELS from VISITED_HOTELS where SSN =:a";
            adapter = new OracleDataAdapter(cmdstr1, constr);
            adapter.SelectCommand.Parameters.Add("a", Int32.Parse(textBox2.Text));
            DataSet ds2 = new DataSet();
            adapter.Fill(ds2);
            comboBox3.DataSource = (ds2.Tables[0]);
            comboBox3.ValueMember = "VISITED_HOTELS";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string cmdstr1="";
            cmdstr = "select (check_out- check_in)* price as days from resident, room where ROOM_ID=:a and RESIDENT_ID=:b";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("a", Int32.Parse(comboBox1.Text));
            adapter.SelectCommand.Parameters.Add("b", Int32.Parse(textBox2.Text));
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            textBox3.Text = ds.Tables[0].Rows[0][0].ToString();

            cmdstr1 = "select address from hotel where HOTEL_NAME=:a";
            adapter = new OracleDataAdapter(cmdstr1, constr);
            adapter.SelectCommand.Parameters.Add("a", comboBox3.Text);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            //textBox4.Text = ds1.Tables[0].Rows[1][0].ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            cmdstr = "insert into BILL (BILL_ID,DATE_PAYED,PRICE,PAYMENT_TYPE,ROOM_ID) values (:a,:b,:c,:d,:e)";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("a", bill);
            adapter.SelectCommand.Parameters.Add("b", Convert.ToDateTime(textBox1.Text));
            adapter.SelectCommand.Parameters.Add("c", Int32.Parse(textBox3.Text));
            adapter.SelectCommand.Parameters.Add("d", comboBox2.Text);
            adapter.SelectCommand.Parameters.Add("e", comboBox1.Text);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            string cmdstr1 = "";
            cmdstr1 = "update ROOM set RATE=:a where ROOM_ID=:b and ADDRESS =:c";
            adapter = new OracleDataAdapter(cmdstr1, constr);
            adapter.SelectCommand.Parameters.Add("a", Int32.Parse(comboBox4.Text));
            adapter.SelectCommand.Parameters.Add("b", Int32.Parse(comboBox1.Text));
            adapter.SelectCommand.Parameters.Add("c", textBox4.Text);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);

            MessageBox.Show("Done");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
           

        }

        private void Bill_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

     
    }
}
