using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace POS_Eatery
{
    public partial class Report_Expenditure : Form
    {
        public Report_Expenditure()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();

       // #region Member Variables
        const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height


        private string ab()
        {
             total_expenses.Text = "0.00";
            //total_sales.Text = "0.00";
            //total_discount_given.Text = "0.00";

            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                total_expenses.Text = sum.ToString();
            }

           /* double sum1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                total_expenses.Text = sum1.ToString();
            }

            /*double sum2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                total_discount_given.Text = sum2.ToString();
            }*/
            no_of_record.Text = (Convert.ToInt32(dataGridView1.Rows.Count) - 1).ToString();
            return "sola";
        }
        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            month.SelectedIndex = -1;
            day.SelectedIndex = -1;
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Year='" + year.Text + "' and branch='"+ branch.Text +"' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            day.SelectedIndex = -1;
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void Report_Expenditure_Load(object sender, EventArgs e)
        {
           // webb1.ScriptErrorsSuppressed = true;

            gclass.display_in_combobox("SELECT DISTINCT Expenses FROM Table_Expenditure_List ORDER BY Expenses", expenditure, "Expenses");
            expenditure.SelectedIndex = -1;

           // webb1.Navigate("http://localhost:4138/Report-Group.aspx?det=mid&School=Brightest%20Star%20Montessori%20School.%20Odutola&session=2016/2017&term=Second&student_name=lawal%20oyinkansola%20olamiposi&class=GRADE%203%20(BRIGHT)&filecopy=false&pdf=true");
        }

        private void day_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Year='" + year.Text + "' and branch='"+ branch.Text +"' AND Month='" + month.Text + "' AND Day='" + day.Text + "' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
              //  printDocument2.Print();
            }
            // gclass.printdocument(dataGridView1, e); gclass.print(dataGridView1);
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            gclass.Delete("DELETE FROM Table_Expenditure WHERE p_id='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) + "' and branch='"+ branch.Text +"'");
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            year1.SelectedIndex = -1;
            month1.SelectedIndex = -1;
            day1.SelectedIndex = -1;
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Expenses='" + expenditure.Text + "' and branch='"+ branch.Text +"' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            month1.SelectedIndex = -1;
            day1.SelectedIndex = -1;
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Expenses='" + expenditure.Text + "' and branch='"+ branch.Text +"' AND Year='"+ year1.Text +"' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            day1.SelectedIndex = -1;
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Expenses='" + expenditure.Text + "' and branch='"+ branch.Text +"' AND Year='" + year1.Text + "' and Month='"+ month1.Text +"' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT p_id AS 'S/N',Expenses,Amount AS 'Amount Spent',Date,Note From Table_Expenditure Where Expenses='" + expenditure.Text + "' and branch='"+ branch.Text +"' AND Year='" + year1.Text + "' and Month='" + month1.Text + "' AND Day='"+ day1.Text +"' ORDER BY p_id DESC", dataGridView1);
            ab();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //  }
         
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Customer Summary", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //webb1.Print();
        }
       
    }
}

