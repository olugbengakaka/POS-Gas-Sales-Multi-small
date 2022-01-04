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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add("Gas", "25kg", "5,000.00", "3/25/2015", "9:45AM", "6 Secs");
            dataGridView2.Rows.Add("Gas", "50kg", "10,000.00", "3/25/2015", "4:35PM", "4 Secs");
            dataGridView2.Rows.Add("Gas", "25kg", "5,000.00", "3/25/2015", "5:00PM", "6 Secs");
            dataGridView2.Rows.Add("Gas", "2kg", "400.00", "3/11/2015", "9:45AM", "8 Secs");


            PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                printDocument1.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
        }
    }
}
