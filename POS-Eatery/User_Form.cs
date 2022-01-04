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
    public partial class User_Form : Form
    {
        public User_Form()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentpost.Text) || string.IsNullOrWhiteSpace(loginstatus.Text) || string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrWhiteSpace(confirmpassword.Text))
            {
                MessageBox.Show("* All Fields are required!");
            }
            else if (name.SelectedIndex==-1 || string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Select Name from Employee Menu to Add as User ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password.Text != confirmpassword.Text)
            {
                MessageBox.Show("Password doe not Match ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               // string fullname = firstname.Text + " " + lastname.Text;
                string code = name.Text + username.Text;
                string query = "INSERT INTO Table_Login(First_Name,Last_Name,Current_Post,Login_Status,User_Name,Password,Full_Name,Code,Branch)VALUES('" + firstname.Text + "','" + lastname.Text + "','" + currentpost.Text + "','" + loginstatus.Text + "','" + username.Text + "','" + password.Text + "','" + name.Text + "','" + code.ToString() + "','"+ branch.Text +"') ON DUPLICATE KEY UPDATE Current_Post=values(current_post),Login_Status=values(login_status),user_name=values(user_name),Password=values(Password),Full_Name=values(Full_Name),Code=values(Code)";
                gclass.insert(query);
                gclass.panel_format(panel1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void User_Form_Load(object sender, EventArgs e)
        {
            gclass.display_in_combobox("SELECT DISTINCT(Name) FROM Table_Employee where branch='" + branch.Text + "'", name, "Name");
            name.SelectedIndex = -1;
        }
    }
}
