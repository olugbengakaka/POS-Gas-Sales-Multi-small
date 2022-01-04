using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace POS_Eatery
{
    public partial class ssssss : Form
    {
        public ssssss()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string url;
            url = "https://smsexperience.com/api/sms/sendsms?username=dtm123&password=dtm@solutions&sender=" + s_t.Text.TrimEnd() + "&recipient=" + receipient.Text.TrimEnd() + "@@&message=" + body.Text.TrimEnd() + "";

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

        }
    }
}
