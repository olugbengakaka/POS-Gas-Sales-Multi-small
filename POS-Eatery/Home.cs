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
using System.IO;

namespace POS_Eatery
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
       
        
       // bool proceed = false;
       /* private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Now.Second <= 5)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 5 && DateTime.Now.Second <= 10)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 10 && DateTime.Now.Second <= 15)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 15 && DateTime.Now.Second <= 20)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 20 && DateTime.Now.Second <= 25)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 25 && DateTime.Now.Second <= 30)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 30 && DateTime.Now.Second <= 35)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 35 && DateTime.Now.Second <= 40)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 40 && DateTime.Now.Second <= 45)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 45 && DateTime.Now.Second <= 50)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 50 && DateTime.Now.Second <= 55)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 55 && DateTime.Now.Second <= 60)
                {
                    this.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }*/

        private void Home_Load(object sender, EventArgs e)
        {
            panel_ax.Visible = true;

            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_config_percentage` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `config_percent` varchar(255) NOT NULL, `kg_to_litre` varchar(255) NOT NULL, `L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, `Branch` varchar(255) NOT NULL,  PRIMARY KEY(`p_id`), UNIQUE KEY `Branch` (`Branch`)) ENGINE = MyISAM DEFAULT CHARSET = latin1 AUTO_INCREMENT = 1;         ");

            gclass.Expand_Database("ALTER TABLE  `table_repayment` ADD  `Cash` DECIMAL( 65, 2 ) NOT NULL AFTER  `Branch` ,ADD  `POS` DECIMAL(65, 2) NOT NULL AFTER  `Cash` ,ADD  `Transfer` DECIMAL(65, 2) NOT NULL AFTER  `POS`");

            MySqlConnection cn100 = new MySqlConnection();
            MySqlCommand cmd100 = new MySqlCommand();
            MySqlConnection cn120 = new MySqlConnection();
            MySqlCommand cmd120 = new MySqlCommand();

           // timer1.Start();
            try
            {
                this.BackgroundImage = Image.FromFile("C:/POST/images/img1.jpg");
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }


            //################################## START OF CHECKING AND REPARING CRASHED TABLE ###################################################
            MySqlDataReader dr = gclass.display_in_box1("show table status where comment like '%crash%'", cn100, cmd100);
            try
            {
                if (dr.Read())
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
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                cn100.Close(); cn100.Dispose();
                cmd100.Dispose();
                dr.Close(); dr.Dispose();
            }
            //################################## END OF CHECKING AND REPARING CRASHED TABLE ###################################################



            gclass.display_in_box_server_t(s_day, s_month, s_year, s_date, s_time);

            MySqlDataReader dr17 = gclass.display_in_box1("SELECT* FROM Table_mr", cn100, cmd100);

            try
            {
                if (dr17.Read())
                {
                    g_school.Text = (string)dr17.GetValue(3).ToString();
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


            bool det = false;
         ///////////////////////////////////// START OF DETERMINATION ////////////////////////////////////////////
            MySqlDataReader dr9 = gclass.display_in_box1("SELECT* FROM Table_ma", cn100, cmd100);
            try
            {
                if (dr9.Read())
                {
                    det = true;
                }
                else
                {
                    det = false;
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
                dr9.Close(); dr9.Dispose();
            }






            if (det == false)
            {
                Application.Run(new GP());
            }
            else
            {
                try
                {
                    MySqlDataReader dr7 = gclass.display_in_box("SELECT* FROM Table_stock_inventory_summary WHERE Day='" + s_day.Text + "' and Month='" + s_month.Text + "' and Year='" + s_year.Text + "' and Branch='" + branch.Text + "'");
                    if (dr7.Read())
                    {
                       /* // ready = true;
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Login1());
                        //  fm.Hide();*/
                    }
                    else
                    {
                        /* Application.EnableVisualStyles();
                         Application.SetCompatibleTextRenderingDefault(false);*/
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
                        // Application.Run(new Form2());
                        Form2 fm = new Form2();
                        fm.branch.Text = branch.Text;
                        fm.Show();
                      //  this.Hide();


                    }
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show(ex.Message);
                    // MessageBox.Show("Kindly Re-Login and ensure that both the Server and Routers are Switch \n \n On ... ", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         ////////////////////////////////////  END OF DETERMINATION   ///////////////////////////////////////////
           


            ////////////////////////////////////////////////////////////////////////////
            

            //////////////////////////////////////////////////////////////////////////////////////
            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_enhance` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Date` date NOT NULL,`L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,PRIMARY KEY (`p_id`), UNIQUE KEY `Date` (`Date`))");
            MySqlDataReader dr1 = gclass.display_in_box1("SELECT* FROM Table_enhance where date=curdate()", cn120, cmd120);
            try
            {
                if (dr1.Read())
                {

                }
                else
                {
                    // MessageBox.Show(" Not Exist ...");
                    try
                    {
                        if (!Directory.Exists("C:\\pp"))
                        {
                            Directory.CreateDirectory("C:\\pp");
                        }

                        Random rnd = new Random();
                        string asb = rnd.Next(1234567, 7654321).ToString() + DateTime.Now.Day.ToString();
                        string file2 = "C:\\pp/bku_" + asb + ".sql";
                        MySqlConnection cn6 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn6.Open();
                        if (File.Exists(file2))
                        {
                            File.Delete(file2);
                        }
                        MySqlCommand cmd = new MySqlCommand();
                        MySqlBackup mb = new MySqlBackup(cmd);
                        cmd.Connection = cn6;
                        mb.ExportInfo.AddCreateDatabase = true;
                        mb.ExportInfo.ExportTableStructure = true;
                        mb.ExportInfo.ExportRows = true;
                        // mb.ExportInfo.FileName = file;
                        mb.ExportToFile(file2);
                        string rbd = "ALTER TABLE `table_buyers` DROP `p_id`;ALTER TABLE `table_buyers` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_in` DROP `p_id`;ALTER TABLE `table_in` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_new_product` DROP `p_id`;ALTER TABLE `table_new_product` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales` DROP `p_id`;ALTER TABLE `table_sales` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales_confirmed` DROP `p_id`;ALTER TABLE `table_sales_confirmed` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales_lump` DROP `p_id`;ALTER TABLE `table_sales_lump` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales_summary` DROP `p_id`;ALTER TABLE `table_sales_summary` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_stock_inventory` DROP `p_id`;ALTER TABLE `table_stock_inventory` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_stock_inventory_summary` DROP `p_id`;ALTER TABLE `table_stock_inventory_summary` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_customer` DROP `p_id`;ALTER TABLE `table_customer` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_repayment` DROP `p_id`;ALTER TABLE `table_repayment` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_employee` DROP `p_id`;ALTER TABLE `table_employee` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_expenditure_list` DROP `p_id`;ALTER TABLE `table_expenditure_list` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_expenditure` DROP `p_id`;ALTER TABLE `table_expenditure` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_login` DROP `p_id`;ALTER TABLE `table_login` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_customize` DROP `p_id`;ALTER TABLE `table_customize` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_enhance` DROP `p_id`;ALTER TABLE `table_enhance` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;";
                        gclass.insert1(rbd);
                        gclass.Expand_Database("INSERT INTO Table_Enhance(Date)VALUES(curdate()) ON DUPLICATE KEY UPDATE date=values(date)");
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                cn120.Close(); cn120.Dispose();
                cmd120.Dispose();
                dr1.Close(); dr1.Dispose();
            }

            string cd = "Cash to Bank" + cmb_school.Text;
            gclass.Expand_Database("INSERT into table_expenditure_list(Expenses,Date,Code,Registered_By,Branch)VALUES('Cash to Bank','" + DateTime.Now + "','" + cd + "','AUTO INSERT','" + cmb_school.Text + "')");

            backgroundWorker1.RunWorkerAsync();

            panel_ax.Visible = false;
            ////////////////////////////////////////////////////////////////////////////

        }

        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Do you really want to Close COMGAS Application ...", "COMGAS Application Intelligence Says:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Change_Password fm = new Change_Password();
            fm.branch.Text = cmb_school.Text;
            fm.user_name.Text = login_name.Text;
            fm.owner.Text = owner.Text;
            fm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Super") || status.Text.Contains("Admin"))
            {
                Staff_Registration fm = new Staff_Registration();
                fm.branch.Text = cmb_school.Text;
                fm.users.Text = login_name.Text;
                fm.status.Text = login_status.Text;
                fm.owner.Text = owner.Text;
                fm.ShowDialog();
               // //this.Hide();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Inventory_Product fm = new Inventory_Product();
            fm.branch.Text = cmb_school.Text;
            fm.status.Text = status.Text;
            fm.owner.Text = owner.Text;
            fm.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                if (status.Text.Contains("Super"))
                {
                    User_Form fm = new User_Form();
                    fm.branch.Text = cmb_school.Text;
                    fm.loginstatus.Items.Clear();
                    fm.owner.Text = owner.Text;
                    fm.loginstatus.Items.Add("Sales Person");
                    fm.loginstatus.Items.Add("Admin");
                    fm.loginstatus.Items.Add("Super User");
                    fm.ShowDialog();
                }
                else if (status.Text.Contains("Admin"))
                {
                    User_Form fm = new User_Form();
                    fm.branch.Text = cmb_school.Text;
                    fm.loginstatus.Items.Clear();
                    fm.loginstatus.Items.Add("Sales Person");
                    fm.loginstatus.Items.Add("Admin");
                    fm.ShowDialog();
                }
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            User_View fm = new User_View();
            fm.owner.Text = owner.Text;
            fm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Manage_Price fm = new Manage_Price();
                 fm.status.Text = status.Text;
                 fm.branch.Text = cmb_school.Text;
                 fm.owner.Text = owner.Text;
                 if (fm.status.Text.Contains("Super"))
                 {
                     fm.cost_button.Visible = true;
                     fm.cost_label.Visible = true;
                    // fm.owner.Text = owner.Text;
                     fm.cost_price.Visible = true;
                 }
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Register_Product fm = new Register_Product();
                fm.branch.Text = cmb_school.Text;
                fm.owner.Text = owner.Text;
                fm.ShowDialog();
            }
             else
            {
                gclass.message_reject();
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Stock_Add fm = new Stock_Add();
                fm.status.Text = status.Text;
                fm.branch.Text = cmb_school.Text;
                fm.owner.Text = owner.Text;

                fm.s_day.Text = s_day.Text;
                fm.s_month.Text = s_month.Text;
                fm.s_year.Text = s_year.Text;
                fm.s_date.Text = s_date.Text;
                fm.s_time.Text = s_time.Text;

                if (fm.status.Text.Contains("Super"))
                {
                    fm.cost_button.Visible = true;
                    fm.cost_label.Visible = true;
                    fm.cost_price.Visible = true;
                }
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sales_end_user fm = new Sales_end_user();
            fm.branch.Text = cmb_school.Text;
            fm.cashier_name.Text = login_name.Text;
            fm.channel.Text = "End User";
           // fm.label1_unit.Text = "KG";
            fm.label1_unit.Enabled = false;
            fm.label17.Visible = false;
            fm.company_name_search.Visible = false;
            fm.Sales_Method.SelectedIndex = 0;
            fm.Sales_Method.Visible = true;
            fm.owner.Text = owner.Text;
            fm.credit.Visible = false;
            fm.label6.Visible = false;
            fm.Sales_Method.Visible = false;

            fm.s_day.Text = s_day.Text;
            fm.s_month.Text = s_month.Text;
            fm.s_year.Text = s_year.Text;
            fm.s_date.Text = s_date.Text;
            fm.s_time.Text = s_time.Text;

           // fm.label6.Visible = true;
           // fm.Sales_Method.SelectedIndex = 0;
           // fm.Sales_Method.Enabled = false;
            fm.status.Text = status.Text;
            fm.ShowDialog();
            //this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                try
                {

                    bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                    if (bb == true)
                    {
                        if (login_status.Text.Contains("Admin") || login_status.Text.Contains("Super"))
                        {
                            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_act");
                            if (dr.Read())
                            {
                                SMS_Text fm = new SMS_Text();
                                fm.users.Text = login_name.Text;
                                fm.branch.Text = cmb_school.Text;
                                fm.owner.Text = owner.Text;
                                fm.status.Text = login_status.Text;
                                fm.ShowDialog();
                                //this.Hide();
                            }
                            else
                            {
                                Sact fm = new Sact();
                                fm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("SMS Messaging Module Strictly out of Bound to Non-Admin Users ...!", " Response From Server ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to Connect to Internet ...!", " Connection Failure ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                gclass.message_reject();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_ax.Visible = true;
            if (owner.Text.Contains("HEPHZ") || owner.Text.Contains("Hephz") || owner.Text.Contains("hephz"))
            {
                if (status.Text.Contains("Super"))
                {
                    Report_comp fm = new Report_comp();
                    fm.status.Text = status.Text;
                    fm.button_delete.Visible = true;
                    fm.branch.Text = cmb_school.Text;
                    fm.owner.Text = owner.Text;
                    fm.login_name.Text = login_name.Text;
                    if (fm.status.Text.Contains("Super"))
                    {
                        fm.gross_profit.Visible = true;
                        fm.gross_profit_label.Visible = true;
                        fm.net_profit.Visible = true;
                        fm.net_profit_label.Visible = true;
                    }
                    fm.ShowDialog();
                }
               /* else if (status.Text.Contains("Admin"))
                {
                    Report_comp fm = new Report_comp();
                    fm.status.Text = status.Text;
                    fm.button_delete.Visible = false;
                    fm.owner.Text = owner.Text;

                    fm.gross_profit.Visible = false;
                    fm.gross_profit_label.Visible = false;
                    fm.net_profit.Visible = false;
                    fm.net_profit_label.Visible = false;

                    fm.ShowDialog();
                }*/
                else
                {
                    gclass.message_reject();
                }
            }
            else
            {
                if (status.Text.Contains("Super"))
                {
                    Report_comp fm = new Report_comp();
                    fm.status.Text = status.Text;
                    fm.button_delete.Visible = true;
                    fm.branch.Text = cmb_school.Text;
                    fm.login_name.Text = login_name.Text;
                    if (fm.status.Text.Contains("Super"))
                    {
                        fm.gross_profit.Visible = true;
                        fm.gross_profit_label.Visible = true;
                        fm.net_profit.Visible = true;
                        fm.owner.Text = owner.Text;
                        fm.net_profit_label.Visible = true;
                    }
                    fm.ShowDialog();
                }
                else if (status.Text.Contains("Admin"))
                {
                    Report_comp fm = new Report_comp();
                    fm.status.Text = status.Text;
                    fm.branch.Text = cmb_school.Text;
                    fm.button_delete.Visible = false;
                    fm.login_name.Text = login_name.Text;

                    fm.gross_profit.Visible = false;
                    fm.gross_profit_label.Visible = false;
                    fm.net_profit.Visible = false;
                    fm.owner.Text = owner.Text;
                    fm.net_profit_label.Visible = false;

                    fm.ShowDialog();
                }
                else
                {
                    Report_comp fm = new Report_comp();
                    fm.branch.Text = cmb_school.Text;
                    fm.status.Text = status.Text;
                    fm.button_delete.Visible = false;
                    fm.gross_profit.Visible = false;
                    fm.owner.Text = owner.Text;
                    fm.login_name.Text = login_name.Text;
                    fm.gross_profit_label.Visible = false;
                    fm.net_profit.Visible = false;
                    fm.net_profit_label.Visible = false;
                    fm.ShowDialog();
                    //gclass.message_reject();
                }
            }
            panel_ax.Visible = false;

           /* if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Report_comp fm = new Report_comp();
                fm.status.Text = status.Text;
                if (fm.status.Text.Contains("Super"))
                {
                    fm.gross_profit.Visible = true;
                    fm.gross_profit_label.Visible = true;
                    fm.net_profit.Visible = true;
                    fm.login_name.Text = login_name.Text;
                    fm.net_profit_label.Visible = true;
                }
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }*/
                       
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Super"))
            {
                Stock_Remove fm = new Stock_Remove();
                fm.branch.Text = cmb_school.Text;
                fm.owner.Text = owner.Text;

                fm.s_day.Text = s_day.Text;
                fm.s_month.Text = s_month.Text;
                fm.s_year.Text = s_year.Text;
                fm.s_date.Text = s_date.Text;
                fm.s_time.Text = s_time.Text;

                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Unit_Conversion fm = new Unit_Conversion();
            fm.owner.Text = owner.Text;
            fm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Account_History fm = new Account_History();
            if (status.Text == "Admin")
            {
                fm.button_delete.Visible = true;
                fm.customername_query.Visible = true;
                //########################## AUTO COMPLETE CUSTOMER'S NAME FROM THE DATABASE ##################################
                try
                {

                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string str = "SELECT Full_Name FROM Table_Login";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.Day.ToString() + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')";
                    MySqlCommand cmd = new MySqlCommand(str, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        acc.Add(dr.GetString(0));
                    }
                    fm.customername_query.AutoCompleteCustomSource = acc;

                    gclass.display_in_combobox("SELECT Full_Name FROM Table_Login", fm.customername_query, "Full_Name");
                    fm.customername_query.SelectedIndex = -1;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                fm.button_delete.Visible = false;
                fm.customername_query.Visible = true;
                fm.customername_query.Text = user.Text;
            }
            fm.ShowDialog();
           // //this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Upload_Form fm = new Upload_Form();
            fm.users.Text = login_name.Text;
            fm.g_school.Text = g_school.Text;
            fm.branch.Text = cmb_school.Text;
            fm.owner.Text = owner.Text;
            fm.status.Text = login_status.Text;
            fm.ShowDialog();

           /* if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Upload_Form fm = new Upload_Form();
                fm.users.Text = login_name.Text;
                fm.g_school.Text = g_school.Text;
                fm.owner.Text = owner.Text;
                fm.status.Text = login_status.Text;
                fm.ShowDialog();
               // //this.Hide();
            }
            else
            {
                gclass.message_reject();
            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Customize1 fm = new Customize1();
                fm.branch.Text = cmb_school.Text;
                fm.owner.Text = owner.Text;
                fm.ShowDialog();
                //this.Hide();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Register_supplier fm = new Register_supplier();
                fm.branch.Text = cmb_school.Text;
                fm.label4.Text = "Customer/ Supplier Registration Form ";
                fm.company_name_search.Visible = false;
                fm.owner.Text = owner.Text;
                fm.button3.Visible = false;
                fm.button1.Text = " Save Record ";
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Employee_View fm = new Employee_View();
                fm.branch.Text = cmb_school.Text;
                fm.owner.Text = owner.Text;
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Super"))
            {
                Account_Confirmed fm = new Account_Confirmed();
                //########################## AUTO COMPLETE STAFF/ WORKER'S NAME FROM THE DATABASE ##################################
                try
                {

                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string str = "SELECT Full_Name FROM Table_Login";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.Day.ToString() + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')";
                    MySqlCommand cmd = new MySqlCommand(str, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        acc.Add(dr.GetString(0));
                    }
                    fm.customername_query.AutoCompleteCustomSource = acc;
                    gclass.display_in_combobox("SELECT Full_Name FROM Table_Login", fm.customername_query, "Full_Name");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                fm.users.Text = login_name.Text;
                fm.status.Text = status.Text;

                fm.customername_query.Visible = true;
                fm.button_delete.Visible = true;
                fm.button_export.Visible = true;
                fm.button_print.Visible = true;

                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Area Strictly Restricted for Super Super User ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Download_Form fm = new Download_Form();
                fm.users.Text = login_name.Text;
                fm.owner.Text = owner.Text;
                fm.branch.Text = cmb_school.Text;
                fm.g_school.Text = g_school.Text;
                fm.status.Text = login_status.Text;
                fm.ShowDialog();
              //  //this.Hide();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
             Price_List fm = new Price_List();
             fm.branch.Text = cmb_school.Text;
             fm.owner.Text = owner.Text; 
            fm.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Sales_end_user fm = new Sales_end_user();
            fm.branch.Text = cmb_school.Text;
            fm.cashier_name.Text = login_name.Text;
            fm.channel.Text = "Distributor";
           // fm.label1_unit.Text = "KG";
            fm.label1_unit.Enabled = true;
            fm.status.Text = status.Text;
            fm.Sales_Method.SelectedIndex = 0;
            fm.owner.Text = owner.Text;
            fm.Sales_Method.Visible = true;
            fm.credit.Visible = true;
            fm.label6.Visible = false;
            fm.Sales_Method.Visible = false;

            fm.s_day.Text = s_day.Text;
            fm.s_month.Text = s_month.Text;
            fm.s_year.Text = s_year.Text;
            fm.s_date.Text = s_date.Text;
            fm.s_time.Text = s_time.Text;
           // fm.Sales_Method.Visible = true;
            //fm.label6.Visible = true;
            fm.ShowDialog();
            //this.Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Sales_end_user fm = new Sales_end_user();
            fm.branch.Text = cmb_school.Text;
            fm.cashier_name.Text = login_name.Text;
            fm.channel.Text = "Industrial";
           // fm.label1_unit.Text = "Litre(s)";
            fm.label1_unit.Enabled = true;
            fm.credit.Visible = true;
            fm.label6.Visible = false;
            fm.owner.Text = owner.Text;
            fm.Sales_Method.Visible = false;

            fm.s_day.Text = s_day.Text;
            fm.s_month.Text = s_month.Text;
            fm.s_year.Text = s_year.Text;
            fm.s_date.Text = s_date.Text;
            fm.s_time.Text = s_time.Text;
           // fm.Sales_Method.Visible = true;
           // fm.label6.Visible = true;

            if (fm.channel.Text.Contains("Indus"))
            {
               // fm.channel.Visible = false;
                fm.panel_receipt.Visible = true;
                /* linkLabel1.Visible = false;
                 button_ok.Visible = false;
                 titletext.Visible = false;
                 dataGridView2.Visible = false;*/
            }
            else
            {
                fm.panel_receipt.Visible = true;
                /* linkLabel1.Visible = true;
                 button_ok.Visible = true;
                 titletext.Visible = true;
                 dataGridView2.Visible = true;*/
            }

            fm.status.Text = status.Text;
            fm.ShowDialog();
            //this.Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Sales_end_user fm = new Sales_end_user();
            fm.branch.Text = cmb_school.Text;
            fm.cashier_name.Text = login_name.Text;
            fm.channel.Text = "Home Delivery";
            fm.transport.Visible = true;
            fm.label1_unit.Enabled = false;
            fm.transport_label.Visible = true;
            fm.label6.Visible = false;
            fm.owner.Text = owner.Text;
            fm.Sales_Method.Visible = false;

            fm.s_day.Text = s_day.Text;
            fm.s_month.Text = s_month.Text;
            fm.s_year.Text = s_year.Text;
            fm.s_date.Text = s_date.Text;
            fm.s_time.Text = s_time.Text;
           // fm.Sales_Method.Visible = true;
           // fm.label6.Visible = true;
            fm.credit.Visible = true;
            fm.status.Text = status.Text;
            fm.ShowDialog();
            //this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Register_supplier fm = new Register_supplier();
                fm.branch.Text = cmb_school.Text;
                fm.label4.Text = "Select Name of Company ";
                fm.company_name_search.Visible = true;
                fm.owner.Text = owner.Text;
                fm.button3.Visible = true;
                fm.button1.Text = " Update Record "; 
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Expenditure fm = new Expenditure();
                fm.branch.Text = cmb_school.Text;
                fm.user_name.Text = login_name.Text;
                fm.owner.Text = owner.Text;
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Report_Expenditure fm = new Report_Expenditure();
                fm.branch.Text = cmb_school.Text;
                fm.owner.Text = owner.Text;
               // fm.user_name.Text = login_name.Text;
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Remitances fm = new Remitances();
                fm.branch.Text = cmb_school.Text;
                fm.s_day.Text = s_day.Text;
                fm.s_month.Text = s_month.Text;
                fm.s_year.Text = s_year.Text;
                fm.s_date.Text = s_date.Text;
                fm.s_time.Text = s_time.Text;
                fm.textBox3.Text = login_name.Text;
                // fm.user_name.Text = login_name.Text;
                fm.owner.Text = owner.Text;
                fm.ShowDialog();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Enhance fm = new Enhance();
            fm.owner.Text = owner.Text;
            fm.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Super") || status.Text.Contains("Admin"))
            {
                Closing_Stock fm = new Closing_Stock();
                fm.branch.Text = cmb_school.Text;
                fm.users.Text = login_name.Text;
                fm.status.Text = login_status.Text;
                if (status.Text.Contains("Super"))
                {
                   // fm.chk_edit.Visible = true;
                    fm.dataGridView1.Visible = true;
                    fm.button3.Visible = true;
                }
                else
                {
                   // fm.chk_edit.Visible = false;
                    fm.button3.Visible = false;
                    fm.dataGridView1.Visible = false;
                }
                fm.ShowDialog();
                // //this.Hide();
            }
            else
            {
                gclass.message_reject();
            }

        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Payroll_Register fm = new Payroll_Register();
                // fm.department.Text = department.Text;
                fm.branch.Text = branch.Text;
                /*fm.g_school.Text = g_school.Text;
                fm.category_status.Text = category_status.Text;
                fm.users.Text = users.Text;
                fm.user_name.Text = user_name.Text;*/
                fm.ShowDialog();
                // this.Hide();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Payroll_Generate fm = new Payroll_Generate();
                // fm.department.Text = department.Text;
                fm.branch.Text = branch.Text;
                /*fm.g_school.Text = g_school.Text;
                fm.category_status.Text = category_status.Text;
                fm.users.Text = users.Text;
                fm.user_name.Text = user_name.Text;*/
                fm.ShowDialog();
                // this.Hide();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (status.Text.Contains("Admin") || status.Text.Contains("Super"))
            {
                Payroll_History fm = new Payroll_History();
                // fm.department.Text = department.Text;
                fm.branch.Text = branch.Text;
                /*fm.g_school.Text = g_school.Text;
                fm.category_status.Text = category_status.Text;
                fm.users.Text = users.Text;
                fm.user_name.Text = user_name.Text;*/
                fm.ShowDialog();
                // this.Hide();
            }
            else
            {
                gclass.message_reject();
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            /*Report_Summary fm = new Report_Summary();
            fm.branch1.Text = cmb_school.Text;
            fm.status1.Text = status.Text;
            fm.owner1.Text = owner.Text;
            fm.ShowDialog();*/
            panel_ax.Visible = true;
            if (owner.Text.Contains("HEPHZ") || owner.Text.Contains("Hephz") || owner.Text.Contains("hephz"))
            {
                if (status.Text.Contains("Super"))
                {
                    Report_Summary fm = new Report_Summary();
                    fm.branch1.Text = cmb_school.Text;
                    fm.status1.Text = status.Text;
                    fm.owner1.Text = owner.Text;
                    fm.ShowDialog();
                }
                /* else if (status.Text.Contains("Admin"))
                 {
                     Report_comp fm = new Report_comp();
                     fm.status.Text = status.Text;
                     fm.button_delete.Visible = false;
                     fm.owner.Text = owner.Text;

                     fm.gross_profit.Visible = false;
                     fm.gross_profit_label.Visible = false;
                     fm.net_profit.Visible = false;
                     fm.net_profit_label.Visible = false;

                     fm.ShowDialog();
                 }*/
                else
                {
                    gclass.message_reject();
                }
            }
            else
            {
                if (status.Text.Contains("Super"))
                {
                    Report_Summary fm = new Report_Summary();
                    fm.branch1.Text = cmb_school.Text;
                    fm.status1.Text = status.Text;
                    fm.owner1.Text = owner.Text;
                    fm.ShowDialog();
                }
                else if (status.Text.Contains("Admin"))
                {
                    Report_Summary fm = new Report_Summary();
                    fm.branch1.Text = cmb_school.Text;
                    fm.status1.Text = status.Text;
                    fm.owner1.Text = owner.Text;
                    fm.ShowDialog();
                }
                else
                {
                    Report_Summary fm = new Report_Summary();
                    fm.branch1.Text = cmb_school.Text;
                    fm.status1.Text = status.Text;
                    fm.owner1.Text = owner.Text;
                    fm.ShowDialog();
                }
            }
            panel_ax.Visible = false;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            P_N1 fm = new P_N1();
            fm.branch.Text = branch.Text;
            fm.name_sales.Text = users.Text;
            fm.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (bb == true)
            {
                /* try
                 {
                     string web = "http://memesco.com/cstring.aspx";
                     WebBrowser wb1 = new WebBrowser();
                     wb1.Navigate(web);
                     System.Threading.Thread.Sleep(15000);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }*/

                try
                {
                    string str400 = "";
                    string bto = "";
                    /* gclass.get_on1(webBrowser1);    
                     DialogResult dr27 = MessageBox.Show("Click OK to Continue ...", "  Message from School-MS Online Monitoring Server: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     if (dr27 == DialogResult.OK)
                     {*/
                    // string str400 = Convert.ToString(webBrowser1.Document.GetElementById("content").OuterText).Trim().TrimEnd();
                    str400 = "Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;";
                    if (str400 != "")
                    {
                        MySqlConnection cn = new MySqlConnection(str400);
                        cn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT S_status FROM Table_verify_schoolms WHERE School_name='" + g_school.Text + "'", cn);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        try
                        {
                            if (dr.Read())
                            {
                                // MessageBox.Show((string)dr.GetValue(0).ToString());
                                bto = Convert.ToString((string)dr.GetValue(0).ToString());
                                try
                                {
                                    MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                                    cn1.Open();
                                    string query = "UPDATE Table_Mr set s_status='" + bto + "'";
                                    MySqlCommand cmd1 = new MySqlCommand(query, cn1);
                                    cmd1.ExecuteNonQuery();
                                    // MessageBox.Show("Success");
                                }
                                catch (Exception ex)
                                {
                                    // MessageBox.Show(ex.Message);
                                }
                                // MessageBox.Show("Verification Sussesfully Done ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            else
                            {
                                // MessageBox.Show("Unable to Verify ... \n \n Contact the application vendor for a valid License Key.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            //  MessageBox.Show("Connection to Internet was Terminated. \n \n Kindly Check your Internet Connection and try again ...", "Message from Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            cn.Close(); cn.Dispose();
                            cmd.Dispose();
                            dr.Close(); dr.Dispose();
                        }
                    }
                }
                // }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Loyalty_Card_Given fm = new Loyalty_Card_Given();
            fm.branch.Text = cmb_school.Text;
            fm.registered_by.Text = login_name.Text;
            fm.ShowDialog();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            panel_ax.Visible = true;
            if (owner.Text.Contains("HEPHZ") || owner.Text.Contains("Hephz") || owner.Text.Contains("hephz"))
            {
                if (status.Text.Contains("Super"))
                {
                    Loyalty fm = new Loyalty();                   
                    fm.ShowDialog();
                }
                else
                {
                    gclass.message_reject();
                }
            }
            else
            {
                if (status.Text.Contains("Super"))
                {
                    Loyalty fm = new Loyalty();
                    fm.ShowDialog();
                }
                else if (status.Text.Contains("Admin"))
                {
                    Loyalty fm = new Loyalty();
                    fm.ShowDialog();
                }
                else
                {
                    Loyalty fm = new Loyalty();
                    fm.ShowDialog();
                    //gclass.message_reject();
                }
            }
            panel_ax.Visible = false;
        }
    }
}
