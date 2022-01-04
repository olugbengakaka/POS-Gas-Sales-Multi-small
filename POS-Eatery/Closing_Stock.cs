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
    public partial class Closing_Stock : Form
    {
        public Closing_Stock()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        MySqlDataReader dr;
        bool ready = false;
        private void crosscheck()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* FROM TABLE_CLOSING_STOCK_GAS where date='" + s_date.Text + "' and branch='" + branch.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ready = true;
                }
                else
                {
                    ready = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void find_display()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                txt1.Text = "0"; txt2.Text = "0"; txt_total.Text = "0";
                string param = pump.Text.Replace(" ", "_") + "_" + meter.Text.Replace(" ", "_");
                MySqlCommand cmd = new MySqlCommand("SELECT " + param + ",(pump_1_meter_1+pump_1_meter_2+pump_2_meter_1+pump_2_meter_2+pump_3_meter_1+pump_3_meter_2+pump_4_meter_1+pump_4_meter_2+pump_5_meter_1+pump_5_meter_2+pump_6_meter_1+pump_6_meter_2) FROM TABLE_CLOSING_STOCK_GAS where branch='" + branch.Text + "' order by p_id desc limiT 1,1", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt1.Text = (string)dr.GetValue(0).ToString();
                    txt_total.Text = (string)dr.GetValue(1).ToString();
                }
                else
                {
                    txt1.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //////////////////////////////
           /* try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                txt1.Text = "0"; txt2.Text = "0"; txt_total.Text = "0";
                string param = pump.Text.Replace(" ", "_") + "_" + meter.Text.Replace(" ", "_");
                MySqlCommand cmd = new MySqlCommand("SELECT (pump_1_meter_1+pump_1_meter_2+pump_2_meter_1+pump_2_meter_2+pump_3_meter_1+pump_3_meter_2+pump_4_meter_1+pump_4_meter_2+pump_5_meter_1+pump_5_meter_2+pump_6_meter_1+pump_6_meter_2) FROM TABLE_CLOSING_STOCK_GAS where branch='" + branch.Text + "' order by p_id desc limiT 1,1", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_total.Text = (string)dr.GetValue(1).ToString();
                    MessageBox.Show(txt_total.Text.ToString());
                }
                else
                {
                    txt1.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/



        }

        private void total_of_sales_gas_kg()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                textBox1.Text = "0";
                MySqlCommand cmd = new MySqlCommand("select SUM(Quantity) from table_sales_confirmed where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "' and Product_Name like 'Gas%'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = (string)dr.GetValue(0).ToString();
                    gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET sales_report='" + textBox1.Text + "' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void column_hide()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[17].Visible = false;
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void Closing_Stock_Load(object sender, EventArgs e)
        {
            crosscheck();
            gclass.display_in_box_server_t(s_day, s_month, s_year, s_date, s_time);

           // gclass.Update1("pump_1_meter_1+pump_1_meter_2+pump_2_meter_1+pump_2_meter_2+pump_3_meter_1+pump_3_meter_2+pump_4_meter_1+pump_4_meter_2+pump_5_meter_1+pump_5_meter_2+pump_6_meter_1+pump_6_meter_2")

            gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Total=(PUMP_1_METER_1+PUMP_1_METER_2+PUMP_2_METER_1+PUMP_2_METER_2+PUMP_3_METER_1+PUMP_3_METER_2+PUMP_4_METER_1+PUMP_4_METER_2+PUMP_5_METER_1+PUMP_5_METER_2+PUMP_6_METER_1+PUMP_6_METER_2)");

            gclass.display_in_dgv("SELECT Date,PUMP_1_METER_1 AS 'P1M1',PUMP_1_METER_2 AS 'P1M2',PUMP_2_METER_1 AS 'P2M1',PUMP_2_METER_2 AS 'P2M2',PUMP_3_METER_1 AS 'P3M1',PUMP_3_METER_2 AS 'P3M2',PUMP_4_METER_1 AS 'P4M1',PUMP_4_METER_2 AS 'P4M2',PUMP_5_METER_1 AS 'P5M1',PUMP_5_METER_2 AS 'P5M2',PUMP_6_METER_1 AS 'P6M1',PUMP_6_METER_2 AS 'P6M2',Total as 'Total Reading(Meter)',sales_Report as 'Total kg(Sales Report)',(tt_out-sales_report) as 'Difference(kg)',Verdict as 'Status',Code,tt_out as 'Total Output' FROM TABLE_CLOSING_STOCK_GAS where branch='"+ branch.Text +"' order by p_id desc", dataGridView1);
            column_hide();
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            panel_ax.Visible = true;
            if (pump.SelectedIndex == -1)
            {
                MessageBox.Show(" Select Pump ...", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (meter.SelectedIndex == -1)
            {
                MessageBox.Show(" Select Meter for the Selected Pump ...", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                /////////////////////////////////
                if (ready == false)
                {
                    string code1 = s_date.Text + branch.Text;
                    gclass.insert1("INSERT INTO TABLE_CLOSING_STOCK_GAS(DATE,DAY,MONTH,YEAR,TIME,REGISTERED_bY,Code,Branch)values('" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + users.Text + "','" + code1 + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE registered_by=values(registered_by)");
                }
                /////////////////////////////
                find_display();
                txt2.Text = (Convert.ToDecimal(quantity.Text) - Convert.ToDecimal(txt1.Text)).ToString();
                string code = s_date.Text + branch.Text;
                string param = pump.Text.Replace(" ", "_") + "_" + meter.Text.Replace(" ", "_");
                gclass.insert("INSERT INTO TABLE_CLOSING_STOCK_GAS(" + param + ",Code)values('" + quantity.Text + "','" + code + "') ON DUPLICATE KEY UPDATE code=values(code)," + param + "=values(" + param + ");UPDATE TABLE_CLOSING_STOCK_GAS SET Total=(PUMP_1_METER_1+PUMP_1_METER_2+PUMP_2_METER_1+PUMP_2_METER_2+PUMP_3_METER_1+PUMP_3_METER_2+PUMP_4_METER_1+PUMP_4_METER_2+PUMP_5_METER_1+PUMP_5_METER_2+PUMP_6_METER_1+PUMP_6_METER_2);");
                  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                try
                {
                    
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    comp1.Text = "0"; comp2.Text = "0";
                    MySqlCommand cmd = new MySqlCommand("SELECT (pump_1_meter_1+pump_1_meter_2+pump_2_meter_1+pump_2_meter_2+pump_3_meter_1+pump_3_meter_2+pump_4_meter_1+pump_4_meter_2+pump_5_meter_1+pump_5_meter_2+pump_6_meter_1+pump_6_meter_2),sales_report FROM TABLE_CLOSING_STOCK_GAS where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        comp1.Text = (string)dr.GetValue(0).ToString();
                        comp2.Text = (string)dr.GetValue(1).ToString();
                        
                        string total_prev_deduct_current = (Convert.ToDecimal(comp1.Text) - Convert.ToDecimal(txt_total.Text)).ToString();//tt_out
                        gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET tt_out='" + total_prev_deduct_current + "' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");

                      /*  if (Convert.ToDecimal(comp1.Text) == Convert.ToDecimal(comp2.Text))
                        {
                            gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                            // MessageBox.Show(" Pump and Meter Balanced with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCE' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                            // MessageBox.Show(" Pump and Meter Not Balance with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' where Sales_Report=tt_out AND branch='" + branch.Text + "';UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCED' where Sales_Report!=tt_out AND branch='" + branch.Text + "';");
                gclass.display_in_dgv("SELECT Date,PUMP_1_METER_1 AS 'P1M1',PUMP_1_METER_2 AS 'P1M2',PUMP_2_METER_1 AS 'P2M1',PUMP_2_METER_2 AS 'P2M2',PUMP_3_METER_1 AS 'P3M1',PUMP_3_METER_2 AS 'P3M2',PUMP_4_METER_1 AS 'P4M1',PUMP_4_METER_2 AS 'P4M2',PUMP_5_METER_1 AS 'P5M1',PUMP_5_METER_2 AS 'P5M2',PUMP_6_METER_1 AS 'P6M1',PUMP_6_METER_2 AS 'P6M2',Total as 'Total Reading(Meter)',sales_Report as 'Total kg(Sales Report)',(tt_out-sales_report) as 'Difference(kg)',Verdict as 'Status',Code,tt_out as 'Total Output' FROM TABLE_CLOSING_STOCK_GAS where branch='" + branch.Text + "' order by p_id desc", dataGridView1);
                column_hide();
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                total_of_sales_gas_kg();

            }
            panel_ax.Visible = false;
        }

        private void pump_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* /////////////////////////////////
            if (ready == false)
            {
                string code = s_date.Text + branch.Text;
                gclass.insert1("INSERT INTO TABLE_CLOSING_STOCK_GAS(DATE,DAY,MONTH,YEAR,TIME,REGISTERED_bY,Code,Branch)values('" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + users.Text + "','" + code + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE registered_by=values(registered_by)");
            }
            /////////////////////////////*/
            
        }

        private void meter_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* /////////////////////////////////
            if (ready == false)
            {
                string code = s_date.Text + branch.Text;
                gclass.insert1("INSERT INTO TABLE_CLOSING_STOCK_GAS(DATE,DAY,MONTH,YEAR,TIME,REGISTERED_bY,Code,Branch)values('" + s_date.Text + "','" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + DateTime.Now.ToLongTimeString() + "','" + users.Text + "','" + code + "','" + branch.Text + "') ON DUPLICATE KEY UPDATE registered_by=values(registered_by)");
            }
            /////////////////////////////*/
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*panel_ax.Visible = true;
            total_of_sales_gas_kg();
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                comp1.Text = "0"; comp2.Text = "0";
                MySqlCommand cmd = new MySqlCommand("SELECT (pump_1_meter_1+pump_1_meter_2+pump_2_meter_1+pump_2_meter_2+pump_3_meter_1+pump_3_meter_2+pump_4_meter_1+pump_4_meter_2+pump_5_meter_1+pump_5_meter_2+pump_6_meter_1+pump_6_meter_2),sales_report FROM TABLE_CLOSING_STOCK_GAS where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comp1.Text = (string)dr.GetValue(0).ToString();
                    comp2.Text = (string)dr.GetValue(1).ToString();

                    string total_prev_deduct_current = (Convert.ToDecimal(comp1.Text) - Convert.ToDecimal(txt_total.Text)).ToString();
                    gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Total='" + total_prev_deduct_current + "' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                   
                    if (Convert.ToDecimal(comp1.Text) == Convert.ToDecimal(comp2.Text))
                    {
                        gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                       // MessageBox.Show(" Pump and Meter Balanced with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCE' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                       // MessageBox.Show(" Pump and Meter Not Balance with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            panel_ax.Visible = false;*/
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_ax.Visible = true;
            total_of_sales_gas_kg();
            try
            {
                gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' where Sales_Report=tt_out AND branch='" + branch.Text + "';UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCED' where Sales_Report!=tt_out AND branch='" + branch.Text + "';");
           
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                comp1.Text = "0"; comp2.Text = "0";
                MySqlCommand cmd = new MySqlCommand("SELECT tt_out,sales_report FROM TABLE_CLOSING_STOCK_GAS where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comp1.Text = (string)dr.GetValue(0).ToString();
                    comp2.Text = (string)dr.GetValue(1).ToString();
                    if (Convert.ToDecimal(comp1.Text) == Convert.ToDecimal(comp2.Text))
                    {
                        gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                        MessageBox.Show(" Pump and Meter Reading for " + s_date.Text + " Balanced with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCE' where year='" + s_year.Text + "' AND MONTH='" + s_month.Text + "' AND Day='" + s_day.Text + "' and branch='" + branch.Text + "'");
                        MessageBox.Show(" Pump and Meter Reading for " + s_date.Text + " Does Not Balance with Sales Report ... \n \n Some Went Wrong Somewhere ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            panel_ax.Visible = false;
        }

        private void chk_edit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_edit.Checked == true)
                {
                    dataGridView1.ReadOnly = false;
                }
                else
                {
                    dataGridView1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_ax.Visible = true;
           /* if (pump.SelectedIndex == -1)
            {
                MessageBox.Show(" Select Pump ...", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (meter.SelectedIndex == -1)
            {
                MessageBox.Show(" Select Meter for the Selected Pump ...", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {*/
            string query = "INSERT INTO TABLE_CLOSING_STOCK_GAS(pump_1_meter_1,pump_1_meter_2,pump_2_meter_1,pump_2_meter_2,pump_3_meter_1,pump_3_meter_2,pump_4_meter_1,pump_4_meter_2,pump_5_meter_1,pump_5_meter_2,pump_6_meter_1,pump_6_meter_2,Total,Sales_Report,Verdict,Code)VALUES('" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[7].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[8].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[9].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[10].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[11].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[12].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[13].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[14].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[16].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[17].Value.ToString() + "') ON DUPLICATE KEY UPDATE pump_1_meter_1=values(pump_1_meter_1),pump_1_meter_2=values(pump_1_meter_2),code=values(code),pump_2_meter_1=values(pump_2_meter_1),pump_2_meter_2=values(pump_2_meter_2),pump_3_meter_1=values(pump_3_meter_1),pump_3_meter_2=values(pump_3_meter_2),pump_4_meter_1=values(pump_4_meter_1),pump_4_meter_2=values(pump_4_meter_2),pump_5_meter_1=values(pump_5_meter_1),pump_5_meter_2=values(pump_5_meter_2),pump_6_meter_1=values(pump_6_meter_1),pump_6_meter_2=values(pump_6_meter_2),registered_by=values(registered_by),branch=values(branch),total=values(total),sales_report=values(sales_report),verdict=values(verdict);UPDATE TABLE_CLOSING_STOCK_GAS SET Total=(PUMP_1_METER_1+PUMP_1_METER_2+PUMP_2_METER_1+PUMP_2_METER_2+PUMP_3_METER_1+PUMP_3_METER_2+PUMP_4_METER_1+PUMP_4_METER_2+PUMP_5_METER_1+PUMP_5_METER_2+PUMP_6_METER_1+PUMP_6_METER_2);";
                gclass.insert(query); 
            /* // find_display();
// txt2.Text = (Convert.ToDecimal(quantity.Text) - Convert.ToDecimal(txt1.Text)).ToString();
string code = s_date.Text + branch.Text;
string param = pump.Text.Replace(" ", "_") + "_" + meter.Text.Replace(" ", "_");
gclass.Update("UPDATE TABLE_CLOSING_STOCK_GAS SET " + param + "=" + quantity.Text + " WHERE Date='"+ Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) +"' and Branch='"+ branch.Text +"';UPDATE TABLE_CLOSING_STOCK_GAS SET Total=(PUMP_1_METER_1+PUMP_1_METER_2+PUMP_2_METER_1+PUMP_2_METER_2+PUMP_3_METER_1+PUMP_3_METER_2+PUMP_4_METER_1+PUMP_4_METER_2+PUMP_5_METER_1+PUMP_5_METER_2+PUMP_6_METER_1+PUMP_6_METER_2);");
////////////////////////////////////////////////////////
total_of_sales_gas_kg();
// total_of_sales_gas_kg();
try
{
MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
cn.Open();
comp1.Text = "0"; comp2.Text = "0";
MySqlCommand cmd = new MySqlCommand("SELECT total,sales_report FROM TABLE_CLOSING_STOCK_GAS WHERE Date='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) + "' and Branch='" + branch.Text + "'", cn);
dr = cmd.ExecuteReader();
if (dr.Read())
{
comp1.Text = (string)dr.GetValue(0).ToString();
comp2.Text = (string)dr.GetValue(1).ToString();
if (Convert.ToDecimal(comp1.Text) == Convert.ToDecimal(comp2.Text))
{
    gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' WHERE Date='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) + "' and Branch='" + branch.Text + "'");
    // MessageBox.Show(" Pump and Meter Balanced with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
else
{
    gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCE' WHERE Date='" + Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value) + "' and Branch='" + branch.Text + "'");
    // MessageBox.Show(" Pump and Meter Not Balance with Sales Report ... ", " POS Intelliscense Says! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
}
catch (Exception ex)
{
MessageBox.Show(ex.Message);
}
///////////////////////////////////////////////////////*/
                gclass.insert1("UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='BALANCED' where Sales_Report=tt_out AND branch='" + branch.Text + "';UPDATE TABLE_CLOSING_STOCK_GAS SET Verdict='NOT BALANCED' where Sales_Report!=tt_out AND branch='" + branch.Text + "';");
                gclass.display_in_dgv("SELECT Date,PUMP_1_METER_1 AS 'P1M1',PUMP_1_METER_2 AS 'P1M2',PUMP_2_METER_1 AS 'P2M1',PUMP_2_METER_2 AS 'P2M2',PUMP_3_METER_1 AS 'P3M1',PUMP_3_METER_2 AS 'P3M2',PUMP_4_METER_1 AS 'P4M1',PUMP_4_METER_2 AS 'P4M2',PUMP_5_METER_1 AS 'P5M1',PUMP_5_METER_2 AS 'P5M2',PUMP_6_METER_1 AS 'P6M1',PUMP_6_METER_2 AS 'P6M2',Total as 'Total Reading(Meter)',sales_Report as 'Total kg(Sales Report)',(tt_out-sales_report) as 'Difference(kg)',Verdict as 'Status',Code,tt_out as 'Total Output' FROM TABLE_CLOSING_STOCK_GAS where branch='" + branch.Text + "' order by p_id desc", dataGridView1);
                column_hide();
                total_of_sales_gas_kg();
          //  }
            panel_ax.Visible = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //dataGridView1.SelectedRows[0].ReadOnly = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
