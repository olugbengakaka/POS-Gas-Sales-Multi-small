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
using System.Drawing.Printing;

namespace POS_Eatery
{
    public partial class Report_Summary : Form
    {
        public Report_Summary()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Report_Summary_Load(object sender, EventArgs e)
        {
            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_expenditure set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);");
            gclass.display_in_combobox("SELECT DISTINCT Employee from table_Sales_lump ORDER BY Employee", employee, "Employee");
            employee.SelectedIndex = -1;

            gclass.Expand_Database("UPDATE table_sales_lump set amount_paid=cash+pos+transfer");

            MySqlDataReader dr4 = gclass.display_in_box("SELECT* FROM Table_Customize where Branch='" + branch1.Text + "'");
            while (dr4.Read())
            {
                owner.Text = (string)dr4.GetValue(1).ToString();
                branch.Text = (string)dr4.GetValue(7).ToString();
               // company_address.Text = (string)dr4.GetValue(3).ToString();
               // address.Text = (string)dr4.GetValue(4).ToString();
               // company_telephone.Text = (string)dr4.GetValue(5).ToString();
            }
            dr4.Close();

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button_print_Click(object sender, EventArgs e)
        {
            
            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);");
            gclass.panel_format(panel1);

            title.Text = "Sale's Transaction Report From " + dateTimePicker1.Value.Date + " to " + dateTimePicker2.Value.Date;

            string a = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            string b = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;

            //////////////////////////////////////////////////////////////////////////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Quantity) from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and Product_Name like 'Gas%' AND CODE like '%End User%'";
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
                string query10 = "select SUM(Quantity) from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
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
                string query10 = "select SUM(Quantity) from table_sales_confirmed where  dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
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
                string query10 = "select SUM(Quantity) from table_sales_confirmed where  dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
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
                string query10 = "select SUM(Cash),Sum(pos),sum(transfer) from table_Repayment where  dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        remit_cash.Text = (string)dr10.GetValue(0).ToString();
                        remit_pos.Text = (string)dr10.GetValue(1).ToString();
                        remit_transfer.Text = (string)dr10.GetValue(2).ToString();
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

          
            //////////////////////////////////////////////////////////////////////////////////

            // gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE  year='" + year.Text + "' and branch='" + branch1.Text + "' ORDER BY Receipt_No", receipt_no, "Receipt_No");
            // receipt_no.SelectedIndex = -1;

            try
            {
                // ######################################### SUM GAS SALES ONLY  ############################################
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND Product_Name LIKE 'Gas%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    sales_gas.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // cn.Close();

            // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
            try
            {
                MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn2.Open();
                string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND Product_Name NOT LIKE 'Gas%'";
                MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                }
                dr2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // cn2.Close();
            //  ############################################### START OF FRESH COMP #######################################
              try
              {
                  MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                  cn10.Open();
                  string query10 = "select SUM(item_value) from table_sales_lump where Payment_Method like 'cred%' and  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "'";
                  MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                  MySqlDataReader dr10 = cmd10.ExecuteReader();
                  if (dr10.Read())
                      try
                      {
                          credit.Text = (string)dr10.GetValue(0).ToString();
                       // credit_so_far.Text = (string)dr10.GetValue(1).ToString();
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
                string query10 = "select sum(item_value-amount_paid) from table_sales_lump where Payment_Method like 'cred%' and branch='" + branch1.Text + "'";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        credit_so_far.Text = (string)dr10.GetValue(0).ToString();
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
                  string query10 = "select SUM(transport) from table_sales_lump where   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "'";
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
                  string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'en%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "'";
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

            ////////////////////

            ////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'dist%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "'";
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

            ////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'ind%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "'";
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

            ////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'hom%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "'";
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
                string query10 = "select sum(cash-changes),sum(pos),sum(transfer),sum(Discount),SUM(Item_Value-Cost),Sum(Item_Value),sum(item_value),sum(cost) from table_sales_lump where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1 .Text + "' and payment_method not like 'cred%'";

                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        cash.Text = (string)dr10.GetValue(0).ToString();
                        pos.Text = (string)dr10.GetValue(1).ToString();
                        transfer.Text = (string)dr10.GetValue(2).ToString();
                        discount.Text = (string)dr10.GetValue(3).ToString();
                       // gross_profit.Text = (string)dr10.GetValue(4).ToString();
                        total_sales.Text = (string)dr10.GetValue(5).ToString();
                       // ts.Text = (string)dr10.GetValue(6).ToString();
                       // tc.Text = (string)dr10.GetValue(7).ToString();
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


            // ######################################### CASH TO BANK  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND Code LIKE 'Cash to Bank%'";
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
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND Code Not LIKE 'Cash to Bank%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    expenditure.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // ######################################### DEBT PAID BY POS  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount_Paid) FROM Table_repayment WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND code LIKE '%POS%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    remit_pos.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ######################################### DEBT PAID BY TRANSFER  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount_Paid) FROM Table_repayment WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND code LIKE '%Transfer%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    remit_transfer.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            gclass.panel_format_money(panel1);

            textBox4.Text = (Convert.ToDecimal(total_sales.Text)).ToString();        // + Convert.ToDecimal(transport.Text)).ToString();
            textBox2.Text = (Convert.ToDecimal(total_sales.Text)).ToString();       //- Convert.ToDecimal(discount.Text)).ToString();
            textBox5.Text = (Convert.ToDecimal(cash.Text) + Convert.ToDecimal(remit_cash.Text)).ToString();
            textBox8.Text = (Convert.ToDecimal(textBox5.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenditure.Text))).ToString();
            textBox11.Text = (Convert.ToDecimal(pos.Text) + Convert.ToDecimal(transfer.Text) + Convert.ToDecimal(remit_pos.Text) + Convert.ToDecimal(remit_transfer.Text)).ToString();
            textBox14.Text = (Convert.ToDecimal(credit.Text) - Convert.ToDecimal(credit_so_far.Text)).ToString();

           // to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
            //////////////

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

            // MessageBox.Show(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Report Sheet for fransaction from " + dateTimePicker1.Value + " to " + dateTimePicker2.Value;
                printDocument1.Print();
               // printDocument2.Print();
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
                e.HasMorePages = false;
            }
        }

