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
    public partial class Expenditure : Form
    {
        public Expenditure()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show(" Enter expenses title/ Category ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string code = password.Text+branch.Text;
                gclass.insert("INSERT INTO Table_Expenditure_List(Expenses,Date,Code,branch)values('" + password.Text + "','" + DateTime.Now + "','" + code.ToString() + "','"+branch.Text+"') ON DUPLICATE KEY UPDATE Expenses=values(Expenses)");

                gclass.display_in_combobox("SELECT DISTINCT Expenses FROM Table_Expenditure_List where branch='" + branch.Text + "' ORDER BY Expenses", category, "Expenses");
                category.SelectedIndex = -1;
                password.Text = null;
            }
        }

        private void Expenditure_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "/images/portal.png");
            gclass.display_in_combobox("SELECT DISTINCT Expenses FROM Table_Expenditure_List where branch='" + branch.Text + "' ORDER BY Expenses", category, "Expenses");
            category.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (category.SelectedIndex == -1)
            {
                MessageBox.Show(" Select expenses title/ Category ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToDecimal(amount.Text) <= 0)
            {
                MessageBox.Show(" Enter the Amount ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    var s = name_sales.Text;
                     name_sales.Text = s.Substring(0, s.IndexOf(" "));
                    // MessageBox.Show(firstWord);
                }
                catch
                {
                    name_sales.Text = name_sales.Text;
                }

                Random rnd = new Random(); string abs = rnd.Next(12345, 6789123).ToString();
                string code = category.Text + dateTimePicker1.Value.Day + dateTimePicker1.Value.Month + dateTimePicker1.Value.Year + branch.Text + name_sales.Text + name_admin.Text + DateTime.Now.ToLongTimeString() + abs;
                string query = "INSERT INTO Table_Expenditure(Expenses,Amount,Note,Code,Date,Day,Month,Year,Registered_By,branch)VALUES('" + category.Text + "','" + amount.Text + "','" + richTextBox1.Text + "','" + code.ToString() + "','" + DateTime.Now + "','" + dateTimePicker1.Value.Day + "','" + dateTimePicker1.Value.Month + "','" + dateTimePicker1.Value.Year + "','" + user_name.Text + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE expenses=values(expenses),amount=values(amount),note=values(note),code=values(code),date=values(date),registered_by=values(registered_by)";
                gclass.insert(query);
                amount.Text = "0.00";
                richTextBox1.Text = null;
                category.SelectedIndex = -1;
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
                    MessageBox.Show(" Amount can only contain Number ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    amount.Text = "0.00";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
