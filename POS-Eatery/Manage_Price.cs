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
    public partial class Manage_Price : Form
    {
        public Manage_Price()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button1_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                MessageBox.Show("Select Product from Product List ...", "POS Intelliscense Says: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (category.SelectedIndex == -1)
            {
                MessageBox.Show("Select Category ...", "POS Intelliscense Says: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price_new.Text == "0.00" || price_new.Text == "0")
            {
                MessageBox.Show("Enter the New Price ...", " POS Intelliscense Say ... ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           /* else if (cost_price.Text == "0.00" || cost_price.Text == "0")
            {
                MessageBox.Show("Enter Cost Price ...", " POS Intelliscense Say ... ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            else
            {
                string code = list.Text + category.Text+branch.Text;
                gclass.Update("UPDATE Table_stock_inventory_Summary SET Price='" + price_new.Text + "' WHERE Product_Name='" + list.Text + "' AND Category='" + category.Text + "' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");
                gclass.insert1("INSERT INTO Table_Price_Product(Product_Name,Price,Reg_By,Date,Code,Category,branch)VALUES('" + list.Text + "','" + price_new.Text + "','" + users.Text + "','" + DateTime.Now.ToShortDateString() + "','" + code.ToString() + "','" + category.Text + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),price=values(price),reg_by=values(reg_by),date=values(date),code=values(code),category=values(category)");
                price_new.Text = null;
                price_old.Text = null;
               // cost_price.Text = null;
               // list.SelectedIndex = -1;
               // category.SelectedIndex = -1;
            }
        }

        private void Manage_Price_Load(object sender, EventArgs e)
        {
            gclass.format_form(panel1, groupBox1, pictureBox2, statusStrip1, toolStripStatusLabel1);

            gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product where branch='" + branch.Text + "' ORDER BY Product_Name ASC", list, "Product_Name");
            list.SelectedIndex = -1;

           /* gclass.display_in_combobox("SELECT DISTINCT Unit FROM Table_Unit ORDER BY Unit ASC", unit, "Unit");
            unit.SelectedIndex = -1;*/

           
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            price_old.Text = null;
            price_new.Text = null;
           // cost_price.Text = null;
            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_price_product WHERE Product_Name='" + list.Text + "' AND Category='" + category.Text + "' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
            if (dr.Read())
            {
                price_old.Text = (string)dr.GetValue(2).ToString();
                cost_price.Text = (string)dr.GetValue(7).ToString();
            }
        }

        private void price_new_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(price_new.Text))
            {
                price_new.Text = "0.00";
            }

            try
            {
                decimal a = decimal.Parse(price_new.Text);
            }
            catch
            {
                MessageBox.Show("Price Can only Contain Number/ Numeric Character ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                price_new.Text = "0.00";
            }
        }

        private void price_old_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(price_old.Text))
            {
                price_old.Text = "0.00";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            price_old.Text = null;
            price_new.Text = null;
           // cost_price.Text = null;
            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_price_product WHERE Product_Name='" + list.Text + "' AND Category='" + category.Text + "' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
            if (dr.Read())
            {
                price_old.Text = (string)dr.GetValue(2).ToString();
                cost_price.Text = (string)dr.GetValue(7).ToString();
            }
        }

        private void cost_price_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cost_price.Text))
            {
                cost_price.Text = "0";
            }
            try
            {
                decimal s = decimal.Parse(cost_price.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cost Price can only contain numbers ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cost_price.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                MessageBox.Show("Select Product from Product List ...", "POS Intelliscense Says: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (category.SelectedIndex == -1)
            {
                MessageBox.Show("Select Category ...", "POS Intelliscense Says: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           /* else if (price_new.Text == "0.00" || price_new.Text == "0")
            {
                MessageBox.Show("Enter the New Price ...", " POS Intelliscense Say ... ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
             else if (cost_price.Text == "0.00" || cost_price.Text == "0")
             {
                 MessageBox.Show("Enter Cost Price ...", " POS Intelliscense Say ... ", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            else
            {
                string code = list.Text + category.Text + branch.Text;
                gclass.Update("UPDATE Table_stock_inventory_Summary SET Cost='" + cost_price.Text + "' WHERE Product_Name='" + list.Text + "' AND Category='" + category.Text + "' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");
                gclass.insert1("INSERT INTO Table_Price_Product(Product_Name,Reg_By,Date,Code,Category,Cost,branch)VALUES('" + list.Text + "','" + users.Text + "','" + DateTime.Now.ToShortDateString() + "','" + code.ToString() + "','" + category.Text + "','" + cost_price.Text + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),reg_by=values(reg_by),date=values(date),code=values(code),category=values(category),cost=values(cost)");
                price_new.Text = null;
                price_old.Text = null;
                // cost_price.Text = null;
                // list.SelectedIndex = -1;
                // category.SelectedIndex = -1;
            }
        }
    }
}
