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
    public partial class Stock_Add : Form
    {
        public Stock_Add()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Stock_Add_Load(object sender, EventArgs e)
        {
            gclass.format_form(panel1, groupBox1, pictureBox2, statusStrip1, toolStripStatusLabel1);


            gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product WHERE Category='Product' and branch='" + branch.Text + "' ORDER BY Product_Name ASC", list, "Product_Name");
            list.SelectedIndex = -1;
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_left.Text = null;
            label8.Text = null;
            label6.Text = null;
            quantity_litre.Text = null;
            price.Text = null;
            cost.Text = null;

            if (list.Text.Contains("Gas") || list.Text.Contains("gas"))
            {
                label2.Text = "Litre(s)";
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                if (dr.Read())
                {
                   // string ab = (string)dr.GetValue(5).ToString();
                   // quantity_left.Text = (Convert.ToDecimal(ab) / Convert.ToDecimal(1.752)).ToString();
                    quantity_left.Text = (string)dr.GetValue(5).ToString();
                    label6.Text = "KG";
                    price.Text = (string)dr.GetValue(12).ToString();
                    cost.Text = (string)dr.GetValue(14).ToString();
                    label8.Text = "Available";
                }
            }
            else
            {
                label2.Text = "Piece(s)";
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='" + list.Text + "' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                if (dr.Read())
                {
                    quantity_left.Text = (string)dr.GetValue(5).ToString();
                    label6.Text = (string)dr.GetValue(6).ToString();
                    price.Text = (string)dr.GetValue(12).ToString();
                    label6.Text = "KG";
                    label6.Text = "Piece(s)";
                    label8.Text = "Available";
                }
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                MessageBox.Show(" *Select Product to Update ...", "POS Intelligence Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(quantity_litre.Text))
            {
                MessageBox.Show(" *Enter Quantity ...", "POS Intelligence Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    decimal a = decimal.Parse(quantity_litre.Text);
                    if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
                    {
                        textBox1.Text = Math.Round((Convert.ToDecimal(quantity_litre.Text) / Convert.ToDecimal(1.75)), 2).ToString();
                    }
                    else
                    {
                        textBox1.Text = quantity_litre.Text;
                    }
                    Random rnd = new Random(); string abs = rnd.Next(12345, 67896789).ToString();
                    string code = list.Text + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + abs + branch.Text;
                    MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory WHERE Date='" + s_date.Text + "' AND Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
                    if (dr.Read())//s_date.Text
                    {
                        if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
                        {
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + textBox1.Text + "',Quantity_Left=Quantity_Left+'" + textBox1.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='Gas' AND Category='Product' AND branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Unit,Date,Day,Month,Year,Code,Branch)VALUES('Gas','Product','" + textBox1.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','" + branch.Text + "')");
                        }
                        else
                        {
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + textBox1.Text + "',Quantity_Left=Quantity_Left+'" + textBox1.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='" + list.Text + "' AND Category='Product' AND branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Unit,Date,Day,Month,Year,Code,Branch)VALUES('" + list.Text + "','Product','" + textBox1.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                        }
                        quantity_litre.Text = null;
                        list.SelectedIndex = -1;
                    }
                    else
                    {
                        if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
                        {
                            gclass.insert1("INSERT INTO Table_stock_inventory_Summary(Product_Name,Category,Quantity_Left,Date,Day,Month,Year,Price,Code,branch)VALUES('Gas','Product','" + quantity_left.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + price.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + textBox1.Text + "',Quantity_Left=Quantity_Left+'" + textBox1.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Unit,Date,Day,Month,Year,Code,Branch)VALUES('Gas','Product','" + textBox1.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                        }
                        else
                        {
                            gclass.insert1("INSERT INTO Table_stock_inventory_Summary(Product_Name,Category,Quantity_Left,Date,Day,Month,Year,Price,Code,Branch)VALUES('" + list.Text + "','Product','" + quantity_left.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + price.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + textBox1.Text + "',Quantity_Left=Quantity_Left+'" + textBox1.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='" + list.Text + "' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Unit,Date,Day,Month,Year,Code,Branch)VALUES('" + list.Text + "','Product','" + textBox1.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                     
                        }
                        quantity_litre.Text = null;
                        list.SelectedIndex = -1;
                        // *142#
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   // MessageBox.Show(" *Quantity can only Contain Numbers/ Numeric Characters Only ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    quantity_litre.Text = null;
                }
            }            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(quantity_litre.Text))
            {
                quantity_litre.Text = "0";
            }
            try
            {
                decimal a = decimal.Parse(quantity_litre.Text);
                quantity_kg.Text = (Convert.ToDecimal(quantity_kg.Text) / Convert.ToDecimal(1.75)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quantity can only contain numbers ...");
                quantity_litre.Text = "0";
            }

        }

        private void quantity_kg_TextChanged(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(quantity_kg.Text))
            {
                quantity_kg.Text = "0";
            }

            try
            {
                decimal a = decimal.Parse(quantity_kg.Text);
                quantity_litre.Text = (Convert.ToDecimal(quantity_kg.Text) * Convert.ToDecimal(1.75)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quantity can only contain numbers ...");
                quantity_kg.Text = "0";
            }*/

        }

        private void cost_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal a = decimal.Parse(cost_price.Text);
            }
            catch
            {
                //MessageBox.Show("Cost Price can only contain numeric character ...");
                cost_price.Text = "0";
            }
        }

        private void cost_button_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                MessageBox.Show("Select Product from Product List ...", "POS Intelliscense Says: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(cost_price.Text))
            {
                MessageBox.Show("Enter Cost Price ...", "POS Intelliscense Says: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cost_price.Text == "0.00" || cost_price.Text == "0")
            {
                MessageBox.Show("Enter Cost Price ...", " POS Intelliscense Say ... ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Random rnd = new Random();
                int a = rnd.Next(1, 8000000);
                string code = list.Text + a;
                if (list.Text.Contains("gas") || list.Text.Contains("Gas") || list.Text.Contains("GAS"))
                {
                    gclass.Update("UPDATE Table_stock_inventory_Summary SET Cost='" + cost_price.Text + "' WHERE Product_Name Like 'Gas%' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");
                    gclass.Update1("UPDATE Table_Price_Product set Cost='" + cost_price.Text + "' WHERE Product_Name Like 'Gas%' and branch='" + branch.Text + "'");
                    gclass.Update1("UPDATE Table_Price_Product set Cost='" + cost_price.Text + "' WHERE Product_Name='Gas' and branch='" + branch.Text + "'");
                    gclass.Update1("UPDATE Table_stock_inventory_Summary SET Cost='" + cost_price.Text + "' WHERE Product_Name='Gas' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");
                }
                else
                {
                    gclass.Update("UPDATE Table_stock_inventory_Summary SET Cost='" + cost_price.Text + "' WHERE Product_Name='" + list.Text + "' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");
                    gclass.Update1("UPDATE Table_Price_Product set Cost='" + cost_price.Text + "' WHERE Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
                }
                // gclass.insert1("INSERT INTO Table_Price_Product(Product_Name,Reg_By,Date,Code,Category,Cost)VALUES('" + list.Text + "','" + users.Text + "','" + s_date.Text + "','" + code.ToString() + "','" + category.Text + "','" + cost_price.Text + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),reg_by=values(reg_by),date=values(date),code=values(code),category=values(category),cost=values(cost)");
                cost_price.Text = null;
                cost_price.Text = null;
                // cost_price.Text = null;
                // list.SelectedIndex = -1;
                // category.SelectedIndex = -1;
            }
        }

        private void unit_TextChanged(object sender, EventArgs e)
        {
            //label6.Text = unit.Text;
        }
    }
}
