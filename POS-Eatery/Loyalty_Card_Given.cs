using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS_Eatery
{
    public partial class Loyalty_Card_Given : Form
    {
        public Loyalty_Card_Given()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void specialty_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Patronizers fm = new Patronizers();
            fm.branch.Text = branch.Text;
            fm.registered_by.Text = registered_by.Text;
            fm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card_History fm = new Card_History();
            fm.branch.Text = branch.Text;
            fm.registered_by.Text = registered_by.Text;
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(card_serial.Text) || string.IsNullOrWhiteSpace(address.Text) || string.IsNullOrWhiteSpace(phone.Text) || string.IsNullOrWhiteSpace(email.Text))
            {
                MessageBox.Show("*All Fields Are Required ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string code = card_serial.Text + branch.Text;
                string query = "insert into table_loyalty_card_given(Name,Card_Serial,Address,Phone,Email,Code,Branch,Registered_By,Date,day,month,year)VALUES('" + name.Text + "','" + card_serial.Text + "','" + address.Text + "','" + phone.Text + "','" + email.Text + "','" + code + "','" + branch.Text + "','" + registered_by.Text + "',now(),'" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "') on duplicate key update code=values(code)";
                gclass.insert(query);
            }
        }
    }
}
