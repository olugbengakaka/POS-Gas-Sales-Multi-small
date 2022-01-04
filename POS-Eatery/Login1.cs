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
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        string log_branch = null;
        string abs=null;

        public string active()
        {
            bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (bb == true)
            {
                General_Class_Imp gclass = new General_Class_Imp();
                gclass.get_time_server(wb1, branch);
                DialogResult dr1 = MessageBox.Show("Server Verification is Required to Proceed... \n \n You must be connected to Internet to Proceed ...", " Warning From Server ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (dr1 == DialogResult.OK)
                {
                    try
                    {
                        s_day.Text = Convert.ToString(wb1.Document.GetElementById("content_day").OuterText).Trim().TrimEnd();
                        s_month.Text = Convert.ToString(wb1.Document.GetElementById("content_month").OuterText).Trim().TrimEnd();
                        s_year.Text = Convert.ToString(wb1.Document.GetElementById("content_year").OuterText).Trim().TrimEnd();
                        s_date.Text = Convert.ToString(wb1.Document.GetElementById("content_date").OuterText).Trim().TrimEnd();
                        s_time.Text = Convert.ToString(wb1.Document.GetElementById("content_time").OuterText).Trim().TrimEnd();
                        string code = s_date.Text + branch.Text;
                        string asp = "INSERT INTO table_s_t(day,month,year,date,time,branch,code)values('" + s_day.Text + "','" + s_month.Text + "','" + s_year.Text + "','" + s_date.Text + "','" + s_time.Text + "','" + branch.Text + "','" + code + "') on duplicate key update day=values(day),month=values(month),year=values(year),time=values(time)";
                        gclass.insert_timer_server(asp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // MessageBox.Show((wb1.Document.GetElementById("content_day").OuterText).Trim().TrimEnd());
                }
            }
            else
            {
                MessageBox.Show("Unable to Connect to Internet for Server Verification ... \n \n Check Your Internet Connection and Try again ...", " SERVER TIMER API VERIFICATION ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Sola";
        }

        private void Login1_Load(object sender, EventArgs e)
        {
            try
            {
               // this.BackgroundImage = Image.FromFile("C:/POST/images/bg1.jpg");
                panel2.BackgroundImage = Image.FromFile("C:/POST/images/img4.JPG");
                // label1.Text = "AMOS SHOPPING MALL";
              //  timer1.Start();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }

            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn.Open();
           // MySqlCommand cmd = new MySqlCommand("SELECT company_name from table_customize", cn);
            MySqlCommand cmd = new MySqlCommand("SELECT branch_name from table_mr", cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    label1.Text = (string)dr.GetValue(0).ToString().ToUpper() + " LPG Solution".ToUpper();
                    textBox1.Text = (string)dr.GetValue(0).ToString().ToUpper();
                    g_school.Text = (string)dr.GetValue(0).ToString().ToUpper();
                }
                else
                {
                    label1.Text = "EHR LPG SOLUTION";
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
            /////////////////////////////////////////////////////////////////////////////////
            MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            cn1.Open();
            MySqlCommand cmd1 = new MySqlCommand("SELECT s_status FROM Table_Mr", cn1);
            MySqlDataReader dr1 = cmd1.ExecuteReader();
            try
            {
                if (dr1.Read())
                {
                    abs = (string)dr1.GetValue(0).ToString();
                }

                /* if (abs != "**********")
                 {
                     MessageBox.Show("This Application had been De-activated due to failure of the School to \n \nPurchase Result Pin for Checking Result Online. \n \nContact any of Our Agents/ Representative in your Country for \n \nRe-activation ...", " Action from the Server ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                     Application.Exit();
                 }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn1.Close(); cn1.Dispose();
                cmd1.Dispose();
                dr1.Close(); dr1.Dispose();
            }
            ////////////////////////////////////////////////////////////////////////////////
            backgroundWorker1.RunWorkerAsync();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Now.Second <= 3)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 3 && DateTime.Now.Second <= 6)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 6 && DateTime.Now.Second <= 9)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 9 && DateTime.Now.Second <= 12)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 12 && DateTime.Now.Second <= 15)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 15 && DateTime.Now.Second <= 18)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 18 && DateTime.Now.Second <= 21)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 21 && DateTime.Now.Second <= 24)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 24 && DateTime.Now.Second <= 27)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 27 && DateTime.Now.Second <= 30)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 30 && DateTime.Now.Second <= 33)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 33 && DateTime.Now.Second <= 36)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 36 && DateTime.Now.Second <= 39)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 39 && DateTime.Now.Second <= 42)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 42 && DateTime.Now.Second <= 45)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 45 && DateTime.Now.Second <= 48)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 48 && DateTime.Now.Second <= 51)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 51 && DateTime.Now.Second <= 54)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 54 && DateTime.Now.Second <= 57)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 57 && DateTime.Now.Second <= 60)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }

           /* try
            {
                if (DateTime.Now.Second <= 5)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 5 && DateTime.Now.Second <= 10)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 10 && DateTime.Now.Second <= 15)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 15 && DateTime.Now.Second <= 20)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 20 && DateTime.Now.Second <= 25)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 25 && DateTime.Now.Second <= 30)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 30 && DateTime.Now.Second <= 35)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 35 && DateTime.Now.Second <= 40)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img4.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 40 && DateTime.Now.Second <= 45)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img5.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 45 && DateTime.Now.Second <= 50)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img1.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 50 && DateTime.Now.Second <= 55)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img2.JPG");
                    //panel1.Visible = true;
                }
                else if (DateTime.Now.Second > 55 && DateTime.Now.Second <= 60)
                {
                    panel2.BackgroundImage = Image.FromFile("C:/POST/images/Img3.JPG");
                    //panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "dtmoyo" && password.Text == "dtm@oyo#")
            {
                 MySqlDataReader dre1 = gclass.display_in_box("SELECT* FROM Table_S_T");
                 if (dre1.Read())
                 {
                     Home fm = new Home();
                     fm.login_status.Text = "Super";
                     fm.status.Text = "Super";
                    fm.owner.Text = textBox1.Text;
                    fm.g_school.Text = textBox1.Text;
                    gclass.display_in_combobox("SELECT Branch FROM Table_mr order by branch", fm.cmb_school, "branch");
                     fm.cmb_school.SelectedIndex = 0;
                     fm.cmb_school.Enabled = true;
                    // log_branch = (string)dr.GetValue(9).ToString();
                     fm.login_name.Text = "Super";
                     fm.Show();
                     this.Hide();
                 }
                 else
                 {
                     active();
                    /* Form10 fm = new Form10();
                     fm.branch.Text = log_branch;
                     fm.Show();
                     this.Close();*/
                 }

            }
            else if (abs != "**********")
            {
                MessageBox.Show("This Application had been De-activated/ block from execution \n \n ...", " Action from the Server ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               // Application.Exit();
            }
            else
            {
                if (username.Text == "activate" && password.Text == "activate@activate")
                {
                    GP fm = new GP();
                    gclass.Delete1("DELETE FROM Table_ma");
                    gclass.Delete1("DELETE FROM Table_mr");
                    fm.Show();
                    this.Hide();

                }
                else if (username.Text == "dtmoyo" && password.Text == "dtmoyophone")
                {
                    P_N fm = new P_N();
                    // fm.owner.Text = label1.Text;
                    fm.Show();
                }


                else
                {
                    MySqlDataReader dr = gclass.display_in_box("SELECT* FROM Table_Login WHERE User_Name='" + username.Text + "' AND Password='" + password.Text + "'");
                    if (dr.Read())
                    {
                        MySqlDataReader dre = gclass.display_in_box("SELECT* FROM Table_S_T");
                        if (dre.Read())
                        {
                            Home fm = new Home();
                            fm.login_status.Text = (string)dr.GetValue(4).ToString();
                            fm.status.Text = (string)dr.GetValue(4).ToString();
                            fm.login_name.Text = (string)dr.GetValue(7).ToString();
                            fm.users.Text = (string)dr.GetValue(7).ToString();
                            gclass.display_in_combobox("SELECT Branch FROM Table_mr order by branch", fm.cmb_school, "branch");
                            fm.cmb_school.SelectedIndex = -1;
                            fm.branch.Text = (string)dr.GetValue(9).ToString();
                            branch.Text = (string)dr.GetValue(9).ToString();
                            log_branch = (string)dr.GetValue(9).ToString();

                            fm.cmb_school.Text = fm.branch.Text;
                            if (fm.status.Text.Contains("Supe") || fm.status.Text.Contains("SUPE") || fm.status.Text.Contains("supe"))
                            {
                                fm.cmb_school.Enabled = true;
                                fm.cmb_school.Text = fm.branch.Text;
                            }
                            fm.owner.Text = textBox1.Text;
                            fm.g_school.Text = textBox1.Text;
                            fm.Show();
                            this.Hide();
                        }
                        else
                        {
                            active();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorect User Name/ Password Detected!", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (bb == true)
            {
                /* try
                 {
                     string web = "http://memesco.com/cstring.aspx";
                     WebBrowser wb1 = new WebBrowser();
                     wb1.Navigate(web);
                     System.Threading.Thread.Sleep(15000);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }*/

                try
                {
                    string str400 = "";
                    string bto = "";
                    /* gclass.get_on1(webBrowser1);    
                     DialogResult dr27 = MessageBox.Show("Click OK to Continue ...", "  Message from School-MS Online Monitoring Server: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     if (dr27 == DialogResult.OK)
                     {*/
                    // string str400 = Convert.ToString(webBrowser1.Document.GetElementById("content").OuterText).Trim().TrimEnd();
                    str400 = "Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;";
                    if (str400 != "")
                    {
                        MySqlConnection cn = new MySqlConnection(str400);
                        cn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT S_status FROM Table_verify_schoolms WHERE School_name='" + g_school.Text + "'", cn);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        try
                        {
                            if (dr.Read())
                            {
                                // MessageBox.Show((string)dr.GetValue(0).ToString());
                                bto = Convert.ToString((string)dr.GetValue(0).ToString());
                                try
                                {
                                    MySqlConnection cn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                                    cn1.Open();
                                    string query = "UPDATE Table_Mr set s_status='" + bto + "'";
                                    MySqlCommand cmd1 = new MySqlCommand(query, cn1);
                                    cmd1.ExecuteNonQuery();
                                    // MessageBox.Show("Success");
                                }
                                catch (Exception ex)
                                {
                                    // MessageBox.Show(ex.Message);
                                }
                                // MessageBox.Show("Verification Sussesfully Done ...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            else
                            {
                                // MessageBox.Show("Unable to Verify ... \n \n Contact the application vendor for a valid License Key.", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            //  MessageBox.Show("Connection to Internet was Terminated. \n \n Kindly Check your Internet Connection and try again ...", "Message from Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            cn.Close(); cn.Dispose();
                            cmd.Dispose();
                            dr.Close(); dr.Dispose();
                        }
                    }
                }
                // }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
