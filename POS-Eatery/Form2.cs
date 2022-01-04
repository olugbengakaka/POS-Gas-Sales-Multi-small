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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        Random rnd = new Random();
        private void Form2_Load(object sender, EventArgs e)
        {
            gclass.display_in_box_server_t(s_day, s_month, s_year, s_date, s_time);
            //gclass.display_in_dgv("SELECT* FROM Table_stock_inventory_summary WHERE p_id IN (SELECT MAX(p_id) FROM table_stock_inventory_summary GROUP BY Product_Name)", dataGridView1);
            gclass.display_in_dgv("SELECT DISTINCT Product_Name FROM Table_New_Product WHERE Branch='"+ branch.Text +"'", dataGridView2);
            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                gclass.display_in_dgv("SELECT* FROM table_stock_inventory_summary WHERE Product_Name='" + Convert.ToString(dataGridView2.Rows[j].Cells[0].Value) + "' and Branch='"+ branch.Text +"' order by p_id desc limit 1", dataGridView1);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                        cn.Open();
                        string ab = rnd.Next(1, 9500000) + "/" + s_date.Text+DateTime.Now.ToLongTimeString() + "/" + rnd.Next(1, 9500000) + branch.Text + dataGridView1.Rows[i].Cells[13].Value.ToString();

                        string query = "INSERT INTO table_stock_inventory_summary(Product_Name,Category,Quantity_Left,Unit,Reg_By,Date,Day,Month,Year,Code,Price,Branch)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value) + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + ab.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[15].Value.ToString() + "')";
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        cmd.CommandTimeout = 500000;
                        cmd.ExecuteNonQuery();
                        Login1 fm = new Login1();
                        fm.Show();
                       // this.Hide();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_VisibleChanged(object sender, EventArgs e)
        {
            if (button2.Visible == true)
            {
              /*Login1 fm = new Login1();
                fm.Show();
                this.Hide();*/
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string ab = rnd.Next(1, 9500000) + "/" + s_date.Text+DateTime.Now.ToLongTimeString() + "/" + rnd.Next(1, 9500000);

                    string query = "INSERT INTO table_stock_inventory_summary(Product_Name,Category,Quantity_Left,Unit,Reg_By,Date,Day,Month,Year,Code,Price)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value) + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + ab.ToString() + "','" + dataGridView1.Rows[i].Cells[12].Value.ToString() + "')";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();


                }
                catch (Exception ex)
                {
                  //  MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string ab = rnd.Next(1, 9500000) + "/" + s_date.Text+DateTime.Now.ToLongTimeString() + "/" + rnd.Next(1, 9500000);

                    string query = "INSERT INTO table_stock_inventory_summary(Product_Name,Category,Quantity_Left,Unit,Reg_By,Date,Day,Month,Year,Code)VALUES('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value) + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + ab.ToString() + "')";
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
