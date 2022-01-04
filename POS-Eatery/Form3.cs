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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        Random rnd = new Random();
        private void Form3_Load(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT* FROM Table_stock_inventory_summary WHERE p_id IN (SELECT MAX(p_id) FROM table_stock_inventory_summary GROUP BY Product_Name)", dataGridView1);
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string ab = rnd.Next(1, 9500000) + "/" + DateTime.Now + "/" + rnd.Next(1, 9500000);

                    string query = "INSERT INTO table_stock_inventory_summary(Product_Name,Category,Quantity_Left,Unit,Reg_By,Date,Day,Month,Year,Price,Code)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value) + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + ab.ToString() + "')";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
