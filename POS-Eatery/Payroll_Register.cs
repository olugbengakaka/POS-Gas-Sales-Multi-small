using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace POS_Eatery
{
    public partial class Payroll_Register : Form
    {
        public Payroll_Register()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(funding_bank.Text) || string.IsNullOrWhiteSpace(funding_account.Text))
            {
                MessageBox.Show("Enter the branch Funding Account and Funding Account No.", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gclass.insert("INSERT INTO Table_Payroll_Config(Bank_Name,Bank_Account,branch,Code,Date)VALUES('" + funding_bank.Text + "','" + funding_account.Text + "','" + branch.Text + "','" + branch.Text + "','" + DateTime.Now + "') ON DUPLICATE KEY UPDATE BANK_NAME=VALUES(bank_name),bank_account=values(bank_account)");
            }
            // /////////////  RETREIVING THE FUNDING ACCOUNT DETAIL  /////////////////////////////////////////////
            try
            {

                MySqlCommand cmd101 = new MySqlCommand();
                MySqlConnection cn101 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlDataReader dr5 = gclass.display_in_box1("SELECT* FROM Table_payroll_config where branch='"+ branch.Text +"'", cn101, cmd101);
                try
                {
                    if (dr5.Read())
                    {
                        funding_bank.Text = (string)dr5.GetValue(1).ToString();
                        funding_account.Text = (string)dr5.GetValue(2).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn101.Close(); cn101.Dispose();
                    cmd101.Dispose();
                    dr5.Close(); dr5.Dispose();
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }




        }

        private void Payroll_Register_Load(object sender, EventArgs e)
        {
           // gclass.aj(pictureBox2, image_loading);
            panel_ax.Visible = true;
            // /////////////  RETREIVING THE FUNDING ACCOUNT DETAIL  /////////////////////////////////////////////
            try
            {

                MySqlCommand cmd101 = new MySqlCommand();
                MySqlConnection cn101 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlDataReader dr5 = gclass.display_in_box1("SELECT* FROM Table_payroll_config where branch='"+ branch.Text +"'", cn101, cmd101);
                try
                {
                    if (dr5.Read())
                    {
                        funding_bank.Text = (string)dr5.GetValue(1).ToString();
                        funding_account.Text = (string)dr5.GetValue(2).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn101.Close(); cn101.Dispose();
                    cmd101.Dispose();
                    dr5.Close(); dr5.Dispose();
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            
            gclass.display_in_combobox("SELECT* FROM Table_employee WHERE branch='" + branch.Text + "' ORDER BY Name ASC", staff_name, "Name");
            staff_name.SelectedIndex = -1;
            panel_ax.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staff_name.Text))
            {
                MessageBox.Show("Select Name of Staff ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                string code=staff_name.Text;
                string query = "INSERT INTO Table_Payroll_Register(Staff_Name,Actual_Salary,social_saving,compulsory_saving,overtime,bonus,tuition_deduct,loan_deduct,tax_deduct,bank_name,bank_account,bank_code,account_type,beneficiary_name,currency_code,branch,code,date)VALUES('" + staff_name.Text + "','" + actual_salary.Text + "','" + social_saving.Text + "','" + compulsory_saving.Text + "','" + over_time.Text + "','" + bonus.Text + "','" + tuition_deduct.Text + "','" + loan_repayment.Text + "','" + tax_deduct.Text + "','" + benefiary_bank.Text + "','" + beneficiary_account_no.Text + "','" + bank_code.Text + "','" + account_type.Text + "','" + beneficiary_name.Text + "','" + currency_code.Text + "','" + branch.Text + "','" + code + "','" + DateTime.Now + "') ON DUPLICATE KEY UPDATE staff_name=values(staff_name),actual_salary=values(actual_salary),social_saving=values(social_saving),compulsory_saving=values(compulsory_saving),overtime=values(overtime),bonus=values(bonus),tuition_deduct=values(tuition_deduct),loan_deduct=values(loan_deduct),tax_deduct=values(tax_deduct),bank_name=values(bank_name),bank_account=values(bank_account),bank_code=values(bank_code),account_type=values(account_type),beneficiary_name=values(beneficiary_name),currency_code=values(currency_code),branch=values(branch),code=values(code)";
                gclass.insert(query);
            }


        }

        private void staff_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_ax.Visible = true;
            // /////////////  RETREIVING THE FUNDING ACCOUNT DETAIL  /////////////////////////////////////////////
            try
            {
                actual_salary.Text = "0.00";
                social_saving.Text = "0.00";
                compulsory_saving.Text = "0.00";
                over_time.Text = "0.00";
                bonus.Text = "0.00";
                tuition_deduct.Text = "0.00";
                loan_repayment.Text = "0.00";
                tax_deduct.Text = "0.00";
                benefiary_bank.Text = null;
                beneficiary_account_no.Text = null;
                bank_code.Text = null;
                account_type.Text = null;
                beneficiary_name.Text = null;
                currency_code.Text = null;
               // textBox1.Text=staff_name.Text;
               // gclass.panel_format(panel2);
                MySqlCommand cmd101 = new MySqlCommand();
                MySqlConnection cn101 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlDataReader dr5 = gclass.display_in_box1("SELECT* FROM Table_payroll_register where staff_name='"+ staff_name.Text +"'", cn101, cmd101);
                try
                {
                    if (dr5.Read())
                    {
                        actual_salary.Text = (string)dr5.GetValue(2).ToString();
                        social_saving.Text = (string)dr5.GetValue(3).ToString();
                        compulsory_saving.Text = (string)dr5.GetValue(4).ToString();
                        over_time.Text = (string)dr5.GetValue(5).ToString();
                        bonus.Text = (string)dr5.GetValue(6).ToString();
                        tuition_deduct.Text = (string)dr5.GetValue(7).ToString();
                        loan_repayment.Text = (string)dr5.GetValue(8).ToString();
                        tax_deduct.Text = (string)dr5.GetValue(9).ToString();
                        benefiary_bank.Text = (string)dr5.GetValue(10).ToString();
                        beneficiary_account_no.Text = (string)dr5.GetValue(11).ToString();
                        bank_code.Text = (string)dr5.GetValue(12).ToString();
                        account_type.Text = (string)dr5.GetValue(13).ToString();
                        beneficiary_name.Text = (string)dr5.GetValue(14).ToString();
                        currency_code.Text = (string)dr5.GetValue(15).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn101.Close(); cn101.Dispose();
                    cmd101.Dispose();
                    dr5.Close(); dr5.Dispose();
                }
              //  staff_name.Text = textBox1.Text;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            panel_ax.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gclass.panel_format(panel2);
        }
    }
}
