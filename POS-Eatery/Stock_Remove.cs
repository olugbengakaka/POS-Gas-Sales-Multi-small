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
    public partial class Stock_Remove : Form
    {
        public Stock_Remove()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Remove_From_Stock_Load(object sender, EventArgs e)
        {
            gclass.format_form(panel1, groupBox1, pictureBox2, statusStrip1, toolStripStatusLabel1);
            //s_date.Text

            gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product WHERE Category='Product' and branch='"+ branch.Text +"' ORDER BY Product_Name ASC", list, "Product_Name");
            list.SelectedIndex = -1;
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_left.Text = null;
            label8.Text = null;
            label6.Text = null;
            quantity.Text = null;
            price.Text = null;

            if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
            {
                unit.Text = "KG";
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                if (dr.Read())
                {
                   // string ab = (string)dr.GetValue(5).ToString();
                   // quantity_left.Text = (Convert.ToDecimal(ab) / Convert.ToDecimal(1.752)).ToString();
                    quantity_left.Text = (string)dr.GetValue(5).ToString();
                    label6.Text = "KG";
                    price.Text = (string)dr.GetValue(12).ToString();
                    label8.Text = "Available";
                }
            }
            else
            {
                unit.Text = "Piece(s)";
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='" + list.Text + "' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                if (dr.Read())
                {
                    quantity_left.Text = (string)dr.GetValue(5).ToString();
                    label6.Text = (string)dr.GetValue(6).ToString();
                    price.Text = (string)dr.GetValue(12).ToString();
                    label6.Text = "Piece(s)";
                    label8.Text = "Available";
                }
            }

        }

        private void unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_left.Text = null;
            label6.Text = null;
            label8.Text = null;
            price.Text = null;
            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='" + list.Text + "' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
            if (dr.Read())
            {
                quantity_left.Text = (string)dr.GetValue(5).ToString();
                label6.Text = (string)dr.GetValue(6).ToString();
                price.Text = (string)dr.GetValue(12).ToString();
                label8.Text = "Available";
                //     }
            }
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                decimal a = decimal.Parse(quantity.Text);
                textBox1.Text = (Convert.ToDecimal(quantity.Text) / Convert.ToDecimal(1.752)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                MessageBox.Show(" *Select Product to Update ...", "POS Intelligence Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(quantity.Text))
            {
                MessageBox.Show(" *Enter Quantity ...", "POS Intelligence Says ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDecimal(quantity.Text) > Convert.ToDecimal(quantity_left.Text))
            {
                MessageBox.Show("You Cannot take more than " + quantity_left.Text + " " + label6.Text + " of " + list.Text + "\n\n Currently Available in Stock ...", "POS Intelliscence Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDecimal(quantity.Text) > Convert.ToDecimal(quantity_left.Text))
            {
                MessageBox.Show("Quantity of " + list.Text + " available is not up to " + quantity.Text + " Units ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Text = "0";
            }
            else
            {
                try
                {
                    decimal a = decimal.Parse(quantity.Text);
                   //(Convert.ToDecimal(quantity.Text) / Convert.ToDecimal(1.752)).ToString();
                    if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
                    {
                        textBox1.Text = quantity.Text;
                    }
                    else
                    {
                        textBox1.Text = quantity.Text;
                    }
                    string code = list.Text + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + branch.Text;
                    MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_summary WHERE Date='" + s_date.Text + "' AND Product_Name='" + list.Text + "' and branch='" + branch.Text + "'");
                    if (dr.Read())
                    {
                        if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
                        {
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + textBox1.Text + "',Quantity_Left=Quantity_Left-'" + textBox1.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Unit,Date,Day,Month,Year,Code,Branch)VALUES('Gas','Product','" + textBox1.Text + "','" + purpose.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                        }
                        else
                        {
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + textBox1.Text + "',Quantity_Left=Quantity_Left-'" + textBox1.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='" + list.Text + "' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Unit,Date,Day,Month,Year,Code,Branch)VALUES('" + list.Text + "','Product','" + textBox1.Text + "','" + purpose.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                        }
                        quantity.Text = null;
                        list.SelectedIndex = -1;
                        purpose.Text = null;
                    }
                    else
                    {
                        if (list.Text.Contains("Gas") || list.Text.Contains("gas") || list.Text.Contains("GAS"))
                        {
                            gclass.insert1("INSERT INTO Table_stock_inventory_Summary(Product_Name,Category,Quantity_Left,Date,Day,Month,Year,Price,Code,Branch)VALUES('Gas','Product','" + quantity_left.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + price.Text + "','" + code.ToString() + "','"+branch.Text+"')");
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + textBox1.Text + "',Quantity_Left=Quantity_Left-'" + quantity.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='Gas' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Unit,Date,Day,Month,Year,Code,Branch)VALUES('Gas','Product','" + textBox1.Text + "','" + purpose.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                        }
                        else
                        {
                            gclass.insert1("INSERT INTO Table_stock_inventory_Summary(Product_Name,Category,Quantity_Left,Date,Day,Month,Year,Price,Code,Branch)VALUES('" + list.Text + "','Product','" + quantity_left.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + price.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + textBox1.Text + "',Quantity_Left=Quantity_Left-'" + quantity.Text + "',Unit='" + unit.Text + "',Price='" + price.Text + "' WHERE Year='" + s_year.Text + "' AND Month='" + s_month.Text + "' and Day='" + s_day.Text + "' AND Product_Name='" + list.Text + "' AND Category='Product' and branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1");
                            gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Unit,Date,Day,Month,Year,Code,Branch)VALUES('" + list.Text + "','Product','" + textBox1.Text + "','" + purpose.Text + "','" + unit.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','"+ branch.Text +"')");
                        }
                        quantity.Text = null;
                        list.SelectedIndex = -1;
                        purpose.Text = null;
                        // *142#
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" *Quantity can only Contain Numbers/ Numeric Characters Only ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    quantity.Text = null;
                }
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void unit_TextChanged(object sender, EventArgs e)
        {
            //label6.Text = unit.Text;
        }
    }
}
