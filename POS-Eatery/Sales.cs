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
using System.Net;

namespace POS_Eatery
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        Random rnd = new Random();
        private void productname1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (productname1.Text.Length >= 14)
                {
                    try
                    {
                        receipt_description.Text = textBox6.Text.Substring(0, 8) + "-" + textBox6.Text.Substring(textBox6.Text.Length - 5);

                    }
                    catch
                    { 
                    
                    }
                }
                else
                {
                    receipt_description.Text = textBox6.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (productname1.Text.Length >= 14)
            {
                try
                {
                    receipt_description.Text = productname1.Text.Substring(0, 8) + "-" + productname1.Text.Substring(productname1.Text.Length - 5);
                }

                catch
                {

                }
            }
            else
            {
                receipt_description.Text = productname1.Text;
            }

           

           /* if (productname1.Text == productname_det.Text)
            {
                quantity.Text = (Convert.ToDecimal(quantity.Text) + Convert.ToDecimal(1)).ToString();
            }
            else if (productname1.Text != productname_det.Text)
            {*/
                if (productname1.Text.Length >= 14)
                {
                    try
                    {
                        receipt_description.Text = productname1.Text.Substring(0, 8) + "-" + productname1.Text.Substring(productname1.Text.Length - 5);
                    }

                    catch
                    {

                    }  
                }
                else
                {
                    receipt_description.Text = productname1.Text;
                }


                    if (productname1.Text.Length >= 14)
                    {
                        try
                        {
                            receipt_description.Text = productname1.Text.Substring(0, 8) + "-" + productname1.Text.Substring(productname1.Text.Length - 5);
                        }

                        catch
                        {

                        } 
                    }
                    else
                    {
                        receipt_description.Text = productname1.Text;
                    }
                    textBox7.Text = "0";
                    quantity.Text = "0";
                    try
                    {
                        if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
                        {
                            string query1 = "SELECT* FROM Table_Stock_Inventory_Summary WHERE Product_Name='Gas' AND Category='Product' ORDER BY p_id DESC LIMIT 1";
                            MySqlDataReader dr2 = gclass.display_in_box(query1);
                            if (dr2.Read())
                            {
                                no_of_product.Text = (string)dr2.GetValue(5).ToString();
                              //  no_of_product.Text = Math.Round((Convert.ToDecimal(ab) / Convert.ToDecimal(1.752)), 2).ToString();
                            }


                            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn.Open();
                            string query = "SELECT* FROM Table_Stock_Inventory_Summary WHERE Product_Name='"+ productname1.Text +"' AND Category='Product' ORDER BY p_id DESC LIMIT 1";
                            MySqlCommand cmd = new MySqlCommand(query, cn);
                            MySqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                productname_det.Text = (string)dr.GetValue(1).ToString();
                                // category.Text = (string)dr.GetValue(5).ToString();
                                textBox7.Text = (string)dr.GetValue(12).ToString();
                                //  no_of_product.Text = (string)dr.GetValue(5).ToString();
                                quantity.Text = (Convert.ToDecimal(quantity.Text) + Convert.ToDecimal(1)).ToString();
                            }
                        }
                        else //if (!(productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS")))
                        {
                            string query1 = "SELECT* FROM Table_Stock_Inventory_Summary WHERE Product_Name='"+ productname1.Text +"' AND Category='Product' ORDER BY p_id DESC LIMIT 1";
                            MySqlDataReader dr2 = gclass.display_in_box(query1);
                            if (dr2.Read())
                            {
                                no_of_product.Text = (string)dr2.GetValue(5).ToString();
                                //  no_of_product.Text = Math.Round((Convert.ToDecimal(ab) / Convert.ToDecimal(1.752)), 2).ToString();
                            }


                            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                            cn.Open();
                            string query = "SELECT* FROM Table_Stock_Inventory_Summary WHERE Product_Name='" + productname1.Text + "' AND Category='Product' ORDER BY p_id DESC LIMIT 1";
                            MySqlCommand cmd = new MySqlCommand(query, cn);
                            MySqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                productname_det.Text = (string)dr.GetValue(1).ToString();
                                // category.Text = (string)dr.GetValue(5).ToString();
                                textBox7.Text = (string)dr.GetValue(12).ToString();
                                total.Text = (string)dr.GetValue(12).ToString();
                                quantity.Text = (Convert.ToDecimal(quantity.Text) + Convert.ToDecimal(1)).ToString();
                            }
                        }
                     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
          //  }




      //  }

        private void Sales_Load(object sender, EventArgs e)
        {
           
            quantity.SelectedIndex = 0;
            quantity.Text = "0";
            txt_amount_paid.Text = "0";

           
            try
            {
                MySqlConnection cn11 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn11.Open();
                string str11 = "SELECT* FROM table_buyers ORDER BY Full_Name ASC";
                MySqlCommand cmd11 = new MySqlCommand(str11, cn11);
                MySqlDataReader dr11 = cmd11.ExecuteReader();
                // MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr11.Read())
                {
                    acc.Add(dr11.GetString(1));
                }
                textBox3.AutoCompleteCustomSource = acc;
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
           // gclass.display_in_combobox("SELECT* FROM table_buyers", cst_name, "Full_Name");
           // cst_name.SelectedIndex = -1;


            gclass.Update1("UPDATE Table_Stock_Inventory_Summary SET Quantity_Left='0' WHERE Quantity_Left <0");
            /*gclass.Update1("Table_Stock_Inventory_Summary SET Quantity_In='0.00' WHERE Quantity_In <0");
            gclass.Update1("Table_Stock_Inventory_Summary SET Quantity_Out='0.00' WHERE Quantity_Left <0");*/

            label10.Text = DateTime.Now.ToString();//DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();


            //############################### FETCH THE NEXT INVOICE NUMBER TO THE RECEIPT ########################################

            MySqlConnection cn12 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn12.Open();
            String query12 = "SELECT COUNT(p_id) FROM Table_In";
            MySqlCommand cmd12 = new MySqlCommand(query12, cn12);
            MySqlDataReader dr12 = cmd12.ExecuteReader();
            try
            {
                
                while (dr12.Read())
                {
                    int a = Convert.ToInt32((string)dr12.GetValue(0).ToString());
                    invoice_number.Text = "0" + (a + 1).ToString();
                }
                //dr12.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd12.Dispose();
                cn12.Close();
                dr12.Close();
            }

            //############################### DISPLAY CUSTOMIZE RECEIPT DETAILS ########################################

            MySqlDataReader dr4 = gclass.display_in_box("SELECT* FROM Table_Customize");
            while (dr4.Read())
            {
                company_name.Text = (string)dr4.GetValue(1).ToString();
                company_specialty.Text = (string)dr4.GetValue(2).ToString();
                company_address.Text = (string)dr4.GetValue(3).ToString();
                company_email.Text = (string)dr4.GetValue(4).ToString();
                company_telephone.Text = (string)dr4.GetValue(5).ToString();
            }
            dr4.Close();

            // dataGridView1.Width = 260;

            MySqlConnection cn53 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn53.Open();
            string str13 = "SELECT DISTINCT(Product_Name) FROM Table_Stock_Inventory_Summary WHERE Category='Product' AND Product_Name NOT LIKE 'Discount' ORDER BY Product_Name ASC";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.Day.ToString() + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')";
            MySqlCommand cmd13 = new MySqlCommand(str13, cn53);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd13);
            try
            {
                DataTable dt13 = new DataTable();
                da.Fill(dt13);
                productname1.DataSource = dt13;
                productname1.DisplayMember = "Product_Name";
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                MySqlDataReader dr13 = cmd13.ExecuteReader();
                while (dr13.Read())
                {
                    acc.Add(dr13.GetString(0));
                }
                productname1.AutoCompleteCustomSource = acc;
                dr13.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn53.Close();
                cmd13.Dispose();
                // dr13.Close();
            }

            if (cashier_name.Text.Contains("Modup"))
            {
                cashier_name.Text = null;
                label22.Text = null;
            }
            productname1.SelectedIndex = -1;
            price.Text = "0";
            quantity.Text = "0";
            quantity.SelectedIndex = 0;
            textBox6.Text = null;
            receipt_description.Text = null;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            productname_det.Text = null;
            textBox1.Text = null;
          //  textBox7.ReadOnly = false;
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(quantity.Text))
            {
                quantity.Text = "0";
            }

            try
            {
                discount.Text = null;
                decimal a = Convert.ToDecimal(quantity.Text);
                decimal b = Convert.ToDecimal(quantity.Text);
                decimal c = Convert.ToDecimal(textBox7.Text);
                decimal res = c * b;
                total.Text = res.ToString();
                charges.Text = res.ToString();
                //stock_current.Text=()
                barcode_scan.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Convert.ToDecimal(quantity.Text) > Convert.ToDecimal(no_of_product.Text))
            {
                MessageBox.Show("Quantity of " + productname1.Text + " available is not up to " + quantity.Text + " Units ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Text = "0";
            }
        }

        private void button_ok_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToDecimal(discount1.Text) > 0)
            {
                decimal ab = (Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text));
                total.Text = ab.ToString();
            }

                if (Convert.ToDecimal(quantity.Text) > 0 && Convert.ToDecimal(total.Text) > 0)
                {
                    if (Convert.ToDecimal(discount1.Text) > 0)
                    {

                        if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
                        {
                            Random rnd = new Random();
                            int a = rnd.Next(1, 9999999);
                            string code = "Gas" + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + "/" + DateTime.Now.Millisecond + a;

                           gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + quantity.Text + "',Quantity_Left=Quantity_Left-'" + quantity.Text + "',price='"+ textBox7.Text +"' WHERE Day='" + DateTime.Now.Day + "' AND Month='" + DateTime.Now.Month + "' AND Year='" + DateTime.Now.Year + "' AND Product_Name='Gas' AND Category='Product' ORDER BY p_id DESC Limit 1");
                            
                            
                            gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code)VALUES('Gas','Product','" + quantity.Text + "','Sold Out','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + code.ToString() + "')");

                            decimal deca = (Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text));

                            gclass.insert1("INSERT INTO Table_Sales_Summary(Product_Name,Category,Quantity,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('Gas','Product','" + quantity.Text + "','" + total.Text + "','" + DateTime.Now + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + cashier_name.Text + "','" + code.ToString() + "','" + payment_method.Text + "','" + cst_name.Text + "','" + discount1.Text + "','" + invoice_number.Text + "')");
                            

                            dataGridView1.Rows.Add(quantity.Text + "kg", receipt_description.Text, textBox7.Text, total.Text);
                            dataGridView2.Rows.Add(quantity.Text, productname1.Text, textBox7.Text, total.Text, discount1.Text,code.ToString());
                            dataGridView1.Rows.Add(quantity.Text + "kg", "Discount", discount1.Text, "0.00");

                            // dataGridView2.Rows.Add(quantity.Text, "Discount", discount1.Text, "0");
                        }
                        else
                        {
                            Random rnd = new Random();
                            int a = rnd.Next(1, 9999999);
                            string code = productname1.Text + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + "/" + DateTime.Now.Millisecond + a;

                            gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code)VALUES('" + productname1.Text + "','Product','" + quantity.Text + "','Sold Out','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + code.ToString() + "')");
                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + quantity.Text + "',Quantity_Left=Quantity_Left-'" + quantity.Text + "',Price='"+ textBox7.Text +"' WHERE Day='" + DateTime.Now.Day + "' AND Month='" + DateTime.Now.Month + "' AND Year='" + DateTime.Now.Year + "' AND Product_Name='" + productname1.Text + "' AND Category='Product' ORDER BY p_id DESC Limit 1");
                           
                            decimal deca = Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text);

                            gclass.insert1("INSERT INTO Table_Sales_Summary(Product_Name,Category,Quantity,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('" + productname1.Text + "','Product','" + quantity.Text + "','" + total.Text + "','" + DateTime.Now + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + cashier_name.Text + "','" + code.ToString() + "','" + payment_method.Text + "','" + cst_name.Text + "','" + discount1.Text + "','" + invoice_number.Text + "')");
                            

                            dataGridView1.Rows.Add(quantity.Text, receipt_description.Text, textBox7.Text, total.Text);
                            dataGridView2.Rows.Add(quantity.Text, productname1.Text, textBox7.Text, total.Text, discount1.Text,code.ToString());
                            dataGridView1.Rows.Add(quantity.Text, "Discount", discount1.Text, "0");
                            // dataGridView2.Rows.Add(quantity.Text, "Discount", discount1.Text, "0");
                        }
                    }
                    else
                    {
                        if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
                        {
                            Random rnd = new Random();
                            int a = rnd.Next(1, 9999999);
                            string code = "Gas" + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + "/" + DateTime.Now.Millisecond + a;

                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + quantity.Text + "',Quantity_Left=Quantity_Left-'" + quantity.Text + "',price='" + textBox7.Text + "' WHERE  Day='" + DateTime.Now.Day + "' AND Month='" + DateTime.Now.Month + "' AND Year='" + DateTime.Now.Year + "' AND  Product_Name='Gas' AND Category='Product' ORDER BY p_id DESC Limit 1");
                            gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code)VALUES('Gas','Product','" + quantity.Text + "','Sold Out','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + code.ToString() + "')");

                            decimal deca = Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text);

                            gclass.insert1("INSERT INTO Table_Sales_Summary(Product_Name,Category,Quantity,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('Gas','Product','" + quantity.Text + "','" + total.Text + "','" + DateTime.Now + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + cashier_name.Text + "','" + code.ToString() + "','" + payment_method.Text + "','" + cst_name.Text + "','" + discount1.Text + "','" + invoice_number.Text + "')");
                            

                            dataGridView1.Rows.Add(quantity.Text+"kg", receipt_description.Text, textBox7.Text, total.Text);
                            dataGridView2.Rows.Add(quantity.Text, productname1.Text, textBox7.Text, total.Text, discount1.Text, code.ToString());
                        }
                        else
                        {
                            Random rnd = new Random();
                            int a = rnd.Next(1, 9999999);
                            string code = productname1.Text + DateTime.Now + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second + "/" + DateTime.Now.Millisecond + a;

                            gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + quantity.Text + "',Quantity_Left=Quantity_Left-'" + quantity.Text + "',price='" + textBox7.Text + "' WHERE Day='" + DateTime.Now.Day + "' AND Month='" + DateTime.Now.Month + "' AND Year='" + DateTime.Now.Year + "' AND Product_Name='" + productname1.Text + "' AND Category='Product' ORDER BY p_id DESC Limit 1");
                            gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code)VALUES('"+ productname1.Text +"','Product','" + quantity.Text + "','Sold Out','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + code.ToString() + "')");

                            decimal deca = Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text);

                            gclass.insert1("INSERT INTO Table_Sales_Summary(Product_Name,Category,Quantity,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('" + productname1.Text + "','Product','" + quantity.Text + "','" + total.Text + "','" + DateTime.Now + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + cashier_name.Text + "','" + code.ToString() + "','" + payment_method.Text + "','" + cst_name.Text + "','" + discount1.Text + "','" + invoice_number.Text + "')");
                            

                            dataGridView1.Rows.Add(quantity.Text, receipt_description.Text, textBox7.Text, total.Text);
                            dataGridView2.Rows.Add(quantity.Text, productname1.Text, textBox7.Text, total.Text, discount1.Text, code.ToString());
                        }
                    }
                    
                    double sum = 0;

                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {

                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        textBox1.Text = sum.ToString();

                    }
                    gclass.panel_format(panel_cash_sales);
                    productname_det.Text = null;
                }
                else
                {
                    MessageBox.Show("Select at Least one Item/ Product from the Item Box!", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               

        }

        private void total_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(total.Text))
            {
                total.Text = "0";
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // MessageBox.Show(dataGridView1.CurrentCell.RowIndex.ToString());
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                // dataGridView2.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Refresh();
                // dataGridView2.Refresh();
            }
            catch
            {

            }
            double sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {

                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                textBox1.Text = sum.ToString();

            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // MessageBox.Show(dataGridView1.CurrentCell.RowIndex.ToString());
                // dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                if (dataGridView2.SelectedRows[0].Cells[1].Value.ToString().Contains("Gas") || dataGridView2.SelectedRows[0].Cells[1].Value.ToString().Contains("gas") || dataGridView2.SelectedRows[0].Cells[1].Value.ToString().Contains("GAS"))
                {
                    gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out-'" + Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[0].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[0].Value) + "',Price='" + Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[2].Value) + "' WHERE Date='" + DateTime.Now.ToShortDateString() + "' AND Product_Name='Gas' AND Category='Product' ORDER BY p_id DESC Limit 1");
                    gclass.insert1("DELETE FROM Table_Stock_inventory WHERE CODE='"+ dataGridView2.SelectedRows[0].Cells[5].Value.ToString() +"'");
                    gclass.insert1("DELETE FROM Table_Sales_Summary WHERE CODE='" + dataGridView2.SelectedRows[0].Cells[5].Value.ToString() + "'");
                    

                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    // dataGridView1.Refresh();
                   // dataGridView2.Refresh();
                }
                else
                {
                    gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out-'" + Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[0].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[0].Value) + "',Price='" + Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[2].Value) + "' WHERE Date='" + DateTime.Now.ToShortDateString() + "' AND Product_Name='" + dataGridView2.SelectedRows[0].Cells[1].Value.ToString() + "' AND Category='Product' ORDER BY p_id DESC Limit 1");
                    gclass.insert1("DELETE FROM Table_Stock_inventory WHERE CODE='" + dataGridView2.SelectedRows[0].Cells[5].Value.ToString() + "'");
                    gclass.insert1("DELETE FROM Table_Sales_Summary WHERE CODE='" + dataGridView2.SelectedRows[0].Cells[5].Value.ToString() + "'");
                    
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    // dataGridView1.Refresh();
                    //dataGridView2.Refresh();
                }
               
            }
            catch
            {

            }
                double sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                textBox1.Text = sum.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show(" Invoice cannot be empty. Product(s) must be added! ", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (payment_cash.Checked == false && payment_pos.Checked == false)
            {
                MessageBox.Show(" Select Method of Payment (Cash or POS Payment Method) ", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tendered_cash.Text == "0" && payment_cash.Checked == true)
            {
                MessageBox.Show(" Enter the Amount Tendered! ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (payment_pos.Checked == true)
                {
                    tendered_cash.Text = textBox1.Text;
                }


               


                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    for (int w = 0; w < dataGridView2.Rows.Count; w++)
                    {
                        Random rnd = new Random();
                        string cd = rnd.Next(1, 9999999).ToString();
                        string prod_name = dataGridView2.Rows[w].Cells[1].Value.ToString();
                        string code = prod_name + DateTime.Now + cd.ToString() + DateTime.Now.Millisecond;

                        string desc = dataGridView2.Rows[w].Cells[2].Value.ToString();
                        string pris = dataGridView2.Rows[w].Cells[3].Value.ToString();
                        string disco = dataGridView2.Rows[w].Cells[4].Value.ToString();
                        string quantiti = dataGridView2.Rows[w].Cells[0].Value.ToString();
                        string date = DateTime.Now.ToString();
                        string day = DateTime.Now.Day.ToString();
                        string month = DateTime.Now.Month.ToString();
                        string year = DateTime.Now.Year.ToString();
                        // string date = DateTime.Now.ToShortDateString() + " " + " " + DateTime.Now.ToLongTimeString();
                        label10.Text = date.ToString();
                        MySqlCommand cmd1 = new MySqlCommand("INSERT INTO Table_Sales_confirmed(Product_Name,Category,Quantity,Price,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('" + dataGridView2.Rows[w].Cells[1].Value.ToString() + "','Product','" + quantiti + "','" + desc + "','" + pris + "','" + date + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + cashier_name.Text + "','" + code.ToString() + "','" + payment_method.Text + "','" + cst_name.Text + "','" + disco + "','" + invoice_number.Text + "')", cn);
                        /*
                 dataGridView2.Rows.Add(quantity.Text, productname1.Text, textBox7.Text, total.Text, discount1.Text, code.ToString());
                       */
                        cmd1.ExecuteNonQuery();
                    }

                }

                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.Message);
                }


                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    string code = cst_name.Text + textBox3.Text + DateTime.Now;
                    gclass.insert1("INSERT INTO Table_Buyers(tel_no,Day,Month,Year,Code,Full_Name)VALUES('" + textBox3.Text + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + code.ToString() + "','" + cst_name.Text + "') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),full_name=values(full_name)");
                }

                gclass.insert1("INSERT INTO table_customer(Full_Name,Phone)VALUES('" + cst_name.Text + "','" + textBox3.Text + "') ON DUPLICATE KEY UPDATE Full_Name=values(full_name),Phone=values(phone)");
                gclass.insert1("INSERT INTO Table_In(Invo)Values('" + invoice_number.Text + "')");


                printDocument1.DocumentName = "Print Document";

                pageSetupDialog1.Document = printDocument1;

                PrintDialog printDlg = new PrintDialog();
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;

                if (printDlg.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                   // printDocument1.Print();
                }


                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                textBox1.Text = "0";
                txt_amount_paid.Text = "0";
                change.Text = "0";
                textBox3.Text = null;
                quantity.Text = "0";
                total.Text = "0";
                textBox7.Text = "0";
                tendered_cash.Text = "0";
                receipt_description.Text = null;
                productname1.SelectedIndex = -1;


                productname1.SelectedIndex = -1;
                price.Text = "0";
                quantity.Text = "0";
                quantity.SelectedIndex = 0;
                textBox6.Text = null;
                receipt_description.Text = null;
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                productname_det.Text = null;
                textBox1.Text = "0";
                payment_cash.Checked = false;
                payment_pos.Checked = false;

                MySqlConnection cn21 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn21.Open();
                String query21 = "SELECT COUNT(p_id) FROM Table_In";
                MySqlCommand cmd21 = new MySqlCommand(query21, cn21);
                MySqlDataReader dr21 = cmd21.ExecuteReader();
                try
                {
                   
                    while (dr21.Read())
                    {
                        int a = Convert.ToInt32((string)dr21.GetValue(0).ToString());
                        invoice_number.Text = "0" + (a + 1).ToString();
                    }
                    dr21.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn21.Close();
                    cmd21.Dispose();
                    dr21.Close();
                }

                gclass.display_in_combobox("SELECT* FROM table_buyers", cst_name, "Full_Name");
                cst_name.SelectedIndex = -1;


                MessageBox.Show("Transaction was successfull and current Stock Updated ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                textBox3.Text = null;
                
                /* Sales fm = new Sales();
                fm.cashier_name.Text = cashier_name.Text;
                fm.status.Text = status.Text;
                fm.Show();
                this.Hide();*/

                /////////////////////// SENDING SMS MESSAGE ALERT ON PAYMENT CONFIRMATION /////////////////////////////////////////
                /*  try
                  {
                      string url;
                          url = "http://smsexperience.com/components/com_spc/smsapi.php?username=dtm123&password=dtm@solutions&sender=HEPHZIBAH&recipient=" + textBox3.Text.TrimEnd() + "@@&message=" + message.Text.TrimEnd() + "";
                      HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                      //Get response from the SMS Gateway Server and read the answer
                      HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                      System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                      string responseString = respStreamReader.ReadToEnd();
                      respStreamReader.Close();
                      myResp.Close();
                  }
                  catch (Exception ex)
                  {
                      // MessageBox.Show(ex.Message);
                  }*/
            
            }
        }
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
                Bitmap bmp = new Bitmap(panel_receipt.Width, panel_receipt.Height);
                panel_receipt.DrawToBitmap(bmp, new Rectangle(0, 0, panel_receipt.Width, panel_receipt.Height));
                e.Graphics.DrawImage(bmp, 0, 0);
                int row = 1;
                if (row <= 12)
                {
                    e.HasMorePages = false;
                }
            }
        

        private void button13_Click(object sender, EventArgs e)
        {
            Sales fm = new Sales();
            fm.cashier_name.Text = cashier_name.Text;
            fm.status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void txt_amount_paid_Click(object sender, EventArgs e)
        {
            change.Text = (Convert.ToDecimal(tendered_cash.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            /*pos.Account_History fm = new pos.Account_History();
            fm.employee_name.Text = cashier_name.Text;
            fm.Show();*/
        }

        private void tendered_cash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tendered_cash.Text))
            {
                tendered_cash.Text = "0";
            }

            change.Text = tendered_cash.Text;
            txt_amount_paid.Text = tendered_cash.Text;

            if (Convert.ToDecimal(tendered_cash.Text) > 0)
            {
                try
                {
                    decimal a = decimal.Parse(tendered_cash.Text);
                    txt_amount_paid.Text = tendered_cash.Text;
                    change.Text = (Convert.ToDecimal(tendered_cash.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tendered Cash must only be Integer");
                    tendered_cash.Text = "0";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home fm = new Home();
            fm.login_name.Text = cashier_name.Text;
            fm.login_status.Text = status.Text;
            fm.status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void cst_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = null;
            MySqlDataReader dr = gclass.display_in_box("SELECT tel_no FROM Table_buyers WHERE Full_Name='" + cst_name.Text + "'");
            if (dr.Read())
            {
                textBox3.Text = (string)dr.GetValue(0).ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(quantity.Text))
            {
                quantity.Text = "0";
               // quantity.SelectedIndex = 0;
            }

            try
            {
                discount.Text = null;
                decimal a = Convert.ToDecimal(quantity.Text);
                decimal b = Convert.ToDecimal(quantity.Text);
                decimal c = Convert.ToDecimal(textBox7.Text);
                int res = Convert.ToInt32((c * b));
                total.Text = res.ToString();
                charges.Text = res.ToString();
                //stock_current.Text=()
                barcode_scan.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Convert.ToDecimal(quantity.Text) > Convert.ToDecimal(no_of_product.Text))
            {
               // MessageBox.Show("Quantity of " + productname1.Text + " available is not up to " + quantity.Text + " Units ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Text = "0";
            }
        }

        private void quantity_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(quantity.Text))
            {
                quantity.Text = "0";
               // quantity.SelectedIndex = 0;
            }
            try
            {
                discount.Text = null;
                decimal a = Convert.ToDecimal(quantity.Text);
                decimal b = Convert.ToDecimal(quantity.Text);
                decimal c = Convert.ToDecimal(textBox7.Text);
                decimal res = c * b;
                total.Text = res.ToString();
                charges.Text = res.ToString();
                //stock_current.Text=()
                barcode_scan.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Convert.ToDecimal(quantity.Text) > Convert.ToDecimal(no_of_product.Text))
            {
                MessageBox.Show("Quantity of " + productname1.Text + " available is not up to " + quantity.Text + " Units ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Text = "0";
            }
        }

        private void discount1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(discount1.Text))
            {
                discount1.Text = "0";
                // quantity.SelectedIndex = 0;
            }

            if (discount1.Text == "0")
            {
                decimal a = Convert.ToDecimal(quantity.Text);
                decimal b = Convert.ToDecimal(quantity.Text);
                decimal c = Convert.ToDecimal(textBox7.Text);
                int res = Convert.ToInt32((c * b));
                total.Text = Convert.ToDecimal((c * b)).ToString();
            }


           /* if (Convert.ToDecimal(discount1.Text) > 0)
            {
                try
                {
                    decimal a = decimal.Parse(discount1.Text);
                    double sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {

                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        textBox1.Text = sum.ToString();

                    }
                    textBox1.Text = (Convert.ToDecimal(sum) - Convert.ToDecimal(discount1.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    discount1.Text = "0";
                }
            }
            else if (Convert.ToDecimal(discount1.Text) <= 0)
            {
                if (Convert.ToDecimal(quantity.Text) > 0 && Convert.ToDecimal(total.Text) > 0)
                {
                    double sum = 0;

                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {

                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        textBox1.Text = sum.ToString();

                    }
                }
            }*/
        }

        private void change_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            change.Text = (Convert.ToDecimal(txt_amount_paid.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
        }

        private void payment_cash_CheckedChanged(object sender, EventArgs e)
        {
            payment_method.Text = "Cash";
            tendered_cash.Enabled = true;
        }

        private void payment_pos_CheckedChanged(object sender, EventArgs e)
        {
            payment_method.Text = "POS";
            tendered_cash.Enabled = false;

        }

        private void change_TextChanged(object sender, EventArgs e)
        {
            try
            {
                change.Text = (Convert.ToDecimal(txt_amount_paid.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
            }
            catch
            {

            }
        }

        private void txt_amount_paid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                change.Text = (Convert.ToDecimal(txt_amount_paid.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
            }
            catch
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                change.Text = (Convert.ToDecimal(txt_amount_paid.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
            }
            catch
            { 
            
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
