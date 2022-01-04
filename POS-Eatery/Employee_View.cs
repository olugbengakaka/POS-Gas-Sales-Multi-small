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
    public partial class Employee_View : Form
    {
        public Employee_View()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void titletext_Click(object sender, EventArgs e)
        {
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gclass.Delete("DELETE FROM Table_Employee WHERE p_id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and Branch='" + branch.Text + "'");
            string query1 = "SELECT p_id AS ID,Name,Address,Tel_No AS 'Phone Number',Position,Qualification,Guarantor_Name AS 'Guarantor',Guarantor_Address AS 'Addr. of Guarantor',Guarantor_Relationship AS 'Relationship',Reg_By AS 'Registered By' FROM Table_Employee where branch='" + branch.Text + "'";
            gclass.display_in_dgv(query1, dataGridView1);
        }

        private void Employee_View_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT p_id AS ID,Name,Address,Tel_No AS 'Phone Number',Position,Qualification,Guarantor_Name AS 'Guarantor',Guarantor_Address AS 'Addr. of Guarantor',Guarantor_Relationship AS 'Relationship',Reg_By AS 'Registered By' FROM Table_Employee where branch='" + branch.Text + "'";
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
            this.Hide();
        }
    }
}
