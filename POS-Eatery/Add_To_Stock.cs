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
    public partial class Add_To_Stock : Form
    {
        public Add_To_Stock()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Add_To_Stock_Load(object sender, EventArgs e)
        {
            gclass.format_form(panel1, groupBox1, pictureBox2, statusStrip1, toolStripStatusLabel1);

           // gclass.display_in_combobox("SELECT DISTINCT Unit FROM Table_Unit ORDER BY Unit ASC", unit, "Unit");
           // unit.SelectedIndex = -1;

            gclass.display_in_combobox("SELECT DISTINCT Product_Name FROM Table_New_Product WHERE Category='Product' ORDER BY Product_Name ASC", list, "Product_Name");
            list.SelectedIndex = -1;
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_left.Text = null;
            label8.Text = null;
            label6.Text = null;
            quantity.Text = null;
          //  unit.SelectedIndex = -1;
            price.Text = "0.00";

            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='" + list.Text + "' AND Category='Product' ORDER BY p_id DESC Limit 1");
            if (dr.Read())
            {
                quantity_left.Text = (string)dr.GetValue(5).ToString();
                label6.Text = (string)dr.GetValue(6).ToString();
                price.Text = (string)dr.GetValue(12).ToString();
                label8.Text = "Available";
            }
        }

        private void unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_left.Text = null;
            label8.Text = null;
            label6.Text = null;
            price.Text = null;
            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_Summary WHERE Product_Name='" + list.Text + "' AND Category='Product' ORDER BY p_id DESC Limit 1");
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
          //  unit.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex == -1)
            {
                MessageBox.Show(" *Select Product to Update ...", "POS Intelligence Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else if (string.IsNullOrWhiteSpace(quantity.Text))
            {
                MessageBox.Show(" *Enter Quantity ...", "POS Intelligence Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    decimal a = decimal.Parse(quantity.Text);
                   // string code = quantity.Text + unit.Text;
                    MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory WHERE Date='" + DateTime.Now.ToShortDateString() + "' AND Product_Name='" + list.Text + "'");
                    if (dr.Read())
                    {
                        gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + quantity.Text + "',Quantity_Left=Quantity_Left+'" + quantity.Text + "',Price='"+ price.Text +"' WHERE Date='" + DateTime.Now.ToShortDateString() + "' AND Product_Name='" + list.Text + "' ORDER BY p_id DESC LIMIT 1");
                        gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Date,Day,Month,Year)VALUES('" + list.Text + "','Product','" + quantity.Text + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')");

                        quantity.Text = null;
                       // unit.SelectedIndex = -1;
                        list.SelectedIndex = -1;
                    }
                    else
                    {
                        gclass.insert1("INSERT INTO Table_stock_inventory_Summary(Product_Name,Category,Quantity_Left,Date,Day,Month,Year,Price)VALUES('" + list.Text + "','Product','" + quantity_left.Text + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','"+ price.Text +"')");
                        gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_In=Quantity_In+'" + quantity.Text + "',Quantity_Left=Quantity_Left+'" + quantity.Text + "',Price='"+ price.Text +"' WHERE Date='" + DateTime.Now.ToShortDateString() + "' AND Product_Name='" + list.Text + "' ORDER BY p_id DESC LIMIT 1");
                        gclass.insert("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Date,Day,Month,Year)VALUES('" + list.Text + "','Product','" + quantity.Text + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')");

                        quantity.Text = null;
                      //  unit.SelectedIndex = -1;
                        list.SelectedIndex = -1;
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
            this.Hide();
        }
    }
}
