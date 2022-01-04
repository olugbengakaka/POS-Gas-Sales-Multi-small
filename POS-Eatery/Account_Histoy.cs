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
    public partial class Account_History : Form
    {
        public Account_History()
        {
            InitializeComponent();
        }
        General_Class_Imp fm = new General_Class_Imp();
        // General_Class gclass = new General_Class();
        private string ab()
        {
            total_quantity_sold.Text = "0.00";
            total_sales.Text = "0.00";
            total_discount_given.Text = "0.00";

            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                total_quantity_sold.Text = sum.ToString();
            }

            double sum1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                total_sales.Text = sum1.ToString();
            }

            double sum2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                total_discount_given.Text = sum2.ToString();
            }
            return "sola";
           
        }
        private void Account_History_Load(object sender, EventArgs e)
        {
            textBox1.Text = customername_query.Text;
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string str = "SELECT Distinct Customer_Name FROM table_Sales_Summary ORDER BY Customer_Name ASC";
                MySqlCommand cmd = new MySqlCommand(str, cn);
                // MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    acc.Add(dr.GetString(0));
                }
                cst_name.AutoCompleteCustomSource = acc;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fm.display_in_combobox("SELECT Distinct Customer_Name FROM table_Sales_Summary ORDER BY Customer_Name ASC", cst_name, "Customer_Name");
            cst_name.SelectedIndex = -1;




            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string str = "SELECT* FROM table_Sales_Summary ORDER BY p_id Desc";
                MySqlCommand cmd = new MySqlCommand(str, cn);
                // MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    acc.Add(dr.GetString(20));
                }
                receipt_invoice_no.AutoCompleteCustomSource = acc;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fm.display_in_combobox("SELECT DISTINCT Receipt_No FROM table_Sales_Summary ORDER BY p_id Desc", receipt_invoice_no, "Receipt_No");
            cst_name.SelectedIndex = -1;






            sales_gas.Checked = true;
           /* if (status.Text == "Admin" || status.Text == "admin")
            {
                button_delete.Visible = true;
                customername_query.Visible = true;
                // customername_query.Text = users.Text;
            }
            else
            {
                button_delete.Visible = false;
                customername_query.Visible = false;
                customername_query.Text = users.Text;
                employee_name.Text = users.Text;
            }*/
            /*try
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "/Img8.PNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            day.SelectedIndex = 0;
            month.SelectedIndex = 0;
            year.SelectedIndex = 0;
           

            
           // customername_query.SelectedIndex = -1;
           // customername_query.Text = textBox1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel2.Visible = true;
                dataGridView1.ReadOnly = false;
            }
            else
            {
                panel2.Visible = false;
                dataGridView1.ReadOnly = true;
            }
        }

        private void customername_query_TextChanged(object sender, EventArgs e)
        {
            /* employee_name.Text = customername_query.Text;

             try
             {
                 MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                 cn.Open();
                 string query = "SELECT p_id AS 'Invoice Number', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "'";

                 // ######################################### START OF ACCOUNT DETAILS  ############################################
                 string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "'";
                 MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                 MySqlDataReader dr1 = cmd1.ExecuteReader();
                 if (dr1.Read())
                 {
                     total_amount_due.Text = (string)dr1.GetValue(0).ToString();

                 }
                 dr1.Close();
                 // ######################################### END OF ACCOUNT DETAIL ##############################################

                 MySqlCommand cmd = new MySqlCommand(query, cn);
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(amountpaid.Text))
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();

                    double new_bal = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value) - Convert.ToDouble(amountpaid.Text);
                    double new_amt_paid = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value) + Convert.ToDouble(amountpaid.Text);

                    string query = "Update Table_Sales_Summary SET Amount_Paid='" + new_amt_paid + "',Balance='" + new_bal + "' WHERE p_id='" + Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[0].Value) + "'";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(amountpaid.Text))
            {
                amountpaid.Text = "0";
            }
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sales_gas.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Year='" + year.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            else if (sales_accessory.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Year='" + year.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            else
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Year='" + year.Text + "' ORDER BY p_id DESC";

                   /* // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Employee='" + employee_name.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################
                    */
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (year.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Year", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sales_gas.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        // string query = "SELECT p_id AS [Invoice Number], Product_Name AS [Product Name/ Description],Quantity,Price,Item_Value AS [Item Bought],Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "' AND Month='" + month.Text + "'";
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Month='" + month.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            //total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else if (sales_accessory.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        // string query = "SELECT p_id AS [Invoice Number], Product_Name AS [Product Name/ Description],Quantity,Price,Item_Value AS [Item Bought],Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "' AND Month='" + month.Text + "'";
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Month='" + month.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            //total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        // string query = "SELECT p_id AS [Invoice Number], Product_Name AS [Product Name/ Description],Quantity,Price,Item_Value AS [Item Bought],Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "' AND Month='" + month.Text + "'";
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Month='" + month.Text + "' ORDER BY p_id DESC";
                        

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                
            }
            ab();
        }

        private void day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (year.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Year", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (month.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Month", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sales_gas.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else if (sales_accessory.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' ORDER BY p_id DESC";

                       /* // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + employee_name.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################
                        */
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
            }
            ab();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to Update the selected Sales?", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        int itembought = int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                        int amountpaid = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                        int balance = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "UPDATE Table_Sales_Summary SET Item_Value='" + itembought + "',Amount_Paid='" + amountpaid + "',Balance='" + balance + "' WHERE p_id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sales successfully Updated");
                        dataGridView1.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to Delete the selected Sales?", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "DELETE FROM Table_Sales_Summary WHERE p_id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sales successfully Deleted");
                        dataGridView1.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Do you really want to Delete the Selected Sales! ", " Message Center ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                   // int a = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());

                    MySqlCommand cmd2 = new MySqlCommand("Update Table_Stock_Inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[2].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[2].Value) + "' WHERE Product_Name='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "' AND Category='Product' AND Date='" + DateTime.Now.ToShortDateString() + "' ORDER BY P_id DESC LIMIT 1", cn);
                    string query = "DELETE FROM Table_Sales_Summary WHERE p_id='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'";
                    MySqlCommand cmd1 = new MySqlCommand(query, cn);

                    cmd2.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();

                    string code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second;
                    fm.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Date,Day,Month,Year,Code,Purpose)VALUES('" + dataGridView1.SelectedRows[0].Cells[1].Value + "','Product','" + dataGridView1.SelectedRows[0].Cells[2].Value + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + code.ToString() + "','Returned Sales')");


                    MessageBox.Show(" Sales successfully Deleted and current stock updated ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);

                    double sum = 0;

                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {

                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        total_sales.Text = sum.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDialog1.Document = printDocument1;
                printDocument1.Print();
            }
        }

        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sales_gas.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            else if (sales_accessory.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            else
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' ORDER BY p_id DESC";

                  /*  // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################
                    */
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            ab();
        }

        private void month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month1.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Year", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sales_gas.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        // string query = "SELECT p_id AS [Invoice Number], Product_Name AS [Product Name/ Description],Quantity,Price,Item_Value AS [Item Bought],Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "' AND Month='" + month.Text + "'";
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            //total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else if (sales_accessory.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        // string query = "SELECT p_id AS [Invoice Number], Product_Name AS [Product Name/ Description],Quantity,Price,Item_Value AS [Item Bought],Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "' AND Month='" + month.Text + "'";
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            //total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        // string query = "SELECT p_id AS [Invoice Number], Product_Name AS [Product Name/ Description],Quantity,Price,Item_Value AS [Item Bought],Date FROM Table_Sales_Summary WHERE Employee='" + employee_name.Text + "' AND Month='" + month.Text + "'";
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' ORDER BY p_id DESC";
                       /* // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            //total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################
                        */
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
            }
            ab();
        }

        private void day1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (year.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Year", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (month.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Month", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sales_gas.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Day='" + day1.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else if (sales_accessory.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Day='" + day1.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Day='" + day1.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' ORDER BY p_id DESC";

                       /* // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################
                        */
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
            }
            
        }

        private void customername_query_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = customername_query.Text;
            if (sales_gas.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            else if (sales_accessory.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        total_sales.Text = (string)dr1.GetValue(0).ToString();
                    }
                    dr1.Close();
                    // ######################################### END OF ACCOUNT DETAIL ##############################################

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }
            else
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Employee='" + customername_query.Text + "' ORDER BY p_id DESC";

                 
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ab();
            }

        }

        private void button_export_Click(object sender, EventArgs e)
        {
            fm.export_to_excell(dataGridView1);
        }

        private void sales_gas_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void sales_accessory_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void cst_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Customer_Name='" + cst_name.Text + "' ORDER BY p_id DESC";

                // ######################################### START OF ACCOUNT DETAILS  ############################################
                string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Customer_Name='" + cst_name.Text + "'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    total_sales.Text = (string)dr1.GetValue(0).ToString();
                }
                dr1.Close();
                // ######################################### END OF ACCOUNT DETAIL ##############################################

                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ab();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
            

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
          /*  for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                double sum = 0;
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                total_quantity_sold.Text = sum.ToString();
            }

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                double sum = 0;
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                total_sales.Text = sum.ToString();
            }

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                double sum = 0;
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                total_discount_given.Text = sum.ToString();
            }

            total_no_of_sales.Text = (Convert.ToInt32(((DataGridView)sender).Rows.Count) - Convert.ToInt32(1)).ToString();*/
        }

        private void receipt_invoice_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Summary WHERE Receipt_No='" + receipt_invoice_no.Text + "' ORDER BY p_id DESC";

                // ######################################### START OF ACCOUNT DETAILS  ############################################
                string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_Summary WHERE Customer_Name='" + cst_name.Text + "'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    total_sales.Text = (string)dr1.GetValue(0).ToString();
                }
                dr1.Close();
                // ######################################### END OF ACCOUNT DETAIL ##############################################

                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ab();
        }

        private void total_discount_given_TextChanged(object sender, EventArgs e)
        {

        }

        private void sales_both_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void payment_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (year.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Year", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (month.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Month", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sales_gas.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_summary WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Product_Name LIKE 'Gas%' AND Payment_Method='" + payment_method.Text + "' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%' AND Payment_Method='" + payment_method.Text + "'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else if (sales_accessory.Checked == true)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_summary WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Product_Name NOT LIKE 'Gas%' AND Payment_Method='" + payment_method.Text + "' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%' AND Payment_Method='" + payment_method.Text + "'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            total_sales.Text = (string)dr1.GetValue(0).ToString();
                            // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                            // total_balance.Text = (string)dr1.GetValue(2).ToString();

                        }
                        dr1.Close();
                        // ######################################### END OF ACCOUNT DETAIL ##############################################

                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
                else
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_summary WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Payment_Method='" + payment_method.Text + "' ORDER BY p_id DESC";

                        /* // ######################################### START OF ACCOUNT DETAILS  ############################################
                         string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_Summary WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + employee_name.Text + "' AND Product_Name LIKE 'Gas%'";
                         MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                         MySqlDataReader dr1 = cmd1.ExecuteReader();
                         if (dr1.Read())
                         {
                             total_sales.Text = (string)dr1.GetValue(0).ToString();
                             // total_amount_paid.Text = (string)dr1.GetValue(1).ToString();
                             // total_balance.Text = (string)dr1.GetValue(2).ToString();

                         }
                         dr1.Close();
                         // ######################################### END OF ACCOUNT DETAIL ##############################################
                         */
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ab();
                }
            }
            ab();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

        
    
        
    

    
    
