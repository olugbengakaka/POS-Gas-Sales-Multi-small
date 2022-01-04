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
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Change_Password_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "/images/portal.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show(" Enter Your New Password! ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "UPDATE Table_login SET Password='" + password.Text + "' WHERE full_Name='" + user_name.Text + "' and branch='"+ branch.Text +"'";
                gclass.Update(query);
                password.Text = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