        private void employee_SelectedIndexChanged(object sender, EventArgs e)
        {

            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);");
            gclass.panel_format(panel1);

            title.Text = "Sale's Transaction Report From " + dateTimePicker1.Value.Date + " to " + dateTimePicker2.Value.Date + " by " + employee.Text;

            string a = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            string b = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;

            //////////////////////////////////////////////////////////////////////////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Quantity) from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and employee='"+ employee.Text +"' and Product_Name like 'Gas%' AND CODE like '%End User%'";
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
                string query10 = "select SUM(Quantity) from table_sales_confirmed where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and employee='" + employee.Text + "'  and Product_Name like 'Gas%' AND CODE like '%Home Delivery%'";
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
                string query10 = "select SUM(Quantity) from table_sales_confirmed where  dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and employee='" + employee.Text + "'  and Product_Name like 'Gas%' AND CODE like '%Distributor%'";
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
                string query10 = "select SUM(Quantity) from table_sales_confirmed where  dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and employee='" + employee.Text + "'  and Product_Name like 'Gas%' AND CODE like '%Industrial%'";
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
                string query10 = "select SUM(cash),sum(pos),sum(transfer) from table_Repayment where  dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and registered_by='" + employee.Text + "' ";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        remit_cash.Text = (string)dr10.GetValue(0).ToString();
                        remit_pos.Text = (string)dr10.GetValue(1).ToString();
                        remit_transfer.Text = (string)dr10.GetValue(2).ToString();
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


            //////////////////////////////////////////////////////////////////////////////////

            // gclass.display_in_combobox("SELECT RECEIPT_NO FROM Table_Sales_lump WHERE  year='" + year.Text + "' and branch='" + branch1.Text + "' ORDER BY Receipt_No", receipt_no, "Receipt_No");
            // receipt_no.SelectedIndex = -1;

