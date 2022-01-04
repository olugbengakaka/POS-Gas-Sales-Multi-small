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
    public partial class Price_List : Form
    {
        public Price_List()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                // printDocument1.Print();
            }
            //gclass.print(printDocument1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
        }

        private void Price_List_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT p_id AS ID,Product_Name AS 'Name of Product',Price,Date AS 'Last Updated Date' FROM Table_price_product where branch='" + branch.Text + "' ORDER BY Product_Name";
            gclass.display_in_dgv(query1, dataGridView1);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
        }
    }
}
