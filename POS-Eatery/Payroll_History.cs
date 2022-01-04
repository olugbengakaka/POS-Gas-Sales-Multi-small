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

namespace POS_Eatery
{
    public partial class Payroll_History : Form
    {
        public Payroll_History()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Payroll_History_Load(object sender, EventArgs e)
        {
            action.SelectedIndex = -1;

          //  gclass.display_Year1_in_combobox(year);
            year.SelectedIndex = -1;
            gclass.Expand_Database("UPDATE Table_payroll_salary set balance=(actual_salary+overtime+bonus)-(social_saving+compulsory_saving+tuition_deduct+loan_deduct+tax_deduct);delete from table_payroll_salary where staff_name=''");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void action_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool test = false;
            if (year.SelectedIndex == -1 || month.SelectedIndex == -1)
            {
                MessageBox.Show("Select Year and Month to View Salary ...", "Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                /////////////////////////////////////////
                 
                try
                {
                    MySqlCommand cmd101 = new MySqlCommand();
                    MySqlConnection cn101 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    MySqlDataReader dr5 = gclass.display_in_box1("select* from table_payroll_salary where year='" + year.Text + "' and month='" + month.Text + "' and branch='" + branch.Text + "'", cn101, cmd101);
                    try
                    {
                        if (dr5.Read())
                        {
                            test = true;
                        }
                        else
                        {
                            test = false;
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
                /////////////////////////////////////////
            if (test == true)
            {
                if (action.SelectedIndex == 0)
                {
                    string query = "Select funding_bank as 'Funding Bank',Funding_account as 'Funding Account',Beneficiary_name as 'Beneficiary',Bank_Name as 'Bank',Bank_Account as 'Account No',Bank_Code as 'Bank Code',Account_Type as 'Account Type',Balance as 'Amount',code as 'Narration',Bank_account as 'Beneficiary Code' from table_payroll_salary where year='" + year.Text + "' and month='" + month.Text + "' and branch='" + branch.Text + "'";
                    gclass.display_in_dgv(query, dataGridView1);
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[8].Value = month.Text + ", " + year.Text;
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }
                }
                else if (action.SelectedIndex == 1)
                {
                    string query = "Select Staff_Name as 'Name of Staff',Actual_Salary as 'Actual Salary',Social_saving as 'Social Saving',Compulsory_Saving as 'Compulsory Saving',OverTime AS 'Over Time',Bonus,Tuition_Deduct as 'Extra Deduction',Loan_Deduct as 'Loan',tax_deduct as 'Tax',Bank_account as 'Bank Account',Balance from table_payroll_salary where year='" + year.Text + "' and month='" + month.Text + "' and branch='"+ branch.Text +"'";
                    gclass.display_in_dgv(query, dataGridView1);
                }
            }
            else
            {
                MessageBox.Show("Payroll not yet Confirmed ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string query = "select* from table_payroll_salary where year='" + year.Text + "' and month='" + month.Text + "'";
            // /////////////  RETREIVING THE FUNDING ACCOUNT DETAIL  /////////////////////////////////////////////
           /* if (year.SelectedIndex == -1)
            {
                MessageBox.Show("Select Year to Proceed ...");
                action.SelectedIndex = -1;
            }
            else if (year.SelectedIndex == -1)
            {
                MessageBox.Show("Select Month to Proceed ...");
                action.SelectedIndex = -1;
            }
            else
            {
                bool test = false;
                try
                {
                    MySqlCommand cmd101 = new MySqlCommand();
                    MySqlConnection cn101 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    MySqlDataReader dr5 = gclass.display_in_box1("select* from table_payroll_salary where year='" + year.Text + "' and month='" + month.Text + "' and branch='" + branch.Text + "'", cn101, cmd101);
                    try
                    {
                        if (dr5.Read())
                        {
                            test = true;
                        }
                        else
                        {
                            test = false;
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
            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
