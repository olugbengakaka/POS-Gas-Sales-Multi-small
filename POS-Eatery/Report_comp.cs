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


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace POS_Eatery
{
    public partial class Report_comp : Form
    {
        public Report_comp()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        string mth = null; string mth1 = null;
        #region Member Variables
        const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height

        public string abs(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dgv.Columns[9].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string printable_date()
        {
            if (month.Text == "1")
            {
                mth = "January";
            }
            else if (month.Text == "2")
            {
                mth = "February";
            }
            else if (month.Text == "3")
            {
                mth = "March";
            }
            else if (month.Text == "4")
            {
                mth = "April";
            }
            else if (month.Text == "5")
            {
                mth = "May";
            }
            else if (month.Text == "6")
            {
                mth = "June";
            }
            else if (month.Text == "7")
            {
                mth = "July";
            }
            else if (month.Text == "8")
            {
                mth = "August";
            }
            else if (month.Text == "9")
            {
                mth = "September";
            }
            else if (month.Text == "10")
            {
                mth = "October";
            }
            else if (month.Text == "11")
            {
                mth = "November";
            }
            else if (month.Text == "12")
            {
                mth = "December";
            }

            if (year.SelectedIndex > 0 && month.SelectedIndex == 0 && day.SelectedIndex == 0)
            {
                print_date.Text = "Sale's Report for the Year: \t \t \t \t " + year.Text;
            }
            else if (year.SelectedIndex > 0 && month.SelectedIndex > 0 && day.SelectedIndex == 0)
            {
                // print_date.Text = "Sale's Report for the Year: \t \t \t \t " + year.Text;
                print_date.Text = "Sale's Report for the Month of " + mth + ", " + year.Text;
            }
            else if (year.SelectedIndex > 0 && month.SelectedIndex > 0 && day.SelectedIndex > 0)
            {
                print_date.Text = "Sale's Report for: \t \t \t \t " + mth + " " + day.Text + ", " + year.Text;
            }
            return "Sola";
        }

        public string printable_date1()
        {
            if (month1.Text == "1")
            {
                mth1 = "January";
            }
            else if (month1.Text == "2")
            {
                mth1 = "February";
            }
            else if (month1.Text == "3")
            {
                mth1 = "March";
            }
            else if (month1.Text == "4")
            {
                mth1 = "April";
            }
            else if (month1.Text == "5")
            {
                mth1 = "May";
            }
            else if (month1.Text == "6")
            {
                mth1 = "June";
            }
            else if (month1.Text == "7")
            {
                mth1 = "July";
            }
            else if (month1.Text == "8")
            {
                mth1 = "August";
            }
            else if (month1.Text == "9")
            {
                mth1 = "September";
            }
            else if (month1.Text == "10")
            {
                mth1 = "October";
            }
            else if (month1.Text == "11")
            {
                mth1 = "November";
            }
            else if (month1.Text == "12")
            {
                mth1 = "December";
            }

            if (employee.SelectedIndex>0 && year1.SelectedIndex == 0 && month1.SelectedIndex == 0 && day1.SelectedIndex == 0)
            {
                print_date.Text = "Sale's Report by " + employee.Text;
            }
            else if (year1.SelectedIndex > 0 && month1.SelectedIndex == 0 && day1.SelectedIndex == 0)
            {
                print_date.Text = "Sale's Report by " + employee.Text + " for the Year: \t \t \t \t " + year1.Text;
            }
            else if (year1.SelectedIndex > 0 && month1.SelectedIndex > 0 && day1.SelectedIndex == 0)
            {
                // print_date.Text = "Sale's Report for the Year: \t \t \t \t " + year.Text;
                print_date.Text = "Sale's Report by " + employee.Text + " for the Month of " + mth1 + ", " + year1.Text;
            }
            else if (year1.SelectedIndex > 0 && month1.SelectedIndex > 0 && day1.SelectedIndex > 0)
            {
                print_date.Text = "Sale's Report by " + employee.Text + " for: \t \t \t \t " + mth1 + " " + day1.Text + ", " + year1.Text;
            }
            return "Sola";
        }

        #endregion

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);

            textBox1.Text = "true";
            if (year.SelectedIndex > 0)
            {
                printable_date();
                
                //////////////////////////////////////////////////////////////////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Product_Name like 'Gas%' AND CODE like '%End User%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            end_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            home_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where year='" + year.Text + "' and branch='"+ branch.Text +"'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            repayment.Text = (string)dr10.GetValue(0).ToString();
                            remit_cash.Text = (string)dr10.GetValue(1).ToString();
                            remit_pos.Text = (string)dr10.GetValue(2).ToString();
                            remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                    //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                    end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                //////////////////////////////////////////////////////////////////////////////////

                gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE  year='" + year.Text + "' and branch='"+ branch.Text +"' ORDER BY Receipt_No", receipt_no, "Receipt_No");
                receipt_no.SelectedIndex = -1;

                try
                {
                    month1.SelectedIndex = 0;
                    day1.SelectedIndex = 0;

                    // ######################################### SUM GAS SALES ONLY  ############################################
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr6 = cmd1.ExecuteReader();
                    if (dr6.Read())
                    {
                        sales_gas.Text = (string)dr6.GetValue(0).ToString();
                    }
                    dr6.Close();
                    // cn.Close();

                    // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                    MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn2.Open();
                    string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                    }
                    dr2.Close();
                    // cn2.Close();
                    //  ############################################### START OF FRESH COMP #######################################
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(balance) from table_sales_lump where Payment_Method like 'cred%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                credit.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(transport) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                transport.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'en%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                end.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'dist%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                distributor.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'ind%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                industrial.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'hom%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                home.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                       // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost) from table_sales_lump where year='" + year.Text + "' and branch='" + branch.Text + "'";

                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                cash.Text = (string)dr10.GetValue(0).ToString();
                                pos.Text = (string)dr10.GetValue(1).ToString();
                                transfer.Text = (string)dr10.GetValue(2).ToString();
                                discount.Text = (string)dr10.GetValue(3).ToString();
                                gross_profit.Text = (string)dr10.GetValue(4).ToString();
                                to_money.Text = (string)dr10.GetValue(5).ToString();
                                ts.Text = (string)dr10.GetValue(6).ToString();
                                tc.Text = (string)dr10.GetValue(7).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //////////////

                    //  gross_profit.Text = (Convert.ToDecimal(ts.Text) - Convert.ToDecimal(tc.Text)).ToString();
                    //  ############################################### END OF FRESH COMP #######################################


                    MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year.Text + "' and branch='"+ branch.Text +"'");
                    if (dr1.Read())
                    {
                        expenses.Text = (string)dr1.GetValue(0).ToString();
                    }
                    else
                    {
                        expenses.Text = "0.00";
                    }
                    gclass.panel_format_money(panel1);
                    net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();

                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year.Text + "' and branch='" + branch.Text + "'   order by p_id DESC", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {
                sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // ######################################### CASH TO BANK  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='"+ year.Text +"' and  branch='" + branch.Text + "' AND Code LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    cash_to_bank.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ######################################### EXPENDITURE  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='"+ year.Text +"' and  branch='" + branch.Text + "' AND Code Not LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    expenses.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cash_at_hand.Text = (Convert.ToDecimal(cash.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenses.Text))).ToString();

            abs(dataGridView1);
        }

       

        private void expenses_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(expenses.Text))
            {
                expenses.Text = "0.00";
            }
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);  

            textBox1.Text = "true";
            if (year.SelectedIndex > 0 && month.SelectedIndex > 0)
            {
                printable_date();
                //////////////////////////////////////////////////////////////////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "' and Product_Name like 'Gas%' AND CODE like '%End User%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            end_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"'  and Month='" + month.Text + "' and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            home_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"'  and Month='" + month.Text + "' and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "' and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            repayment.Text = (string)dr10.GetValue(0).ToString();
                            remit_cash.Text = (string)dr10.GetValue(1).ToString();
                            remit_pos.Text = (string)dr10.GetValue(2).ToString();
                            remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                    //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                    end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                //////////////////////////////////////////////////////////////////////////////////
               

                gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' ORDER BY Receipt_No", receipt_no, "Receipt_No");
                receipt_no.SelectedIndex = -1;
                try
                {
                    day1.SelectedIndex = 0;

                    // ######################################### SUM GAS SALES ONLY  ############################################
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr6 = cmd1.ExecuteReader();
                    if (dr6.Read())
                    {
                        sales_gas.Text = (string)dr6.GetValue(0).ToString();
                    }
                    dr6.Close();
                    // cn.Close();

                    // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                    MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn2.Open();
                    string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Month='" + month.Text + "' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                    }
                    dr2.Close();
                    // cn2.Close();


                    string query = "SELECT (select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND (Item_Value-Amount_Paid)>0) as 'Credit',(select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND Category like 'en%') as 'End User Sale',(select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND Category like 'dist%') as 'Distributor',(select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND Category like 'ind%') as 'Industrial',(select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND Category like 'hom%') as 'Home',(select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND Payment_Method like 'cas%') as 'Cash',(select SUM(Item_Value) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "' AND Payment_Method like 'PO%') as 'POS',sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall' FROM `table_sales_lump` WHERE year='" + year.Text + "' and branch='"+ branch.Text +"'   AND month='" + month.Text + "'";
                    MySqlDataReader dr = gclass.display_in_box(query);
                    if (dr.Read())
                    {
                        credit.Text = (string)dr.GetValue(0).ToString();
                        end.Text = (string)dr.GetValue(1).ToString();
                        distributor.Text = (string)dr.GetValue(2).ToString();
                        industrial.Text = (string)dr.GetValue(3).ToString();
                        home.Text = (string)dr.GetValue(4).ToString();
                        cash.Text = (string)dr.GetValue(5).ToString();
                        pos.Text = (string)dr.GetValue(6).ToString();
                        discount.Text = (string)dr.GetValue(7).ToString();
                        gross_profit.Text = (string)dr.GetValue(8).ToString();
                        to_money.Text = (string)dr.GetValue(9).ToString();
                    }


                    //  ############################################### START OF FRESH COMP #######################################
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(balance) from table_sales_lump where Payment_Method like 'cred%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                credit.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(transport) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                transport.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'en%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                end.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'dist%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                distributor.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'ind%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                industrial.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'hom%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                home.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost) from table_sales_lump where year='" + year.Text + "' and branch='" + branch.Text + "' and month='"+ month.Text + "'  and payment_method not like 'cred%'";

                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                cash.Text = (string)dr10.GetValue(0).ToString();
                                pos.Text = (string)dr10.GetValue(1).ToString();
                                transfer.Text = (string)dr10.GetValue(2).ToString();
                                discount.Text = (string)dr10.GetValue(3).ToString();
                                gross_profit.Text = (string)dr10.GetValue(4).ToString();
                                to_money.Text = (string)dr10.GetValue(5).ToString();
                                ts.Text = (string)dr10.GetValue(6).ToString();
                                tc.Text = (string)dr10.GetValue(7).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //////////////

                    //  ############################################### END OF FRESH COMP #######################################



                    MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND month='" + month.Text + "'");
                    if (dr1.Read())
                    {
                        expenses.Text = (string)dr1.GetValue(0).ToString();
                    }
                    else
                    {
                        expenses.Text = "0.00";
                    }

                    net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();

                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year.Text + "' and branch='" + branch.Text + "'   AND month='" + month.Text + "' order by p_id DESC", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            try
            {
                sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            // ######################################### CASH TO BANK  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='" + year.Text + "' and month='"+ month.Text +"' and  branch='" + branch.Text + "' AND Code LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    cash_to_bank.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ######################################### EXPENDITURE  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='" + year.Text + "' and month='"+ month.Text +"' and  branch='" + branch.Text + "' AND Code Not LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    expenses.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cash.Text = (Convert.ToDecimal(cash.Text) - Convert.ToDecimal(change.Text)).ToString();

            cash.Text = (Convert.ToDecimal(cash.Text) + Convert.ToDecimal(remit_cash.Text)).ToString();
            pos.Text = (Convert.ToDecimal(pos.Text) + Convert.ToDecimal(remit_pos.Text)).ToString();
            transfer.Text = (Convert.ToDecimal(transfer.Text) + Convert.ToDecimal(remit_transfer.Text)).ToString();

            cash_at_hand.Text = (Convert.ToDecimal(cash.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenses.Text))).ToString();

            abs(dataGridView1);
        }

        private void day_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);

            textBox1.Text = "true";
            if (year.SelectedIndex > 0 && month.SelectedIndex > 0)
            {
                printable_date();
                //////////////////////////////////////////////////////////////////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "' and Day='" + day.Text + "' and Product_Name like 'Gas%' AND CODE like '%End User%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            end_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"'  and Month='" + month.Text + "' and Day='" + day.Text + "' and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            home_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"'  and Month='" + month.Text + "' and Day='" + day.Text + "' and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "' and Day='" + day.Text + "' and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "' and Day='" + day.Text + "'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            repayment.Text = (string)dr10.GetValue(0).ToString();
                            remit_cash.Text = (string)dr10.GetValue(1).ToString();
                            remit_pos.Text = (string)dr10.GetValue(2).ToString();
                            remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                    //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                    end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                //////////////////////////////////////////////////////////////////////////////////
               

                gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "' ORDER BY Receipt_No", receipt_no, "Receipt_No");
                receipt_no.SelectedIndex = -1;
                try
                {
                    // ######################################### SUM GAS SALES ONLY  ############################################
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr6 = cmd1.ExecuteReader();
                    if (dr6.Read())
                    {
                        sales_gas.Text = (string)dr6.GetValue(0).ToString();
                    }
                    dr6.Close();
                    // cn.Close();

                    // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                    MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn2.Open();
                    string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Month='" + month.Text + "' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Day='" + day.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                    }
                    dr2.Close();
                    // cn2.Close();

                    // //////////// START OF FRESH COMP ////////////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(balance) from table_sales_lump where Payment_Method like 'cred%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                credit.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(transport) from table_sales_lump where year='" + year.Text + "' and branch='"+ branch.Text +"' and Month='" + month.Text + "' AND Day='" + day.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                transport.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'en%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                end.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'dist%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                distributor.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'ind%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                industrial.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'hom%' AND year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                home.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost),sum(changes) from table_sales_lump where year='" + year.Text + "' and branch='" + branch.Text + "' and month='" + month.Text + "' and day='" + day.Text + "' and payment_method not like 'cred%'";

                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                cash.Text = (string)dr10.GetValue(0).ToString();
                                pos.Text = (string)dr10.GetValue(1).ToString();
                                transfer.Text = (string)dr10.GetValue(2).ToString();
                                discount.Text = (string)dr10.GetValue(3).ToString();
                                gross_profit.Text = (string)dr10.GetValue(4).ToString();
                                to_money.Text = (string)dr10.GetValue(5).ToString();
                                ts.Text = (string)dr10.GetValue(6).ToString();
                                tc.Text = (string)dr10.GetValue(7).ToString();
                                change.Text = (string)dr10.GetValue(8).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //  ############################################### END OF FRESH COMP #######################################


                    MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "'  AND Day='" + day.Text + "'");
                    if (dr1.Read())
                    {
                        expenses.Text = (string)dr1.GetValue(0).ToString();
                    }
                    else
                    {
                        expenses.Text = "0.00";
                    }

                    net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();

                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year.Text + "' and branch='" + branch.Text + "'   AND Month='" + month.Text + "' AND Day='" + day.Text + "' order by p_id DESC", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            try
            {
                sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            // ######################################### CASH TO BANK  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='" + year.Text + "' and month='" + month.Text + "' and day='"+ day.Text +"' and  branch='" + branch.Text + "' AND Code LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    cash_to_bank.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ######################################### EXPENDITURE  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='" + year.Text + "' and month='" + month.Text + "' and day='"+ day.Text +"' and  branch='" + branch.Text + "' AND Code Not LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    expenses.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cash.Text = (Convert.ToDecimal(cash.Text) - Convert.ToDecimal(change.Text)).ToString();

            cash.Text = (Convert.ToDecimal(cash.Text) + Convert.ToDecimal(remit_cash.Text)).ToString();
            pos.Text = (Convert.ToDecimal(pos.Text) + Convert.ToDecimal(remit_pos.Text)).ToString();
            transfer.Text = (Convert.ToDecimal(transfer.Text) + Convert.ToDecimal(remit_transfer.Text)).ToString();

            cash_at_hand.Text = (Convert.ToDecimal(cash.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenses.Text))).ToString();


            // sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            abs(dataGridView1);
        }

        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);

            textBox1.Text = "true";
            if (year1.SelectedIndex > 0)
            {
                printable_date1();
                //////////////////////////////////////////////////////////////////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%End User%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            end_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            home_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where year='" + year1.Text + "' and Registered_By='" + employee.Text + "'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            repayment.Text = (string)dr10.GetValue(0).ToString();
                            remit_cash.Text = (string)dr10.GetValue(1).ToString();
                            remit_pos.Text = (string)dr10.GetValue(2).ToString();
                            remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                    //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                    end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                //////////////////////////////////////////////////////////////////////////////////


                gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Year='"+ year1.Text +"' ORDER BY Receipt_No", receipt_no, "Receipt_No");
                receipt_no.SelectedIndex = -1;

                try
                {
                    month1.SelectedIndex = 0;
                    day1.SelectedIndex = 0;

                    // ######################################### SUM GAS SALES ONLY  ############################################
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Year='"+ year1.Text +"' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr6 = cmd1.ExecuteReader();
                    if (dr6.Read())
                    {
                        sales_gas.Text = (string)dr6.GetValue(0).ToString();
                    }
                    dr6.Close();
                    // cn.Close();

                    // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                    MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn2.Open();
                    string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Year='"+ year1.Text +"' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                    }
                    dr2.Close();
                    // cn2.Close();


                   /* string query = "SELECT (select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND (Item_Value-Amount_Paid)>0) as 'Credit',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND Category like 'en%') as 'End User Sale',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND Category like 'dist%') as 'Distributor',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND Category like 'ind%') as 'Industrial',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND Category like 'hom%') as 'Home',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND Payment_Method like 'cas%') as 'Cash',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND Payment_Method like 'PO%') as 'POS',sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall' FROM `table_sales_lump` WHERE year='" + year1.Text + "' AND Employee='"+ employee.Text +"' ";
                    MySqlDataReader dr = gclass.display_in_box(query);
                    if (dr.Read())
                    {
                        credit.Text = (string)dr.GetValue(0).ToString();
                        end.Text = (string)dr.GetValue(1).ToString();
                        distributor.Text = (string)dr.GetValue(2).ToString();
                        industrial.Text = (string)dr.GetValue(3).ToString();
                        home.Text = (string)dr.GetValue(4).ToString();
                        cash.Text = (string)dr.GetValue(5).ToString();
                        pos.Text = (string)dr.GetValue(6).ToString();
                        discount.Text = (string)dr.GetValue(7).ToString();
                        gross_profit.Text = (string)dr.GetValue(8).ToString();
                        textBox11.Text = (string)dr.GetValue(9).ToString();
                    }*/




                    //  ############################################### START OF FRESH COMP #######################################
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(balance) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Payment_Method like 'cred%' AND year='" + year1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                credit.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(transport) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and year='"+ year1.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                transport.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'en%' AND year='" + year1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                end.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'dist%' AND year='" + year1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                distributor.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'ind%' AND year='" + year1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                industrial.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'hom%' AND year='" + year1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                home.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost) from table_sales_lump where Employee='" + employee.Text + "' and branch='" + branch.Text + "' and year='" + year1.Text + "'";

                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                cash.Text = (string)dr10.GetValue(0).ToString();
                                pos.Text = (string)dr10.GetValue(1).ToString();
                                transfer.Text = (string)dr10.GetValue(2).ToString();
                                discount.Text = (string)dr10.GetValue(3).ToString();
                                gross_profit.Text = (string)dr10.GetValue(4).ToString();
                                to_money.Text = (string)dr10.GetValue(5).ToString();
                                ts.Text = (string)dr10.GetValue(6).ToString();
                                tc.Text = (string)dr10.GetValue(7).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //  gross_profit.Text = (Convert.ToDecimal(ts.Text) - Convert.ToDecimal(tc.Text)).ToString();
                    //  ############################################### END OF FRESH COMP #######################################








                    MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year1.Text + "'");
                    if (dr1.Read())
                    {
                        expenses.Text = (string)dr1.GetValue(0).ToString();
                    }
                    else
                    {
                        expenses.Text = "0.00";
                    }
                    gclass.panel_format_money(panel1);
                    net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();

                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year1.Text + "' AND Employee='" + employee.Text + "' and branch='" + branch.Text + "' order by p_id DESC", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            try
            {
                sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year1.Text + "' AND Employee='" + employee.Text + "' and branch='" + branch.Text + "' order by p_id DESC", dataGridView1);
            abs(dataGridView1);   
        }

        private void month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);

            textBox1.Text = "true";
            if (year1.SelectedIndex > 0 && month1.SelectedIndex > 0)
            {
                printable_date1();
                //////////////////////////////////////////////////////////////////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Month='" + month1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%End User%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            end_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "'  and Month='" + month1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            home_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "'  and Month='" + month1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Month='" + month1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where year='" + year1.Text + "' and Month='" + month1.Text + "' and Registered_By='" + employee.Text + "'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            repayment.Text = (string)dr10.GetValue(0).ToString();
                            remit_cash.Text = (string)dr10.GetValue(1).ToString();
                            remit_pos.Text = (string)dr10.GetValue(2).ToString();
                            remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                    //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                    end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                //////////////////////////////////////////////////////////////////////////////////



                gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND year='" + year1.Text + "' AND Month='"+ month1.Text +"' ORDER BY Receipt_No", receipt_no, "Receipt_No");
                receipt_no.SelectedIndex = -1;
                try
                {
                    day1.SelectedIndex = 0;

                    // ######################################### SUM GAS SALES ONLY  ############################################
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND year='" + year1.Text + "' AND Month='"+ month1.Text +"' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr6 = cmd1.ExecuteReader();
                    if (dr6.Read())
                    {
                        sales_gas.Text = (string)dr6.GetValue(0).ToString();
                    }
                    dr6.Close();
                    // cn.Close();

                    // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                    MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn2.Open();
                    string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Month='"+ month1.Text +"' AND year='" + year1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                    }
                    dr2.Close();
                    // cn2.Close();


                    string query = "SELECT (select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "' AND (Item_Value-Amount_Paid)>0) as 'Credit',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "' AND Category like 'en%') as 'End User Sale',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "' AND Category like 'dist%') as 'Distributor',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "' AND Category like 'ind%') as 'Industrial',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "' AND Category like 'hom%') as 'Home',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month.Text + "' AND Payment_Method like 'cas%') as 'Cash',(select SUM(Item_Value) from table_sales_lump where year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "' AND Payment_Method like 'PO%') as 'POS',sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall' FROM `table_sales_lump` WHERE year='" + year1.Text + "' AND Employee='"+ employee.Text +"'  AND month='" + month1.Text + "'";
                    MySqlDataReader dr = gclass.display_in_box(query);
                    if (dr.Read())
                    {
                        credit.Text = (string)dr.GetValue(0).ToString();
                        end.Text = (string)dr.GetValue(1).ToString();
                        distributor.Text = (string)dr.GetValue(2).ToString();
                        industrial.Text = (string)dr.GetValue(3).ToString();
                        home.Text = (string)dr.GetValue(4).ToString();
                        cash.Text = (string)dr.GetValue(5).ToString();
                        pos.Text = (string)dr.GetValue(6).ToString();
                        discount.Text = (string)dr.GetValue(7).ToString();
                        gross_profit.Text = (string)dr.GetValue(8).ToString();
                        to_money.Text = (string)dr.GetValue(9).ToString();
                    }


                    //  ############################################### START OF FRESH COMP #######################################
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(balance) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Payment_Method like 'cred%' AND year='" + year1.Text + "' AND Month='" + month1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                credit.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(transport) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and year='" + year1.Text + "' and Month='"+ month1.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                transport.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'en%' AND Year='"+ year1.Text +"' AND Month='"+month1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                end.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'dist%' AND Year='"+ year1.Text +"' AND Month='"+month1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                distributor.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'ind%' AND Year='"+ year1.Text +"' AND Month='"+month1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                industrial.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'hom%' AND Year='"+ year1.Text +"' AND Month='"+month1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                home.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost),sum(changes) from table_sales_lump where Employee='" + employee.Text + "' and branch='" + branch.Text + "' and year='" + year1.Text + "' and month='"+ month1.Text + "' and payment_method not like 'cred%'";

                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                cash.Text = (string)dr10.GetValue(0).ToString();
                                pos.Text = (string)dr10.GetValue(1).ToString();
                                transfer.Text = (string)dr10.GetValue(2).ToString();
                                discount.Text = (string)dr10.GetValue(3).ToString();
                                gross_profit.Text = (string)dr10.GetValue(4).ToString();
                                to_money.Text = (string)dr10.GetValue(5).ToString();
                                ts.Text = (string)dr10.GetValue(6).ToString();
                                tc.Text = (string)dr10.GetValue(7).ToString();
                               // change.Text = (string)dr10.GetValue(8).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    //  gross_profit.Text = (Convert.ToDecimal(ts.Text) - Convert.ToDecimal(tc.Text)).ToString();


                    //  ############################################### END OF FRESH COMP #######################################



                    MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year1.Text + "' AND month='" + month1.Text + "'");
                    if (dr1.Read())
                    {
                        expenses.Text = (string)dr1.GetValue(0).ToString();
                    }
                    else
                    {
                        expenses.Text = "0.00";
                    }

                    net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();

                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year1.Text + "' AND Employee='" + employee.Text + "' and branch='" + branch.Text + "' AND month='" + month1.Text + "' order by p_id DESC", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           // sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            try
            {
                sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            cash.Text = (Convert.ToDecimal(cash.Text) - Convert.ToDecimal(change.Text)).ToString();

            cash.Text = (Convert.ToDecimal(cash.Text) + Convert.ToDecimal(remit_cash.Text)).ToString();
            pos.Text = (Convert.ToDecimal(pos.Text) + Convert.ToDecimal(remit_pos.Text)).ToString();
            transfer.Text = (Convert.ToDecimal(transfer.Text) + Convert.ToDecimal(remit_transfer.Text)).ToString();

            cash_at_hand.Text = (Convert.ToDecimal(cash.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenses.Text))).ToString();


            abs(dataGridView1);
        }

        private void day1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);

            textBox1.Text = "true";
            if (year1.SelectedIndex > 0 && month1.SelectedIndex > 0)
            {
                printable_date1();
                //////////////////////////////////////////////////////////////////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Month='" + month1.Text + "' and Day='" + day1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%End User%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            end_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "'  and Month='" + month1.Text + "' and Day='" + day1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            home_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "'  and Month='" + month1.Text + "' and Day='" + day1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Quantity) from table_sales_confirmed where year='" + year1.Text + "' and Month='" + month1.Text + "' and Day='" + day1.Text + "' and Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where year='" + year1.Text + "' and Month='" + month1.Text + "' and Day='" + day1.Text + "' and Registered_By='" + employee.Text + "'";
                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            repayment.Text = (string)dr10.GetValue(0).ToString();
                            remit_cash.Text = (string)dr10.GetValue(1).ToString();
                            remit_pos.Text = (string)dr10.GetValue(2).ToString();
                            remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                    //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                    end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                //////////////////////////////////////////////////////////////////////////////////


                gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='"+ day1.Text +"' ORDER BY Receipt_No", receipt_no, "Receipt_No");
                receipt_no.SelectedIndex = -1;
                try
                {
                    // ######################################### SUM GAS SALES ONLY  ############################################
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='"+ day1.Text +"' AND Product_Name LIKE 'Gas%'";
                    MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                    MySqlDataReader dr6 = cmd1.ExecuteReader();
                    if (dr6.Read())
                    {
                        sales_gas.Text = (string)dr6.GetValue(0).ToString();
                    }
                    dr6.Close();
                    // cn.Close();

                    // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                    MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn2.Open();
                    string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Month='" + month1.Text + "' AND year='" + year1.Text + "' AND Day='"+ day1.Text +"' AND Product_Name NOT LIKE 'Gas%'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                    }
                    dr2.Close();
                    // cn2.Close();


                    // //////////// START OF FRESH COMP ////////////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(balance) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Payment_Method like 'cred%' AND year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                credit.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(transport) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and year='" + year1.Text + "' and Month='" + month1.Text + "' AND Day='"+ day1.Text +"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                transport.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////

                    ////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'en%' AND year='" + year1.Text + "' AND Month='"+month1.Text+"' AND Day='"+day1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                end.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ///////////////////////////
                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'dist%' AND year='" + year1.Text + "' AND Month='"+month1.Text+"' AND Day='"+day1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                distributor.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'ind%' AND year='" + year1.Text + "' AND Month='"+month1.Text+"' AND Day='"+day1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                industrial.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'hom%' AND year='" + year1.Text + "' AND Month='"+month1.Text+"' AND Day='"+day1.Text+"'";
                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                home.Text = (string)dr10.GetValue(0).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////

                    try
                    {
                        MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn10.Open();
                        // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                        string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost),sum(changes) from table_sales_lump where Employee='" + employee.Text + "' and branch='" + branch.Text + "' and year='" + year1.Text + "' and month='" + month1.Text + "' and day='" + day1.Text + "' and payment_method not like 'cred%'";

                        MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                        MySqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                            try
                            {
                                cash.Text = (string)dr10.GetValue(0).ToString();
                                pos.Text = (string)dr10.GetValue(1).ToString();
                                transfer.Text = (string)dr10.GetValue(2).ToString();
                                discount.Text = (string)dr10.GetValue(3).ToString();
                                gross_profit.Text = (string)dr10.GetValue(4).ToString();
                                to_money.Text = (string)dr10.GetValue(5).ToString();
                                ts.Text = (string)dr10.GetValue(6).ToString();
                                tc.Text = (string)dr10.GetValue(7).ToString();
                                change.Text = (string)dr10.GetValue(8).ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cn10.Close(); cn10.Dispose();
                                cmd10.Dispose();
                                dr10.Close(); dr10.Dispose();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    // gross_profit.Text = (Convert.ToDecimal(ts.Text) - Convert.ToDecimal(tc.Text)).ToString();

                    //  ############################################### END OF FRESH COMP #######################################


                    MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year1.Text + "' AND Month='" + month1.Text + "'  AND Day='" + day1.Text + "'");
                    if (dr1.Read())
                    {
                        expenses.Text = (string)dr1.GetValue(0).ToString();
                    }
                    else
                    {
                        expenses.Text = "0.00";
                    }

                    net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();

                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE year='" + year1.Text + "' AND Employee='" + employee.Text + "' and branch='" + branch.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' order by p_id DESC", dataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {
                sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

            // ######################################### CASH TO BANK  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='" + year1.Text + "' and month='" + month1.Text + "' and day='" + day1.Text + "' and code like '%" + employee.Text + "%' and  branch='" + branch.Text + "' AND Code LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    cash_to_bank.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ######################################### EXPENDITURE  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  year='" + year1.Text + "' and month='"+ month1.Text +"' and day='"+ day1.Text +"' and code like '%"+ employee.Text +"%' and  branch='" + branch.Text + "' AND Code Not LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    expenses.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cash.Text = (Convert.ToDecimal(cash.Text) - Convert.ToDecimal(change.Text)).ToString();

            cash.Text = (Convert.ToDecimal(cash.Text) + Convert.ToDecimal(remit_cash.Text)).ToString();
            pos.Text = (Convert.ToDecimal(pos.Text) + Convert.ToDecimal(remit_pos.Text)).ToString();
            transfer.Text = (Convert.ToDecimal(transfer.Text) + Convert.ToDecimal(remit_transfer.Text)).ToString();

            cash_at_hand.Text = (Convert.ToDecimal(cash.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenses.Text))).ToString();


            abs(dataGridView1);
        }

        private void employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format_money(panel7);

            textBox1.Text = "true";
            printable_date1();
            //////////////////////////////////////////////////////////////////////////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Quantity) from table_sales_confirmed where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%End User%'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        end_kg.Text = (string)dr10.GetValue(0).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn10.Close(); cn10.Dispose();
                        cmd10.Dispose();
                        dr10.Close(); dr10.Dispose();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Quantity) from table_sales_confirmed where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        home_kg.Text = (string)dr10.GetValue(0).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn10.Close(); cn10.Dispose();
                        cmd10.Dispose();
                        dr10.Close(); dr10.Dispose();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Quantity) from table_sales_confirmed where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        distributor_kg.Text = (string)dr10.GetValue(0).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn10.Close(); cn10.Dispose();
                        cmd10.Dispose();
                        dr10.Close(); dr10.Dispose();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Quantity) from table_sales_confirmed where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        industrial_kg.Text = (string)dr10.GetValue(0).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn10.Close(); cn10.Dispose();
                        cmd10.Dispose();
                        dr10.Close(); dr10.Dispose();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Amount_Paid),SUM(CASH),SUM(POS),SUM(TRANSFER) from table_Repayment where Registered_By='" + employee.Text + "'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        repayment.Text = (string)dr10.GetValue(0).ToString();
                        remit_cash.Text = (string)dr10.GetValue(1).ToString();
                        remit_pos.Text = (string)dr10.GetValue(2).ToString();
                        remit_transfer.Text = (string)dr10.GetValue(3).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn10.Close(); cn10.Dispose();
                        cmd10.Dispose();
                        dr10.Close(); dr10.Dispose();
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
                //  to_money.Text = (Convert.ToDecimal(end.Text) + Convert.ToDecimal(distributor.Text) + Convert.ToDecimal(home.Text) + Convert.ToDecimal(industrial.Text)).ToString();
                end_kg.Text = end_kg.Text + "kg"; distributor_kg.Text = distributor_kg.Text + "kg"; home_kg.Text = home_kg.Text + "kg"; industrial_kg.Text = industrial_kg.Text + "kg"; to_kg.Text = to_kg.Text + "kg";
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            //////////////////////////////////////////////////////////////////////////////////

            gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE employee='"+ employee.Text +"' ORDER BY Receipt_No", receipt_no, "Receipt_No");
            receipt_no.SelectedIndex = -1;
            //  if (employee.SelectedIndex > -1)
          //  {
                year1.SelectedIndex = 0;
                month1.SelectedIndex = 0;
                day1.SelectedIndex = 0;

                    try
                    {
                        month1.SelectedIndex = 0;
                        day1.SelectedIndex = 0;
                       
                        // ######################################### SUM GAS SALES ONLY  ############################################
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Product_Name LIKE 'Gas%'";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            sales_gas.Text = (string)dr1.GetValue(0).ToString();
                        }
                        dr1.Close();
                       // cn.Close();

                        // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
                        MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn2.Open();
                        string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Product_Name NOT LIKE 'Gas%'";
                        MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                        MySqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                        }
                        dr2.Close();
                       // cn2.Close();



                        string query = "SELECT (select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND (Item_Value-Amount_Paid)>0) as 'Credit',(select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND Category like 'en%') as 'End User Sale',(select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND Category like 'dist%') as 'Distributor',(select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND Category like 'ind%') as 'Industrial',(select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND Category like 'hom%') as 'Home',(select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND Payment_Method like 'cas%') as 'Cash',(select SUM(Item_Value) from table_sales_lump where Employee='"+ employee.Text +"' AND Payment_Method like 'PO%') as 'POS',sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall' FROM `table_sales_lump` WHERE Employee='"+ employee.Text +"'";
                        MySqlDataReader dr = gclass.display_in_box(query);
                        if (dr.Read())
                        {
                           // credit.Text = (string)dr.GetValue(0).ToString();
                           // end.Text = (string)dr.GetValue(1).ToString();
                           // distributor.Text = (string)dr.GetValue(2).ToString();
                           // industrial.Text = (string)dr.GetValue(3).ToString();
                          //  home.Text = (string)dr.GetValue(4).ToString();
                          //  cash.Text = (string)dr.GetValue(5).ToString();
                          //  pos.Text = (string)dr.GetValue(6).ToString();
                            discount.Text = (string)dr.GetValue(7).ToString();
                            gross_profit.Text = (string)dr.GetValue(8).ToString();
                            to_money.Text = (string)dr.GetValue(9).ToString();
                        }



                        //  ############################################### START OF FRESH COMP #######################################
                        try
                        {
                            MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn10.Open();
                            string query10 = "select SUM(balance) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Payment_Method like 'cred%'";
                            MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                            MySqlDataReader dr10 = cmd10.ExecuteReader();
                            if(dr10.Read())
                                try
                                {
                                    credit.Text = (string)dr10.GetValue(0).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    cn10.Close(); cn10.Dispose();
                                    cmd10.Dispose();
                                    dr10.Close(); dr10.Dispose();
                                }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        ////////////
                        try
                        {
                            MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn10.Open();
                            string query10 = "select SUM(transport) from table_sales_lump where Employee='" + employee.Text + "'";
                            MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                            MySqlDataReader dr10 = cmd10.ExecuteReader();
                            if (dr10.Read())
                                try
                                {
                                    transport.Text = (string)dr10.GetValue(0).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    cn10.Close(); cn10.Dispose();
                                    cmd10.Dispose();
                                    dr10.Close(); dr10.Dispose();
                                }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        ///////////////////////////

                        ////////////
                        try
                        {
                            MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn10.Open();
                            string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'en%'";
                            MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                            MySqlDataReader dr10 = cmd10.ExecuteReader();
                            if (dr10.Read())
                                try
                                {
                                    end.Text = (string)dr10.GetValue(0).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    cn10.Close(); cn10.Dispose();
                                    cmd10.Dispose();
                                    dr10.Close(); dr10.Dispose();
                                }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        ///////////////////////////
                        try
                        {
                            MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn10.Open();
                            string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'dist%'";
                            MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                            MySqlDataReader dr10 = cmd10.ExecuteReader();
                            if (dr10.Read())
                                try
                                {
                                    distributor.Text = (string)dr10.GetValue(0).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    cn10.Close(); cn10.Dispose();
                                    cmd10.Dispose();
                                    dr10.Close(); dr10.Dispose();
                                }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        ////////////////////

                        try
                        {
                            MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn10.Open();
                            string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'ind%'";
                            MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                            MySqlDataReader dr10 = cmd10.ExecuteReader();
                            if (dr10.Read())
                                try
                                {
                                    industrial.Text = (string)dr10.GetValue(0).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    cn10.Close(); cn10.Dispose();
                                    cmd10.Dispose();
                                    dr10.Close(); dr10.Dispose();
                                }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }



                        ////////////////////

                        try
                        {
                            MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn10.Open();
                            string query10 = "select SUM(Item_Value) from table_sales_lump where Employee='" + employee.Text + "' and branch='"+ branch.Text +"'AND Category like 'hom%'";
                            MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                            MySqlDataReader dr10 = cmd10.ExecuteReader();
                            if (dr10.Read())
                                try
                                {
                                    home.Text = (string)dr10.GetValue(0).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    cn10.Close(); cn10.Dispose();
                                    cmd10.Dispose();
                                    dr10.Close(); dr10.Dispose();
                                }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                ////////////////////
                try
                {
                    MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn10.Open();
                    // string query10 = "select SUM(Item_Value) from table_sales_lump where Payment_Method like 'cas%' AND year='" + year.Text + "' and branch='"+ branch.Text +"'";
                    string query10 = "select sum(cash),sum(pos),sum(transfer),sum(Discount) as 'Discount',SUM(Item_Value-Cost) AS 'GP',Sum(Item_Value) AS 'overall',sum(item_value),sum(cost) from table_sales_lump where Employee='" + employee.Text + "' and branch='" + branch.Text + "'";

                    MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                    MySqlDataReader dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                        try
                        {
                            cash.Text = (string)dr10.GetValue(0).ToString();
                            pos.Text = (string)dr10.GetValue(1).ToString();
                            transfer.Text = (string)dr10.GetValue(2).ToString();
                            discount.Text = (string)dr10.GetValue(3).ToString();
                            gross_profit.Text = (string)dr10.GetValue(4).ToString();
                            to_money.Text = (string)dr10.GetValue(5).ToString();
                            ts.Text = (string)dr10.GetValue(6).ToString();
                            tc.Text = (string)dr10.GetValue(7).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            cn10.Close(); cn10.Dispose();
                            cmd10.Dispose();
                            dr10.Close(); dr10.Dispose();
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //  ############################################### END OF FRESH COMP #######################################










                /* MySqlDataReader dr1 = gclass.display_in_box("SELECT SUM(Amount) FROM Table_Expenditure WHERE year='" + year1.Text + "'");
                 if (dr1.Read())
                 {
                     expenses.Text = (string)dr1.GetValue(0).ToString();
                 }
                 else
                 {
                     expenses.Text = "0.00";
                 }
                 gclass.panel_format_money(panel1);*/
                net_profit.Text = (Convert.ToDecimal(gross_profit.Text) - Convert.ToDecimal(expenses.Text)).ToString();
                        gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE Employee='" + employee.Text + "' and branch='" + branch.Text + "'order by p_id DESC", dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        sales_gas.Text = (Convert.ToDecimal(sales_gas.Text) + Convert.ToDecimal(transport.Text)).ToString();
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }
                    gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE Employee='" + employee.Text + "' and branch='" + branch.Text + "'order by p_id DESC", dataGridView1);
                    abs(dataGridView1);
        }

        private void Report_comp_Load(object sender, EventArgs e)
        {
            year1.SelectedIndex = 0; year.SelectedIndex = 0;
            month1.SelectedIndex = 0; month.SelectedIndex = 0;
            day1.SelectedIndex = 0; day.SelectedIndex = 0;
            gclass.display_in_combobox("SELECT DISTINCT Employee from table_Sales_lump ORDER BY Employee", employee, "Employee");
            employee.SelectedIndex = -1;
            gclass.Expand_Database("UPDATE table_sales_lump set amount_paid=cash+pos+transfer");
            gclass.Expand_Database("UPDATE Table_Sales_Lump set balance=item_value-amount_paid");
            gclass.Expand_Database("update table_sales_confirmed set short_code=concat(day,month,year)");
            gclass.Expand_Database("update table_sales_lump set short_code=concat(day,month,year)");

            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);update table_expenditure set dat=concat(year,'-',month,'-',day);");

        }

        private void net_profit_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "true")
            {
                try
                {
                    Repayment_Break fm = new Repayment_Break();
                    // gclass.display_in_dgv("SELECT Code AS 'Sales ID',Category,Product_Name AS 'Name of Product',Quantity,Item_Value AS 'Total',Date FROM Table_Sales_Confirmed WHERE Code LIKE '%" + dataGridView1.SelectedRows[0].Cells[0].Value + "%' ORDER BY p_id DESC", fm.dataGridView1);
                    gclass.display_in_dgv("SELECT Code AS 'Sales ID',Category,Product_Name AS 'Name of Product',Quantity,Item_Value AS 'Total',Date FROM Table_Sales_Confirmed WHERE Receipt_No='" + dataGridView1.SelectedRows[0].Cells[9].Value + "' AND Short_Code='" + dataGridView1.SelectedRows[0].Cells[10].Value + "' and branch='" + branch.Text + "' ORDER BY p_id DESC", fm.dataGridView1);
                    fm.textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    fm.payment_method.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    fm.receipt_number.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    fm.short_code.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

                    fm.login_name.Text = login_name.Text;
                    fm.branch.Text = branch.Text;
                    if (owner.Text.Contains("HEPHZ") || owner.Text.Contains("Hephz") || owner.Text.Contains("hephz"))
                    {
                        /* if (status.Text.Contains("Admi") || status.Text.Contains("Supe"))
                         {
                             fm.button_print.Visible = true
                         }*/
                        if (!status.Text.Contains("Supe"))
                        {
                            fm.button_print.Visible = false;
                        }

                    }
                    fm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void receipt_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "true";
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE Receipt_No='" + receipt_no.Text + "' order by p_id DESC", dataGridView1);         
        }

        private void receipt_no_TextChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code FROM Table_Sales_lump WHERE Receipt_No='" + receipt_no.Text + "' order by p_id DESC", dataGridView1);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Double Click on the Record You Want to Delete ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            button_delete.Visible = false;
            button_print.Visible = false;
            button1.Visible = false;
            label15.Visible = false;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                try
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                }
                catch
                {

                }
            }      


            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {   
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
                printDocument2.Print();
            }

            

            /*PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                button_delete.Visible = false;
                button_print.Visible = false;
                button1.Visible = false;
                label15.Visible = false;
                receipt_no.Visible = false;
                printDocument2.Print();
           
            }

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                button_delete.Visible = false;
                button_print.Visible = false;
                button1.Visible = false;
                label15.Visible = false;
                receipt_no.Visible = false;
                printDocument1.Print();
            }*/

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                try
                {
                    dataGridView1.Columns[i].Visible = true;
                    dataGridView1.Columns[4].Visible = true;
                }
                catch
                {

                }
            }

            button_delete.Visible = true;
            button_print.Visible = true;
           // button1.Visible = true;
            label15.Visible = true;
            receipt_no.Visible = true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Customer Summary", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           /* Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = true;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
        }

        private void pos_TextChanged(object sender, EventArgs e)
        {

        }

        private void transport_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(transport.Text))
            {
                transport.Text = "0.00";
            }
        }

        private void sales_gas_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sales_gas.Text))
            {
                sales_gas.Text = "0.00";
            }
        }

        private void home_kg_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(home_kg.Text))
            {
                home_kg.Text = "0.00";
            }
        }

        private void end_kg_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(end_kg.Text))
            {
                end_kg.Text = "0.00";
            }
        }

        private void industrial_kg_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(industrial_kg.Text))
            {
                industrial_kg.Text = "0.00";
            }
        }

        private void distributor_kg_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(distributor_kg.Text))
            {
                distributor_kg.Text = "0.00";
            }
        }

        private void expenses_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(expenses.Text))
            {
                expenses.Text = "0.00";
            }
        }

        private void cash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cash.Text))
            {
                cash.Text = "0.00";
            }
        }

        private void sales_gas_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sales_gas.Text))
            {
                sales_gas.Text = "0.00";
            }
        }

        private void sales_accessory_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sales_accessory.Text))
            {
                sales_accessory.Text = "0.00";
            }
        }

        private void transport_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(transport.Text))
            {
                transport.Text = "0.00";
            }
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(discount.Text))
            {
                discount.Text = "0.00";
            }
        }

        private void gross_profit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gross_profit.Text))
            {
                gross_profit.Text = "0.00";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refactor fm = new Refactor();
            fm.Show();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel7.Width, panel7.Height);
            panel7.DrawToBitmap(bmp, new Rectangle(0, 0, panel7.Width, panel7.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      //  }
         
        }

        private void year_pos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "true";
            gclass.panel_format_money(panel7);
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code,Employee as 'Sales Person' FROM Table_Sales_lump WHERE year='" + year_pos.Text + "' AND Payment_Method='" + comboBox1.Text + "' and branch='" + branch.Text + "'  order by p_id DESC", dataGridView1);
        }

        private void month_pos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "true";
            gclass.panel_format_money(panel7);
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code,Employee as 'Sales Person' FROM Table_Sales_lump WHERE year='" + year_pos.Text + "' and month='" + month_pos.Text + "' AND Payment_Method='" + comboBox1.Text + "' and branch='" + branch.Text + "'  order by p_id DESC", dataGridView1);
        }

        private void day_pos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            gclass.panel_format_money(panel7);
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Sales_Method AS 'Sales Method',Discount,Item_Value AS 'Item Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS Balance,Receipt_No,Short_Code,Employee as 'Sales Person' FROM Table_Sales_lump WHERE year='" + year_pos.Text + "' and month='" + month_pos.Text + "' and day='" + day_pos.Text + "' AND Payment_Method='" + comboBox1.Text + "' and branch='" + branch.Text + "'  order by p_id DESC", dataGridView1);
        }

        private void comboBox4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "true";
            gclass.panel_format_money(panel7);
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Date,customer_name as 'Name of Customer',Receipt_No AS 'Receipt No',Amount_Paid as 'Amount Paid' From Table_repayment WHERE year='"+repayment_year.Text+"' ORDER BY p_id DESC", dataGridView1);
        }

        private void repayment_month_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "true";
            gclass.panel_format_money(panel7);
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Date,customer_name as 'Name of Customer',Receipt_No AS 'Receipt No',Amount_Paid as 'Amount Paid' From Table_repayment WHERE year='" + repayment_year.Text + "' and Month='" + repayment_month.Text + "' and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
      
        }

        private void repayment_day_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "true";
            gclass.panel_format_money(panel7);
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Date,customer_name as 'Name of Customer',Receipt_No AS 'Receipt No',Amount_Paid as 'Amount Paid' From Table_repayment WHERE year='" + repayment_year.Text + "' and Month='" + repayment_month.Text + "' and day='" + repayment_day.Text + "' and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
      
        }

        private void accessory_year_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "false";
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Product_Name 'Name of Product',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Discount,Item_Value AS 'Item Value',Item_Value AS 'Amount Paid',(Item_Value-Item_Value) AS Balance,Receipt_No,Short_Code FROM Table_Sales_Confirmed WHERE year='" + accessory_year.Text + "' AND Product_Name not like 'Gas%' and branch='" + branch.Text + "' order by p_id DESC", dataGridView1);
            abs(dataGridView1); 
        }

        private void accessory_month_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "false";
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Product_Name 'Name of Product',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Discount,Item_Value AS 'Item Value',Item_Value AS 'Amount Paid',(Item_Value-Item_Value) AS Balance,Receipt_No,Short_Code FROM Table_Sales_Confirmed WHERE year='" + accessory_year.Text + "' AND Month='" + accessory_month.Text + "' AND Product_Name not like 'Gas%' and branch='" + branch.Text + "'  order by p_id DESC", dataGridView1);
            abs(dataGridView1); 
        }

        private void accessory_day_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = "false";
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Product_Name 'Name of Product',Customer_Name AS 'Name of Customer',Category,Payment_Method AS 'Method of Payment',Discount,Item_Value AS 'Item Value',Item_Value AS 'Amount Paid',(Item_Value-Item_Value) AS Balance,Receipt_No,Short_Code FROM Table_Sales_Confirmed WHERE year='" + accessory_year.Text + "' AND Month='" + accessory_month.Text + "' AND Day='" + accessory_day.Text + "' AND Product_Name not like 'Gas%' and branch='" + branch.Text + "'  order by p_id DESC", dataGridView1);
            abs(dataGridView1); 
        }

        private void branch_TextChanged(object sender, System.EventArgs e)
        {
            if (branch.Text == "0.00")
            {
                branch.Text = null;
            }
        }

        private void owner_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void transfer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(transfer.Text))
            {
                transfer.Text = "0.00";
            }
        }

        private void amount_to_bank_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cash_to_bank.Text))
            {
                cash_to_bank.Text = "0.00";
            }
        }

        private void cash_at_hand_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cash_at_hand.Text))
            {
                cash_at_hand.Text = "0.00";
            }
        }

        private void change_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(change.Text))
            {
                change.Text = "0.00";
            }
        }

        private void remit_cash_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(remit_cash.Text))
            {
                remit_cash.Text = "0.00";
            }
        }

        private void remit_pos_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(remit_pos.Text))
            {
                remit_pos.Text = "0.00";
            }
        }

        private void remit_transfer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(remit_transfer.Text))
            {
                remit_transfer.Text = "0.00";
            }
        }

        private void repayment_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(repayment.Text))
            {
                repayment.Text = "0.00";
            }
        }

        private void home_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(home.Text))
            {
                home.Text = "0.00";
            }
        }

        private void end_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(end.Text))
            {
                end.Text = "0.00";
            }
        }

        private void industrial_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(industrial.Text))
            {
                industrial.Text = "0.00";
            }
        }

        private void distributor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(distributor.Text))
            {
                distributor.Text = "0.00";
            }
        }

        private void credit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(credit.Text))
            {
                credit.Text = "0.00";
            }
        }

        private void pos_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pos.Text))
            {
                pos.Text = "0.00";
            }
        }

        private void to_money_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(to_money.Text))
            {
                to_money.Text = "0.00";
            }
        }
    }

}
