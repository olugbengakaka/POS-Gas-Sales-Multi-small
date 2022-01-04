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
    public partial class Register_supplier : Form
    {
        public Register_supplier()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(contact_name.Text))
            {
                MessageBox.Show("Enter Contact Person's Name ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(company_name.Text))
            {
                MessageBox.Show("Enter Name of Company ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reg_status.SelectedIndex==-1)
            {
                MessageBox.Show(" Select Registration Status ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string code = company_name.Text + branch.Text;
                //gclass.insert("INSERT INTO Table_Employee(Full_Name,Phone,Code)VALUES('" + contact_name.Text + "','" + company_phone.Text + "','" + code.ToString() + "') ON DUPLICATE KEY UPDATE full_name=values(full_name),Phone=values(Phone),code=values(code)");
                string query = "INSERT INTO Table_Customer(Company_Name,Company_Address,Company_Phone,Company_Email,Company_Website,Contact_Name,Contact_Address,Contact_Phone,Contact_Email,Contact_Website,Guarantor_Name,Guarantor_Address,Guarantor_Info,Code,Date,Day,Month,Year,Rate,Reg_Status,branch)VALUES('" + company_name.Text + "','" + company_address.Text + "','" + company_phone.Text + "','" + company_email.Text + "','" + company_website.Text + "','" + contact_name.Text + "','" + contact_address.Text + "','" + contact_phone.Text + "','" + contact_email.Text + "','" + contact_website.Text + "','" + guarantor_name.Text + "','" + guarantor_address.Text + "','" + guarantor_info.Text + "','" + code.ToString() + "','" + DateTime.Now + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + textBox1.Text + "','"+ reg_status.Text +"','"+ branch.Text +"') ON DUPLICATE KEY UPDATE company_name=values(company_name),company_address=values(company_address),company_phone=values(company_phone),company_email=values(company_email),company_website=values(company_website),contact_name=values(contact_name),contact_address=values(contact_address),contact_phone=values(contact_phone),contact_email=values(contact_email),contact_website=values(contact_website),guarantor_name=values(guarantor_name),guarantor_address=values(guarantor_address),guarantor_info=values(guarantor_info),code=values(code),Rate=values(Rate),reg_status=values(reg_status)";
                if (button1.Text.Contains("Save"))
                {
                    gclass.insert(query);
                    gclass.panel_format(panel1);
                }
                else
                {
                    gclass.Update(query);
                    gclass.panel_format(panel1);
                }
                contact_name.Text = null;
                company_phone.Text = null;
            }
        }

        private void Add_Staff_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "/images/portal.png");
            MySqlConnection cn53 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn53.Open();
            string str13 = "SELECT DISTINCT(Company_Name) FROM Table_Customer WHERE Branch='"+ branch.Text +"' ORDER BY Company_Name ASC";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.Day.ToString() + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')";
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
        }

        private void productname1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format(panel1);
            MySqlDataReader dr4 = gclass.display_in_box("SELECT* FROM Table_Customer WHERE Company_Name='"+ company_name_search.Text +"' AND branch='"+ branch.Text +"'");
            while (dr4.Read())
            {
                company_name.Text = (string)dr4.GetValue(1).ToString();
                company_address.Text = (string)dr4.GetValue(2).ToString();
                company_phone.Text = (string)dr4.GetValue(3).ToString();
                company_email.Text = (string)dr4.GetValue(4).ToString();
                company_website.Text = (string)dr4.GetValue(5).ToString();
                contact_name.Text = (string)dr4.GetValue(6).ToString();
                contact_address.Text = (string)dr4.GetValue(7).ToString();
                contact_phone.Text = (string)dr4.GetValue(8).ToString();
                contact_email.Text = (string)dr4.GetValue(9).ToString();
                contact_website.Text = (string)dr4.GetValue(10).ToString();
                guarantor_name.Text = (string)dr4.GetValue(11).ToString();
                guarantor_address.Text = (string)dr4.GetValue(12).ToString();
                guarantor_info.Text = (string)dr4.GetValue(13).ToString();
                textBox1.Text = (string)dr4.GetValue(20).ToString();
                reg_status.Text = (string)dr4.GetValue(21).ToString();
               /* company_address.Text = (string)dr4.GetValue(3).ToString();
                company_email.Text = (string)dr4.GetValue(4).ToString();
                company_name.Text = (string)dr4.GetValue(1).ToString();
                company_address.Text = (string)dr4.GetValue(3).ToString();
                company_email.Text = (string)dr4.GetValue(4).ToString();*/
              
            }
            dr4.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "0.00";
            }
            try
            {
                decimal a = decimal.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rate Can only Contain Numeric Character ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0.00";
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void reg_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reg_status.Text.Contains("ind") || reg_status.Text.Contains("Ind"))
            {
                label16.Text = "/ Litre(s)";
            }
            else
            {
                label16.Text = "/ KG";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gclass.Delete("DELETE from Table_Customer WHERE Company_Name='" + company_name_search.Text + "' and branch='"+ branch.Text +"'");
        }
    }
}
