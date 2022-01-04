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
using System.Net;
using System.Net.Mail;

namespace POS_Eatery
{
    public partial class SMS_Text : Form
    {
        public SMS_Text()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        string s_t = "";
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home fm = new Home();
            fm.login_name.Text = users.Text;
            fm.login_status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Home fm = new Home();
            fm.login_name.Text = users.Text;
            fm.login_status.Text = status.Text;
            fm.Show();
            this.Hide();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login1 fm = new Login1();
            fm.Show();
            this.Hide();
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you Really want to Exit the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (dr == DialogResult.Yes)
           // {
                Application.Exit();
           // }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Do you Really want to Exit the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (dr == DialogResult.Yes)
           // {
                Application.Exit();
           // }
        }

        private void receipient_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(body.Text))
                {
                    MessageBox.Show("Enter Your Message ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             else if (sms_reminder.Checked==false && sms_acknowledgement.Checked==false && sms_general.Checked==false)
             {
                 MessageBox.Show(" Select Category of SMS you are sending (Reminder, Acknowledgment, or General SMS) ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else if (sms_reminder.Checked == true && Convert.ToDecimal(no_of_days.Text) <= 0)
             {
                 MessageBox.Show("Enter the No. of Days ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 /* if (receipient.Text.Contains("Staff"))
                  {
                      query_textbox.Text = "SELECT Tel_NO FROM Table_Employee";
                      gclass.display_in_dgv(query_textbox.Text, dgvdisplay);
                  }
                  else if (receipient.Text.Contains("Buy"))
                  {

                      gclass.display_in_dgv_online("SELECT* FROM table_buyers", dgvdisplay);

                      for (int i = 0; i < dgvdisplay.Rows.Count; i++)
                      {

                          try
                          {
                              MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                              cn.Open();
                              string query = "INSERT INTO table_buyers(p_id,tel_no,Date,Day,Month,Year,Code,Full_Name)VALUES('" + dgvdisplay.Rows[i].Cells[0].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[1].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[2].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[3].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[4].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[5].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[6].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[7].Value.ToString() + "') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),date=values(date),day=values(day),month=values(month),year=values(year),code=values(code),full_name=values(full_name)";
                              MySqlCommand cmd = new MySqlCommand(query, cn);
                              cmd.ExecuteNonQuery();
                              cn.Close();
                          }
                          catch (Exception ex)
                          {
                              // MessageBox.Show(ex.Message);
                          }
                      }


                       gclass.display_in_dgv("SELECT DISTINCT Tel_NO FROM Table_Buyers", dgvdisplay);
                      for (int j = 0; j < dgvdisplay.Rows.Count; j++)
                      {
                          textBox2.Text = textBox2.Text + Convert.ToString(dgvdisplay.Rows[j].Cells[0].Value) + ",";
                      }


                  }



                  gclass.display_in_dgv_online("SELECT* FROM table_buyers", dgvdisplay);

                  for (int i = 0; i < dgvdisplay.Rows.Count; i++)
                  {

                      try
                      {
                          MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                          cn.Open();
                          string query = "INSERT INTO table_buyers(p_id,tel_no,Date,Day,Month,Year,Code,Full_Name)VALUES('" + dgvdisplay.Rows[i].Cells[0].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[1].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[2].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[3].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[4].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[5].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[6].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[7].Value.ToString() + "') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),date=values(date),day=values(day),month=values(month),year=values(year),code=values(code),full_name=values(full_name)";
                          MySqlCommand cmd = new MySqlCommand(query, cn);
                          cmd.ExecuteNonQuery();
                          cn.Close();
                      }
                      catch (Exception ex)
                      {
                          //      MessageBox.Show(ex.Message);
                      }
                  }*/


               //  gclass.Update1("UPDATE Table_buyers set tel_no='08055144000,08030756848' where tel_no=''");



                 try
                 {
                     MySqlDataReader dr16 = gclass.display_in_box("SELECT* FROM Table_mr where branch='" + branch.Text + "'");
                     if (dr16.Read())
                     {
                         s_t = (string)dr16.GetValue(4).ToString();
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                     //result_output.Text = ex.Message;
                 }


                 if (sms_reminder.Checked == true)
                 {
                     gclass.display_in_dgv("SELECT DISTINCT Tel_NO from table_buyers WHERE branch='"+ branch.Text +"' AND date<DATE( DATE_SUB( NOW() , INTERVAL " + no_of_days.Text + " DAY ) )", dgvdisplay);
                 }
                 else if (sms_acknowledgement.Checked == true)
                 {
                     gclass.display_in_dgv("SELECT DISTINCT Tel_NO FROM Table_Buyers WHERE Day='" + dateTimePicker1.Value.Day + "' and Month='" + dateTimePicker1.Value.Month + "' and Year='" + dateTimePicker1.Value.Year + "' AND branch='" + branch.Text + "'", dgvdisplay);
                    // dgvdisplay.Rows.Add(textBox4.Text);
                 }
                 else if (sms_general.Checked == true)
                 {
                     gclass.display_in_dgv("SELECT DISTINCT Tel_NO FROM Table_Buyers WHERE branch='" + branch.Text + "'", dgvdisplay);
                    // dgvdisplay.Rows.Add(textBox4.Text);
                 }
                 for (int j = 0; j < dgvdisplay.Rows.Count; j++)
                 {
                     textBox2.Text = Convert.ToString(dgvdisplay.Rows[j].Cells[0].Value);
                 }
                 // textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);

                 // MySqlConnection cn = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");


                 try
                 {
                     MySqlConnection cn7 = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");
                     cn7.Open();
                     MySqlCommand cmd7 = new MySqlCommand("SELECT* FROM table_sms_balance WHERE Act='" + sms_act_code.Text + "' AND School_ID='" + sms_school_id.Text + "'", cn7);
                     MySqlDataReader dr7 = cmd7.ExecuteReader();
                     if (dr7.Read())
                     {
                         sms_no_message_to_send.Text = dgvdisplay.Rows.Count.ToString();

                         textBox3.Text = (string)dr7.GetValue(3).ToString();
                         if (Convert.ToDecimal(textBox3.Text) > Convert.ToDecimal(sms_no_message_to_send.Text))
                         {
                             // /////////////// TRYING TO SEND SMS ALERT /////////////////////////////////////////////

                             try
                             {

                                 MySqlConnection cn5 = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");
                                 cn5.Open();

                                 MySqlCommand mmd = new MySqlCommand("UPDATE Table_sms_balance set balance=balance-'" + Convert.ToDecimal(sms_no_message_to_send.Text) + "' WHERE School_ID='" + sms_school_id.Text + "' AND Act='" + sms_act_code.Text + "'", cn5);
                                 mmd.ExecuteNonQuery();
                             }
                             catch (Exception ex)
                             {
                                 MessageBox.Show(ex.Message);
                             }

                             result.Visible = true;
                             for (int i = 0; i < dgvdisplay.Rows.Count; i++)
                             {
                                 try
                                 {
                                     string url;
                                     url = "https://smsexperience.com/api/sms/sendsms?username=dtm123&password=dtm@solutions&sender=" + s_t.TrimEnd() + "&recipient=" + Convert.ToString(dgvdisplay.Rows[i].Cells[0].Value).TrimEnd() + "@@&message=" + body.Text.TrimEnd() + "";

                                     HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                                     //Get response from the SMS Gateway Server and read the answer
                                     HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                                     System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                                     try
                                     {
                                         string responseString = respStreamReader.ReadToEnd();
                                     }
                                     catch (Exception ex)
                                     {
                                         // MessageBox.Show(ex.Message);
                                     }
                                     finally
                                     {
                                         myResp.Close();
                                         respStreamReader.Close(); respStreamReader.Dispose();
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     //////////////////////////////////////////////////
                                     string url;
                                     url = "https://smsexperience.com/api/sms/sendsms?username=dtm123&password=dtm@solutions&sender=" + s_t.TrimEnd() + "&recipient=" + textBox4.Text.TrimEnd() + "@@&message=" + body.Text.TrimEnd() + "";

                                     HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                                     //Get response from the SMS Gateway Server and read the answer
                                     HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                                     System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                                     try
                                     {
                                         string responseString = respStreamReader.ReadToEnd();
                                     }
                                     catch (Exception ef)
                                     {
                                         // MessageBox.Show(ex.Message);
                                     }
                                     finally
                                     {
                                         myResp.Close();
                                         respStreamReader.Close(); respStreamReader.Dispose();
                                     }
                                     /////////////////////////////////////////////////
                                     // MessageBox.Show(xe.Message);
                                 }
                             }


                             ///////////////////////////////////DISPLAY SMS BALANCE //////////////////////////////////
                             try
                             {
                                 MySqlConnection cn6 = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");
                                 cn6.Open();
                                 MySqlCommand cmd6 = new MySqlCommand("SELECT* FROM table_sms_balance WHERE Act='" + sms_act_code.Text + "' AND School_ID='" + sms_school_id.Text + "'", cn6);
                                 MySqlDataReader dr6 = cmd6.ExecuteReader();
                                 if (dr6.Read())
                                 {
                                     sms_balance.Text = "Current SMS Balance: \t \t \t \t \t " + (string)dr6.GetValue(3).ToString();
                                 }
                             }
                             catch (Exception ex)
                             {
                                 MessageBox.Show(ex.Message);
                             }


                             result.Visible = false;
                             MessageBox.Show("Successfully Sent SMS Message ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);

                         }


                     }
                     else if (Convert.ToDecimal(textBox3.Text) < 1)
                     {
                         MessageBox.Show("Insufficient SMS Credit Balance  ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                     else
                     {
                         MessageBox.Show("SMS Not Yet Activated for HEPHZIBAH PET. LTD ... ", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
    

        }

        private void query_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* FROM table_sms_balance WHERE Act='" + sms_act_code.Text + "' AND School_ID='" + sms_school_id.Text + "'", cn);
                MySqlDataReader dr5 = cmd.ExecuteReader();
                if (dr5.Read())
                {
                    sms_balance.Text = "Current SMS Balance: \t \t \t \t \t " + (string)dr5.GetValue(3).ToString() + " unit(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // query_textbox.Text = ;
            gclass.display_in_dgv("SELECT DISTINCT Tel_NO FROM Table_Buyers WHERE branch='" + branch.Text + "'", dgvdisplay);
            for (int j = 0; j < dgvdisplay.Rows.Count; j++)
            {
                textBox2.Text = textBox2.Text + Convert.ToString(dgvdisplay.Rows[j].Cells[0].Value) + ",";
            }
            sms_no_message_to_send.Text = dgvdisplay.Rows.Count.ToString();
            sms_no_message_to_send.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void SMS_Text_Load(object sender, EventArgs e)
        {
            textBox4.Visible = false;
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT number from table_number where branch='"+ branch.Text +"' order by p_id desc limit 1", cn);
                MySqlDataReader dr9 = cmd.ExecuteReader();
                try
                {
                    if (dr9.Read())
                    {
                        textBox4.Text = (string)dr9.GetValue(0).ToString();
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
                    dr9.Close(); dr9.Dispose();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }


            receipient.SelectedIndex = 0;

            MySqlDataReader dr = gclass.display_in_box("SELECT* FROM table_act");
            try
            {
                if (dr.Read())
                {
                    sms_act_code.Text = (string)dr.GetValue(1).ToString();
                    sms_school_id.Text = (string)dr.GetValue(2).ToString();
                    //MessageBox.Show(sms_act_code.Text + " =========== " + sms_school_id.Text);
                    dr.Close();
                }
            }
            catch
            {

            }
            finally
            {
                dr.Close();
            }


            pictureBox3.Image = Image.FromFile(Application.StartupPath + "/images/error.png");
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "/images/lock.ico");
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "/images/arrow2.png");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/images/student1.jpg");
            panel1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/portal.png");

        }

        private void dgvdisplay_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            sms_no_message_to_send.Text = dgvdisplay.Rows.Count.ToString();
        }

        private void dgvdisplay_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            sms_no_message_to_send.Text = dgvdisplay.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(body.Text.Length.ToString());
            /*gclass.display_in_dgv_online("SELECT* FROM table_buyers", dgvdisplay);

            for (int i = 0; i < dgvdisplay.Rows.Count; i++)
            {

                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    string query = "INSERT INTO table_buyers(p_id,tel_no,Date,Day,Month,Year,Code,Full_Name)VALUES('" + dgvdisplay.Rows[i].Cells[0].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[1].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[2].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[3].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[4].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[5].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[6].Value.ToString() + "','" + dgvdisplay.Rows[i].Cells[7].Value.ToString() + "') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),date=values(date),day=values(day),month=values(month),year=values(year),code=values(code),full_name=values(full_name)";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    //      MessageBox.Show(ex.Message);
                }
            }*/
        }

        private void no_of_days_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(no_of_days.Text))
            {
                no_of_days.Text = "0";
            }

            try
            {
                int a = int.Parse(no_of_days.Text);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void sms_reminder_CheckedChanged(object sender, EventArgs e)
        {
            if (sms_reminder.Checked == true)
            {
                label3.Visible = true;
                label3.Text = " No. of Days ";
                no_of_days.Visible = true;
                dateTimePicker1.Visible = false;
                sms_general.Checked = false;
                sms_acknowledgement.Checked = false;
            }
        }

        private void sms_acknowledgement_CheckedChanged(object sender, EventArgs e)
        {
            if (sms_acknowledgement.Checked == true)
            {
                label3.Visible = true;
                label3.Text = " Select Date ";
                no_of_days.Visible = false;
                dateTimePicker1.Visible = true;
                sms_general.Checked = false;
                sms_reminder.Checked = false;
            }
        }

        private void sms_general_CheckedChanged(object sender, EventArgs e)
        {
            if (sms_general.Checked == true)
            {
                label3.Visible = false;
                label3.Visible = false;
                no_of_days.Visible = false;
                dateTimePicker1.Visible = false;
                sms_acknowledgement.Checked = false;
                sms_reminder.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gclass.display_in_dgv("SELECT DISTINCT Tel_NO FROM Table_Buyers WHERE branch='" + branch.Text + "'", dgvdisplay);
        }
    }
}
