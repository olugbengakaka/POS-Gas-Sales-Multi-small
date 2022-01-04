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
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        General_Class_Imp gclass = new General_Class_Imp();
        private void Receipt_Load(object sender, EventArgs e)
        {
            MySqlDataReader dr4 = gclass.display_in_box("SELECT* FROM Table_Customize where branch='"+ branch.Text +"'");
            while (dr4.Read())
            {
                company_name.Text = (string)dr4.GetValue(1).ToString();
                company_specialty.Text = (string)dr4.GetValue(2).ToString();
                company_address.Text = (string)dr4.GetValue(3).ToString();
                company_address.Text = (string)dr4.GetValue(4).ToString();
                company_telephone.Text = (string)dr4.GetValue(5).ToString();
                comp.Text = "For: " + company_name.Text;

                company_name1.Text = (string)dr4.GetValue(1).ToString();
               // company_specialty1.Text = (string)dr4.GetValue(2).ToString();
                company_address1.Text = (string)dr4.GetValue(3).ToString();
                company_address1.Text = (string)dr4.GetValue(4).ToString();
                comp1.Text = "For: " + company_name.Text;
               // company_telephone1.Text = (string)dr4.GetValue(5).ToString();
            }
            dr4.Close();



          /*  //############################### FETCH THE NEXT RECEIPT NUMBER TO THE RECEIPT ########################################

            MySqlConnection cn12 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn12.Open();
            String query12 = "SELECT COUNT(p_id) FROM Table_Repayment";
            MySqlCommand cmd12 = new MySqlCommand(query12, cn12);
            MySqlDataReader dr12 = cmd12.ExecuteReader();
            try
            {

                while (dr12.Read())
                {
                    int a = Convert.ToInt32((string)dr12.GetValue(0).ToString());
                    receipt_no.Text = "00" + (a + 1).ToString();
                    receipt_no1.Text = "00" + (a + 1).ToString();
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
            }*/





        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            button_print.Visible = false;
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
            button_print.Visible = true;
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            button_print.Visible = false;
            printDocument1.DocumentName = "Print Document";

            pageSetupDialog1.Document = printDocument1;

            PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                // printDocument1.Print();
            }
            button_print.Visible = true;
        }
    }
}
