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
    public partial class Refactor : Form
    {
        public Refactor()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button1_Click(object sender, EventArgs e)
        {
            if (year1.SelectedIndex == 0 || month1.SelectedIndex == 0)
            {
                MessageBox.Show("Both Year and Month must be Selected to begin Task ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                panel_ax.Visible = true;
                ///////////////////////////////////////////////////////////////////////
                gclass.display_in_dgv("Select distinct receipt_no from table_sales_confirmed where year='" + year1.Text + "' and Month='" + month1.Text + "'", dataGridView7);
                for (int i = 0; i < dataGridView7.Rows.Count; i++)
                {
                    string a = null;
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT SUM(Item_value) from table_sales_confirmed where receipt_no='" + Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    try
                    {
                        if (dr.Read())
                        {
                            a = (string)dr.GetValue(0).ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cn.Close(); cn.Dispose();
                        cmd.Dispose();
                        dr.Close(); dr.Dispose();
                    }
                    gclass.Update1("UPDATE table_sales_lump set item_value='" + a + "',Amount_Paid='" + a + "' where receipt_no='" + Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) + "' and item_value=amount_paid");
                }
                //////////////////////////////////////////////////////////////////////
                panel_ax.Visible = false;
            }



        }

        private void Refactor_Load(object sender, EventArgs e)
        {
            year1.SelectedIndex = 0; month1.SelectedIndex = 0;
        }
    }
}
