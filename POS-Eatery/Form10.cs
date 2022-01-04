using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace POS_Eatery
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
      

        private void Form10_Load(object sender, EventArgs e)
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
                 MessageBox.Show("Unable to Connect to Internet for Server Verification ... \n \n Check Your Internet Connection and Try again ...");
             }


        }
    }
}