            try
            {
                // ######################################### SUM GAS SALES ONLY  ############################################
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "'  AND Product_Name LIKE 'Gas%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    sales_gas.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // cn.Close();

            // ######################################### SUM ACCESSORIES SALES ONLY  ############################################
            try
            {
                MySqlConnection cn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn2.Open();
                string query2 = "SELECT SUM(Item_Value) FROM Table_Sales_confirmed WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "'  AND Product_Name NOT LIKE 'Gas%'";
                MySqlCommand cmd2 = new MySqlCommand(query2, cn2);
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    sales_accessory.Text = (string)dr2.GetValue(0).ToString();
                }
                dr2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // cn2.Close();
            //  ############################################### START OF FRESH COMP #######################################
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(item_value) from table_sales_lump where Payment_Method like 'cred%' and  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        credit.Text = (string)dr10.GetValue(0).ToString();
                       // credit_so_far.Text = (string)dr10.GetValue(1).ToString();
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
                string query10 = "select sum(item_value-amount_paid) from table_sales_lump where Payment_Method like 'cred%' and branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        credit_so_far.Text = (string)dr10.GetValue(0).ToString();
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
                string query10 = "select SUM(transport) from table_sales_lump where   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
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
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'en%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
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

            ////////////////////

            ////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'dist%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
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

            ////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'ind%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
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

            ////////////
            try
            {
                MySqlConnection cn10 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn10.Open();
                string query10 = "select SUM(Item_Value) from table_sales_lump where Category like 'hom%' AND   dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and employee='" + employee.Text + "' ";
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
                string query10 = "select sum(cash-changes),sum(pos),sum(transfer),sum(Discount),SUM(Item_Value-Cost),Sum(Item_Value),sum(item_value),sum(cost) from table_sales_lump where dat>='" + a + "' and dat<='" + b + "' and branch='" + branch1.Text + "' and employee='" + employee.Text + "' and payment_method not like 'cred%' ";

                MySqlCommand cmd10 = new MySqlCommand(query10, cn10);
                MySqlDataReader dr10 = cmd10.ExecuteReader();
                if (dr10.Read())
                    try
                    {
                        cash.Text = (string)dr10.GetValue(0).ToString();
                        pos.Text = (string)dr10.GetValue(1).ToString();
                        transfer.Text = (string)dr10.GetValue(2).ToString();
                        discount.Text = (string)dr10.GetValue(3).ToString();
                        // gross_profit.Text = (string)dr10.GetValue(4).ToString();
                        total_sales.Text = (string)dr10.GetValue(5).ToString();
                        // ts.Text = (string)dr10.GetValue(6).ToString();
                        // tc.Text = (string)dr10.GetValue(7).ToString();
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


            // ######################################### CASH TO BANK  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND Code LIKE 'Cash to Bank%' AND CODE LIKE '%" + employee.Text + "%'";
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
                string query1 = "SELECT SUM(Amount) FROM Table_Expenditure WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' AND Code Not LIKE 'Cash to Bank%' AND CODE LIKE '%" + employee.Text + "%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    expenditure.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // ######################################### DEBT PAID BY POS  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount_Paid) FROM Table_repayment WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and registered_by='" + employee.Text + "'  AND code LIKE '%POS%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    remit_pos.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ######################################### DEBT PAID BY TRANSFER  ############################################
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string query1 = "SELECT SUM(Amount_Paid) FROM Table_repayment WHERE  dat>='" + a + "' and dat<='" + b + "' and  branch='" + branch1.Text + "' and registered_by='" + employee.Text + "'  AND code LIKE '%Transfer%'";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                MySqlDataReader dr6 = cmd1.ExecuteReader();
                if (dr6.Read())
                {
                    remit_transfer.Text = (string)dr6.GetValue(0).ToString();
                }
                dr6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            gclass.panel_format_money(panel1);

            textBox4.Text = (Convert.ToDecimal(total_sales.Text)).ToString();        // + Convert.ToDecimal(transport.Text)).ToString();
            textBox2.Text = (Convert.ToDecimal(total_sales.Text)).ToString();       //- Convert.ToDecimal(discount.Text)).ToString();
            textBox5.Text = (Convert.ToDecimal(cash.Text) + Convert.ToDecimal(remit_cash.Text)).ToString();
            textBox8.Text = (Convert.ToDecimal(textBox5.Text) - (Convert.ToDecimal(cash_to_bank.Text) + Convert.ToDecimal(expenditure.Text))).ToString();
            textBox11.Text = (Convert.ToDecimal(pos.Text) + Convert.ToDecimal(transfer.Text) + Convert.ToDecimal(remit_pos.Text) + Convert.ToDecimal(remit_transfer.Text)).ToString();
            textBox14.Text = (Convert.ToDecimal(credit.Text) + Convert.ToDecimal(credit_so_far.Text)).ToString();

            // to_kg.Text = (Convert.ToDecimal(end_kg.Text) + Convert.ToDecimal(home_kg.Text) + Convert.ToDecimal(distributor_kg.Text) + Convert.ToDecimal(industrial_kg.Text)).ToString();
            //////////////

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

        }
    }
}
