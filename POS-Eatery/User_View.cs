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
    public partial class User_View : Form
    {
        public User_View()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void User_View_Load(object sender, EventArgs e)
        {
            /*try
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "/Img8.PNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            string query1 = "SELECT p_id AS ID,Full_Name AS 'Name of Employee',Current_Post AS 'Current Post',Login_Status AS 'Login Status',User_Name AS 'User Name' FROM Table_Login where branch='" + branch.Text + "'";
            gclass.display_in_dgv(query1, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gclass.Delete("DELETE FROM Table_Login WHERE p_id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and branch='"+ branch.Text +"'");
            string query1 = "SELECT p_id AS ID,First_Name AS 'First Name',Last_Name AS 'Last Name',Current_Post AS 'Current Post',Login_Status AS 'Login Status',User_Name AS 'User Name' FROM Table_Login where branch='" + branch.Text + "'";
            gclass.display_in_dgv(query1, dataGridView1);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            gclass.printdocument(dataGridView1, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gclass.print(printDocument1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
