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
    public partial class Account_Confirmed : Form
    {
        public Account_Confirmed()
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
        private void customername_query_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = customername_query.Text;
            if (sales_gas.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
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
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_Confirmed WHERE Employee='" + customername_query.Text + "' ORDER BY p_id DESC";


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

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sales_gas.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Year='" + year.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Year='" + year.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
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
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Year='" + year.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Year='" + year.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Year='" + year.Text + "' ORDER BY p_id DESC";

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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Month='" + month.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Month='" + month.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Month='" + month.Text + "' ORDER BY p_id DESC";


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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Year='" + year.Text + "' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Employee='" + customername_query.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Employee='" + customername_query.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' ORDER BY p_id DESC";

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

        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sales_gas.Checked == true)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Product_Name LIKE 'Gas%'";
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
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                    // ######################################### START OF ACCOUNT DETAILS  ############################################
                    string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                    string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' ORDER BY p_id DESC";

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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";
                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' ORDER BY p_id DESC";
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
            if (year1.SelectedIndex == -1)
            {
                // MessageBox.Show("Select Year", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (month1.SelectedIndex == -1)
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Day='" + day1.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' AND Product_Name LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Day='" + day1.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Product_Name NOT LIKE 'Gas%' ORDER BY p_id DESC";

                        // ######################################### START OF ACCOUNT DETAILS  ############################################
                        string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
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
                        string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Day='" + day1.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' ORDER BY p_id DESC";

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

        private void receipt_invoice_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Receipt_No='" + receipt_invoice_no.Text + "' ORDER BY p_id DESC";

                // ######################################### START OF ACCOUNT DETAILS  ############################################
                string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Customer_Name='" + cst_name.Text + "'";
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

        private void cst_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Customer_Name='" + cst_name.Text + "' ORDER BY p_id DESC";

                // ######################################### START OF ACCOUNT DETAILS  ############################################
                string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Customer_Name='" + cst_name.Text + "'";
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

        private void button_delete_Click(object sender, EventArgs e)
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
                    string query = "DELETE FROM Table_Sales_confirmed WHERE p_id='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'";
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

        private void button_print_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDialog1.Document = printDocument1;
                printDocument1.Print();
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            fm.export_to_excell(dataGridView1);
        }

        private void sales_both_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
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

        private void Account_Confirmed_Load(object sender, EventArgs e)
        {
            textBox1.Text = customername_query.Text;
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string str = "SELECT Distinct Customer_Name FROM table_Sales_Confirmed ORDER BY Customer_Name ASC";
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
            fm.display_in_combobox("SELECT Distinct Customer_Name FROM table_Sales_Confirmed ORDER BY Customer_Name ASC", cst_name, "Customer_Name");
            cst_name.SelectedIndex = -1;




            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string str = "SELECT Distinct Receipt_no FROM table_Sales_confirmed ORDER BY p_id Desc";
                MySqlCommand cmd = new MySqlCommand(str, cn);
                // MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    acc.Add(dr.GetString(0));
                }
                receipt_invoice_no.AutoCompleteCustomSource = acc;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fm.display_in_combobox("SELECT DISTINCT Receipt_No FROM table_Sales_confirmed ORDER BY p_id Desc", receipt_invoice_no, "Receipt_No");
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

        private void payment_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query = "SELECT p_id AS 'S/N', Product_Name AS 'Product Name/ Description',Quantity,Price,Item_Value AS 'Item Bought',Discount,Code AS 'Short-Code',Date FROM Table_Sales_confirmed WHERE Payment_Method='" + payment_method.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Employee='" + customername_query.Text + "' ORDER BY p_id DESC";

                // ######################################### START OF ACCOUNT DETAILS  ############################################
                string query1 = "SELECT SUM(Item_Value),Product_Name FROM Table_Sales_confirmed WHERE Payment_Method='" + payment_method.Text + "' AND Day='" + day.Text + "' AND Year='" + year.Text + "' AND Month='" + month.Text + "' AND Employee='" + customername_query.Text + "'";
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


            double sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {

                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                total_sales.Text = sum.ToString();

            }






        }
    }
}
