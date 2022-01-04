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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        string str200 = "";
        MySqlConnection cn100 = new MySqlConnection();
        MySqlConnection cn99 = new MySqlConnection();
        MySqlCommand cmd100 = new MySqlCommand();
        MySqlCommand cmd101 = new MySqlCommand();
        MySqlCommand cmd99 = new MySqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            //string part = textBox1.Text.Substring(0, textBox1.Text.IndexOf('_'));
            //MessageBox.Show(part);

            gclass.get_on(webBrowser1, g_school);
            DialogResult dr27 = MessageBox.Show("Online and Offline Database Synchronization can take Several Hours to Days to complete based on the number of Modules Selected.\n \nFor more Efficiency and Data Integrity, It is advisable to only Select Module(s) that need synchronization with Online Database ... \n \nDo you really want to Upload and Synchronize with Online Database ? \n \n Click Yes to Continue Or No to Cancel and Re-Select Module(s) ...", "  Message from School-MS Online Monitoring Server: ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                str200 = Convert.ToString(webBrowser1.Document.GetElementById("content").OuterText).Trim().TrimEnd();
                // MessageBox.Show("Click OK Button to Continue ... default", "Confirmation Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (str200 != "")
                {
                    //  MessageBox.Show(str200);
                    gclass.display_in_dgv_online("SELECT* FROM table_sales_confirmed WHERE Day='" + dateTimePicker1.Value.Day + "' AND Month='" + dateTimePicker1.Value.Month + "' AND Year='" + dateTimePicker1.Value.Year + "' and branch='" + branch.Text + "'", dataGridView2, str200);

                    /* for (int i = 0; i < dataGridView2.Rows.Count; i++)
                     {

                         try
                         {
                             MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                             cn.Open();
                             string query = "INSERT INTO Table_Sales_confirmed(Product_Name,Category,Quantity,Price,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Branch)VALUES('" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[22].Value.ToString() + "') ON DUPLICATE KEY UPDATE customer_name=values(customer_name),quantity=values(quantity),product_name=values(product_name),Category=values(category),Price=values(price),amount_paid=values(amount_paid),balance=values(balance),Date=values(date),day=values(day),month=values(month),year=values(year),employee=values(employee),code=values(code),payment_method=values(payment_method),discount=values(discount),Receipt_No=values(Receipt_No)";
                             MySqlCommand cmd = new MySqlCommand(query, cn);
                             cmd.ExecuteNonQuery();
                             MessageBox.Show("Success from table_sales_confirmed");
                             cn.Close();
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            ///////////////////////////////////////////////////////

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "SELECT* FROM table_sales_confirmed WHERE Day='" + dateTimePicker1.Value.Day + "' AND Month='" + dateTimePicker1.Value.Month + "' AND Year='" + dateTimePicker1.Value.Year + "' and branch='" + branch.Text + "'";// "SELECT* FROM table_sales_confirmed WHERE Day='" + dateTimePicker1.Value.Day + "' AND Month='" + dateTimePicker1.Value.Month + "' AND Year='" + dateTimePicker1.Value.Year + "' and branch='" + branch.Text + "'";
            //MessageBox.Show(dateTimePicker1.Value.Day.ToString());
            //  MessageBox.Show(dateTimePicker1.Value.Month.ToString());
            //  MessageBox.Show(dateTimePicker1.Value.Year.ToString());
        }
    }
}
