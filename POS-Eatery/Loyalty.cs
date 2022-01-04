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
    public partial class Loyalty : Form
    {
        public Loyalty()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Loyalty_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "/images/student1.jpg");
            gclass.display_in_combobox("SELECT DISTINCT(Branch) FROM Table_Mr where branch!=''", branch, "Branch");
            branch.SelectedIndex = -1;
        }

        private void no_of_times_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(no_of_times.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No. of Times can only contains Numeric/ Integer ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                no_of_times.Text = "0";
            }
        }

        private void amount_percent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal a = decimal.Parse(amount_percent.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Amount can only contains Numeric/ Decimal Character ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                amount_percent.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(branch.Text))
            {
                MessageBox.Show("Select Gas Plant from the Dropdown Menu ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(no_of_times.Text) <= 0)
            {
                MessageBox.Show("Enter the Number of Times/ Benchmark for Customers to Start receiving Loyalty ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDecimal(amount_percent.Text) <= 0)
            {
                MessageBox.Show("Amount can only contains Numeric/ Decimal Character ...", "Point of Sales Intelligence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gclass.insert("INSERT INTO Table_Loyalty(times,amount,branch,code)VALUES('" + no_of_times.Text + "','" + amount_percent.Text + "','" + branch.Text + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE times=values(times),amount=values(amount),branch=values(branch),code=values(code)");
                branch.SelectedIndex = -1;
                no_of_times.Text = "0";
                amount_percent.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            no_of_times.Text = "0";
            amount_percent.Text = "0";
            MySqlDataReader dr = gclass.display_in_box("Select* from table_loyalty where branch='" + branch.Text + "'");
            try
            {
                if (dr.Read())
                {
                    no_of_times.Text = (string)dr.GetValue(1).ToString();
                    amount_percent.Text = (string)dr.GetValue(2).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close(); dr.Dispose();
            }
        }
    }
}
