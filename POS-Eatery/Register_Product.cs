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
    public partial class Register_Product : Form
    {
        public Register_Product()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Form1_Load(object sender, EventArgs e)
        {
           // panel1.Font = new Font("Arial", 12.0F, FontStyle.Italic);
            gclass.format_form(panel1, groupBox1, pictureBox2, statusStrip1, toolStripStatusLabel1);
            gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product where branch='"+ branch.Text +"' ORDER BY Product_Name ASC", list, "Product_Name");
            list.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Enter Product Name for Registration ...", "Point of Sales Intelliscence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM table_new_product where product_name='" + name.Text + "' AND Category='Product' and branch='" + branch.Text + "'");
                if (dr.Read())
                {
                    MessageBox.Show(" Product had already Been Registered ...", "Point of Sales Intelliscence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string code = name.Text + "/Category"+branch.Text;

                    string query = "INSERT INTO Table_New_Product(Product_Name,Reg_By,Category,Date,Code,branch)VALUES('" + name.Text + "','" + users.Text + "','Product','" + DateTime.Now.ToShortTimeString() + "','"+ code.ToString() +"','"+ branch.Text +"') ON DUPLICATE KEY UPDATE Product_Name=values(product_name),Category=values(category),Code=values(code)";
                    gclass.insert(query);

                    gclass.insert1("INSERT INTO Table_Stock_Inventory(Product_Name,Category,Date,Code,branch)VALUES('" + name.Text + "','Product','" + DateTime.Now.ToShortDateString() + "','" + code.ToString() + "','"+ branch.Text +"') ON DUPLICATE KEY UPDATE Product_Name=values(product_name),Category=values(category),Code=values(code)");
                    gclass.insert1("INSERT INTO Table_Stock_Inventory_Summary(Product_Name,Category,Date,Code,Day,Month,Year,branch)VALUES('" + name.Text + "','Product','" + DateTime.Now.ToShortDateString() + "','" + code.ToString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','"+ branch.Text +"') ON DUPLICATE KEY UPDATE Product_Name=values(product_name),Category=values(category),Code=values(code)");

                    gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product WHERE Category='Product' and branch='" + branch.Text + "' ORDER BY Product_Name ASC", list, "Product_Name");
                    list.SelectedIndex = -1;
                    name.Text = null;
                    name.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gclass.Delete1("DELETE FROM Table_New_Product WHERE Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
            gclass.Delete1("DELETE FROM Table_stock_inventory_summary WHERE Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
            gclass.Delete1("DELETE FROM Table_stock_inventory WHERE Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
            gclass.Delete("DELETE FROM Table_price_product WHERE Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
            
            gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product where branch='" + branch.Text + "' ORDER BY Product_Name ASC", list, "Product_Name");
            list.SelectedIndex = -1;
        }
    }
}
