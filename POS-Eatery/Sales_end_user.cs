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
using System.IO;

namespace POS_Eatery
{
    public partial class Sales_end_user : Form
    {
        public Sales_end_user()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        Random rnd = new Random();
        int kast;

        private void p_receipt()
        {
            // if (chk_save.Checked == true)
            //  {
            try
            {
                int width = panel_receipt.Size.Width;
                int height = panel_receipt.Size.Height;

                Bitmap bm = new Bitmap(width, height);
                panel_receipt.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                string tp1 = s_date.Text.Replace("-", "_").Replace(":", "_").Replace(" ", "_");
                string tmp = s_date.Text + "_time_" + DateTime.Now.ToLongTimeString();
                string ggg = tmp.Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                if (!Directory.Exists(Application.LocalUserAppDataPath + "/" + s_date.Text.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_")))
                {
                    Directory.CreateDirectory(Application.LocalUserAppDataPath + "/" + s_date.Text.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_"));
                }
                bm.Save(Application.LocalUserAppDataPath + "/" + s_date.Text.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + "/" + DateTime.Now.ToLongTimeString().Replace(":","_") + ".png", System.Drawing.Imaging.ImageFormat.Png);
                //  bm.Save("C:\\img/" + ggg + ".png", System.Drawing.Imaging.ImageFormat.Png);
                // bm.Save("C:\\img/panel.PNG", System.Drawing.Imaging.ImageFormat.Png);
                // bm.Save(@"C:\TestDrawToBitmap.bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            //Convert.ToDateTime(s_date.Text).ToShortDateString()
        private void productname1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {//Dat
                
                if (productname1.Text.Length >= 14)
                {
                    try
                    {
                        //Convert.ToDateTime(s_date.Text).ToShortDateString()
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
                   
                    try
                    {
                        MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn1.Open();
                        string query1 = "SELECT* FROM Table_Stock_Inventory_Summary WHERE Product_Name='Gas' and Branch='"+ branch.Text +"' ORDER BY p_id DESC LIMIT 1";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn1);
                        MySqlDataReader dr2 = cmd1.ExecuteReader();
                        try
                        {
                            if (dr2.Read())
                            {
                                no_of_product.Text = (string)dr2.GetValue(5).ToString();
                                productname_det.Text = (string)dr2.GetValue(1).ToString();
                                quantity.Text = (Convert.ToDecimal(quantity.Text) + Convert.ToDecimal(1)).ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message;)
                        }
                        finally
                        {
                            cn1.Close(); cn1.Dispose();
                            cmd1.Dispose();
                            dr2.Close(); dr2.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show(ex.Message);
                    }
               
                 
                    try
                    {
                        MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn1.Open();
                        string query1 = "SELECT* FROM Table_price_product WHERE Product_Name='" + productname1.Text + "' AND Category='" + channel.Text + "' and Branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn1);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        try
                        {
                            if (dr1.Read())
                            {
                                textBox7.Text = (string)dr1.GetValue(2).ToString();
                                cost.Text = (string)dr1.GetValue(7).ToString();
                                cost_temp.Text = (string)dr1.GetValue(7).ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message;)
                        }
                        finally
                        {
                            cn1.Close(); cn1.Dispose();
                            cmd1.Dispose();
                            dr1.Close(); dr1.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    try
                    {
                        MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn1.Open();
                        string query1 = "SELECT* FROM Table_Stock_Inventory_Summary WHERE Product_Name='" + productname1.Text + "' and Branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn1);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        try
                        {
                            if (dr1.Read())
                            {
                                no_of_product.Text = (string)dr1.GetValue(5).ToString();
                                productname_det.Text = (string)dr1.GetValue(1).ToString();
                                total.Text = (string)dr1.GetValue(12).ToString();
                                quantity.Text = (Convert.ToDecimal(quantity.Text) + Convert.ToDecimal(1)).ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message;)
                        }
                        finally
                        {
                            cn1.Close(); cn1.Dispose();
                            cmd1.Dispose();
                            dr1.Close(); dr1.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn1.Open();
                        string query1 = "SELECT* FROM Table_price_product WHERE Product_Name='" + productname1.Text + "' AND Category='" + channel.Text + "' and Branch='" + branch.Text + "' ORDER BY p_id DESC LIMIT 1";
                        MySqlCommand cmd1 = new MySqlCommand(query1, cn1);
                        MySqlDataReader dr1 = cmd1.ExecuteReader();
                        try
                        {
                            if (dr1.Read())
                            {
                                textBox7.Text = (string)dr1.GetValue(2).ToString();
                                cost.Text = (string)dr1.GetValue(7).ToString();
                                cost_temp.Text = (string)dr1.GetValue(7).ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message;)
                        }
                        finally
                        {
                            cn1.Close(); cn1.Dispose();
                            cmd1.Dispose();
                            dr1.Close(); dr1.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (company_name_search.SelectedIndex > -1 && productname1.Text.Contains("Gas"))
            {
                MySqlDataReader dr9 = gclass.display_in_box("SELECT Rate FROM  Table_Customer WHERE Company_Name='" + company_name_search.Text + "' AND Rate>0 AND Reg_Status='" + channel.Text + "' and Branch='" + branch.Text + "'");
                if (dr9.Read())
                {
                    textBox7.Text = (string)dr9.GetValue(0).ToString();
                }
            }

            if ((productname1.Text.Contains("Gas") || productname1.Text.Contains("gas")) && channel.Text.Contains("Indus"))
            {
                label1_unit.Text = "Ltr(s)";
            }
            else if ((productname1.Text.Contains("Gas") || productname1.Text.Contains("gas")) && !channel.Text.Contains("Indus"))
            {
                label1_unit.Text = "Kg";
            }
            else
            {
                label1_unit.Text = "Pc(s)";
            }

        }

        private void Sales_Load(object sender, EventArgs e)
        {
            pos_id.Enabled = false;
            this.Text = channel.Text + " Sales.";
            quantity.SelectedIndex = 0;
            quantity.Text = "0";
            txt_amount_paid.Text = "0";

           // dataGridView2.Columns[6].Visible = false;

            MySqlConnection cn100 = new MySqlConnection();
            MySqlCommand cmd100 = new MySqlCommand();
            MySqlConnection cn120 = new MySqlConnection();
            MySqlCommand cmd120 = new MySqlCommand();
            //################################## START OF CHECKING AND REPARING CRASHED TABLE ###################################################
            MySqlDataReader dr17 = gclass.display_in_box1("show table status where comment like '%crash%'", cn100, cmd100);
            try
            {
                if (dr17.Read())
                {
                    ////////////////////////////////////////////////

                    gclass.display_in_dgv("select concat('repair table ', table_name, ' use_frm;' 'alter table ', table_name, ' drop p_id;' 'alter table ', table_name, ' ADD p_id INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;') from information_schema.tables where table_schema='db_pos_ayegun';", dataGridView21);

                    try
                    {
                        for (int i = 0; i < dataGridView21.Rows.Count; i++)
                        {

                            gclass.insert_nil(dataGridView21.Rows[i].Cells[0].Value.ToString());

                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    };


                    /////////////////////////////////////////////////////
                }
                else
                {
                    //  DO NOTHING

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn100.Close(); cn100.Dispose();
                cmd100.Dispose();
                dr17.Close(); dr17.Dispose();
            }
            //################################## END OF CHECKING AND REPARING CRASHED TABLE ###################################################


            //////////////////////////////////////////////// START OF LOYALTY STUFF /////////////////////////
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* from table_loyalty where Branch='" + branch.Text + "'", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                    {
                        benchmark.Text = (string)dr.GetValue(1).ToString();
                        default_amount.Text = (string)dr.GetValue(2).ToString();
                        default_amount.Text = (Convert.ToDecimal(default_amount.Text) / Convert.ToDecimal(100)).ToString();
                    }
                    else
                    {
                        benchmark.Text = "0";
                        default_amount.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close(); cn.Dispose();
                    cmd.Dispose();
                    dr.Close(); dr.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            ////////////////////////////////////////////////// END OF LOYALTY STUFF /////////////////////////


            ////////////////////////////////////////////////
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT no_receipt from table_number where Branch='" + branch.Text + "' order by p_id desc limit 1", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                    {
                        print_no.Text = (string)dr.GetValue(0).ToString();
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close(); cn.Dispose();
                    cmd.Dispose();
                    dr.Close(); dr.Dispose();
                }
            }
            catch (Exception ex)
            { 
            
            }
            //////////////////////////////////////////////////

            try
            {
                MySqlConnection cn11 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn11.Open();
                string str11 = "SELECT* FROM table_buyers where Branch='" + branch.Text + "' ORDER BY Full_Name ASC";
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


            gclass.Update1("UPDATE Table_Stock_Inventory_Summary SET Quantity_Left='0' WHERE Quantity_Left <0 and Branch='" + branch.Text + "'");
            //gclass.Update1("Table_Stock_Inventory_Summary SET Quantity_In='0.00' WHERE Quantity_In <0");
           // gclass.Update1("Table_Stock_Inventory_Summary SET Quantity_Out='0.00' WHERE Quantity_Left <0");

            label10.Text = s_date.Text + " " + DateTime.Now.ToLongTimeString(); //DateTime.Now.ToString();//DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();


            //############################### FETCH THE NEXT INVOICE NUMBER TO THE RECEIPT ########################################

            MySqlConnection cn12 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn12.Open();
            String query12 = "SELECT p_id FROM Table_In where Branch='" + branch.Text + "' order by p_id desc limit 1";
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

            MySqlDataReader dr4 = gclass.display_in_box("SELECT* FROM Table_Customize where Branch='" + branch.Text + "'");
            while (dr4.Read())
            {
                company_name.Text = (string)dr4.GetValue(1).ToString();
                company_specialty.Text = (string)dr4.GetValue(2).ToString();
                company_address.Text = (string)dr4.GetValue(3).ToString();
                address.Text = (string)dr4.GetValue(4).ToString();
                company_telephone.Text = (string)dr4.GetValue(5).ToString();
            }
            dr4.Close();

            // dataGridView1.Width = 260;

            MySqlConnection cn53 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn53.Open();
            string str13 = "SELECT DISTINCT(Product_Name) FROM Table_New_Product WHERE Product_Name NOT LIKE 'Discount' and Branch='" + branch.Text + "' ORDER BY Product_Name ASC";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + s_day.Text.ToString() + "','" + s_month.Text + "','" + s_year.Text + "')";
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

            MySqlConnection cn54 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn54.Open();
            string str54 = "SELECT Distinct Company_Name FROM Table_Customer WHERE Reg_Status='" + channel.Text + "' and Branch='" + branch.Text + "' ORDER BY Company_Name ASC";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + s_day.Text.ToString() + "','" + s_month.Text + "','" + s_year.Text + "')";
            MySqlCommand cmd54 = new MySqlCommand(str54, cn54);
            MySqlDataAdapter da54 = new MySqlDataAdapter(cmd54);
            try
            {
                DataTable dt54 = new DataTable();
                da54.Fill(dt54);
                company_name_search.DataSource = dt54;
                company_name_search.DisplayMember = "Company_Name";
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                MySqlDataReader dr54 = cmd54.ExecuteReader();
                while (dr54.Read())
                {
                    acc.Add(dr54.GetString(0));
                }
                company_name_search.AutoCompleteCustomSource = acc;
                dr54.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn54.Close();
                cmd54.Dispose();
                // dr13.Close();
            }
            company_name_search.SelectedIndex = -1;

            kast = rnd.Next(50000, 9999999);

            try
            {
                var s = cashier_name.Text;
                cashier_name.Text = s.Substring(0, s.IndexOf(" "));
                // MessageBox.Show(firstWord);
            }
            catch
            {
                cashier_name.Text = cashier_name.Text;
            }

            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_expenditure set dat=concat(year,'-',month,'-',day);");
            
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
            //////////////////////////////////////////////// START OF LOYALTY STUFF /////////////////////////
            if ((productname1.Text.Contains( "gas") || productname1.Text.Contains( "Gas") || productname1.Text.Contains( "GAS")) && (!string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT count(p_id) from table_sales_confirmed where Phone='" + textBox3.Text + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    try
                    {
                        if (dr.Read())
                        {
                            no_of_appearance.Text = (string)dr.GetValue(0).ToString();
                        }
                        else
                        {
                            no_of_appearance.Text = "Nil";
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn.Close(); cn.Dispose();
                        cmd.Dispose();
                        dr.Close(); dr.Dispose();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            ////////////////////////////////////////////////// END OF LOYALTY STUFF /////////////////////////



            Random sdp = new Random();
            string rand1 = sdp.Next(16547, 8123456).ToString() + s_date.Text+DateTime.Now.ToLongTimeString();
            if (Convert.ToDecimal(discount1.Text) > 0)
            {
                decimal ab = (Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text));
                total.Text = ab.ToString();
            }

            string q1 = quantity.Text; ; string q2 = quantity.Text;
            if ((channel.Text.Contains("Indus") && productname1.Text.Contains("Gas") && label1_unit.Text.Contains("Ltr")) || (channel.Text.Contains("Indus") && productname1.Text.Contains("GAS") && label1_unit.Text.Contains("Ltr")) || (channel.Text.Contains("Indus") && productname1.Text.Contains("gas") && label1_unit.Text.Contains("Ltr")))
            {
                q2 = Math.Round((Convert.ToDecimal(quantity.Text) / Convert.ToDecimal(1.75)), 2).ToString();
            }
            else
            {
                q2 = Convert.ToDecimal(quantity.Text).ToString();
            }


            if (Convert.ToDecimal(quantity.Text) > 0 && Convert.ToDecimal(total.Text) > 0)
            {
                if (Convert.ToDecimal(discount1.Text) > 0)
                {

                    if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
                    {

                        string code = productname1.Text + rand1 + channel.Text + branch.Text;

                        decimal deca = (Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text));


                        if (channel.Text.Contains("Indus") && productname1.Text.Contains("Gas"))
                        {
                            dataGridView1.Rows.Add(q1 + label1_unit.Text, receipt_description.Text, textBox7.Text, total.Text);
                            dataGridView1.Rows.Add(q1 + label1_unit.Text, "Discount", discount1.Text, "0.00");
                        }
                        else
                        {
                            dataGridView1.Rows.Add(q1 + label1_unit.Text, receipt_description.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)));
                        }
                          if (Convert.ToInt32(no_of_appearance.Text) > Convert.ToInt32(benchmark.Text) && (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS")))
                            {
                            string a = (Convert.ToDecimal(default_amount.Text) * Convert.ToDecimal(total.Text)).ToString();
                            string b = (Convert.ToDecimal(total.Text) - (Convert.ToDecimal(default_amount) * Convert.ToDecimal(total.Text))).ToString();
                                dataGridView1.Rows.Add(" ", "Loyalty", a, b);
                            }
                     
                        Random rdd = new Random();
                        string abd = rdd.Next(1234, 7897896).ToString() + s_date.Text + DateTime.Now.ToLongTimeString();
                        dataGridView2.Rows.Add(q2, productname1.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)), discount1.Text, code.ToString() + abd.ToString(), cost.Text);
                        
                    }
                    else
                    {
                       
                        string code = productname1.Text + rand1 + channel.Text+branch.Text;

                        decimal deca = Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text);

                        Random rdd = new Random();
                        string abd = rdd.Next(1234, 7897896).ToString() + rand1 + s_date.Text + DateTime.Now.ToLongTimeString();

                        dataGridView1.Rows.Add(q1, receipt_description.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)));
                        dataGridView2.Rows.Add(q2, productname1.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)), discount1.Text, code.ToString() + abd.ToString(), cost.Text);
                        dataGridView1.Rows.Add(" ", "Discount", discount1.Text, "0");
                        // dataGridView2.Rows.Add(quantity.Text, "Discount", discount1.Text, "0");
                    }
                }
                else
                {
                    if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
                    {
                        string code = productname1.Text + rand1 + s_date.Text + DateTime.Now.ToLongTimeString() + channel.Text + branch.Text;

                        decimal deca = Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text);

                        if (channel.Text.Contains("Indus") && productname1.Text.Contains("Gas"))
                        {
                            dataGridView1.Rows.Add(q1 + label1_unit.Text, receipt_description.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)));
                        }
                        else
                        {
                            dataGridView1.Rows.Add(q1 + label1_unit.Text, receipt_description.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)));
                        }

                        if (Convert.ToInt32(no_of_appearance.Text) > Convert.ToInt32(benchmark.Text) && (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS")))
                        {
                            string a = (Convert.ToDecimal(default_amount.Text) * Convert.ToDecimal(total.Text)).ToString();
                            string b = (Convert.ToDecimal(total.Text) - (Convert.ToDecimal(default_amount.Text) * Convert.ToDecimal(total.Text))).ToString();
                            dataGridView1.Rows.Add(" ", "Loyalty", Math.Round(Convert.ToDecimal(a)), Math.Round(Convert.ToDecimal(b)));
                            Random rdd = new Random();
                            string abd = rdd.Next(1234, 7897896).ToString() + rand1 + s_date.Text + DateTime.Now.ToLongTimeString();
                            dataGridView2.Rows.Add(q2, productname1.Text, textBox7.Text, Math.Round(Convert.ToDecimal(b)), discount1.Text, code.ToString() + abd.ToString(), cost.Text, Math.Round(Convert.ToDecimal(a)));
                        }
                        else
                        {
                            Random rdd = new Random();
                            string abd = rdd.Next(1234, 7897896).ToString() + rand1 + s_date.Text + DateTime.Now.ToLongTimeString();
                            dataGridView2.Rows.Add(q2, productname1.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)), discount1.Text, code.ToString() + abd.ToString(), cost.Text);
                        }
                    }
                    else
                    {

                        string code = productname1.Text + kast + s_date.Text + DateTime.Now.ToLongTimeString() + channel.Text + branch.Text;

                        decimal deca = Convert.ToDecimal(total.Text) - Convert.ToDecimal(discount1.Text);

                        Random rdd = new Random();
                        string abd = rdd.Next(1234, 7897896).ToString() + rand1 + s_date.Text + DateTime.Now.ToLongTimeString();

                        dataGridView1.Rows.Add(q1, receipt_description.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)));
                        dataGridView2.Rows.Add(q2, productname1.Text, textBox7.Text, Math.Round(Convert.ToDecimal(total.Text)), discount1.Text, code.ToString() + abd.ToString(), cost.Text);
                    }
                }

                double sum = 0;

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    textBox1.Text = sum.ToString();
                }
                // gclass.panel_format(panel_cash_sales);
                productname1.SelectedIndex = -1;
                textBox7.Text = "0.00";
                total.Text = "0.00";
                discount1.Text = "0";
                productname_det.Text = null;
                quantity.Text = "0";
                cost.Text = "0";
                receipt_description.Text = null;
            }
            else
            {
                MessageBox.Show(" Select at Least one Item/ Product from the Item Box ... ", "POS Intelliscense Says ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Refresh();
            }
            catch
            {

            }
            /*double sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {

                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                textBox1.Text = sum.ToString();

            }*/
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                dataGridView2.Refresh();
            }
            catch
            {

            }
            double sum = 0;

            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {

                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                textBox1.Text = sum.ToString();

            }
            /* try
             {
                 dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
             }
             catch
             {

             }
             double sum = 0;

             for (int i = 0; i < dataGridView1.Rows.Count; ++i)
             {
                 sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                 textBox1.Text = sum.ToString();
             }*/
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
               // textBox1.Text = (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text)).ToString();
                tendered_cash.Text = (Convert.ToDecimal(cash_amt.Text) + Convert.ToDecimal(pos_amt.Text) + Convert.ToDecimal(transfer_amt.Text)).ToString();
               // txt_amount_paid.Text = tendered_cash.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            kast = rnd.Next(50000, 9999999);
            if (!channel.Text.Contains("Indus"))
            {
                if (dataGridView1.Rows.Count <= 1)
                {
                    MessageBox.Show(" Invoice cannot be empty. Product(s) must be added! ", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (payment_cash.Checked == false && payment_pos.Checked == false && credit.Checked == false && transfer.Checked == false && multiple_mode.Checked == false)
                {
                    MessageBox.Show(" Select Method of Payment (Cash, POS Payment Method, Credit, Multi or Transfer) ", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /* else if (Sales_Method.SelectedIndex == -1)
                 {
                     MessageBox.Show(" Select Category of Sales (Cash/ Credit) ... ", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }*/
                else if (Sales_Method.SelectedIndex == -1 && company_name_search.SelectedIndex == -1)
                {
                    MessageBox.Show(" Select Name of Company/ Individual Buying on Credit ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (channel.Text.Contains("Home") && Convert.ToDecimal(transport.Text) <= 0)
                {
                    MessageBox.Show(" Enter Amount for Transportation ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (payment_pos.Checked == true && string.IsNullOrWhiteSpace(pos_id.Text) || transfer.Checked == true && string.IsNullOrWhiteSpace(pos_id.Text))
                {
                    MessageBox.Show(" Enter Transaction's ID From POS Machine or Transfer ID/Name ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (channel.Text.Contains("Dist") && string.IsNullOrWhiteSpace(company_name_search.Text))
                {
                    MessageBox.Show(" Select the Name of the Distributor ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tendered_cash.Text == "0" && Sales_Method.Text.Contains("Cash") && payment_cash.Checked == true)
                {
                    MessageBox.Show(" Enter the Amount Tendered ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (payment_cash.Checked == false && payment_pos.Checked == false && credit.Checked == false && transfer.Checked == false && multiple_mode.Checked == false)
                {
                    MessageBox.Show(" Select Payment Method (Cash, POS, Credit, Multi or Transfer) ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((payment_cash.Checked == true || payment_pos.Checked == true || transfer.Checked == true || multiple_mode.Checked == true) && Convert.ToDecimal(tendered_cash.Text) < (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport_fare.Text)))
                {
                    MessageBox.Show(" Insufficient amount is tendered ... Insufficient Amount ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    //############################### START TO FETCH THE NEXT INVOICE NUMBER TO THE RECEIPT ########################################

                    MySqlConnection cn12 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn12.Open();
                    String query12 = "SELECT p_id from table_In where Branch='" + branch.Text + "' order by p_id desc limit 1";
                    MySqlCommand cmd12 = new MySqlCommand(query12, cn12);
                    MySqlDataReader dr12 = cmd12.ExecuteReader();
                    try
                    {

                        while (dr12.Read())
                        {
                            int a = Convert.ToInt32((string)dr12.GetValue(0).ToString());
                            invoice_number.Text = (a + 1).ToString();
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
                    //###############################  END TO FETCH THE NEXT INVOICE NUMBER TO THE RECEIPT  //##################################################


                    // pos_id.BorderStyle = BorderStyle.None;

                  /*  if (payment_pos.Checked == true)
                    {
                        tendered_cash.Text = textBox1.Text;
                    }*/

                    /* if (transport.Visible == true)
                     {
                         textBox1.Text = (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text)).ToString();
                     }*/


                    if (channel.Text.Contains("Credit") || channel.Text.Contains("credit"))
                    {
                        try
                        {
                            decimal a = decimal.Parse(tendered_cash.Text);
                            txt_amount_paid.Text = tendered_cash.Text;
                            textBox1.Text = (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text)).ToString();
                            change.Text = (Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(tendered_cash.Text)).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Tendered Cash must only be Integer");
                            tendered_cash.Text = "0";
                        }
                    }
                    else
                    {
                        try
                        {
                            decimal a = decimal.Parse(tendered_cash.Text);
                            txt_amount_paid.Text = tendered_cash.Text;
                            textBox1.Text = (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text)).ToString();
                            change.Text = (Convert.ToDecimal(tendered_cash.Text) - (Convert.ToDecimal(textBox1.Text))).ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Tendered Cash must only be Integer");
                            tendered_cash.Text = "0";
                        }
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
                            Random rnd1 = new Random();
                            string kast1 = rnd1.Next(0, 9876543).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;

                            string prod_name = dataGridView2.Rows[w].Cells[1].Value.ToString();

                            Random rnd7 = new Random();
                            string kast7 = rnd7.Next(3000, 9876543).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Second;

                            string code = prod_name + kast + s_date.Text + DateTime.Now.ToLongTimeString() + channel.Text + DateTime.Now.Millisecond + DateTime.Now.Second + kast7 + branch.Text;

                            string desc = dataGridView2.Rows[w].Cells[2].Value.ToString();
                            string pris = dataGridView2.Rows[w].Cells[3].Value.ToString();
                            string disco = dataGridView2.Rows[w].Cells[4].Value.ToString();
                            string loya = dataGridView2.Rows[w].Cells[5].Value.ToString();
                            string cos = dataGridView2.Rows[w].Cells[6].Value.ToString();
                            string quantiti = dataGridView2.Rows[w].Cells[0].Value.ToString();
                            string date = s_date.Text;
                            string day = s_day.Text.ToString();
                            string month = s_month.Text.ToString();
                            string year = s_year.Text.ToString();

                            Random ppt1 = new Random();
                            string ast1 = ppt1.Next(1, 6500000).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;
                            // string date = DateTime.Now.ToShortDateString() + " " + " " + DateTime.Now.ToLongTimeString();
                            label10.Text = s_date.Text + " " + DateTime.Now.ToLongTimeString();
                            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO Table_Sales_confirmed(Product_Name,Category,Quantity,Price,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Branch,phone,Loyalty)VALUES('" + dataGridView2.Rows[w].Cells[1].Value.ToString() + "','" + channel.Text + "','" + quantiti + "','" + desc + "','" + pris + "','" + date + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + cashier_name.Text + "','" + code.ToString() + ast1.ToString() + "','" + payment_method.Text + "','" + company_name_search.Text + "','" + disco + "','" + invoice_number.Text + "','" + cos.ToString() + "','" + branch.Text + "','" + textBox3.Text + "','" + loya + "')", cn);
                            cmd1.ExecuteNonQuery();
                            ///////////////////////////////////////////////////////////////////
                            if (prod_name.Contains("GAS") || prod_name.Contains("Gas") || prod_name.Contains("gas"))
                            {
                                Random ppt2 = new Random();
                                string ast2 = ppt2.Next(15648, 6556474).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;
                                gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + Convert.ToDecimal(quantiti) + "',Quantity_Left=Quantity_Left-'" + Convert.ToDecimal(quantiti) + "',price='" + pris.ToString() + "' WHERE  Day='" + s_day.Text + "' AND Month='" + s_month.Text + "' AND Year='" + s_year.Text + "' AND  Product_Name='Gas' and Branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                                Random zzz = new Random();
                                string zzz1 = cos + zzz.Next(123, 6546789).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Second + DateTime.Now.Millisecond;
                                gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code,Cost,Branch,Time)VALUES('Gas','" + channel.Text + "','" + quantiti + "','Sold Out','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + ast2.ToString() + zzz1.ToString() + "','" + cos.ToString() + "','" + branch.Text + "','" + DateTime.Now.ToLongTimeString() + "')");
                                System.Threading.Thread.Sleep(2000);
                            }
                            else
                            {
                                Random ppt3 = new Random();
                                string ast3 = ppt3.Next(15648, 6556474).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;
                                gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + Convert.ToDecimal(quantiti) + "',Quantity_Left=Quantity_Left-'" + Convert.ToDecimal(quantiti) + "',price='" + pris.ToString() + "' WHERE  Day='" + s_day.Text + "' AND Month='" + s_month.Text + "' AND Year='" + s_year.Text + "' AND  Product_Name='" + prod_name.ToString() + "' and Branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                                Random zzz = new Random();
                                string zzz1 = cos + zzz.Next(123, 6546789).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Second + DateTime.Now.Millisecond;
                                gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code,Cost,Branch,Time)VALUES('" + prod_name.ToString() + "','" + channel.Text + "','" + quantiti + "','Sold Out','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + ast3.ToString() + zzz1.ToString() + "','" + cos.ToString() + "','" + branch.Text + "','" + DateTime.Now.ToLongTimeString() + "')");
                                System.Threading.Thread.Sleep(2000);
                            }
                            ///////////////////////////////////////////////////////////////////
                        }



                    }

                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }

                    decimal sum_total = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_total += Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value);
                    }

                    decimal sum_cost = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_cost += Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                    }

                    decimal sum_discount = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_discount += Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value);
                    }

                    decimal sum_quantity = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_quantity += Convert.ToDecimal(dataGridView2.Rows[i].Cells[0].Value);
                    }
                    string code2 = kast.ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + channel.Text + branch.Text;
                    string dato = s_year.Text + "-" + s_month.Text + "-" + s_day.Text;
                    if (Sales_Method.Text.Contains("Cash") || Sales_Method.Text.Contains("POS") || Sales_Method.Text.Contains("Multiple"))
                    {
                        string query = "INSERT INTO Table_Sales_lump(Sales_ID,Category,Quantity,Item_Value,Amount_Paid,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Sales_Method,POS_ID,Transport,Branch,Cash,POS,Transfer,changes,Dat,phone)VALUES('" + code2.ToString() + "','" + channel.Text + "','" + sum_quantity.ToString() + "','" + textBox1.Text + "','" + textBox1.Text + "','" + s_date.Text + DateTime.Now.ToLongTimeString() + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + cashier_name.Text + "','" + code2.ToString() + "','" + payment_method.Text + "','" + company_name_search.Text + "','" + sum_discount.ToString() + "','" + invoice_number.Text + "','" + sum_cost.ToString() + "','" + Sales_Method.Text + "','" + pos_id.Text + "','" + transport.Text + "','" + branch.Text + "','" + cash_amt.Text + "','" + pos_amt.Text + "','" + transfer_amt.Text + "','" + change.Text + "','" + dato + "','" + textBox3.Text + "')";
                        gclass.insert1(query);
                    }
                    else
                    {
                        string query = "INSERT INTO Table_Sales_lump(Sales_ID,Category,Quantity,Item_Value,Amount_Paid,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Sales_Method,POS_ID,Transport,Branch,Cash,POS,Transfer,changes,Dat,phone)VALUES('" + code2.ToString() + "','" + channel.Text + "','" + sum_quantity.ToString() + "','" + textBox1.Text + "','0.00','" + DateTime.Now + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + cashier_name.Text + "','" + code2.ToString() + "','" + payment_method.Text + "','" + company_name_search.Text + "','" + sum_discount.ToString() + "','" + invoice_number.Text + "','" + sum_cost.ToString() + "','" + Sales_Method.Text + "','" + pos_id.Text + "','" + transport.Text + "','" + branch.Text + "','" + cash_amt.Text + "','" + pos_amt.Text + "','" + transfer_amt.Text + "','" + change.Text + "','" + dato + "','" + textBox3.Text + "')";
                        gclass.insert1(query);
                    }

                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        string code8 = cst_name.Text + textBox3.Text + s_date.Text + DateTime.Now.ToLongTimeString() + branch.Text;
                        gclass.insert1("INSERT INTO Table_Buyers(tel_no,Date,Day,Month,Year,Code,Full_Name,Branch)VALUES('" + textBox3.Text + "',now(),'" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code8.ToString() + "','" + cst_name.Text + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),full_name=values(full_name),tel_no=values(tel_no),day=values(day),year=values(year),month=values(month),full_name=values(full_name)");
                    }

                    // gclass.insert1("INSERT INTO table_customer(Full_Name,Phone)VALUES('" + cst_name.Text + "','" + textBox3.Text + "') ON DUPLICATE KEY UPDATE Full_Name=values(full_name),Phone=values(phone)");
                    gclass.insert1("INSERT INTO Table_In(Invo,Branch)Values('" + invoice_number.Text + "','" + branch.Text + "')");

                   

                    printDocument1.DocumentName = "Print Document";

                    pageSetupDialog1.Document = printDocument1;

                    PrintDialog printDlg = new PrintDialog();
                    printDlg.AllowSelection = true;
                    printDlg.AllowSomePages = true;
                    ////////////////////////////////////// PRINT /////////////////////////////
                    //  if (printDlg.ShowDialog() == DialogResult.OK)
                    //  {
                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(print_no.Text); i++)
                        {
                            printDocument1.Print();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    p_receipt();
                    //  }
                    /////////////////////////////////////// PRINT ///////////////////////////////////

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
                    company_name_search.SelectedIndex = -1;
                    textBox6.Text = null;
                    receipt_description.Text = null;
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    productname_det.Text = null;
                    textBox1.Text = "0";
                    payment_cash.Checked = false;
                    payment_pos.Checked = false;
                    credit.Checked = false;
                    pos_id.Text = null;
                    transport.Text = null;
                    pos_id.Text = null;

                    cash_amt.Text = "0.00";
                    transfer_amt.Text = "0.00";
                    pos_amt.Text = "0.00";
                    payment_cash.Checked = false;
                    payment_pos.Checked = false;
                    transfer.Checked = false;
                    multiple_mode.Checked = false;
                    credit.Checked = false;

                    MySqlConnection cn21 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn21.Open();
                    String query21 = "SELECT p_id FROM Table_In where Branch='" + branch.Text + "' order by p_id desc limit 1";
                    MySqlCommand cmd21 = new MySqlCommand(query21, cn21);
                    MySqlDataReader dr21 = cmd21.ExecuteReader();
                    try
                    {

                        while (dr21.Read())
                        {
                            int a = Convert.ToInt32((string)dr21.GetValue(0).ToString());
                            invoice_number.Text = (a + 1).ToString();
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
                    MessageBox.Show("Transaction was successfull and current Stock Updated ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox3.Text = null;
                    kast = rnd.Next(50000, 9999999);
                }
            }



            else
            {
                if (dataGridView1.Rows.Count <= 1)
                {
                    MessageBox.Show(" Invoice cannot be empty. Product(s) must be added ... ", "Empty Field Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (payment_cash.Checked == false && payment_pos.Checked == false && credit.Checked == false && multiple_mode.Checked==false)
                {
                    MessageBox.Show(" Select Payment Method (Cash, POS,Multi or Credit) ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {

                        // TRYING TO CALCULATE CHANGE
                        if (Convert.ToDecimal(tendered_cash.Text) > 0)
                        {
                            if (channel.Text.Contains("Credit") || channel.Text.Contains("credit"))
                            {
                                try
                                {
                                    decimal a = decimal.Parse(tendered_cash.Text);
                                    txt_amount_paid.Text = tendered_cash.Text;
                                    textBox1.Text = (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text)).ToString();
                                    change.Text = (Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(tendered_cash.Text)).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Tendered Cash must only be Integer");
                                    tendered_cash.Text = "0";
                                }
                            }
                            else
                            {
                                try
                                {
                                    decimal a = decimal.Parse(tendered_cash.Text);
                                    txt_amount_paid.Text = tendered_cash.Text;
                                    textBox1.Text = (Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text)).ToString();
                                    change.Text = (Convert.ToDecimal(tendered_cash.Text) - (Convert.ToDecimal(textBox1.Text))).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Tendered Cash must only be Integer");
                                    tendered_cash.Text = "0";
                                }
                            }
                        }

                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }

                        for (int w = 0; w < dataGridView2.Rows.Count; w++)
                        {
                            Random rnd1 = new Random();
                            string kast1 = rnd1.Next(0, 9876543).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;

                            string prod_name = dataGridView2.Rows[w].Cells[1].Value.ToString();
                            string code = prod_name + kast + channel.Text+DateTime.Now.Millisecond+branch.Text+branch.Text;

                            string desc = dataGridView2.Rows[w].Cells[2].Value.ToString();
                            string pris =dataGridView2.Rows[w].Cells[3].Value.ToString();
                            string disco = dataGridView2.Rows[w].Cells[4].Value.ToString();
                            string loya = dataGridView2.Rows[w].Cells[5].Value.ToString();
                            string cos = dataGridView2.Rows[w].Cells[6].Value.ToString();
                            string quantiti = dataGridView2.Rows[w].Cells[0].Value.ToString();
                            string date = s_date.Text + DateTime.Now.ToLongTimeString();
                            string day = s_day.Text.ToString();
                            string month = s_month.Text.ToString();
                            string year = s_year.Text.ToString();
                            // string date = DateTime.Now.ToShortDateString() + " " + " " + DateTime.Now.ToLongTimeString();
                            label10.Text = s_date.Text + " " + DateTime.Now.ToLongTimeString();
                            Random ppt = new Random();
                            string ast = ppt.Next(1, 6500000).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;

                            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO Table_Sales_confirmed(Product_Name,Category,Quantity,Price,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Branch,phone,Loyalty)VALUES('" + dataGridView2.Rows[w].Cells[1].Value.ToString() + "','" + channel.Text + "','" + quantiti + "','" + desc + "','" + pris + "','" + date + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + cashier_name.Text + "','" + code.ToString() + ast.ToString() + "','" + payment_method.Text + "','" + company_name_search.Text + "','" + disco + "','" + invoice_number.Text + "','" + cos.ToString() + "','" + branch.Text + "','" + textBox3.Text + "','" + loya + "')", cn);
                            cmd1.ExecuteNonQuery();
                            
                            if (prod_name.Contains("GAS") || prod_name.Contains("Gas") || prod_name.Contains("gas"))
                            {
                                Random ppt1 = new Random();
                                string ast1 = ppt1.Next(15648, 6556474).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;
                                string q2 = quantiti;
                                 
                                Random ppt7 = new Random();
                                string ast7 = ppt7.Next(4567, 6789878).ToString();
                                gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + Convert.ToDecimal(q2) + "',Quantity_Left=Quantity_Left-'" + Convert.ToDecimal(q2) + "',price='" + pris.ToString() + "' WHERE  Day='" + s_day.Text + "' AND Month='" + s_month.Text + "' AND Year='" + s_year.Text + "' AND  Product_Name='Gas' and Branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                                Random zzz = new Random();
                                string zzz1 = zzz.Next(123, 6546789).ToString() + DateTime.Now + DateTime.Now.Second + DateTime.Now.Millisecond;
                                gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code,Cost,Branch,Time)VALUES('Gas','" + channel.Text + "','" + q2.ToString() + "','Sold Out','" + DateTime.Now.ToShortDateString() + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + ast1.ToString() + ast7.ToString() + zzz1.ToString() + "','" + cos.ToString() + "','" + branch.Text + "','" + DateTime.Now.ToLongTimeString() + "')");
                                System.Threading.Thread.Sleep(2000);
                            }
                            else
                            {
                                Random ppt2 = new Random();
                                string ast2 = ppt.Next(15648, 6556474).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond;
                                gclass.Update1("UPDATE Table_stock_inventory_Summary SET Quantity_Out=Quantity_Out+'" + Convert.ToDecimal(quantiti) + "',Quantity_Left=Quantity_Left-'" + Convert.ToDecimal(quantiti) + "',price='" + pris.ToString() + "' WHERE  Day='" + s_day.Text + "' AND Month='" + s_month.Text + "' AND Year='" + s_year.Text + "' AND  Product_Name='" + prod_name.ToString() + "' and Branch='" + branch.Text + "' ORDER BY p_id DESC Limit 1");
                                Random zzz = new Random();
                                string zzz1 = cos + zzz.Next(123, 6546789).ToString() + s_date.Text + DateTime.Now.ToLongTimeString() + DateTime.Now.Second + DateTime.Now.Millisecond;
                                gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_Out,Purpose,Date,Day,Month,Year,Code,Cost,Branch,Time)VALUES('" + prod_name.ToString() + "','" + channel.Text + "','" + quantiti + "','Sold Out','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + ast2.ToString() + zzz1.ToString() + "','" + cos.ToString() + "','" + branch.Text + "','" + DateTime.Now.ToLongTimeString() + "')");
                                System.Threading.Thread.Sleep(2000);
                            }
                        }



                    }

                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }

                    double sum_total = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_total += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }

                    double sum_cost = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_cost += Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                    }

                    double sum_discount = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_discount += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                    }

                    double sum_quantity = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum_quantity += Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value);
                    }
                    string code2 = kast + s_date.Text + DateTime.Now.ToLongTimeString() + channel.Text + branch.Text;
                    string dato = s_year.Text + "-" + s_month.Text + "-" + s_day.Text;
                    if (Sales_Method.Text.Contains("Cash") || Sales_Method.Text.Contains("POS") || Sales_Method.Text.Contains("Multiple"))
                    {
                        string query = "INSERT INTO Table_Sales_lump(Sales_ID,Category,Quantity,Item_Value,Amount_Paid,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Sales_Method,POS_ID,Transport,Branch,Cash,POS,Transfer,changes,Dat,phone)VALUES('" + code2.ToString() + "','" + channel.Text + "','" + sum_quantity.ToString() + "','" + textBox1.Text + "','" + textBox1.Text + "','" + s_date.Text + DateTime.Now.ToLongTimeString() + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + cashier_name.Text + "','" + code2.ToString() + "','" + payment_method.Text + "','" + company_name_search.Text + "','" + sum_discount.ToString() + "','" + invoice_number.Text + "','" + sum_cost.ToString() + "','" + Sales_Method.Text + "','" + pos_id.Text + "','" + transport.Text + "','" + branch.Text + "','" + cash_amt.Text + "','" + pos_amt.Text + "','" + transfer_amt.Text + "','" + change.Text + "','" + dato + "','" + textBox3.Text + "')";
                        gclass.insert1(query);
                    }
                    else
                    {
                        string query = "INSERT INTO Table_Sales_lump(Sales_ID,Category,Quantity,Item_Value,Amount_Paid,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Sales_Method,POS_ID,Transport,Branch,Cash,POS,Transfer,changes,Dat,phone)VALUES('" + code2.ToString() + "','" + channel.Text + "','" + sum_quantity.ToString() + "','" + textBox1.Text + "','0.00','" + s_date.Text + DateTime.Now.ToLongTimeString() + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + cashier_name.Text + "','" + code2.ToString() + "','" + payment_method.Text + "','" + company_name_search.Text + "','" + sum_discount.ToString() + "','" + invoice_number.Text + "','" + sum_cost.ToString() + "','" + Sales_Method.Text + "','" + pos_id.Text + "','" + transport.Text + "','" + branch.Text + "','" + cash_amt.Text + "','" + pos_amt.Text + "','" + transfer_amt.Text + "','" + change.Text + "','" + dato + "','" + textBox3.Text + "')";
                        gclass.insert1(query);
                    }

                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        string code8 = company_name_search.Text + textBox3.Text + s_date.Text + DateTime.Now.ToLongTimeString() + branch.Text;
                        gclass.insert1("INSERT INTO Table_Buyers(tel_no,Date,Day,Month,Year,Code,Full_Name,Branch)VALUES('" + textBox3.Text + "',now(),'" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code8.ToString() + "','" + cst_name.Text + "','"+ branch.Text +"') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),full_name=values(full_name),tel_no=values(tel_no),day=values(day),year=values(year),month=values(month),full_name=values(full_name)");
                    }

                    // gclass.insert1("INSERT INTO table_customer(Full_Name,Phone)VALUES('" + cst_name.Text + "','" + textBox3.Text + "') ON DUPLICATE KEY UPDATE Full_Name=values(full_name),Phone=values(phone)");
                    gclass.insert1("INSERT INTO Table_In(Invo,Branch)Values('" + invoice_number.Text + "','"+ branch.Text +"')");
                    p_receipt();
                    if (company_name.Text.Contains("Dapni") || company_name.Text.Contains("DAPNI") || company_name.Text.Contains("dapni"))
                    {
                        printDocument1.DocumentName = "Print Document";

                        pageSetupDialog1.Document = printDocument1;

                        PrintDialog printDlg = new PrintDialog();
                        printDlg.AllowSelection = true;
                        printDlg.AllowSomePages = true;
                        ////////////////////////////////////// PRINT /////////////////////////////
                       // if (printDlg.ShowDialog() == DialogResult.OK)
                      //  {
                            for (int i = 0; i < Convert.ToInt32(print_no.Text); i++)
                            {
                                printDocument1.Print();
                            }
                        
                        //   }
                    }
                    else
                    {
                        /////////////////////////////////////////////// START OF WAY-BILL GENERATION ////////////////////////
                        try
                        {
                            Way_bill fm = new Way_bill();

                            fm.day.Text = s_day.Text.ToString();
                            fm.month.Text = s_month.Text.ToString();
                            fm.year.Text = s_year.Text.ToString();
                            fm.time.Text = DateTime.Now.ToLongTimeString();
                            fm.company_name.Text = company_name.Text;
                            fm.company_specialty.Text = company_specialty.Text;
                            fm.company_address.Text = company_address.Text;
                            //  fm.address.Text = company_address.Text;
                            fm.company_telephone.Text = company_telephone.Text;
                            fm.name_of_customer.Text = company_name_search.Text;

                            fm.invoice_no.Text = invoice_number.Text;

                            MySqlDataReader dr9 = gclass.display_in_box("SELECT Company_Address FROM  Table_Customer WHERE Company_Name='" + company_name_search.Text + "' and Branch='" + branch.Text + "'");
                            if (dr9.Read())
                            {
                                fm.address.Text = (string)dr9.GetValue(0).ToString();
                            }

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                int edit = fm.dataGridView1.Rows.Add();
                                fm.dataGridView1.Rows[edit].Cells[0].Value = "001";//dataGridView1.Rows[i].Cells[0].Value;
                                fm.dataGridView1.Rows[edit].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value;
                                fm.dataGridView1.Rows[edit].Cells[2].Value = dataGridView1.Rows[i].Cells[0].Value;
                            }

                            fm.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        /////////////////////////////////////////////// END OF WAY-BILL GENERATION ////////////////////////



                        /////////////////////////////////////////////// START OF INVOICE GENERATION ////////////////////////
                        try
                        {
                            Invoice fm1 = new Invoice();

                            fm1.day.Text = s_day.Text.ToString();
                            fm1.month.Text = s_month.Text.ToString();
                            fm1.year.Text = s_year.Text.ToString();
                            fm1.time.Text = DateTime.Now.ToLongTimeString();
                            fm1.company_name.Text = company_name.Text;
                            fm1.company_specialty.Text = company_specialty.Text;
                            fm1.company_address.Text = company_address.Text;
                            //  fm.address.Text = company_address.Text;
                            fm1.company_telephone.Text = company_telephone.Text;
                            fm1.name_of_customer.Text = company_name_search.Text;

                            fm1.invoice_no.Text = invoice_number.Text;

                            MySqlDataReader dr19 = gclass.display_in_box("SELECT Company_Address FROM  Table_Customer WHERE Company_Name='" + company_name_search.Text + "' and Branch='" + branch.Text + "'");
                            if (dr19.Read())
                            {
                                fm1.address.Text = (string)dr19.GetValue(0).ToString();
                            }

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                int edit = fm1.dataGridView1.Rows.Add();
                                fm1.dataGridView1.Rows[edit].Cells[0].Value = dataGridView1.Rows[i].Cells[0].Value;
                                fm1.dataGridView1.Rows[edit].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value;
                                fm1.dataGridView1.Rows[edit].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value;
                                fm1.dataGridView1.Rows[edit].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value;
                                fm1.dataGridView1.Rows[edit].Cells[4].Value = "0.00";
                                // fm.dataGridView1.Rows[edit].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value;
                            }

                            double sum1 = 0;
                            for (int i = 0; i < fm1.dataGridView1.Rows.Count; ++i)
                            {
                                sum1 += Convert.ToDouble(fm1.dataGridView1.Rows[i].Cells[3].Value);
                                fm1.total.Text = sum1.ToString();
                            }


                            fm1.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        /////////////////////////////////////////////// END OF INVOICE GENERATION ////////////////////////
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
                    company_name_search.SelectedIndex = -1;
                    textBox6.Text = null;
                    receipt_description.Text = null;
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    productname_det.Text = null;
                    textBox1.Text = "0";
                    payment_cash.Checked = false;
                    payment_pos.Checked = false;
                    credit.Checked = false;
                    pos_id.Text = null;
                    transport.Text = null;
                    pos_id.Text = null;

                    cash_amt.Text = "0.00";
                    transfer_amt.Text = "0.00";
                    pos_amt.Text = "0.00";
                    payment_cash.Checked = false;
                    payment_pos.Checked = false;
                    transfer.Checked = false;
                    multiple_mode.Checked = false;
                    credit.Checked = false;

                    MySqlConnection cn21 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn21.Open();
                    String query21 = "SELECT p_id FROM Table_In where Branch='" + branch.Text + "' order by p_id desc limit 1";
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


                    MessageBox.Show("Transaction was successfull and current Stock Updated ...", "POS Intelliscense Says:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox3.Text = null;
                    kast = rnd.Next(50000, 9999999);
                   // pos_id.BorderStyle = BorderStyle.FixedSingle;
                }
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
            Sales_end_user fm = new Sales_end_user();
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

            //change.Text = tendered_cash.Text;
           // txt_amount_paid.Text = tendered_cash.Text;

          /*  if (Convert.ToDecimal(tendered_cash.Text) > 0)
            {
                if (channel.Text.Contains("Credit") || channel.Text.Contains("credit"))
                {
                    try
                    {
                        decimal a = decimal.Parse(tendered_cash.Text);
                        textBox1.Text = Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text).ToString();
                       // txt_amount_paid.Text = tendered_cash.Text;
                      //  change.Text = (Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(tendered_cash.Text)).ToString();
                        //change.Text = (Convert.ToDecimal(change.Text) - Convert.ToDecimal(transport.Text)).ToString();
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show("Tendered Cash must only be Integer");
                        tendered_cash.Text = "0";
                    }
                }
                else
                {
                    try
                    {
                        decimal a = decimal.Parse(tendered_cash.Text);
                        txt_amount_paid.Text = tendered_cash.Text;
                        textBox1.Text = Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(transport.Text).ToString();
                        change.Text = (Convert.ToDecimal(tendered_cash.Text) - Convert.ToDecimal(textBox1.Text)).ToString();
                       // change.Text = (Convert.ToDecimal(change.Text) - Convert.ToDecimal(transport.Text)).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tendered Cash must only be Integer");
                        tendered_cash.Text = "0";
                    }
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            /*Home fm = new Home();
            fm.login_name.Text = cashier_name.Text;
            fm.login_status.Text = status.Text;
            fm.owner.Text = owner.Text;
            fm.status.Text = status.Text;
            fm.Show();
            this.Hide();*/
        }

        private void cst_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = null;
            MySqlDataReader dr = gclass.display_in_box("SELECT tel_no FROM Table_buyers WHERE Full_Name='" + cst_name.Text + "' and Branch='" + branch.Text + "'");
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
                decimal res = Convert.ToDecimal((c * b));
                total.Text = res.ToString();
                charges.Text = res.ToString();
                cost.Text = (b * Convert.ToDecimal(cost_temp.Text)).ToString();
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
                decimal res = Convert.ToDecimal((c * b));
                total.Text = res.ToString();
                charges.Text = res.ToString();
                cost.Text = (b * Convert.ToDecimal(cost_temp.Text)).ToString();
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
            Sales_Method.SelectedIndex = 0;
            pos_id.Enabled = false;
            label8.Text = "POS ID.";

            pos_amt.Text = "0.00";
            transfer_amt.Text = "0.00";

            cash_amt.Enabled = true;
            pos_amt.Enabled = false;
            transfer_amt.Enabled = false;
        }

        private void payment_pos_CheckedChanged(object sender, EventArgs e)
        {
            payment_method.Text = "POS";
            tendered_cash.Enabled = false;
            Sales_Method.SelectedIndex = 2;
            pos_id.Enabled = true;
            label8.Text = "POS ID.";

            cash_amt.Text = "0.00";
            transfer_amt.Text = "0.00";

            cash_amt.Enabled = false;
            pos_amt.Enabled = true;
            transfer_amt.Enabled = false;
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
               // textBox1.Text = Convert.ToInt32(textBox1.Text).ToString();
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

        private void cost_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cost.Text))
            {
                cost.Text = "0";
            }
        }

