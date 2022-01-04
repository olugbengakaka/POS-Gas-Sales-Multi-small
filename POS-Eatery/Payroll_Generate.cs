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
    public partial class Payroll_Generate : Form
    {
        public Payroll_Generate()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(year.Text) || string.IsNullOrWhiteSpace(month.Text))
            {
                MessageBox.Show("Select Year and Month for which Payroll id to be generated ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "SELECT Staff_name as 'Staff Name',actual_salary as 'Actual Salary',social_saving as 'Social Saving',Compulsory_Saving as 'Compulsory Saving',Overtime as 'Over Time',Bonus,Tuition_deduct as 'Extra Deduction',Loan_Deduct as 'Loan',tax_deduct as 'Tax',Bank_Name as 'Bank',Bank_account as 'Account No',Bank_Code as 'Bank Code',account_type as 'Account Type',Beneficiary_Name as 'Beneficiary', currency_code as 'Currency Code',branch,((actual_salary+overtime+bonus)-(social_saving+compulsory_saving+tuition_deduct+loan_deduct+tax_deduct)) as 'Balance' from table_payroll_register WHERE branch='" + branch.Text + "'";
                gclass.display_in_dgv(query, dataGridView1);
                title.Text = "Newly Generated Payroll fro staff from " + branch.Text + " for the month of " + month.Text + "," + year.Text;
                try
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[9].Visible = false;
                        dataGridView1.Columns[10].Visible = false;
                        dataGridView1.Columns[11].Visible = false;
                        dataGridView1.Columns[12].Visible = false;
                        dataGridView1.Columns[13].Visible = false;
                        dataGridView1.Columns[14].Visible = false;
                        dataGridView1.Columns[15].Visible = false;
                       // dataGridView1.Columns[3].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }

            }
        }

        private void Payroll_Generate_Load(object sender, EventArgs e)
        {
           // gclass.display_Year1_in_combobox(year);
            year.SelectedIndex = -1;

            // /////////////  RETREIVING THE FUNDING ACCOUNT DETAIL  /////////////////////////////////////////////
            try
            {

                MySqlCommand cmd101 = new MySqlCommand();
                MySqlConnection cn101 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlDataReader dr5 = gclass.display_in_box1("SELECT* FROM Table_payroll_config where branch='" + branch.Text + "'", cn101, cmd101);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource==null)
            {
                MessageBox.Show("Payroll Must be Generated First ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string code = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + year.Text + month.Text;
                        string query = "INSERT INTO Table_Payroll_salary(Staff_Name,Actual_Salary,social_saving,compulsory_saving,overtime,bonus,tuition_deduct,loan_deduct,tax_deduct,bank_name,bank_account,bank_code,account_type,beneficiary_name,currency_code,branch,code,date,Year,Month,Day,funding_bank,funding_account)VALUES('" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[3].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[8].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[9].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[11].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[12].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[13].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[14].Value) + "','" + Convert.ToString(dataGridView1.Rows[i].Cells[15].Value) + "','" + code + "','" + DateTime.Now + "','" + year.Text + "','" + month.Text + "','" + DateTime.Now.Day + "','" + funding_bank.Text + "','" + funding_account.Text + "') ON DUPLICATE KEY UPDATE staff_name=values(staff_name),actual_salary=values(actual_salary),social_saving=values(social_saving),compulsory_saving=values(compulsory_saving),overtime=values(overtime),bonus=values(bonus),tuition_deduct=values(tuition_deduct),loan_deduct=values(loan_deduct),tax_deduct=values(tax_deduct),bank_name=values(bank_name),bank_account=values(bank_account),bank_code=values(bank_code),account_type=values(account_type),beneficiary_name=values(beneficiary_name),currency_code=values(currency_code),branch=values(branch),code=values(code),year=values(year),month=values(month),day=values(day),funding_bank=values(funding_bank),funding_account=values(funding_account)";
                        gclass.insert1(query);
                    }
                    MessageBox.Show(" Confirmation was successfull ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
