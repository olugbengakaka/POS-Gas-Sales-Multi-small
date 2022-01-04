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
    public partial class Inventory_Detail : Form
    {
        public Inventory_Detail()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Inventory_Detail_Load(object sender, EventArgs e)
        {
            quantity_in.Text = null;
            quantity_out.Text = null;//
            gclass.display_in_dgv("SELECT Date,Product_Name AS 'Product Name',Quantity_IN AS 'Quantity In',Quantity_Out AS 'Quantity Out',Purpose,Time,Category,p_id FROM Table_Stock_Inventory WHERE Product_Name='" + txt_product.Text + "' AND Date='" + txt_date.Text + "' and branch='"+ branch.Text +"' order by p_id desc", dataGridView1);
            MySql.Data.MySqlClient.MySqlDataReader dr = gclass.display_in_box("SELECT SUM(Quantity_In),SUM(Quantity_Out) FROM Table_Stock_Inventory_summary WHERE Product_Name='" + txt_product.Text + "' AND Date='" + txt_date.Text + "' and branch='" + branch.Text + "'");
           if (dr.Read())
           {
               quantity_in.Text = (string)dr.GetValue(0).ToString();
               quantity_out.Text = (string)dr.GetValue(1).ToString();
           }

           try
           {
               for (int i = 0; i < dataGridView1.Columns.Count; i++)
               {
                   dataGridView1.Columns[6].Visible = false;
                   dataGridView1.Columns[7].Visible = false;
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView1.SelectedRows[0].Cells[7].Value).Contains("Gas") || Convert.ToString(dataGridView1.SelectedRows[0].Cells[7].Value) == "gas" || Convert.ToString(dataGridView1.SelectedRows[0].Cells[7].Value) == "Gas")
            {
                gclass.Delete("Delete from table_stock_inventory where p_id='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[7].Value) + "' and branch='" + branch.Text + "'");
                gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "' WHERE Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                gclass.display_in_dgv("SELECT Date,Product_Name AS 'Product Name',Quantity_IN AS 'Quantity In',Quantity_Out AS 'Quantity Out',Purpose,Time,Category,p_id FROM Table_Stock_Inventory WHERE Product_Name='" + txt_product.Text + "' AND Date='" + txt_date.Text + "' and branch='" + branch.Text + "'", dataGridView1);
            }
            else
            {
                gclass.Delete("Delete from table_stock_inventory where p_id='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[7].Value) + "' and branch='" + branch.Text + "'");
                gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "' WHERE Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                gclass.display_in_dgv("SELECT Date,Product_Name AS 'Product Name',Quantity_IN AS 'Quantity In',Quantity_Out AS 'Quantity Out',Purpose,Time,Category,p_id FROM Table_Stock_Inventory WHERE Product_Name='" + txt_product.Text + "' AND Date='" + txt_date.Text + "' and branch='" + branch.Text + "' order by p_id desc", dataGridView1);
         
            }
        }
    }
}
