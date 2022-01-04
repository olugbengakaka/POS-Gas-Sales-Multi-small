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

namespace pos
{
    public partial class Customize : Form
    {
        public Customize()
        {
            InitializeComponent();
        }
        General_Class gclass = new General_Class();
        private void button3_Click(object sender, EventArgs e)
        {
            if (companyname.Text.Length >= 26)
            {
                MessageBox.Show("Company name must not be more than 25 characters!");
            }
            else if (specialty.Text.Length >= 43)
            {
                MessageBox.Show("Specialization/ Service textfield must not be more than 43 characters!");
            }
            else if (address.Text.Length >= 41)
            {
                MessageBox.Show("Company Address must not be more than 34 characters!");
            }

            else if (email.Text.Length >= 41)
            {
                MessageBox.Show("Email Address must not be more than 41 characters!");
            }
            else if (telephone.Text.Length >= 34)
            {
                MessageBox.Show("Phone Number must not be more than 34 characters!");
            }
            else
            {
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_Customize where branch='"+ branch.Text +"'");
                if (dr.Read())
                {
                    string code = companyname.Text+branch.Text;
                    string query = "Update Table_Customize SET Company_Name='" + companyname.Text + "',Company_Specialty='" + specialty.Text + "',Company_Address='" + address.Text + "',Company_Email='" + email.Text + "',Company_Telephone='" + telephone.Text + "',Code='"+ code.ToString() +"' where branch='"+ branch.Text +"'";
                    gclass.Update(query);
                  //  Login fm = new Login();
                   // fm.Show();
                    this.Hide();
                }
                else
                {
                    string code = companyname.Text+branch.Text;
                    string query = "INSERT INTO Table_Customize(Company_Name,Company_Specialty,Company_Address,Company_Email,Company_Telephone,Code,branch)VALUES('" + companyname.Text + "','" + specialty.Text + "','" + address.Text + "','" + email.Text + "','" + telephone.Text + "','"+ code.ToString() +"','"+ branch.Text +"')";
                    gclass.insert(query);
                   // Login fm = new Login();
                   // fm.Show();
                    this.Hide();
                }
            }
        }

        private void Customize_Load(object sender, EventArgs e)
        {
            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_Customize where branch='"+ branch.Text +"'");
                while (dr.Read())
                {
                    companyname.Text = (string)dr.GetValue(1).ToString();
                    specialty.Text = (string)dr.GetValue(2).ToString();
                    address.Text = (string)dr.GetValue(3).ToString();
                    email.Text = (string)dr.GetValue(4).ToString();
                    telephone.Text = (string)dr.GetValue(5).ToString();
                }
                dr.Close();
           

        }

        private void companyname_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
