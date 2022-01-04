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
    public partial class Staff_Registration : Form
    {
        public Staff_Registration()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home fm = new Home();
            fm.login_status.Text = status.Text;
            fm.status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Home fm = new Home();
            fm.login_name.Text = users.Text;
            fm.login_status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you Really want to Exit the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (dr == DialogResult.Yes)
           // {
                this.Close();
                //Application.Exit();
           // }
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you Really want to Exit the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (dr == DialogResult.Yes)
           // {
                this.Close();
               // Application.Exit();
           // }
        }

        private void Staff_Registration_Load(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "/images/error.png");
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "/images/lock.ico");
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "/images/arrow2.png");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/images/student1.jpg");
            panel1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/portal.png");

            gclass.treat_panel_banner(panel2);
            gclass.treat_panel_main(panel1);
            gclass.treat_strip(statusStrip1);
            gclass.treat_groupbox(groupBox1);

            try
            {

                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string str = "SELECT* FROM Table_Employee where Branch='" + branch.Text + "'  ORDER BY Name ASC";
                MySqlCommand cmd = new MySqlCommand(str, cn);
                // MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    acc.Add(dr.GetString(4));
                }
                student_name_query.AutoCompleteCustomSource = acc;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            gclass.display_in_combobox("SELECT* FROM Table_Employee WHERE Branch='"+ branch.Text +"' ORDER BY Name ASC", student_name_query, "Name");
            student_name_query.SelectedIndex = -1;
            gclass.panel_format(panel3);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (student_name_query.Visible == true)
            {
                if (string.IsNullOrWhiteSpace(name.Text))
                {
                    MessageBox.Show("Enter Full Name of the Employee ...", "POS Intelliscense Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (student_name_query.SelectedIndex==-1 || string.IsNullOrWhiteSpace(student_name_query.Text))
                {
                    MessageBox.Show("Select/ Enter Name of an Employee to Update from the Menu Box ...", "POS Intelliscense Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string code = name.Text+branch.Text;
                    string query = "INSERT INTO Table_Employee(Name,Address,Tel_No,Position,Qualification,Guarantor_Name,Guarantor_Address,Guarantor_Relationship,Date,Day,Month,Year,Reg_By,Code,Branch)VALUES('" + name.Text + "','" + address.Text + "','" + telephone.Text + "','" + position.Text + "','" + qualification.Text + "','" + g_name.Text + "','" + g_address.Text + "','" + g_relationship.Text + "','" + date.Value + "','" + date.Value.Day + "','" + date.Value.Month + "','" + date.Value.Year + "','" + users.Text + "','" + code.ToString() + "','"+ branch.Text +"') ON DUPLICATE KEY UPDATE name=values(name),address=values(address),tel_no=values(tel_no),position=values(position),Qualification=values(Qualification),guarantor_name=values(guarantor_name),guarantor_address=values(guarantor_address),guarantor_relationship=values(guarantor_relationship),Date=values(date),day=values(day),month=values(month),year=values(year),code=values(code)";
                    gclass.insert(query);
                    gclass.panel_format(panel3);
                }
            }
            else if (student_name_query.Visible == false)
            {
                if (string.IsNullOrWhiteSpace(name.Text))
                {
                    MessageBox.Show("Enter Full Name of the Employee ...", "POS Intelliscense Says!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string code = name.Text+branch.Text;
                    string query = "INSERT INTO Table_Employee(Name,Address,Tel_No,Position,Qualification,Guarantor_Name,Guarantor_Address,Guarantor_Relationship,Date,Day,Month,Year,Reg_By,Code,Branch)VALUES('" + name.Text + "','" + address.Text + "','" + telephone.Text + "','" + position.Text + "','" + qualification.Text + "','" + g_name.Text + "','" + g_address.Text + "','" + g_relationship.Text + "','" + date.Value + "','" + date.Value.Day + "','" + date.Value.Month + "','" + date.Value.Year + "','" + users.Text + "','"+ code.ToString() +"','"+ branch.Text +"')";
                    gclass.insert(query);
                    gclass.panel_format(panel3);
                }
            }
        }

        private void student_name_query_VisibleChanged(object sender, EventArgs e)
        {
            if (student_name_query.Visible == true)
            {
                name.ReadOnly = true;
            }
            else
            {
                name.ReadOnly = false;
            }
        }

        private void student_name_query_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.panel_format(panel3);
            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_Employee WHERE Name='" + student_name_query.Text + "' and Branch='" + branch.Text + "'");
            if (dr.Read())
            {
                name.Text = (string)dr.GetValue(1).ToString();
                address.Text = (string)dr.GetValue(2).ToString();
                telephone.Text = (string)dr.GetValue(3).ToString();
                position.Text = (string)dr.GetValue(4).ToString();
                qualification.Text = (string)dr.GetValue(5).ToString();
                g_name.Text = (string)dr.GetValue(6).ToString();
                g_address.Text = (string)dr.GetValue(7).ToString();
                g_relationship.Text = (string)dr.GetValue(8).ToString();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(bmp, new Rectangle(0, 0, groupBox1.Width, groupBox1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Print Document";

            pageSetupDialog1.Document = printDocument1;

            PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
        
    }
}
