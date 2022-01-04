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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Invoice_Load(object sender, EventArgs e)
        {
            total.ReadOnly = false;
            /* MySqlDataReader dr9 = gclass.display_in_box("SELECT Company_Address FROM  Table_Customer WHERE Company_Name='" + name_of_customer.Text + "'");
            if (dr9.Read())
            {
                address.Text = (string)dr9.GetValue(0).ToString();
            }*/
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            button_print.Visible = false;
            Bitmap bmp = new Bitmap(panel15.Width, panel15.Height);
            panel15.DrawToBitmap(bmp, new Rectangle(0, 0, panel15.Width, panel15.Height));
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
            if (string.IsNullOrWhiteSpace(amount_in_word.Text))
            {
                MessageBox.Show("Enter Amount in Word ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
}
