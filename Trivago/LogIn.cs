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
    public partial class LogIn : Form
    {
        
        public LogIn()
        {
            InitializeComponent();
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            button5.Visible = false;
            button7.Visible = false;
            button13.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reserve r = new Reserve();
            r.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CancelReservation c = new CancelReservation();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteAccount d = new DeleteAccount();
            d.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateReservation u = new UpdateReservation();
            u.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report g = new Report();
            g.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button5.Visible = true;
            button13.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Report2 r = new Report2();
            r.Show();
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            Disconnected d = new Disconnected();
            d.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Bill b = new Bill();
            b.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            DisplayHotels d = new DisplayHotels();
            d.Show();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            MasterDetail i = new MasterDetail();
            i.Show();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Formula f = new Formula();
            f.Show();
        }
        private void button9_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button14_Click(object sender, EventArgs e)
        {
           

        }
    }
}
