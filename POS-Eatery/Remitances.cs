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
    public partial class Remitances : Form
    {
        public Remitances()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();

        public string stp()
        {
            //  for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //  {
            try
            {
                dataGridView1.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //   }
            return "sola";
        }






        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string IntegerToWords(long inputNum)
        {

            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;
            string retval = "";

            string x = "";
            string[] ones ={

"zero",
"one",

"two",
"three",

"four",
"five",

"six",
"seven",

"eight",
"nine",

"ten",
"eleven",

"twelve",
"thirteen",

"fourteen",
"fifteen",

"sixteen",
"seventeen",

"eighteen",
"nineteen"

};

            string[] tens ={
"zero",

"ten",
"twenty",

"thirty",
"forty",

"fifty",
"sixty",

"seventy",
"eighty",

"ninety"

};

            string[] thou ={
"",

"thousand",
"million",

"billion",
"trillion",

"quadrillion",
"quintillion"

};

            bool isNegative = false; if (inputNum < 0)
            {

                isNegative = true;
                inputNum *= -1;

            }

            if (inputNum == 0)
                return ("zero");

            string s = inputNum.ToString(); while (s.Length > 0)
            {

                // Get the three rightmost characters

                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                // Separate the three digits

                threeDigits = int.Parse(x);
                lasttwo = threeDigits % 100;

                dig1 = threeDigits / 100;

                dig2 = lasttwo / 10;

                dig3 = (threeDigits % 10);

                // append a "thousand" where appropriate

                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {

                    retval = thou[level] + " " + retval;
                    retval = retval.Trim();

                }

                // check that the last two digits is not a zero

                if (lasttwo > 0)
                {

                    if (lasttwo < 20) // if less than 20, use "ones" only

                        retval = ones[lasttwo] + " " + retval;
                    else // otherwise, use both "tens" and "ones" array

                        retval = tens[dig2] + " " + ones[dig3] + " " + retval;
                }

                // if a hundreds part is there, translate it

                if (dig1 > 0)
                    retval = ones[dig1] + " hundred " + retval;

                s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                level++;

            }

            while (retval.IndexOf(" ") > 0) retval = retval.Replace(" ", " ");
            retval = retval.Trim();

            if (isNegative)

                retval = "negative " + retval;
            return (retval);
            MessageBox.Show(retval.ToString());
        }

        private void Remitances_Load(object sender, EventArgs e)
        {
            gclass.Expand_Database("UPDATE table_sales_lump set amount_paid=cash+pos+transfer");
            MySqlConnection cn53 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn53.Open();
            string str13 = "SELECT DISTINCT(Company_Name) FROM Table_Customer where branch='" + branch.Text + "' ORDER BY Company_Name ASC";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.Day.ToString() + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')";
            MySqlCommand cmd13 = new MySqlCommand(str13, cn53);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd13);
            try
            {
                DataTable dt13 = new DataTable();
                da.Fill(dt13);
                company_name_search.DataSource = dt13;
                company_name_search.DisplayMember = "Company_Name";
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                MySqlDataReader dr13 = cmd13.ExecuteReader();
                while (dr13.Read())
                {
                    acc.Add(dr13.GetString(0));
                }
                company_name_search.AutoCompleteCustomSource = acc;
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
            company_name_search.SelectedIndex = -1;

            try
            {
                var s = textBox3.Text;
                textBox3.Text = s.Substring(0, s.IndexOf(" "));
                // MessageBox.Show(firstWord);
            }
            catch
            {
                textBox3.Text = textBox3.Text;
            }

        }

        private void company_name_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Category AS 'Sales Category',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',(Item_Value-(cash+pos+transfer)) AS 'Balance',Receipt_No From Table_Sales_Lump WHERE Customer_Name='" + company_name_search.Text + "' AND (Item_Value-(cash+pos+transfer))>0 and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
            stp();
            // gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',Balance From Table_Sales_Lump WHERE Customer_Name='"+ company_name_search.Text +"' ORDER BY p_id DESC", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                amount.Text = (Convert.ToDecimal(cash_amt.Text) + Convert.ToDecimal(pos_amt.Text) + Convert.ToDecimal(transfer_amt.Text)).ToString();

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show(" Select Sales to Update ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrWhiteSpace(amount_in_word.Text))
                {
                    MessageBox.Show(" Enter Amount Paying in Word ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToDecimal(amount.Text) <= 0)
                {
                    MessageBox.Show(" Enter Amount Paying ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToDecimal(amount.Text) > Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()))
                {
                    MessageBox.Show(" Amount Paying Must Not be greater than Balance ... Enter Valid Amount ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToDecimal(pos_amt.Text) > 0 && string.IsNullOrWhiteSpace(POS_ID.Text))
                {
                    MessageBox.Show(" Enter the POS ID ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToDecimal(transfer_amt.Text) > 0 && string.IsNullOrWhiteSpace(transfer_ID.Text))
                {
                    MessageBox.Show(" Enter the Transfer ID ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show(" Do you really want to Update Payment for the Selected Sales ...", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {

                        string rest = null;

                        //############################### FETCH THE NEXT RECEIPT NUMBER TO THE RECEIPT ########################################

                        MySqlConnection cn12 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn12.Open();
                        String query12 = "SELECT COUNT(p_id) FROM Table_Repayment where branch='" + branch.Text + "'";
                        MySqlCommand cmd12 = new MySqlCommand(query12, cn12);
                        MySqlDataReader dr12 = cmd12.ExecuteReader();
                        try
                        {

                            while (dr12.Read())
                            {
                                int a = Convert.ToInt32((string)dr12.GetValue(0).ToString());
                                rest = "000" + (a + 1).ToString();
                                rest = "000" + (a + 1).ToString();
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


                        amount_in_word.Text = amount_in_word.Text.ToUpper();

                        string payment_ids = " // POS ID: " + POS_ID.Text + " // TRANSFER ID: " + transfer_ID.Text;

                        string code = dataGridView1.SelectedRows[0].Cells[1].Value + "*****" + method_of_payment.Text + "*****" + id.Text + "*****" + owner.Text + "*****" + DateTime.Now.ToString();
                        gclass.insert1("INSERT INTO Table_Repayment(Sales_ID,Amount_Paid,Date,Day,Month,Year,Code,Registered_By,Customer_Name,Receipt_No,Branch,Cash,POS,Transfer)VALUES('" + dataGridView1.SelectedRows[0].Cells[1].Value + "','" + amount.Text + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + code.ToString() + "','" + textBox3.Text + "','" + company_name_search.Text + "','" + rest.ToString() + "','" + branch.Text + "','" + cash_amt.Text + "','" + pos_amt.Text + "','" + transfer_amt.Text + "')");
                        gclass.Update1("UPDATE Table_Sales_Lump SET Cash=Cash+'" + Convert.ToDecimal(cash_amt.Text) + "',POS=POS+'" + Convert.ToDecimal(pos_amt.Text) + "',Transfer=transfer+'" + Convert.ToDecimal(transfer_amt.Text) + "' WHERE Sales_ID='" + dataGridView1.SelectedRows[0].Cells[1].Value + "' and branch='" + branch.Text + "'");

                        gclass.Expand_Database("UPDATE table_sales_lump set amount_paid=cash+pos+transfer");

                        Receipt fm = new Receipt();
                        fm.name.Text = company_name_search.Text;
                        fm.branch.Text = branch.Text;
                        fm.name1.Text = company_name_search.Text;
                        fm.receipt_date.Text = DateTime.Now.ToShortDateString();
                        fm.receipt_date1.Text = DateTime.Now.ToShortDateString();
                        fm.advance.Text = amount.Text;
                        fm.advance1.Text = amount.Text;
                        fm.balance.Text = (Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value) - Convert.ToDecimal(amount.Text)).ToString();
                        fm.balance1.Text = (Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value) - Convert.ToDecimal(amount.Text)).ToString();
                        fm.amount_in_word.Text = amount_in_word.Text;
                        fm.amount_in_word1.Text = amount_in_word.Text;

                        string ab = null;
                        string ab1 = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                        if (ab1.Contains("end"))
                        {
                            ab = "End-User";
                        }
                        else if (ab1.Contains("Dist"))
                        {
                            ab = "Distributor";
                        }
                        else if (ab1.Contains("Ind"))
                        {
                            ab = "Industrial";
                        }
                        else if (ab1.Contains("Hom"))
                        {
                            ab = "Home Delivery";
                        }

                        fm.purpose.Text = ab + " Gas Sales (Invoice No: " + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + ")";
                        fm.purpose1.Text = ab + " Gas Sales (Invoice No: " + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + ")";

                        if (CASH.Checked == true)
                        {
                            fm.checkBox_cash.Checked = true;
                            fm.checkBox_cash1.Checked = true;
                        }

                        if (pos.Checked == true)
                        {
                            fm.checkBox_cheque.Checked = true;
                            fm.checkbox_cheque1.Checked = true;
                        }

                        if (string.IsNullOrWhiteSpace(POS_ID.Text) || POS_ID.Text.Contains("Tel"))
                        {
                            fm.teller_no.Text = "Nil";
                            fm.teller_no1.Text = "Nil";
                        }

                        fm.receipt_no.Text = rest.ToString();
                        fm.receipt_no1.Text = rest.ToString();

                        fm.ShowDialog();
                        MessageBox.Show(" Remitance was Successful and Selected Sales Updated ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        pos.Checked = false;
                        CASH.Checked = false;
                        TRANSFER.Checked = false;
                        // POS_ID.Text = "Teller No";
                        // POS_ID.Visible = false;
                        amount_in_word.Text = null;
                        method_of_payment.Text = null;
                        id.Text = null;
                        amount.Text = null;
                        cash_amt.Text = "0.00";
                        pos_amt.Text = "0.00";
                        transfer_amt.Text = "0.00";
                        POS_ID.Text = null;
                        transfer_ID.Text = null;

                        // gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Category AS 'Sales Category',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',(Item_Value-Amount_Paid) AS 'Balance' From Table_Sales_Lump WHERE Customer_Name='" + company_name_search.Text + "' AND (Item_Value-Amount_Paid)>0 and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
                        gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Category AS 'Sales Category',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',(Item_Value-(cash+pos+transfer)) AS 'Balance',Receipt_No From Table_Sales_Lump WHERE Customer_Name='" + company_name_search.Text + "' AND (Item_Value-(cash+pos+transfer))>0 and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
                        gclass.Expand_Database("UPDATE Table_Sales_Lump set balance=item_value-amount_paid where branch='" + branch.Text + "'");
                        stp();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(dataGridView1.Rows.Count) > 1)
                {
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(amount.Text))
            {
                amount.Text = "0.00";
            }

            try
            {
                decimal a = decimal.Parse(amount.Text);
            }
            catch
            {
                MessageBox.Show("Amount Paying Can only Contain Integer ...");
                amount.Text = "0.00";
            }
        }

        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Category AS 'Sales Category',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',(Item_Value-(cash+pos+transfer)) AS 'Balance',Receipt_No From Table_Sales_Lump WHERE Customer_Name='" + company_name_search.Text + "' AND Year='" + year1.Text + "' AND (Item_Value-(cash+pos+transfer))>0 and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
            stp();
        }

        private void month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Category AS 'Sales Category',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',(Item_Value-(cash+pos+transfer)) AS 'Balance',Receipt_No From Table_Sales_Lump WHERE Customer_Name='" + company_name_search.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND (Item_Value-(cash+pos+transfer))>0 and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
            stp();
        }

        private void day1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT Date,Sales_ID AS 'Sales ID',Category AS 'Sales Category',Item_Value as 'Sales Value',Amount_Paid AS 'Amount Paid',(Item_Value-(cash+pos+transfer)) AS 'Balance',Receipt_No From Table_Sales_Lump WHERE Customer_Name='" + company_name_search.Text + "' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='" + day1.Text + "' AND (Item_Value-(cash+pos+transfer))>0 and branch='" + branch.Text + "' ORDER BY p_id DESC", dataGridView1);
            stp();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Repayment_Break fm = new Repayment_Break();
            fm.branch.Text = branch.Text;
            gclass.display_in_dgv("SELECT Sales_ID AS 'Sales ID',Amount_Paid AS 'Amount Paid',Date from Table_Repayment WHERE Sales_ID='" + dataGridView1.SelectedRows[0].Cells[1].Value + "' and branch='" + branch.Text + "' ORDER BY p_id DESC", fm.dataGridView1);
            fm.ShowDialog();
        }

        private void payment_cash_CheckedChanged(object sender, EventArgs e)
        {
            POS_ID.Text = null;
            transfer_ID.Text = null;
            method_of_payment.Text = "Cash";
            id.Text = "NIL";

            /*if (CASH.Checked == true)
            {
                POS_ID.Visible = false;
                POS_ID.Text = "NIL";
            }
            else
            {
                POS_ID.Visible = true;
                POS_ID.Text = "NIL";
            }*/
        }

        private void payment_bank_CheckedChanged(object sender, EventArgs e)
        {

            POS_ID.Text = null;
            id.Text = null;
            transfer_ID.Text = null;
            method_of_payment.Text = "POS";
            /*if (pos.Checked == true)
            {
                POS_ID.Visible = true;
                POS_ID.Text = "NIL";
            }
            else
            {
                POS_ID.Visible = false;
                POS_ID.Text = "NIL";
            }*/
        }

        private void teller_no_TextChanged(object sender, EventArgs e)
        {
            id.Text = POS_ID.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string aa = IntegerToWords(Convert.ToInt64(amount.Text)).ToString();
                MessageBox.Show(aa.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void amount_in_word_TextChanged(object sender, EventArgs e)
        {

        }

        private void TRANSFER_CheckedChanged(object sender, EventArgs e)
        {

            POS_ID.Text = null;
            id.Text = null;
            transfer_ID.Text = null;
            method_of_payment.Text = "Transfer";
        }

        private void TRANSFER_ID_TextChanged(object sender, EventArgs e)
        {
            id.Text = transfer_ID.Text;
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
                cash_amt.Text = "0.00";
            }

            amount.Text = (Convert.ToDecimal(cash_amt.Text) + Convert.ToDecimal(pos_amt.Text) + Convert.ToDecimal(transfer_amt.Text)).ToString();
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
                pos_amt.Text = "0.00";
            }

            amount.Text = (Convert.ToDecimal(cash_amt.Text) + Convert.ToDecimal(pos_amt.Text) + Convert.ToDecimal(transfer_amt.Text)).ToString();
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
                transfer_amt.Text = "0.00";
            }

            amount.Text = (Convert.ToDecimal(cash_amt.Text) + Convert.ToDecimal(pos_amt.Text) + Convert.ToDecimal(transfer_amt.Text)).ToString();
        }
    }
}


