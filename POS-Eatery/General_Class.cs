using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;

namespace pos
{
    class General_Class
    {
        MySqlDataReader dr;

        public string export_to_excell(DataGridView dataGridView1)
        {
            try
            {
                dataGridView1.SelectAll();
                DataObject dataObj = dataGridView1.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);

                // copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string printdocument(DataGridView dgv_to_print, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dgv_to_print.Width, dgv_to_print.Height);
            dgv_to_print.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, dgv_to_print.Width, dgv_to_print.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = true;
            }
            return "Sola";
        }

        public string print(PrintDocument printDocument1)
        {
            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
            return "Sola";
        }

        public string insert(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Save this Record? \n \n Click yes to Confirm Submission", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "Sola";
        }

        public string insert_online(string query)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        /*  public string insert_online_Multiple_Insert_from_datagridview(string query, DataGridView dgv)
          {
              for (int i = 0; i < dgv.Rows.Count; i++)
              {
                  try
                  {
                      MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                      cn.Open();
                      MySqlCommand cmd = new MySqlCommand(query, cn);
                      cmd.ExecuteNonQuery();
                    //  MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      cn.Close();
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }
              return "Sola";
          }*/

        public string insert1(string query)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string Update(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Save Update on this Record? \n \n Click yes to Confirm Submission", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "Sola";
        }

        public string Update_Online(string query)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string Update1(string query)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //  MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string Delete(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Delete Selected/ Displayed Record? \n \n The Record will be Permanently Deleted from the Database! \n \n  Click Yes to Confirm Delete or No to Abort...", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Successfully Deleted! \n \n You might need to Re-login to see the Effect!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Delete Not Permitted for the Selected Record! ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return "Sola";
        }

        public string Delete_Online(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Selected/ Displayed Record From Online Database? \n \n The Record will be Permanently Deleted from the Database! \n \n  Click Yes to Confirm Delete or No to Abort...", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Record Successfully Deleted!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return "Sola";
        }

        public string display_in_dgv(string query, DataGridView DGV)
        {
            try
            {
                DGV.DataSource = null;
                DGV.Rows.Clear();

                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                DGV.DataSource = dt;
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string display_in_dgv_Online(string query, DataGridView DGV)
        {
            DGV.DataSource = null;
            DGV.Rows.Clear();
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                DGV.DataSource = dt;
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public MySqlDataReader display_in_box(string query)
        {

            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dr;
        }

        public string display_in_combobox(string query, ComboBox cbobox, string vmember)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                cbobox.DataSource = dt;
                cbobox.ValueMember = vmember;
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string verify_id_availability(string query, System.Windows.Forms.TextBox txt)
        {

            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("ID/ Ref No already exists!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Text = null;
                    dr.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return "Sola";
        }

        public string validate_for_int(string input, System.Windows.Forms.TextBox txt)
        {
            try
            {
                decimal a = decimal.Parse(txt.Text);
            }
            catch
            {
                MessageBox.Show("Enter Numbers only!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = "0";
            }
            return "sola";
        }

        public string calculation_add(string variable, string variable_net, System.Windows.Forms.TextBox txt_net)
        {

            int var = Convert.ToInt32(variable);
            int net = Convert.ToInt32(variable_net);
            if (var >= 0)
            {
                try
                {
                    txt_net.Text = (variable_net + var).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "Sola";
        }

        public string calculation_subtract(string variable, string variable_net, System.Windows.Forms.TextBox txt_net)
        {

            int var = Convert.ToInt32(variable);
            int net = Convert.ToInt32(variable_net);
            if (var > 0)
            {
                try
                {
                    txt_net.Text = (var - net).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "Sola";
        }

        public string images(PictureBox pbox)
        {
            pbox.BorderStyle = BorderStyle.FixedSingle;
            // pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            pbox.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "/images/medical2.jpg");
            return "Sola";
        }

        public string treat_panel_main(Panel panel1)
        {
            panel1.BackColor = Color.Peru;
            return "Sola";
        }

        public string treat_panel_inner(Panel panel1)
        {
            panel1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_panel_banner(Panel panel1)
        {
            panel1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_groupbox(System.Windows.Forms.GroupBox gbox1)
        {
            gbox1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_title(System.Windows.Forms.Label label1)
        {
            label1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_strip(StatusStrip strip1)
        {
            strip1.BackColor = Color.Black;
            return "Sola";
        }

        public string panel_format(Panel panel1)
        {
            // panel3 = new Panel();
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    (control as System.Windows.Forms.TextBox).Clear();
                    control.ForeColor = Color.Crimson;
                    // control.Font.Size=new 
                    control.Text = null;
                }

                if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                    control.ForeColor = Color.Crimson;
                }
            }
            return "Sola";
        }

        public string panel_format_money(Panel panel1)
        {
            // panel3 = new Panel();
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    (control as System.Windows.Forms.TextBox).Text = "0.00";
                    control.ForeColor = Color.MidnightBlue;
                    // control.Font.Size=new 
                    control.Text = null;
                }
            }
            return "Sola";
        }

        public string message_reject_admin()
        {
            MessageBox.Show(" Module Strictly for Admin Staff. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }
        public string message_reject_academy()
        {
            MessageBox.Show(" This Application Module has Limited Access. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }
        public string message_reject_super_admin()
        {
            MessageBox.Show(" This Application Module has Limited Access. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }
        public string message_reject_super_academy()
        {
            MessageBox.Show(" This Application Module has Limited Access. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }
        public string mass_promotion()
        {
            // MessageBox.Show(" Module Strictly for Super Admin. Admin Staff. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }
        public string mass_promotion_undo()
        {
            // MessageBox.Show(" Module Strictly for Super Admin. Admin Staff. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }
        public string synchronize_online(System.Windows.Forms.Label lab, System.Windows.Forms.DataGridView dat)
        {

            // MessageBox.Show(" Module Strictly for Super Admin. Admin Staff. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }

        public string message() {
            MessageBox.Show("Area Strictly out of Bound!","Admin Area",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            string a = "Shot";
            return a;
        }
        public string background_format(Panel pan)
        {
            pan.BackColor = Color.Black;
            return "Sola";
        }
    }
}
