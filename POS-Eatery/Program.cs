using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace POS_Eatery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

           // RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
           // add.SetValue("Your App Name", "\"" + Application.ExecutablePath.ToString() + "\"");
          //  MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.Startup).ToString());

            // bool ready = false;
            General_Class_Imp gclass = new General_Class_Imp();
            MySqlConnection cn100 = new MySqlConnection();
            MySqlCommand cmd100 = new MySqlCommand();
            MySqlConnection cn120 = new MySqlConnection();
            MySqlCommand cmd120 = new MySqlCommand();
            bool det = false;
            bool proceed = false;
            //  Splash fm = new Splash();
            //  fm.Show();

            try
            {
                if (!Directory.Exists("C:\\POST"))
                {
                    Directory.CreateDirectory("C:\\POST");
                }

                if (!Directory.Exists("C:\\POST/Images"))
                {
                    Directory.CreateDirectory("C:\\POST/Images");
                }
                ///////////////////////////////////////////////////


                if (!File.Exists("C:/POST/images/img1.jpg"))
                {
                    File.Copy(Application.StartupPath + "/images/img1.jpg", "C:/POST/images/img1.jpg");
                }
                if (!File.Exists("C:/POST/images/img2.jpg"))
                {
                    File.Copy(Application.StartupPath + "/images/img2.jpg", "C:/POST/images/img2.jpg");
                }
                if (!File.Exists("C:/POST/images/img3.jpg"))
                {
                    File.Copy(Application.StartupPath + "/images/img3.jpg", "C:/POST/images/img3.jpg");
                }
                if (!File.Exists("C:/POST/images/img4.jpg"))
                {
                    File.Copy(Application.StartupPath + "/images/img4.jpg", "C:/POST/images/img4.jpg");
                }
                if (!File.Exists("C:/POST/images/img5.jpg"))
                {
                    File.Copy(Application.StartupPath + "/images/img5.jpg", "C:/POST/images/img5.jpg");
                }
                if (!File.Exists("C:/POST/images/img6.jpg"))
                {
                    File.Copy(Application.StartupPath + "/images/img6.jpg", "C:/POST/images/img6.jpg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //////////////////////////////////////////////////



            if (!Directory.Exists("C:\\POS"))
            {
                string file = Application.StartupPath + "/backup.sql";
                try
                {
                    string constr = "server=localhost;port=3310;user=pos;pwd=pos;";
                    MySqlConnection cn = new MySqlConnection(constr);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlBackup mb = new MySqlBackup(cmd);
                    cmd.Connection = cn;
                    mb.ImportFromFile(file);
                    Directory.CreateDirectory("C:\\POS");
                    MessageBox.Show(" Required Database Successfully Created ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_loyalty_card_given` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Name` varchar(255) NOT NULL, `Card_Serial` varchar(255) NOT NULL, `Address` varchar(255) NOT NULL,`Phone` varchar(255) NOT NULL,`Email` varchar(255) NOT NULL, `code` varchar(255) NOT NULL,`Branch` varchar(255) NOT NULL,`registered_by` varchar(255) NOT NULL,`date` datetime NOT NULL,`day` varchar(255) NOT NULL,`month` varchar(255) NOT NULL,`year` varchar(255) NOT NULL,`dat` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,PRIMARY KEY(`p_id`),UNIQUE KEY `code` (`code`)) ENGINE = MyISAM  DEFAULT CHARSET = latin1;");
            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_loyalty` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `times` varchar(255) NOT NULL, `amount` decimal(65, 2) NOT NULL, `branch` varchar(255) NOT NULL, `Code` varchar(255) NOT NULL, `Date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, PRIMARY KEY(`p_id`)) ENGINE = MyISAM  DEFAULT CHARSET = latin1;ALTER TABLE  `table_sales_confirmed` ADD  `Loyalty` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("ALTER TABLE  `table_sales_lump` ADD  `phone` VARCHAR( 255 ) NOT NULL;ALTER TABLE  `table_sales_confirmed` ADD  `phone` VARCHAR( 255 ) NOT NULL;");
            gclass.Expand_Database("ALTER TABLE  `table_mr` ADD  `S_status` VARCHAR( 255 ) NOT NULL AFTER  `s_t`");
            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day);update table_sales_confirmed set dat=concat(year,'-',month,'-',day);update table_stock_inventory set dat=concat(year,'-',month,'-',day);update table_repayment set dat=concat(year,'-',month,'-',day);update table_expenditure set dat=concat(year,'-',month,'-',day);");

            gclass.Expand_Database("ALTER TABLE  `table_sales_lump` ADD  `Cash` DECIMAL( 65, 2 ) NOT NULL ,ADD  `POS` DECIMAL(65, 2) NOT NULL,ADD  `Transfer` DECIMAL(65, 2) NOT NULL");
            gclass.Expand_Database("ALTER TABLE  `table_sales_confirmed` ADD  `dat` DATE NOT NULL"); gclass.Expand_Database("ALTER TABLE  `table_stock_inventory` ADD  `dat` DATE NOT NULL"); gclass.Expand_Database("ALTER TABLE  `table_stock_inventory_summary` ADD  `dat` DATE NOT NULL"); gclass.Expand_Database("ALTER TABLE  `table_sales_lump` ADD  `dat` DATE NOT NULL"); gclass.Expand_Database("ALTER TABLE  `table_sales_confirmed` ADD  `dat` DATE NOT NULL"); gclass.Expand_Database("ALTER TABLE  `table_repayment` ADD  `dat` DATE NOT NULL");gclass.Expand_Database("ALTER TABLE  `table_expenditure` ADD  `dat` DATE NOT NULL");
            gclass.Expand_Database("ALTER TABLE  `table_sales_lump` ADD  `Changes` DECIMAL( 65, 2 ) NOT NULL AFTER  `Transfer`");

            gclass.Expand_Database("UPDATE table_sales_lump set amount_paid=cash+pos+transfer");

            gclass.Expand_Database("ALTER TABLE  `table_mr` ADD  `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST");
            gclass.Expand_Database("ALTER TABLE  `table_act` ADD  `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST");
            gclass.Expand_Database("ALTER TABLE  `table_sales_lump` ADD  `Cash` DECIMAL( 65, 2 ) NOT NULL ,ADD  `POS` DECIMAL(65, 2) NOT NULL,ADD  `Transfer` DECIMAL(65, 2) NOT NULL");
            gclass.Expand_Database("ALTER TABLE  `table_sales_lump` ADD  `dat` DATE NOT NULL");
            gclass.Expand_Database("ALTER TABLE  `table_stock_inventory_summary` ADD  `dat` DATE NOT NULL");

            gclass.Expand_Database("ALTER TABLE  `table_stock_inventory_summary` CHANGE  `Quantity_in_Percent`  `Quantity_in_Percent` DECIMAL( 65, 10 ) NOT NULL ,CHANGE  `Quantity_Out_Percent`  `Quantity_Out_Percent` DECIMAL( 65, 10 ) NOT NULL ,CHANGE  `Quantity_Left_Percent`  `Quantity_Left_Percent` DECIMAL( 65, 10 ) NOT NULL");
            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_payroll_config` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Bank_Name` varchar(255) NOT NULL, `Bank_Account` varchar(255) NOT NULL, `Branch` varchar(255) NOT NULL, `Code` varchar(255) NOT NULL, `Date` varchar(255) NOT NULL, `L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, PRIMARY KEY (`p_id`), UNIQUE KEY `Code` (`Code`)) ENGINE=MyISAM DEFAULT CHARSET=latin1;CREATE TABLE IF NOT EXISTS `table_payroll_register` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Staff_Name` varchar(255) NOT NULL, `Actual_Salary` decimal(65,2) NOT NULL, `Social_Saving` decimal(65,2) NOT NULL, `Compulsory_Saving` decimal(65,2) NOT NULL, `Overtime` decimal(65,2) NOT NULL, `Bonus` decimal(65,2) NOT NULL, `Tuition_Deduct` decimal(65,2) NOT NULL, `Loan_Deduct` decimal(65,2) NOT NULL, `Tax_Deduct` decimal(65,2) NOT NULL, `Bank_Name` varchar(255) NOT NULL, `Bank_Account` varchar(255) NOT NULL, `Bank_Code` varchar(255) NOT NULL, `Account_Type` varchar(255) NOT NULL, `Beneficiary_Name` varchar(255) NOT NULL, `Currency_Code` varchar(255) NOT NULL, `Branch` varchar(255) NOT NULL, `Date` varchar(255) NOT NULL, `code` varchar(255) NOT NULL, `L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, PRIMARY KEY (`p_id`), UNIQUE KEY `code` (`code`)) ENGINE=MyISAM DEFAULT CHARSET=latin1;CREATE TABLE IF NOT EXISTS `table_payroll_salary` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Staff_Name` varchar(255) NOT NULL, `Actual_Salary` decimal(65,2) NOT NULL, `Social_Saving` decimal(65,2) NOT NULL, `Compulsory_Saving` decimal(65,2) NOT NULL, `Overtime` decimal(65,2) NOT NULL, `Bonus` decimal(65,2) NOT NULL, `Tuition_Deduct` decimal(65,2) NOT NULL, `Loan_Deduct` decimal(65,2) NOT NULL, `Tax_Deduct` decimal(65,2) NOT NULL, `Bank_Name` varchar(255) NOT NULL, `Bank_Account` varchar(255) NOT NULL, `Bank_Code` varchar(255) NOT NULL, `Account_Type` varchar(255) NOT NULL, `Beneficiary_Name` varchar(255) NOT NULL, `Currency_Code` varchar(255) NOT NULL, `Branch` varchar(255) NOT NULL, `code` varchar(255) NOT NULL, `Balance` decimal(65,2) NOT NULL, `Date` varchar(255) NOT NULL, `Day` varchar(255) NOT NULL, `Month` varchar(255) NOT NULL, `Year` varchar(255) NOT NULL, `funding_bank` varchar(255) NOT NULL, `funding_account` varchar(255) NOT NULL, `L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, PRIMARY KEY (`p_id`), UNIQUE KEY `code` (`code`)) ENGINE=MyISAM DEFAULT CHARSET=latin1;");

            gclass.Expand_Database("ALTER TABLE  `table_closing_stock_gas` ADD  `tt_out` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("CREATE TABLE  `table_closing_stock_gas` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`pump_1_meter_1` DECIMAL( 65, 2 ) NOT NULL ,`pump_1_meter_2` DECIMAL( 65, 2 ) NOT NULL ,`pump_2_meter_1` DECIMAL( 65, 2 ) NOT NULL ,`pump_2_meter_2` DECIMAL( 65, 2 ) NOT NULL ,`pump_3_meter_1` DECIMAL( 65, 2 ) NOT NULL ,`pump_3_meter_2` DECIMAL( 65, 2 ) NOT NULL ,`pump_4_meter_1` DECIMAL( 65, 2 ) NOT NULL ,`pump_4_meter_2` DECIMAL( 65, 2 ) NOT NULL ,`pump_5_meter_1` DECIMAL( 65, 2 ) NOT NULL ,`pump_5_meter_2` DECIMAL( 65, 2 ) NOT NULL ,`pump_6_meter_1` DECIMAL( 65, 2 ) NOT NULL ,`pump_6_meter_2` DECIMAL( 65, 2 ) NOT NULL ,`Date` VARCHAR( 255 ) NOT NULL ,`Day` VARCHAR( 255 ) NOT NULL ,`Month` VARCHAR( 255 ) NOT NULL ,`Year` VARCHAR( 255 ) NOT NULL ,`Time` VARCHAR( 255 ) NOT NULL ,`Registered_By` VARCHAR( 255 ) NOT NULL ,`Code` VARCHAR( 255 ) NOT NULL ,`Branch` VARCHAR( 255 ) NOT NULL ,`Total` DECIMAL( 65, 2 ) NOT NULL ,`Verdict` VARCHAR( 255 ) NOT NULL ,UNIQUE (`Code`)) ENGINE = MYISAM ;");
            gclass.Expand_Database("ALTER TABLE  `table_closing_stock_gas` ADD  `Sales_Report` DECIMAL( 65, 2 ) NOT NULL");

            gclass.Expand_Database("CREATE TABLE  `table_s_t` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`day` VARCHAR( 255 ) NOT NULL ,`month` VARCHAR( 255 ) NOT NULL ,`year` VARCHAR( 255 ) NOT NULL ,`date` VARCHAR( 255 ) NOT NULL ,`time` VARCHAR( 255 ) NOT NULL ,`branch` VARCHAR( 255 ) NOT NULL ,`code` VARCHAR( 255 ) NOT NULL ,UNIQUE (`code`)) ENGINE = MYISAM ;");
            gclass.Expand_Database("ALTER TABLE  `table_stock_inventory` ADD  `Time` VARCHAR( 255 ) NOT NULL");
            gclass.Expand_Database("CREATE TABLE  `table_number` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`number` VARCHAR( 255 ) NOT NULL ,`L_U` TIMESTAMP ON UPDATE CURRENT_TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP)");


            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_ma` ( `ma` varchar(255) NOT NULL, `L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP) ENGINE=MyISAM DEFAULT CHARSET=latin1;CREATE TABLE IF NOT EXISTS `table_mr` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `branch` varchar(255) NOT NULL, `Pre_id` varchar(255) NOT NULL,`branch_Name` varchar(255) NOT NULL,`s_t` varchar(10) NOT NULL,`L_U` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,PRIMARY KEY (`p_id`), UNIQUE KEY `branch_name` (`branch_name`)) ENGINE=MyISAM  DEFAULT CHARSET=latin1;");
            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_buyers` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`tel_no` VARCHAR( 255 ) NOT NULL ,`Date` DATETIME NOT NULL ,`Day` VARCHAR( 255 ) NOT NULL ,`Month` VARCHAR( 255 ) NOT NULL ,`Year` VARCHAR( 255 ) NOT NULL ,`Code` VARCHAR( 255 ) NOT NULL ,`Full_Name` VARCHAR( 255 ) NOT NULL ,UNIQUE (`Code`)) ENGINE = MYISAM ;");
            gclass.Expand_Database("ALTER TABLE  `table_stock_inventory_summary` ADD  `Quantity_in_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_out_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_left_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_in_bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Out_Bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Left_Bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_in_Percent` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Out_Percent` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Left_Percent` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("ALTER TABLE table_mr DROP INDEX branch_name");


            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_stock_inventory_analysis` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Product_Name` varchar(255) NOT NULL, `Category` varchar(255) NOT NULL, `Quantity_In` decimal(65,2) NOT NULL, `Quantity_Out` decimal(65,2) NOT NULL, `Quantity_Left` decimal(65,2) NOT NULL, `Date` varchar(255) NOT NULL, `Day` int(11) NOT NULL, `Month` varchar(255) NOT NULL, `Year` varchar(255) NOT NULL, `Code` varchar(255) NOT NULL, `Branch` varchar(255) NOT NULL,  PRIMARY KEY (`p_id`), UNIQUE KEY `Code` (`Code`)) ENGINE=MyISAM  DEFAULT CHARSET=latin1;");

            gclass.Expand_Database("ALTER TABLE `table_in` ADD `Date` VARCHAR( 255 ) NOT NULL ,ADD `Day` VARCHAR( 255 ) NOT NULL ,ADD `Month` VARCHAR( 255 ) NOT NULL ,ADD `Year` VARCHAR( 255 ) NOT NULL ");
            gclass.Expand_Database("ALTER TABLE `table_price_product` ADD `Category` VARCHAR( 255 ) NOT NULL ,ADD `Cost` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("ALTER TABLE `table_stock_inventory_summary` ADD `Cost` DECIMAL( 65, 2 ) NOT NULL ");
           
            gclass.Expand_Database("ALTER TABLE `table_customer` ADD `Company_Name` VARCHAR( 255 ) NOT NULL ,ADD `Company_Address` VARCHAR( 255 ) NOT NULL ,ADD `Company_Office` VARCHAR( 255 ) NOT NULL ,ADD `Company_Email` VARCHAR( 255 ) NOT NULL ,ADD `Company_Website` VARCHAR( 255 ) NOT NULL ,ADD `Contact_Name` VARCHAR( 255 ) NOT NULL ,ADD `Contact_Address` VARCHAR( 255 ) NOT NULL ,ADD `Contact_Office` VARCHAR( 255 ) NOT NULL ,ADD `Contact_Email` VARCHAR( 255 ) NOT NULL ,ADD `Contact_Website` VARCHAR( 255 ) NOT NULL ,ADD `Guarantor_Name` VARCHAR( 255 ) NOT NULL ,ADD `Guarantor_Address` VARCHAR( 255 ) NOT NULL ,ADD `Guarantor_Info` VARCHAR( 255 ) NOT NULL ,ADD `Date` VARCHAR( 255 ) NOT NULL ,ADD `Day` VARCHAR( 255 ) NOT NULL ,ADD `Month` VARCHAR( 255 ) NOT NULL ,ADD `Year` VARCHAR( 255 ) NOT NULL ,ADD `Reg_By` VARCHAR( 255 ) NOT NULL ,ADD `Code` VARCHAR( 255 ) NOT NULL ,ADD UNIQUE (`Code`)");
            gclass.Expand_Database("ALTER TABLE `table_customer` CHANGE `Company_Office` `Company_Phone` VARCHAR( 255 ) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL ");
            gclass.Expand_Database("ALTER TABLE `table_customer` CHANGE `Contact_Office` `Contact_Phone` VARCHAR( 255 ) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL ");
            gclass.Expand_Database("CREATE TABLE `table_expenditure_list` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`Expenses` VARCHAR( 255 ) NOT NULL ,`Date` VARCHAR( 255 ) NOT NULL ,`Code` VARCHAR( 255 ) NOT NULL ,`Registered_By` VARCHAR( 255 ) NOT NULL ,UNIQUE (`Code`)) ENGINE = MYISAM ;");
            gclass.Expand_Database("CREATE TABLE `table_expenditure` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`Expenses` VARCHAR( 255 ) NOT NULL ,`Amount` DECIMAL( 65, 2 ) NOT NULL ,`Note` VARCHAR( 255 ) NOT NULL ,`code` VARCHAR( 255 ) NOT NULL ,`Date` VARCHAR( 255 ) NOT NULL ,`Day` VARCHAR( 255 ) NOT NULL ,`Month` VARCHAR( 255 ) NOT NULL ,`Year` VARCHAR( 255 ) NOT NULL ,`Registered_By` VARCHAR( 255 ) NOT NULL ,UNIQUE (`code`)) ENGINE = MYISAM ;");
            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_sales_lump` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Sales_ID` varchar(255) NOT NULL, `Quantity` decimal(65,2) NOT NULL, `Price` decimal(65,2) NOT NULL, `Item_Value` varchar(255) NOT NULL, `Amount_Paid` decimal(65,2) NOT NULL, `Balance` decimal(65,2) NOT NULL, `Date` varchar(255) NOT NULL, `Day` varchar(255) NOT NULL, `Month` varchar(255) NOT NULL, `Year` varchar(255) NOT NULL, `Employee` varchar(255) NOT NULL, `Short_Code` varchar(255) NOT NULL,`Minute` varchar(255) NOT NULL,`Second` varchar(255) NOT NULL, `Category` varchar(255) NOT NULL,`Code` varchar(255) NOT NULL,`Payment_Method` varchar(255) NOT NULL, `Customer_Name` varchar(255) NOT NULL,`Discount` varchar(255) NOT NULL,`Receipt_No` varchar(255) NOT NULL, `Cost` decimal(65,2) NOT NULL,  PRIMARY KEY (`p_id`), UNIQUE KEY `Code` (`Code`)) ENGINE=MyISAM  DEFAULT CHARSET=latin1;");
            gclass.Expand_Database("ALTER TABLE `table_sales_lump` ADD `Sales_Method` VARCHAR( 255 ) NOT NULL ,ADD `POS_ID` VARCHAR( 255 ) NOT NULL ");
            gclass.Expand_Database("ALTER TABLE `table_sales_lump` ADD `Transport` DECIMAL( 65, 2 ) NOT NULL ");
            gclass.Expand_Database("CREATE TABLE `table_repayment` (`p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,`Sales_ID` VARCHAR( 255 ) NOT NULL ,`Amount_Paid` DECIMAL( 65, 2 ) NOT NULL ,`Date` VARCHAR( 255 ) NOT NULL ,`Day` VARCHAR( 255 ) NOT NULL ,`Month` VARCHAR( 255 ) NOT NULL ,`Year` VARCHAR( 255 ) NOT NULL ,`Code` VARCHAR( 255 ) NOT NULL ,`Registered_By` VARCHAR( 255 ) NOT NULL ,UNIQUE (`Code`)) ENGINE = MYISAM ;");
            gclass.Expand_Database("ALTER TABLE  `table_customer` ADD  `Rate` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("ALTER TABLE  `table_repayment` ADD  `Customer_Name` VARCHAR( 255 ) NOT NULL ,ADD  `Receipt_No` VARCHAR( 255 ) NOT NULL");
            gclass.Expand_Database("CREATE TABLE IF NOT EXISTS `table_customer` ( `p_id` int(11) NOT NULL AUTO_INCREMENT, `Company_Name` varchar(255) NOT NULL, `Company_Address` varchar(255) NOT NULL, `Company_Phone` varchar(255) NOT NULL, `Company_Email` varchar(255) NOT NULL, `Company_Website` varchar(255) NOT NULL,  `Contact_Name` varchar(255) NOT NULL, `Contact_Address` varchar(255) NOT NULL, `Contact_Phone` varchar(255) NOT NULL, `Contact_Email` varchar(255) NOT NULL, `Contact_Website` varchar(255) NOT NULL, `Guarantor_Name` varchar(255) NOT NULL, `Guarantor_Address` varchar(255) NOT NULL, `Guarantor_Info` varchar(255) NOT NULL, `Date` varchar(255) NOT NULL, `Day` varchar(255) NOT NULL, `Month` varchar(255) NOT NULL, `Year` varchar(255) NOT NULL, `Reg_By` varchar(255) NOT NULL, `Code` varchar(255) NOT NULL, `Rate` decimal(65,2) NOT NULL, PRIMARY KEY (`p_id`), UNIQUE KEY `Code` (`Code`)) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;");

            gclass.Expand_Database("UPDATE Table_Sales_Lump set item_value=replace(item_value,'.01','.00');UPDATE Table_Sales_Lump set item_value=replace(item_value,'.02','.00');UPDATE Table_Sales_Lump set item_value=replace(item_value,'.000','.00');UPDATE Table_Sales_Lump set amount_paid=replace(amount_paid,'.01','.00');UPDATE Table_Sales_Lump set amount_paid=replace(amount_paid,'.02','.00');UPDATE Table_Sales_Lump set amount_paid=replace(amount_paid,'.000','.00');");
            gclass.Expand_Database("UPDATE Table_Sales_Confirmed set item_value=replace(item_value,'.01','.00');UPDATE Table_Sales_Confirmed set item_value=replace(item_value,'.02','.00');UPDATE Table_Sales_Confirmed set item_value=replace(item_value,'.000','.00');UPDATE Table_Sales_Confirmed set amount_paid=replace(amount_paid,'.01','.00');UPDATE Table_Sales_Confirmed set amount_paid=replace(amount_paid,'.02','.00');UPDATE Table_Sales_Confirmed set amount_paid=replace(amount_paid,'.000','.00');");

         
                MySqlDataReader dr = gclass.display_in_box1("SELECT* FROM Table_ma", cn100, cmd100);
                try
                {
                    if (dr.Read())
                    {
                        det = true;
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Login1());
                    }
                    else
                    {
                        det = false;
                        Application.Run(new GP());
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
                    dr.Close(); dr.Dispose();
                }
            


        }
    }
}
