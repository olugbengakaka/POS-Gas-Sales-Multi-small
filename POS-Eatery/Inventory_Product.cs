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
    public partial class Inventory_Product : Form
    {
        public Inventory_Product()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            gclass.printdocument(dataGridView1, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gclass.print(printDocument1);
            gclass.print(printDocument2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gclass.export_to_excell(dataGridView1);
            gclass.export_to_excell(dataGridView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void View_Product_Load(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                string str = "SELECT DISTINCT(Product_Name) FROM Table_Stock_Inventory_Summary WHERE Category='Product' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' ORDER BY Product_Name ASC";//"INSERT INTO table_referral(Patient_Name,Patient_Age,Sex,Patient_Tel,Patient_Email,Doctor_Name,Doctor_Tel,Hospital_Name,Hospital_Address,Clinical_Details,Date,Day,Month,Year)VALUES('" + patient_name + "','" + age.Text + "','" + sex.Text + "','" + patienttel.Text + "','" + patientemail.Text + "','" + doctorname.Text + "','" + doctortel.Text + "','" + hospitalname.Text + "','" + hospitaladdress.Text + "','" + clinicaldetail.Text + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.Day.ToString() + "','" + DateTime.Now.Month + "','" + DateTime.Now.Year + "')";
                MySqlCommand cmd = new MySqlCommand(str, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                productname1.DataSource = dt;
                productname1.DisplayMember = "Product_Name";
                MySqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    acc.Add(dr.GetString(0));
                }
                productname1.AutoCompleteCustomSource = acc;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //quantity_out_bottle=Round(Quantity_Out/12.5,2)
            gclass.Expand_Database("ALTER TABLE  `table_stock_inventory_summary` ADD  `Quantity_in_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_out_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_left_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_in_bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Out_Bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Left_Bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_in_Percent` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Out_Percent` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Left_Percent` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("update table_stock_inventory_summary set quantity_out_litre=Round(Quantity_Out*1.75,2),quantity_in_litre=Round(Quantity_in*1.75,2),quantity_left_litre=Round(Quantity_left*1.75,2),quantity_out_bottle=Round(Quantity_Out/12.5,2),quantity_in_bottle=Round(Quantity_in/12.5,2),quantity_left_bottle=Round(Quantity_left/12.5,2),quantity_out_percent=Round(Quantity_Out*1.75/681.37412,3),quantity_in_percent=Round(Quantity_in*1.75/681.37412,3),quantity_left_percent=Round(Quantity_left*1.75/681.37412,3)");   //681.37412
            gclass.Expand_Database("update table_stock_inventory_summary set dat=concat(year,'-',month,'-',day);update table_sales_lump set dat=concat(year,'-',month,'-',day)");


            productname1.SelectedIndex = -1;
            student_current.Checked = true;
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            gclass.printdocument(dataGridView2, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void student_current_CheckedChanged(object sender, EventArgs e)
        {

           string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by dat Desc) as my2 group by product_Name";
           // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' Order by p_id Desc limit 1";      //(SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' Order by p_id Desc) as my2 group by product_Name";
            gclass.display_in_dgv(query, dataGridView1);

           // SELECT sum(item_value), dat FROM table_sales_lump group by dat order by p_id desc
            string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',Round(Quantity_Left/12.5,2) as 'Quantity_Left(Bottle)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' ORDER BY DAT DESC";
            
            gclass.display_in_dgv(query1, dataGridView2);
          
          /*  // string query = "SELECT CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_Left AS 'Quantity Left(Unit)' FROM (SELECT* FROM Table_stock_inventory_summary Order by p_id Desc) as my2 group by product_Name";
            string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' Order by p_id Desc) as my2 group by product_Name";
            gclass.display_in_dgv(query, dataGridView1);

            // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
          //  string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Out/12.5,2) AS 'Quantity Out(Bottle)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' ORDER BY p_id DESC";
            string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Out/12.5,2) AS 'Quantity Out(Bottle)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',SUM(Quantity_Left) AS 'Quantity Left (KG)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' GROUP BY DATE ORDER BY p_id DESC";
            gclass.display_in_dgv(query1, dataGridView2);*/
            
        }

        private void student_new_CheckedChanged(object sender, EventArgs e)
        {
            // string query = "SELECT CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_Left AS 'Quantity Left(Unit)' FROM (SELECT* FROM Table_stock_inventory_summary Order by p_id Desc) as my2 group by product_Name";
            string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by dat Desc) as my2 group by product_Name order by product_name";
            gclass.display_in_dgv(query, dataGridView1);

            // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
            string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' ORDER BY dat DESC";
            gclass.display_in_dgv(query1, dataGridView2);
        }

        private void productname1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
            {
                string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by dat Desc) as my2 group by product_Name";
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' Order by p_id Desc limit 1";      //(SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' Order by p_id Desc) as my2 group by product_Name";
                gclass.display_in_dgv(query, dataGridView1);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                // string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Quantity_Left AS 'Quantity Left (KG)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' ORDER BY p_id DESC";
               // string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Out/12.5,2) AS 'Quantity Out(Bottle)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',SUM(Quantity_Left) AS 'Quantity Left (KG)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' GROUP BY DATE ORDER BY p_id DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',Round(Quantity_Left/12.5,2) as 'Quantity_Left(Bottle)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' ORDER BY dat DESC";
         
                gclass.display_in_dgv(query1, dataGridView2);
              /*  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' Order by p_id Desc) as my2 group by product_Name";
                gclass.display_in_dgv(query, dataGridView1);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Quantity_Left AS 'Quantity Left (KG)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);*/
            }
            else
            {
                string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by dat Desc) as my2 group by product_Name";
                gclass.display_in_dgv(query, dataGridView1);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' ORDER BY dat DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Inventory_Detail fm = new Inventory_Detail();
                fm.txt_date.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                fm.txt_product.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                if (status.Text.Contains("Supe"))
                {
                    fm.btn_delete.Visible = true;
                }
                fm.branch.Text = branch.Text;
                // gclass.display_in_dgv("SELECT Date,Product_Name AS 'Product Name',Quantity_IN AS 'Quantity In',Quantity_Out AS 'Quantity Out',Purpose FROM Table_Stock_Inventory WHERE Product_Name='" + dataGridView1.SelectedRows[0].Cells[1].Value + "' AND Date='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'", fm.dataGridView1);
                fm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (student_current.Checked == true)
            {
                string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Out/12.5,2) AS 'Quantity Out(Bottle)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' AND Year='" + year1.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
            else if (student_new.Checked == true)
            {
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%' AND Product_Name NOT LIKE 'DISCOUNT' AND Year='"+ year1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
        }

        private void month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (student_current.Checked == true)
            {
                string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Out/12.5,2) AS 'Quantity Out(Bottle)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' AND Year='" + year1.Text + "' AND Month='"+ month1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
            else if (student_new.Checked == true)
            {
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%' AND Product_Name NOT LIKE 'DISCOUNT' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
        }

        private void day1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (student_current.Checked == true)
            {
                string query1 = "SELECT Date,Product_Name AS 'Product',Round(Quantity_In*1.75,2) AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',Round(Quantity_Out*1.75,2) AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',Round(Quantity_Out/12.5,2) AS 'Quantity Out(Bottle)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75/700,3) AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='"+ day1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
            else if (student_new.Checked == true)
            {
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%' AND Product_Name NOT LIKE 'DISCOUNT' AND Year='" + year1.Text + "' AND Month='" + month1.Text + "' AND Day='"+ day1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Stock_View_Date fm = new Stock_View_Date();
            fm.branch.Text = branch.Text;
            fm.status.Text = status.Text;
            fm.owner.Text = owner.Text;
            fm.ShowDialog();
        }
    }
}
