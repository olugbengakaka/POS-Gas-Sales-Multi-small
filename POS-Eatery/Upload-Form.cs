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
    public partial class Upload_Form : Form
    {
        public Upload_Form()
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
        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you Really want to Exit the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (dr == DialogResult.Yes)
           // {
                this.Close();
              //  Application.Exit();
           // }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           // DialogResult dr = MessageBox.Show("Do you Really want to Exit the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (dr == DialogResult.Yes)
          //  {
                this.Close();
              //  Application.Exit();
          //  }
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home fm = new Home();
            fm.login_status.Text = status.Text;
            fm.status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Home fm = new Home();
            fm.login_name.Text = users.Text;
            fm.login_status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void Upload_Form_Load(object sender, EventArgs e)
        {
            gclass.Expand_Database("update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day)");

            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);update table_expenditure set dat=concat(year,'-',month,'-',day);");
            
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "/images/error.png");
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "/images/lock.ico");
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "/images/arrow2.png");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/images/student1.jpg");
            panel1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/portal.png");

            gclass.treat_panel_banner(panel2);
            gclass.treat_panel_main(panel1);
            gclass.treat_strip(statusStrip1);
            gclass.treat_groupbox(groupBox1);

           

            /* string a = null;
             gclass.Delete1("ALTER TABLE  `table_stock_inventory_summary` DROP  `p_id`;ALTER TABLE  `table_stock_inventory_summary` ADD  `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;");
             MySqlDataReader dr = gclass.display_in_box("Select max(p_id) from table_stock_inventory_summary");//DELETE FROM Table_stock_inventory_summary WHERE p_id<20;
             try
             {
                 if (dr.Read())
                 {
                     a = (string)dr.GetValue(0).ToString();
                 }
                 if (a != null && Convert.ToInt32(a) >= 105)
                 {
                     gclass.Delete1("DELETE FROM Table_stock_inventory_summary WHERE p_id<=25 and branch='"+ branch.Text +"';");
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 dr.Close(); dr.Dispose();
             }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
              gclass.get_on(webBrowser1, g_school);
                DialogResult dr27 = MessageBox.Show("Online and Offline Database Synchronization can take Several Hours to Days to complete based on the number of Modules Selected.\n \nFor more Efficiency and Data Integrity, It is advisable to only Select Module(s) that need synchronization with Online Database ... \n \nDo you really want to Upload and Synchronize with Online Database ? \n \n Click Yes to Continue Or No to Cancel and Re-Select Module(s) ...", "  Message from School-MS Online Monitoring Server: ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr27 == DialogResult.Yes)
                {
                    // ########################################33333 START OF UPLOADING STUFF  ###########################################

                    try
                    {
                        str200 = Convert.ToString(webBrowser1.Document.GetElementById("content").OuterText).Trim().TrimEnd();

                        if (str200 != "")
                        {

                        //ALTER TABLE  `table_repayment` ADD  `Cash` DECIMAL( 65, 2 ) NOT NULL AFTER  `Branch` , ADD  `POS` DECIMAL(65, 2) NOT NULL AFTER  `Cash` ,ADD  `Transfer` DECIMAL(65, 2) NOT NULL AFTER  `POS`
                        try
                        {
                            MySqlConnection cn = new MySqlConnection(str200);
                            cn.Open();
                            //string query = "ALTER TABLE  `table_sales_lump` ADD  `Cash` DECIMAL( 65, 2 ) NOT NULL ,ADD  `POS` DECIMAL(65, 2) NOT NULL,ADD  `Transfer` DECIMAL(65, 2) NOT NULL,ADD  `Changes` DECIMAL(65, 2) NOT NULL";
                            string query = "ALTER TABLE  `table_sales_lump` ADD  `phone` VARCHAR( 255 ) NOT NULL;ALTER TABLE  `table_sales_confirmed` ADD  `phone` VARCHAR( 255 ) NOT NULL;";
                            MySqlCommand cmd = new MySqlCommand(query, cn);
                            cmd.ExecuteNonQuery();
                           // MessageBox.Show("Database Expansion was Successful ...");
                            cn.Close();
                        }
                        catch (Exception ex)
                        {
                            //       MessageBox.Show(ex.Message);
                        }

                        try
                        {
                            MySqlConnection cn = new MySqlConnection(str200);
                            cn.Open();
                            string query = "ALTER TABLE  `table_repayment` ADD  `Cash` DECIMAL( 65, 2 ) NOT NULL AFTER  `Branch` , ADD  `POS` DECIMAL(65, 2) NOT NULL AFTER  `Cash` ,ADD  `Transfer` DECIMAL(65, 2) NOT NULL AFTER  `POS`";
                            MySqlCommand cmd = new MySqlCommand(query, cn);
                            cmd.ExecuteNonQuery();
                            // MessageBox.Show("Database Expansion was Successful ...");
                            cn.Close();
                        }
                        catch (Exception ex)
                        {
                            //       MessageBox.Show(ex.Message);
                        }

                        // SYNCHRONIZATION FOR DAILY METER READING IN KG ************************************************************8
                        if (daily_meter_reading.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM TABLE_CLOSING_STOCK_GAS where Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' AND branch='" + branch.Text + "'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO TABLE_CLOSING_STOCK_GAS(pump_1_meter_1,pump_1_meter_2,pump_2_meter_1,pump_2_meter_2,pump_3_meter_1,pump_3_meter_2,pump_4_meter_1,pump_4_meter_2,pump_5_meter_1,pump_5_meter_2,pump_6_meter_1,pump_6_meter_2,Date,Day,Month,Year,Time,Registered_By,Code,Branch,Total,Verdict,Sales_Report)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[22].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[23].Value.ToString() + "') ON DUPLICATE KEY UPDATE pump_1_meter_1=values(pump_1_meter_1),pump_1_meter_2=values(pump_1_meter_2),code=values(code),pump_2_meter_1=values(pump_2_meter_1),pump_2_meter_2=values(pump_2_meter_2),pump_3_meter_1=values(pump_3_meter_1),pump_3_meter_2=values(pump_3_meter_2),pump_4_meter_1=values(pump_4_meter_1),pump_4_meter_2=values(pump_4_meter_2),pump_5_meter_1=values(pump_5_meter_1),pump_5_meter_2=values(pump_5_meter_2),pump_6_meter_1=values(pump_6_meter_1),pump_6_meter_2=values(pump_6_meter_2),registered_by=values(registered_by),branch=values(branch),total=values(total),sales_report=values(sales_report),verdict=values(verdict)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                       //       MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_Sales *******************************************************************8
                            if (table_sales.Checked == true)
                            {
                                // UPLOADING TO TABLE_SALES_CONFIRM
                                gclass.display_in_dgv("SELECT* FROM table_sales_confirmed WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                    string query = "INSERT INTO Table_Sales_confirmed(Product_Name,Category,Quantity,Price,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Branch,phone,Loyalty)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[22].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[24].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[25].Value.ToString() + "') ON DUPLICATE KEY UPDATE customer_name=values(customer_name),quantity=values(quantity),product_name=values(product_name),Category=values(category),Price=values(price),amount_paid=values(amount_paid),balance=values(balance),Date=values(date),day=values(day),month=values(month),year=values(year),employee=values(employee),code=values(code),payment_method=values(payment_method),discount=values(discount),Receipt_No=values(Receipt_No),Phone=values(Phone),Loyalty=values(Loyalty)";
                                   // string query = "INSERT INTO Table_Sales_confirmed(Product_Name,Category,Quantity,Price,Item_Value,Date,Day,Month,Year,Employee,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Branch,phone)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[22].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[24].Value.ToString() + "') ON DUPLICATE KEY UPDATE customer_name=values(customer_name),quantity=values(quantity),product_name=values(product_name),Category=values(category),Price=values(price),amount_paid=values(amount_paid),balance=values(balance),Date=values(date),day=values(day),month=values(month),year=values(year),employee=values(employee),code=values(code),payment_method=values(payment_method),discount=values(discount),Receipt_No=values(Receipt_No),Phone=values(Phone)";
                                    MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        // MessageBox.Show(ex.Message);
                                    }
                                }
                                ////// UPLOADING TO TABLE_LOYALTY
                                gclass.display_in_dgv("SELECT* FROM table_loyalty where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_sales_loyalty(times,amount,Branch,Code)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "') ON DUPLICATE KEY UPDATE times=values(times),amount=values(amount),branch=values(branch),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                                ////// UPLOADING TO TABLE_SALES_LUMP
                                gclass.display_in_dgv("SELECT* FROM table_sales_lump WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO Table_Sales_lump(Sales_ID,Quantity,Price,Item_Value,Amount_Paid,Balance,Date,Day,Month,Year,Employee,Short_Code,Minute,Second,Category,Code,Payment_Method,Customer_Name,Discount,Receipt_No,Cost,Sales_Method,POS_ID,Transport,Branch,CASH,POS,TRANSFER,CHANGES,phone)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[22].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[23].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[24].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[25].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[26].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[27].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[28].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[29].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[31].Value.ToString() + "') ON DUPLICATE KEY UPDATE Quantity=values(quantity),item_value=values(item_value),amount_paid=values(amount_paid)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }

                                ////// UPLOADING TO TABLE_Repayment
                                gclass.display_in_dgv("SELECT* FROM table_repayment WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO Table_repayment(Sales_ID,Amount_Paid,Date,Day,Month,Year,Code,Registered_By,Customer_Name,Receipt_No,Branch,Cash,POS,Transfer)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "') ON DUPLICATE KEY UPDATE Sales_id=values(sales_id),amount_paid=values(amount_paid)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }

                            }





                            // SYNCHRONIZATION FOR Table_Expenditure and expenditure_list ************************************************************8
                            if (table_expenditure.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_expenditure WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        //  string query = "INSERT INTO table_sales_summary(p_id,Product_Name,Quantity,Price,Item_Value,Amount_Paid,Balance,Date,Day,Month,Year,Employee,Short_Code,Minute,Second,Category,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),quantity=values(quantity),price=values(price),item_value=values(item_value),amount_paid=values(amount_paid),balance=values(balance),date=values(date),day=values(day),month=values(month),year=values(year),employee=values(employee),short_code=values(short_code),minute=values(minute),second=values(second),category=values(category),code=values(code),payment_method=values(payment_method),customer_name=values(customer_name),discount=values(discount),Receipt_No=values(Receipt_No)";
                                        string query = "INSERT INTO Table_Expenditure(Expenses,Amount,Note,Code,Date,Day,Month,Year,Registered_By,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "') ON DUPLICATE KEY UPDATE expenses=values(expenses),amount=values(amount),note=values(note),code=values(code),date=values(date),registered_by=values(registered_by)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }

                                ///////////// second phase for expenditure list
                                gclass.display_in_dgv("SELECT* FROM table_expenditure_list where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        //  string query = "INSERT INTO table_sales_summary(p_id,Product_Name,Quantity,Price,Item_Value,Amount_Paid,Balance,Date,Day,Month,Year,Employee,Short_Code,Minute,Second,Category,Code,Payment_Method,Customer_Name,Discount,Receipt_No)VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),quantity=values(quantity),price=values(price),item_value=values(item_value),amount_paid=values(amount_paid),balance=values(balance),date=values(date),day=values(day),month=values(month),year=values(year),employee=values(employee),short_code=values(short_code),minute=values(minute),second=values(second),category=values(category),code=values(code),payment_method=values(payment_method),customer_name=values(customer_name),discount=values(discount),Receipt_No=values(Receipt_No)";
                                        string query = "INSERT INTO Table_Expenditure_List(Expenses,Date,Code,Registered_By,Branch)values('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "') ON DUPLICATE KEY UPDATE Expenses=values(Expenses)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }

                            }


                            // SYNCHRONIZATION FOR Table_Stoch_Inventory ************************************************************8
                            if (table_stock_inventory.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_stock_inventory WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_stock_inventory(Product_Name,Category,Quantity_In,Quantity_Out,Quantity_Left,Unit,Purpose,Reg_By,Date,Day,Month,Year,Code,Cost,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),category=values(category),quantity_in=values(quantity_in),quantity_out=values(quantity_out),quantity_left=values(quantity_left),unit=values(unit),purpose=values(purpose),reg_by=values(reg_by),date=values(date),day=values(day),month=values(month),year=values(year),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }

                                /////// SECOND PHASE FOR STOCK_INVENTORY_SUMMARY
                                gclass.display_in_dgv("SELECT* FROM table_stock_inventory_summary WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_stock_inventory_summary(Product_Name,Category,Quantity_In,Quantity_Out,Quantity_Left,Unit,Reg_By,Date,Day,Month,Year,Price,Code,Cost,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),category=values(category),quantity_in=values(quantity_in),quantity_out=values(quantity_out),quantity_left=values(quantity_left),unit=values(unit),reg_by=values(reg_by),date=values(date),day=values(day),month=values(month),year=values(year),price=values(price),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }

                            }


                            // SYNCHRONIZATION FOR Table_Employee ************************************************************8
                            if (table_employee.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_employee where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_employee(name,address,tel_no,position,Qualification,Guarantor_Name,Guarantor_Address,Guarantor_Relationship,Date,Day,Month,Year,Reg_By,Code,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "') ON DUPLICATE KEY UPDATE name=values(name),address=values(address),tel_no=values(tel_no),position=values(position),qualification=values(qualification),guarantor_name=values(guarantor_name),guarantor_address=values(guarantor_address),guarantor_relationship=values(guarantor_relationship),date=values(date),day=values(day),month=values(month),year=values(year),Reg_By=values(Reg_By),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_Login ************************************************************8
                            if (table_login.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_login where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_login(first_name,last_name,current_post,login_status,user_name,password,full_name,Code,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "') ON DUPLICATE KEY UPDATE first_name=values(first_name),last_name=values(last_name),current_post=values(current_post),login_status=values(login_status),user_name=values(user_name),password=values(password),full_name=values(full_name),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_New_Product ************************************************************8
                            if (table_new_product.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_new_product where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_new_product(Product_name,Category,Price,Reg_By,Date,unit,Code,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),category=values(category),price=values(price),reg_by=values(reg_by),date=values(date),unit=values(unit),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_buyers ************************************************************8
                            if (table_buyers.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_buyers WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_buyers(tel_no,Date,Day,Month,Year,Code,Full_Name,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),date=values(date),day=values(day),month=values(month),year=values(year),code=values(code),full_name=values(full_name)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_customize ************************************************************8
                            if (table_customize.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_customize where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_customize(company_name,company_specialty,company_address,Company_Email,Company_Telephone,Code,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "') ON DUPLICATE KEY UPDATE company_name=values(company_name),company_specialty=values(company_specialty),company_address=values(company_address),company_email=values(company_email),company_Telephone=values(company_telephone),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                            // SYNCHRONIZATION FOR Table_Price_Product ************************************************************8
                            if (table_price_product.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_price_product where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_price_product(product_name,price,reg_by,Date,Code,Category,Cost,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "') ON DUPLICATE KEY UPDATE product_name=values(product_name),price=values(price),reg_by=values(reg_by),date=values(date),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_Unit ************************************************************8
                            if (table_unit.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_unit where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_unit(Unit,Conversion,reg_by,Date,Code,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "') ON DUPLICATE KEY UPDATE unit=values(unit),conversion=values(conversion),reg_by=values(reg_by),date=values(date),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_Customer ************************************************************8
                            if (table_customer.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_customer where branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                       // string query = "INSERT INTO table_customer(Company_Name,Company_Address,Company_Phone,Company_Email,Company_Website,Contact_Name,Contact_Address,Contact_Phone,Contact_Email,Contact_Website,Guarantor_Name,Guarantor_Address,Guarantor_Info,Code,Date,Day,Month,Year,Rate,Reg_Status,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[22].Value.ToString() + "') ON DUPLICATE KEY UPDATE contact_name=values(contact_name),contact_phone=values(contact_phone),date=values(date)";
                                        string query = "INSERT INTO table_customer(Company_Name,Company_Address,Company_Phone,Company_Email,Company_Website,Contact_Name,Contact_Address,Contact_Phone,Contact_Email,Contact_Website,Guarantor_Name,Guarantor_Address,Guarantor_Info,Date,Day,Month,Year,Reg_By,Code,Rate,Reg_Status,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[11].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[13].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[14].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[16].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[17].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[18].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[19].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[20].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[21].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[22].Value.ToString() + "') ON DUPLICATE KEY UPDATE contact_name=values(contact_name),contact_phone=values(contact_phone),date=values(date)";
                                    
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            // SYNCHRONIZATION FOR Table_Act ************************************************************8
                            if (table_act.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_act", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_act(Act,School_ID,Code)VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "') ON DUPLICATE KEY UPDATE act=values(act),school_id=values(school_id),code=values(code)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }

                            if (table_in.Checked == true)
                            {
                                gclass.display_in_dgv("SELECT* FROM table_in WHERE Day='" + date.Value.Day + "' AND Month='" + date.Value.Month + "' AND Year='" + date.Value.Year + "' and branch='"+ branch.Text +"'", dataGridView1);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    try
                                    {
                                        MySqlConnection cn = new MySqlConnection(str200);
                                        cn.Open();
                                        string query = "INSERT INTO table_in(invo,Date,Day,Month,Year,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "') ON DUPLICATE KEY UPDATE p_id=values(p_id),invo=values(invo),date=values(date),day=values(day),month=values(month),year=values(year)";
                                        MySqlCommand cmd = new MySqlCommand(query, cn);
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        //      MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                            MessageBox.Show("Synchronization was successful ...");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                                       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

        
