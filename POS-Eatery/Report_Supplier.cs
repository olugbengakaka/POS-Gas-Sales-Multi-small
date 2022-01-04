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
    public partial class Report_Supplier : Form
    {
        public Report_Supplier()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private string ab()
        {
            no_of_record.Text = (Convert.ToInt32(dataGridView1.Rows.Count) - 1).ToString();
            return "sola";
        }
            
        private void button_export_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            gclass.Delete("DELETE FROM Table_Customer WHERE p_id='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) + "' and branch='"+ branch.Text +"'");
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void Report_Supplier_Load(object sender, EventArgs e)
        {
            string query = "SELECT p_id AS 'S/N',Company_Name AS 'Company Name',Contact_Name AS 'Contact Name',Company_Phone AS 'Company Phone',Contact_Phone AS 'Contact Phone',Company_Email AS 'Company Email',Contact_Email AS 'Contact Email',DATE AS 'Registered Date' FROM Table_Customer where branch='"+ branch.Text +"' ORDER BY Company_Name";
            gclass.display_in_dgv(query, dataGridView1);
            ab();
        }
    }
}
