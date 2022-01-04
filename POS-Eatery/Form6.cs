using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace POS_Eatery
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null; dataGridView1.Rows.Clear();
                try
                {

                    // String name = ""; //"Sheet1";//"CASH BK ACCESS"; //Name of your Sheet in the work book
                    csvfile.Text = openFileDialog1.FileName;
                    string name_file = openFileDialog1.FileName;// "GB";
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                    openFileDialog1.FileName +
                                    ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    /* String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                     openFileDialog1.FileName +
                                     ";Extended Properties='text;HDR=YES;FMT=Delimited(,)';";*/

                    OleDbConnection Connection = new OleDbConnection(constr);
                    Connection.Open();
                    DataTable Sheets = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string worksheets = null;
                    string sqlQuery = null;
                    string name = null;
                    for (int i = 0; i < Sheets.Rows.Count; i++)
                    {
                        worksheets = Sheets.Rows[i]["TABLE_NAME"].ToString();
                        sqlQuery = String.Format("SELECT * FROM [{0}]", worksheets);
                        name = string.Format(worksheets);
                    }

                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + name + "]", Connection);


                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    System.Data.DataTable data = new System.Data.DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                gclass.insert1("INSERT INTO Table_Buyers(tel_no,Date,Day,Month,Year,Code,Full_Name)VALUES('" + "0" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "',now(),'" + DateTime.Now.Day + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "','" + "0" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "','') ON DUPLICATE KEY UPDATE tel_no=values(tel_no),full_name=values(full_name),tel_no=values(tel_no),day=values(day),year=values(year),month=values(month),full_name=values(full_name)");
            }
        }
    }
}
