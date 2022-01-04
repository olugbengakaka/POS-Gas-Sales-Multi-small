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
    public partial class Sact : Form
    {
        public Sact()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(act_key.Text) || string.IsNullOrWhiteSpace(school_id.Text))
            {
                MessageBox.Show("Enter Your User ID and Activation Code for SMS Activation ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT* FROM Table_act WHERE ACT='" + act_key.Text + "' AND School_id='" + school_id.Text + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        gclass.Update1("DELETE FROM Table_act");
                        gclass.Update_Online1("DELETE FROM Table_Act");

                        gclass.insert1("INSERT INTO Table_Act(Act,school_id)values('" + act_key.Text + "','" + school_id.Text + "')");
                        // gclass.insert_online("INSERT INTO Table_Act(Act)values('" + school_id.Text + "')");

                        MessageBox.Show("School ID AND SMS Activation Key Successfully Verified! \n\n SMS Service had been Activated ... \n\n School-MS Application will be Closed for Effect to take Place ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Login1 fm = new Login1();
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You Entered an Invalid Activation Code ... \n\nContact the Application Customer Care Section to Activate SMS Service ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
