using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace POS_Eatery
{
    public partial class P_N1 : Form
    {
        public P_N1()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                MessageBox.Show("Enter Admin User Name ...");
            }
            else if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Enter Admin Password ...");
            }
            else
            {
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_Login WHERE User_Name='" + username.Text + "' AND Password='" + password.Text + "' and Login_Status not like '%ales%' ");
                if (dr.Read())
                {
                    Expenditure fm = new Expenditure();
                    fm.name_admin.Text = (string)dr.GetValue(7).ToString();
                    fm.name_sales.Text = name_sales.Text;
                    fm.branch.Text = branch.Text;
                    fm.status.Text = (string)dr.GetValue(4).ToString();
                    fm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Access Denied ...");
                }
            }
        }
    }
}