        private void transport_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(transport.Text))
            {
                transport.Text = "0";
            }


            try
            {
                decimal a = decimal.Parse(transport.Text);
               // txt_amount_paid.Text = tendered_cash.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transport must only be Integer ...");
                transport.Text = "0";
            }

            transport_fare.Text = transport.Text;

            if (Convert.ToDecimal(transport.Text) > 0)
            {
                transport_fare.Visible = true;
                transport_fare_label.Visible = true;
            }
            else
            {
                transport_fare_label.Visible = false;
                transport_fare.Visible = false;
            }

        }

        private void Sales_Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sales_Method.Text.Contains("Credit"))
            {
                txt_label.Text = "Amount Paid";
                label15.Text = "Balance";
            }
            else
            {
                txt_label.Text = "Tendered-Cash";
                label15.Text = "Change";
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cashier_name_Click(object sender, EventArgs e)
        {

        }

        private void company_name_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = company_name_search.Text;
            productname1.SelectedIndex = -1;
            textBox7.Text = "0.00";
            quantity.Text = "0";
            total.Text = "0";
        }

        private void channel_TextChanged(object sender, EventArgs e)
        {
            if (channel.Text.Contains("Indus"))
            {
                panel_receipt.Visible = false;
               /* linkLabel1.Visible = false;
                button_ok.Visible = false;
                titletext.Visible = false;
                dataGridView2.Visible = false;*/
            }
            else
            {
                panel_receipt.Visible = true;
               /* linkLabel1.Visible = true;
                button_ok.Visible = true;
                titletext.Visible = true;
                dataGridView2.Visible = true;*/
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void credit_CheckedChanged(object sender, EventArgs e)
        {
            payment_method.Text = "Credit";
            tendered_cash.Enabled = false;
            Sales_Method.SelectedIndex = 1;
            pos_id.Enabled = false;
            label8.Text = "POS ID.";
        }

        private void productname_det_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_unit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_unit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void transfer_CheckedChanged(object sender, EventArgs e)
        {
            payment_method.Text = "Transfer";
            tendered_cash.Enabled = false;
            Sales_Method.SelectedIndex = 3;
            label8.Text = "Transfer ID.";
            pos_id.Enabled = true;

            pos_amt.Text = "0.00";
            cash_amt.Text = "0.00";

            cash_amt.Enabled = false;
            pos_amt.Enabled = false;
            transfer_amt.Enabled = true;
        }

        private void multiple_mode_CheckedChanged(object sender, EventArgs e)
        {
            payment_method.Text = "Multiple";
            tendered_cash.Enabled = true;
            Sales_Method.SelectedIndex = 0;
            pos_id.Enabled = true;
            label8.Text = "Trans. IDs.";

            cash_amt.Enabled = true;
            pos_amt.Enabled = true;
            transfer_amt.Enabled = true;
        }

        private void cash_amt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cash_amt.Text))
            {
                cash_amt.Text = "0.00";
            }

            try
            {
                decimal a = Convert.ToDecimal(cash_amt.Text);
            }
            catch
            {
                MessageBox.Show("Enter Only Numeric Character ...");
                cash_amt.Text = "0.00";
            }

        }

        private void pos_amt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pos_amt.Text))
            {
                pos_amt.Text = "0.00";
            }

            try
            {
                decimal a = Convert.ToDecimal(pos_amt.Text);
            }
            catch
            {
                MessageBox.Show("Enter Only Numeric Character ...");
                pos_amt.Text = "0.00";
            }

        }

        private void transfer_amt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(transfer_amt.Text))
            {
                transfer_amt.Text = "0.00";
            }

            try
            {
                decimal a = Convert.ToDecimal(transfer_amt.Text);
            }
            catch
            {
                MessageBox.Show("Enter Only Numeric Character ...");
                transfer_amt.Text = "0.00";
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            /*//////////////////////////////////////////////// START OF LOYALTY STUFF /////////////////////////
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT count(p_id) from table_sales_confirmed where Phone='" + textBox3.Text + "'", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                    {
                        no_of_appearance.Text = (string)dr.GetValue(0).ToString();
                    }
                    else
                    {
                        no_of_appearance.Text = "Nil";
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close(); cn.Dispose();
                    cmd.Dispose();
                    dr.Close(); dr.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            ////////////////////////////////////////////////// END OF LOYALTY STUFF /////////////////////////*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    MessageBox.Show(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    MessageBox.Show(dataGridView1.Rows[i].Cells[7].Value.ToString());
                   /* if(string.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[6].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[6].Value = "0.00";
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
