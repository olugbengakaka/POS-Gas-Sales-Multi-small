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
    public partial class View_Price : Form
    {
        public View_Price()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
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

        private void View_Price_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT p_id AS 'ID', Product_Name AS 'Name of Product',Price,Reg_By AS 'Last Updated By',Date FROM Table_Price_Product Where Branch='"+ branch.Text +"' ORDER BY Product_Name ASC";
            gclass.display_in_dgv(query1, dataGridView1);
        }
    }
}
