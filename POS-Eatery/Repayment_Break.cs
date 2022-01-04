using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace POS_Eatery
{
    public partial class Repayment_Break : Form
    {
        public Repayment_Break()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button_print_Click(object sender, EventArgs e)
        {
             DialogResult dr = MessageBox.Show("Do you Really want to Delete the Selected/ Displayed Sales? \n \n The Record will be Permanently Deleted from the Database! \n \n  Click Yes to Confirm Delete or No to Abort...", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (dr == DialogResult.Yes)
             {
                 bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                 if (bb == true)
                 {
                      
                    /* string url;
                     string s_t = "Delete Note";
                    // string receiver = "08033431320,08037600192,08034371255,08131234406";
                     string body = "This is to inform you that Confirmed Sales worth of NGN" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + ".00 was deleted by " + login_name.Text + " on the " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToLongTimeString() + ". From: Sale's Delete Monitoring Robot ... on " + branch.Text.ToUpper();
                     url = "https://smsexperience.com/api/sms/sendsms?username=dtm123&password=dtm@solutions&sender=" + s_t.TrimEnd() + "&recipient=" + receive.Text.TrimEnd() + "@@&message=" + body.TrimEnd() + "";

                     HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                     HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                     System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());*/
                     try
                     {
                        /* string responseString = respStreamReader.ReadToEnd();
                         respStreamReader.Close();
                         myResp.Close();*/
                         ///////
                         Random rnd = new Random();
                         string a = rnd.Next(1, 5000000).ToString();

                         string code1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + a;
                         string code = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);

                         if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Contains("Gas") || dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Contains("gas") || dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Contains("GAS"))
                         {
                             gclass.Update1("Update Table_Stock_Inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "' WHERE Product_Name='Gas' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");
                         }
                         else
                         {
                             gclass.Update1("Update Table_Stock_Inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "' WHERE Product_Name='" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "' and branch='" + branch.Text + "' ORDER BY P_id DESC LIMIT 1");

                         }

                         gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Date,Day,Month,Year,Code,Purpose,Branch)VALUES('" + dataGridView1.SelectedRows[0].Cells[3].Value + "','Product','" + dataGridView1.SelectedRows[0].Cells[3].Value + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + Convert.ToString(code1) + "','Returned Sales','"+ branch.Text +"')");

                        //  gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',cash=cash-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[6].Value) + "',POS=POS-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[7].Value) + "',transfer=transfer-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[8].Value) + "',Amount_Paid=Amount_Paid-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Cost='0.00' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "' and branch='" + branch.Text + "'");

                        if (payment_method.Text=="Cash")
                        {
                            gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',cash=cash-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Amount_Paid=Amount_Paid-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "' and branch='" + branch.Text + "'");
                        }
                        else if(payment_method.Text=="POS")
                        {
                            gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',POS=POS-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Amount_Paid=Amount_Paid-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "' and branch='" + branch.Text + "'");
                        }
                        else if (payment_method.Text=="Transfer")
                        {
                            gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',transfer=transfer-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Amount_Paid=Amount_Paid-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "' and branch='" + branch.Text + "'");
                        }
                        else if (payment_method.Text == "Multiple")
                        {
                            gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',cash=cash-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Amount_Paid=Amount_Paid-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "' and branch='" + branch.Text + "'");
                        }
                        else if (payment_method.Text == "Credit")
                        {
                            gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "' and branch='" + branch.Text + "'");
                        }

                        gclass.Delete1("DELETE FROM Table_Sales_Confirmed WHERE Code='" + code.ToString() + "' and branch='" + branch.Text + "'");
                        // dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
                        MessageBox.Show("Selected Sale's Successfully Deleted...", " Message Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                         //////
                     }
                     catch (Exception ex)
                     {
                         // MessageBox.Show("Successfully Sent SMS Notification/ Message ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         MessageBox.Show(ex.Message);
                     }
                     finally
                     {
                        /* myResp.Close();
                         respStreamReader.Close();
                         respStreamReader.Dispose();
                         myResp.Close();*/
                     }
                     /////////////////////////// SEND SMS//////////////////////////////
                     string url;
                     string s_t = "Delete Note";
                     // string receiver = "08033431320,08037600192,08034371255,08131234406";
                     string body = "This is to inform you that Confirmed Sales worth of NGN" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + ".00 was deleted by " + login_name.Text + " on the " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToLongTimeString() + ". From: Sale's Delete Monitoring Robot ... on " + branch.Text.ToUpper();
                     url = "https://smsexperience.com/api/sms/dnd-fallback?username=dtm123&password=dtm@solutions&sender=" + s_t.TrimEnd() + "&recipient=" + receive.Text.TrimEnd() + "@@&message=" + body.TrimEnd() + "";

                     HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                     HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                     System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                     try
                     {
                         string responseString = respStreamReader.ReadToEnd();
                         respStreamReader.Close();
                         myResp.Close();
                         MessageBox.Show("SMS Notification Successfully Sent ...", " Message Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                         ///////
                     }
                     catch (Exception ex)
                     {
                         // MessageBox.Show(ex.Message);
                     }
                     finally
                     {
                         myResp.Close();
                         respStreamReader.Close();
                         respStreamReader.Dispose();
                         myResp.Close();
                     }
                     dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
                     //////////////////////////////////////////////////////////
                     //////////////////////////////////////////////////////////
                 }

                 else
                 {
                     MessageBox.Show("Unable to Connect to Internet ...");
                 }
             }

           /* Random rnd = new Random();
            string a = rnd.Next(1, 5000000).ToString();

            string code1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + a;
            string code = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);

            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Contains("Gas") || dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Contains("gas") || dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Contains("GAS"))
            {
                gclass.Update1("Update Table_Stock_Inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "' WHERE Product_Name='Gas' ORDER BY P_id DESC LIMIT 1");
            }
            else
            {
                gclass.Update1("Update Table_Stock_Inventory_Summary SET Quantity_In=Quantity_In+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Quantity_Left=Quantity_Left+'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "' WHERE Product_Name='" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "' ORDER BY P_id DESC LIMIT 1");
           
            }
            
            gclass.insert1("INSERT INTO Table_Stock_inventory(Product_Name,Category,Quantity_In,Date,Day,Month,Year,Code,Purpose)VALUES('" + dataGridView1.SelectedRows[0].Cells[3].Value + "','Product','" + dataGridView1.SelectedRows[0].Cells[3].Value + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + Convert.ToString(code1) + "','Returned Sales')");
           gclass.Update1("UPDATE Table_Sales_Lump SET Quantity=Quantity-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value) + "',Item_Value=Item_Value-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Amount_Paid=Amount_Paid-'" + Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value) + "',Cost='0.00' WHERE Sales_ID='" + Convert.ToString(textBox1.Text) + "'");
            
           gclass.Delete("DELETE FROM Table_Sales_Confirmed WHERE Code='" + code.ToString() + "'");
           dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);*/
       //  gclass.Delete("DELETE FROM Table_Sales_Lump WHERE Quantity<=0 OR Item_Value<=0");
        }

        private void Repayment_Break_Load(object sender, EventArgs e)
        {
            gclass.Expand_Database("UPDATE table_sales_lump set amount_paid=cash+pos+transfer");
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT number from table_number order by p_id desc limit 1", cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    receive.Text = (string)dr.GetValue(0).ToString();
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
    }
}
