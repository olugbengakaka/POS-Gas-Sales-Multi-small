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
    public partial class Patronizers : Form
    {
        public Patronizers()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button_print_Click(object sender, EventArgs e)
        {
            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);");
           
           // title.Text = "Sale's Transaction Report From " + dateTimePicker1.Value.Date + " to " + dateTimePicker2.Value.Date;

            string a = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            string b = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;

           /* try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                //string query10 = "select Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Customer Name',Item_Value as 'Total Amount',Amount_Paid as 'Amount Paid' from table_sales_lump where dat>='" + a + "' and dat<='" + b + "'";
                string query10 = "select distinct phone as 'Phone',count(phone) Times from table_sales_lump where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch.Text + "' group by phone order by Times desc";
                
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd10);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
           // string query1 = "select distinct phone as 'Phone',count(phone) Times from table_sales_lump where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch.Text + "' group by phone order by Times desc";
            string query1 = "select distinct phone as 'Phone',count(phone) Times from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch.Text + "' group by phone order by Times desc";
            gclass.display_in_dgv(query1, dataGridView1);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string a = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            string b = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;

            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                //string query10 = "select Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Customer Name',Item_Value as 'Total Amount',Amount_Paid as 'Amount Paid' from table_sales_lump where dat>='" + a + "' and dat<='" + b + "'";
                string query1 = "select dat as 'Date',Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Name of Customer',Product_Name as 'Name of Product',Quantity,Discount,Item_Value as 'Total Amount',Employee as 'Staff on Seat' from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch.Text + "' and phone='" + dataGridView1.SelectedRows[0].Cells[0].Value + "' order by p_id desc";
           
                MySqlCommand cmd10 = new MySqlCommand(query1, cn10);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd10);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

           // string query1 = "select dat as 'Date',Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Name of Customer',Product_Name as 'Name of Product',Quantity,Discount,Item_Value as 'Total Amount',Employee as 'Staff on Seat' from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='"+ branch.Text +"' and phone='"+ dataGridView1.SelectedRows[0].Cells[0].Value +"' order by p_id desc";
           // gclass.display_in_dgv(query1, dataGridView2); 
        }

        private void Patronizers_Load(object sender, EventArgs e)
        {
            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);");
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "/images/error.png");

            try
            {
                MySqlConnection cn11 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn11.Open();
                string str11 = "SELECT distinct phone FROM table_sales_lump where Branch='" + branch.Text + "' ORDER BY p_id DESC";
                MySqlCommand cmd11 = new MySqlCommand(str11, cn11);
                MySqlDataReader dr11 = cmd11.ExecuteReader();
                // MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr11.Read())
                {
                    acc.Add(dr11.GetString(0));
                }
                search.AutoCompleteCustomSource = acc;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // cn11.Close();
                // cmd11.Dispose();
                // dr11.Close();
            }

            gclass.display_in_combobox("SELECT distinct phone FROM table_sales_lump where Branch='" + branch.Text + "' ORDER BY p_id DESC", search, "Phone");

            /*string a = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            string b = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;

            string query1 = "select dat as 'Date',Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Name of Customer',Product_Name as 'Name of Product',Quantity,Discount,Item_Value as 'Total Amount',Employee as 'Staff on Seat' from table_sales_confirmed where phone='" + search.Text + "' and branch='" + branch.Text + "' order by p_id desc";
            gclass.display_in_dgv(query1, dataGridView2);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "select dat as 'Date',Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Name of Customer',Product_Name as 'Name of Product',Quantity,Discount,Item_Value as 'Total Amount',Employee as 'Staff on Seat' from table_sales_confirmed where phone='"+ search.Text +"' and branch='" + branch.Text + "' order by p_id desc";
            gclass.display_in_dgv(query1, dataGridView2);
        }

        private void search_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query1 = "select dat as 'Date',Receipt_No as 'Receipt No',Phone as 'Phone No',Customer_Name as 'Name of Customer',Product_Name as 'Name of Product',Quantity,Discount,Item_Value as 'Total Amount',Employee as 'Staff on Seat' from table_sales_confirmed where phone='" + search.Text + "' and branch='" + branch.Text + "' order by p_id desc";
            gclass.display_in_dgv(query1, dataGridView2);

        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
