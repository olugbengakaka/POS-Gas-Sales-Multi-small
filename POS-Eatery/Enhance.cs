using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS_Eatery
{
    public partial class Enhance : Form
    {
        public Enhance()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button36_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to run Enhancement Operation. \n \n Note that all activities must be stopped while the Operation goes on, \n\n Click yes to Continue the Enhancement Performance or No to Quit ?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                gclass.display_in_dgv("select concat('repair table ', table_name, ';') from information_schema.tables where table_schema='db_pos_ayegun';", dataGridView1);
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        gclass.insert1(dataGridView1.Rows[i].Cells[0].Value.ToString());

                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                string query = "ALTER TABLE `table_buyers` DROP `p_id`;ALTER TABLE `table_buyers` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_in` DROP `p_id`;ALTER TABLE `table_in` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_new_product` DROP `p_id`;ALTER TABLE `table_new_product` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales` DROP `p_id`;ALTER TABLE `table_sales` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales_confirmed` DROP `p_id`;ALTER TABLE `table_sales_confirmed` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales_lump` DROP `p_id`;ALTER TABLE `table_sales_lump` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_sales_summary` DROP `p_id`;ALTER TABLE `table_sales_summary` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_stock_inventory` DROP `p_id`;ALTER TABLE `table_stock_inventory` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_stock_inventory_summary` DROP `p_id`;ALTER TABLE `table_stock_inventory_summary` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_customer` DROP `p_id`;ALTER TABLE `table_customer` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_repayment` DROP `p_id`;ALTER TABLE `table_repayment` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_employee` DROP `p_id`;ALTER TABLE `table_employee` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_expenditure_list` DROP `p_id`;ALTER TABLE `table_expenditure_list` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_expenditure` DROP `p_id`;ALTER TABLE `table_expenditure` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_login` DROP `p_id`;ALTER TABLE `table_login` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;ALTER TABLE `table_customize` DROP `p_id`;ALTER TABLE `table_customize` ADD `p_id` INT( 11 ) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST;";
                gclass.insert1(query);
                MessageBox.Show("Operation was successful ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
        }

        private void Enhance_Load(object sender, EventArgs e)
        {

        }
    }
}
