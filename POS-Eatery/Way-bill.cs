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
    public partial class Way_bill : Form
    {
        public Way_bill()
        {
            InitializeComponent();
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

        private void Way_bill_Load(object sender, EventArgs e)
        {

        }
    }
}
