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
    public partial class GP : Form
    {
        public GP()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        string str200 = "";
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                panel_ax.Visible = true;
                gclass.get_on1(webBrowser1);
                DialogResult dr27 = MessageBox.Show("Click Yes to Confirm Activation or No to Abort ...", "  Message from School-MS Online Monitoring Server: ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr27 == DialogResult.Yes)
                {
                    str200 = Convert.ToString(webBrowser1.Document.GetElementById("content").OuterText).Trim().TrimEnd();
                    if (str200 != "")
                    {
                        MySqlConnection cn = new MySqlConnection(str200);
                        cn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT School_ID FROM Table_verify_schoolms WHERE Key1='" + license_key.Text + "'", cn);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        try
                        {
                            if (dr.Read())
                            {
                               
                                gclass.display_in_dgv_Online_v("SELECT Campus,Pre_id,School_Name,s_t,s_status from table_verify_schoolms Where Key1='" + license_key.Text + "'", dataGridView1);
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    try
                                    {
                                        MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                                        cn1.Open();
                                        string query = "INSERT INTO Table_mr(branch,pre_id,branch_Name,s_t,s_status)values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "') ON DUPLICATE KEY UPDATE branch=values(branch),pre_id=values(pre_id),branch_Name=values(branch_name),s_t=values(s_t),s_status=values(s_status)";
                                        MySqlCommand cmd1 = new MySqlCommand(query, cn1);
                                        cmd1.ExecuteNonQuery();
                                        cn1.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        // MessageBox.Show(ex.Message);
                                    }
                                    // gclass.insert1_v("INSERT INTO Table_schools(school,pre_id)values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "') ON DUPLICATE KEY UPDATE school=values(school),pre_id=values(pre_id)");
                                }
                                                               
                                string ab = (string)dr.GetValue(0).ToString();
                                gclass.insert1("INSERT INTO Table_ma(ma)values('" + ab + "') ON DUPLICATE KEY UPDATE ma=values(ma)");


                                MessageBox.Show("License Key Successfully Verified and LPG Solution Activated ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Login1 fm = new Login1();
                                fm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("License key is invalid ... \n \n Contact the application vendor for a valid License Key.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection to Internet was Terminated. \n \n Kindly Check your Internet Connection and try again ...", "Message from Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            cn.Close(); cn.Dispose();
                            cmd.Dispose();
                            dr.Close(); dr.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            panel_ax.Visible = false;
        }
    }
}
