using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS_Eatery
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("1", "Sola");
            dataGridView1.Rows.Add("3", "Adebayo");
            dataGridView1.Rows.Add("2", "Adebayo");
            dataGridView1.Rows.Add("5", "Adebayo");
            dataGridView1.Rows.Add("4", "Adebayo");
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          //  dataGridView1.BeginInvoke(new InvokeDelegate(AttachData));
           

           // MessageBox.Show(dataGridView1.Rows)

           /* DataGridView gv = new DataGridView();
            gclass.display_in_dgv("SELECT* FROM Table_stock_inventory_summary WHERE Date='" + DateTime.Now.ToShortDateString() + "'", gv);
            gv.Show();
            gv.Visible = true;
           // MessageBox.Show("Adebowale sodeeq ...");

            try
            {
                MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_stock_inventory_summary WHERE Date='" + DateTime.Now.ToShortDateString() + "'");
                if (dr.Read())
                {
                    MessageBox.Show(" Exist ...");
                }
                else
                {
                    MessageBox.Show(" Not Exist ..."); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // MessageBox.Show("Kindly Re-Login and ensure that both the Server and Routers are Switch \n \n On ... ", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Completed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Sort(dataGridView1.Columns["serial"], ListSortDirection.Ascending);
            //backgroundWorker1.RunWorkerAsync();
        }
    }
}
