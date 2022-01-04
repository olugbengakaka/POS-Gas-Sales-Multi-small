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

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace POS_Eatery
{
    public partial class Stock_View_Date : Form
    {
        public Stock_View_Date()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        #region Member Variables
        const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height

       /* public string abs(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    dgv.Columns[9].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string printable_date()
        {
            if (month.Text == "1")
            {
                mth = "January";
            }
            else if (month.Text == "2")
            {
                mth = "February";
            }
            else if (month.Text == "3")
            {
                mth = "March";
            }
            else if (month.Text == "4")
            {
                mth = "April";
            }
            else if (month.Text == "5")
            {
                mth = "May";
            }
            else if (month.Text == "6")
            {
                mth = "June";
            }
            else if (month.Text == "7")
            {
                mth = "July";
            }
            else if (month.Text == "8")
            {
                mth = "August";
            }
            else if (month.Text == "9")
            {
                mth = "September";
            }
            else if (month.Text == "10")
            {
                mth = "October";
            }
            else if (month.Text == "11")
            {
                mth = "November";
            }
            else if (month.Text == "12")
            {
                mth = "December";
            }

            if (year.SelectedIndex > 0 && month.SelectedIndex == 0 && day.SelectedIndex == 0)
            {
                print_date.Text = "Sale's Report for the Year: \t \t \t \t " + year.Text;
            }
            else if (year.SelectedIndex > 0 && month.SelectedIndex > 0 && day.SelectedIndex == 0)
            {
                // print_date.Text = "Sale's Report for the Year: \t \t \t \t " + year.Text;
                print_date.Text = "Sale's Report for the Month of " + mth + ", " + year.Text;
            }
            else if (year.SelectedIndex > 0 && month.SelectedIndex > 0 && day.SelectedIndex > 0)
            {
                print_date.Text = "Sale's Report for: \t \t \t \t " + mth + " " + day.Text + ", " + year.Text;
            }
            return "Sola";
        }

        public string printable_date1()
        {
            if (month1.Text == "1")
            {
                mth1 = "January";
            }
            else if (month1.Text == "2")
            {
                mth1 = "February";
            }
            else if (month1.Text == "3")
            {
                mth1 = "March";
            }
            else if (month1.Text == "4")
            {
                mth1 = "April";
            }
            else if (month1.Text == "5")
            {
                mth1 = "May";
            }
            else if (month1.Text == "6")
            {
                mth1 = "June";
            }
            else if (month1.Text == "7")
            {
                mth1 = "July";
            }
            else if (month1.Text == "8")
            {
                mth1 = "August";
            }
            else if (month1.Text == "9")
            {
                mth1 = "September";
            }
            else if (month1.Text == "10")
            {
                mth1 = "October";
            }
            else if (month1.Text == "11")
            {
                mth1 = "November";
            }
            else if (month1.Text == "12")
            {
                mth1 = "December";
            }

            if (employee.SelectedIndex > 0 && year1.SelectedIndex == 0 && month1.SelectedIndex == 0 && day1.SelectedIndex == 0)
            {
                print_date.Text = "Sale's Report by " + employee.Text;
            }
            else if (year1.SelectedIndex > 0 && month1.SelectedIndex == 0 && day1.SelectedIndex == 0)
            {
                print_date.Text = "Sale's Report by " + employee.Text + " for the Year: \t \t \t \t " + year1.Text;
            }
            else if (year1.SelectedIndex > 0 && month1.SelectedIndex > 0 && day1.SelectedIndex == 0)
            {
                // print_date.Text = "Sale's Report for the Year: \t \t \t \t " + year.Text;
                print_date.Text = "Sale's Report by " + employee.Text + " for the Month of " + mth1 + ", " + year1.Text;
            }
            else if (year1.SelectedIndex > 0 && month1.SelectedIndex > 0 && day1.SelectedIndex > 0)
            {
                print_date.Text = "Sale's Report by " + employee.Text + " for: \t \t \t \t " + mth1 + " " + day1.Text + ", " + year1.Text;
            }
            return "Sola";
        }*/

        #endregion

        public string getin_gas()
        {
            try
            {
                decimal sum_cost = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum_cost += Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value);
                }
                quantity_in.Text = sum_cost.ToString();
                label12.Text = "Total Quantity In (kg)";
                label22.Text = "Total Quantity Out (kg)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string getout_gas()
        {
            try
            {
                decimal sum_cost = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum_cost += Convert.ToDecimal(dataGridView2.Rows[i].Cells[5].Value);
                }
                quantity_out.Text = sum_cost.ToString();
                label12.Text = "Total Quantity In (kg)";
                label22.Text = "Total Quantity Out (kg)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string getin_others()
        {
            try
            {
                decimal sum_cost = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum_cost += Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value);
                }
                quantity_in.Text = sum_cost.ToString();
                label12.Text = "Total Quantity In (pcs)";
                label22.Text = "Total Quantity Out (pcs)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string getout_others()
        {
            try
            {
                decimal sum_cost = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum_cost += Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value);
                }
                quantity_out.Text = sum_cost.ToString();
                label12.Text = "Total Quantity In (pcs)";
                label22.Text = "Total Quantity Out (pcs)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        private void Stock_View_Date_Load(object sender, EventArgs e)
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

            gclass.Expand_Database("ALTER TABLE  `table_stock_inventory_summary` ADD  `Quantity_in_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_out_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_left_litre` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_in_bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Out_Bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Left_Bottle` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_in_Percent` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Out_Percent` DECIMAL( 65, 2 ) NOT NULL ,ADD  `Quantity_Left_Percent` DECIMAL( 65, 2 ) NOT NULL");
            gclass.Expand_Database("update table_stock_inventory_summary set quantity_out_litre=Round(Quantity_Out*1.75,2),quantity_in_litre=Round(Quantity_in*1.75,2),quantity_left_litre=Round(Quantity_left*1.75,2),quantity_out_bottle=Round(Quantity_Out/12.5,2),quantity_in_bottle=Round(Quantity_in/12.5,2),quantity_left_bottle=Round(Quantity_left/12.5,2),quantity_out_percent=Round(Quantity_Out*1.75/700,3),quantity_in_percent=Round(Quantity_in*1.75/700,3),quantity_left_percent=Round(Quantity_left*1.75/700,3)");


            productname1.SelectedIndex = -1;
           // gas_product.Checked = true;
        }

        private void productname1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
            {
              //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
               //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_gas(); getout_gas();
            }
            else
            {
               // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
               // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }
        }

        private void year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
            {
                //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' and year='"+year1.Text+"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getout_gas(); getout_gas();
            }
            else
            {
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' and year='"+ year1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }
        }

        private void month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
            {
                //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' and year='" + year1.Text + "' and month='"+ month1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_gas(); getout_gas();
            }
            else
            {
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' and year='" + year1.Text + "' and month='"+ month1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }
        }

        private void day1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productname1.Text.Contains("Gas") || productname1.Text.Contains("gas") || productname1.Text.Contains("GAS"))
            {
                //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' and year='" + year1.Text + "' and month='" + month1.Text + "' and day='"+ day1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_gas(); getout_gas();
            }
            else
            {
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' and year='" + year1.Text + "' and month='" + month1.Text + "' and day='"+ day1.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            /*if (gas_product.Checked==true)
            {
                //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' and year='"+ year.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_gas(); getout_gas();
            }
            else if(other_product.Checked==true)
            {
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%'  and product_name!='Gas'  and branch='" + branch.Text + "' and year='" + year.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }*/
        }

        private void student_new_CheckedChanged(object sender, EventArgs e)
        {
            string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%' and product_name!='Gas' AND Product_Name NOT LIKE 'DISCOUNT' and branch='" + branch.Text + "' ORDER BY p_id DESC";
            gclass.display_in_dgv(query1, dataGridView2);
            getin_others(); getout_others();
        }

        private void student_current_CheckedChanged(object sender, EventArgs e)
        {
            string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' ORDER BY p_id DESC";
            gclass.display_in_dgv(query1, dataGridView2);
            getin_gas(); getout_gas();
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            //branch.Text = "Hephzibah Gas(Akure)";
          /*  gclass.display_in_dgv("Select distinct(product_name),Category,date,day,month,year,code,branch,p_id from table_stock_inventory_summary where branch='" + branch.Text + "' and year='" + year.Text + "' and month='"+ month.Text +"' order by p_id", dataGridView1);

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    string code = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + year.Text + month.Text;
                    string query = "SELECT product_name,category,sum(quantity_in),sum(quantity_out),Date,Day,Month,Year,Code,Branch,quantity_left from table_stock_inventory_summary where product_name='" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "' and category='" + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "' and branch='" + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + "' and year='" + Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "' and month='" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "' order by p_id desc";
                    string query1 = "SELECT p_id,quantity_left from table_stock_inventory_summary where product_name='" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "' and category='" + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "' and branch='" + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + "' and year='" + Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "' and month='" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "' order by p_id desc limit 1";
                   
                    gclass.display_in_dgv(query, dataGridView3);
                    gclass.display_in_dgv(query1, dataGridView4);
                    gclass.insert1("update table_stock_inventory_analysis set quantity_in='0',quantity_out='0' where code='" + code + "'");
                    ////////////////////// INSERTING FOR ANALYSIS MAIN //////////////////////////
                    try
                    {
                        for (int j = 0; j < dataGridView3.Rows.Count; j++)
                        {
                            if (!string.IsNullOrWhiteSpace(Convert.ToString(dataGridView3.Rows[j].Cells[0].Value)))
                            {
                              //  gclass.insert1("INSERT INTO TABLE_STOCK_INVENTORY_ANALYSIS(product_name,category,quantity_in,quantity_out,date,day,month,year,code,branch)values('" + Convert.ToString(dataGridView3.Rows[j].Cells[0].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[1].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[2].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[3].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[4].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[5].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[6].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[7].Value) + "','" + code + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[9].Value) + "') on duplicate key update quantity_in=values(quantity_in),quantity_out=values(quantity_out);update table_stock_inventory_analysis set quantity_in=quantity_in+'" + Convert.ToString(dataGridView3.Rows[j].Cells[2].Value) + "',quantity_out=quantity_out+'" + Convert.ToString(dataGridView3.Rows[j].Cells[3].Value) + "' where code='" + code + "'");
                                gclass.insert1("INSERT INTO TABLE_STOCK_INVENTORY_ANALYSIS(product_name,category,date,day,month,year,code,branch)values('" + Convert.ToString(dataGridView3.Rows[j].Cells[0].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[1].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[4].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[5].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[6].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[7].Value) + "','" + code + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[9].Value) + "') on duplicate key update category=values(category);update table_stock_inventory_analysis set quantity_in=quantity_in+'" + Convert.ToString(dataGridView3.Rows[j].Cells[2].Value) + "',quantity_out=quantity_out+'" + Convert.ToString(dataGridView3.Rows[j].Cells[3].Value) + "' where code='" + code + "'");
                           
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }
                    ////////////////////////////// UPDATING QUANTITY LEFT FOR ANALYSIS MAIN
                    try
                    {
                        for (int K = 0; K < dataGridView4.Rows.Count; K++)
                        {
                            if (!string.IsNullOrWhiteSpace(Convert.ToString(dataGridView4.Rows[K].Cells[0].Value)))
                            {
                                gclass.insert1("UPDATE table_stock_inventory_analysis set quantity_left='" + Convert.ToString(dataGridView4.Rows[K].Cells[1].Value) + "' where code='" + code + "'");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }




                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }


            gclass.display_in_dgv("SELECT pRODUCT_nAME AS 'Name of Product',quantity_in as 'Total Quantity In',Quantity_Out as 'Total Quantity Out', quantity_left as 'Total Quantity Left',Month,Year from table_stock_inventory_analysis where year='" + year.Text + "' and month='" + month.Text + "'", dataGridView2);

            */
            /*if (gas_product.Checked == true)
            {
                //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' and year='" + year.Text + "' and month='"+ month.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getout_gas(); getout_gas();
            }
            else if (other_product.Checked == true)
            {
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas%'  and product_name!='Gas'  and branch='" + branch.Text + "' and year='" + year.Text + "' and month='" + month.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }*/
        }

        private void day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gas_product.Checked == true)
            {
                //  string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (KG)',Round(Quantity_Left*1.75,2) AS 'Quantity Left (Litre)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                //  gclass.display_in_dgv(query, dataGridView2);

                string query1 = "SELECT Date,Product_Name AS 'Product',quantity_in_litre AS 'Quantity In (Litre)',Quantity_In AS 'Quantity In (KG)',quantity_out_litre AS 'Quantity Out(Litre)',Quantity_Out AS 'Quantity Out (KG)',quantity_out_bottle AS 'Quantity Out(Bottle)',quantity_left_litre AS 'Quantity Left (Litre)',quantity_left AS 'Quantity Left (KG)',quantity_left_percent AS 'Percent Left (%)' FROM Table_stock_inventory_summary WHERE Product_Name='Gas' and branch='" + branch.Text + "' and year='" + year.Text + "' and month='" + month.Text + "' and day='"+ day.Text +"' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_gas(); getout_gas();
            }
            else if (other_product.Checked == true)
            {
                // string query = "SELECT Product_Name AS 'Product',Quantity_Left AS 'Quantity Left (Pieces)' FROM (SELECT* FROM Table_stock_inventory_summary WHERE Product_Name='" + productname1.Text + "' AND Product_Name NOT LIKE 'Discount' and branch='" + branch.Text + "' Order by p_id Desc) as my2 group by product_Name";
                // gclass.display_in_dgv(query, dataGridView2);

                // string query1 = "SELECT DATE,CONCAT_WS(' - ',Product_Name,Unit) AS 'Name of Product',Price AS 'Selling Price',Quantity_In AS 'Quantity In(Unit)',Quantity_Out AS 'Quantity Out(Unit)',Quantity_Left AS 'Quantity Left(Unit)' FROM Table_stock_inventory_summary ORDER BY DATE DESC";
                string query1 = "SELECT Date,Product_Name AS 'Product',Quantity_In AS 'Quantity In (Pieces)',Quantity_Out AS 'Quantity Out(Pieces)',Quantity_Left AS 'Quantity Left (Pieces)' FROM Table_stock_inventory_summary WHERE Product_Name NOT LIKE 'Gas'  and product_name!='Gas'  and branch='" + branch.Text + "' and year='" + year.Text + "' and month='" + month.Text + "' and day='" + day.Text + "' ORDER BY p_id DESC";
                gclass.display_in_dgv(query1, dataGridView2);
                getin_others(); getout_others();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            /*try
            {
                Inventory_Detail fm = new Inventory_Detail();
                fm.txt_date.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                fm.txt_product.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                if (status.Text.Contains("Admi") || status.Text.Contains("Supe"))
                {
                    fm.btn_delete.Visible = true;
                }
                fm.branch.Text = branch.Text;
                // gclass.display_in_dgv("SELECT Date,Product_Name AS 'Product Name',Quantity_IN AS 'Quantity In',Quantity_Out AS 'Quantity Out',Purpose FROM Table_Stock_Inventory WHERE Product_Name='" + dataGridView2.SelectedRows[0].Cells[1].Value + "' AND Date='" + dataGridView2.SelectedRows[0].Cells[0].Value + "'", fm.dataGridView2);
                fm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

          //  button_delete.Visible = false;
            button_print.Visible = false;
            button1.Visible = false;
            label15.Visible = false;

            /*for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                try
                {
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[4].Visible = false;
                }
                catch
                {

                }
            }*/


            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
                printDocument2.Print();
            }



            /*PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                button_delete.Visible = false;
                button_print.Visible = false;
                button1.Visible = false;
                label15.Visible = false;
                receipt_no.Visible = false;
                printDocument2.Print();
           
            }

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                button_delete.Visible = false;
                button_print.Visible = false;
                button1.Visible = false;
                label15.Visible = false;
                receipt_no.Visible = false;
                printDocument1.Print();
            }*/

           /* for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                try
                {
                    dataGridView2.Columns[i].Visible = true;
                    dataGridView2.Columns[4].Visible = true;
                }
                catch
                {

                }
            }*/

           // button_delete.Visible = true;
            button_print.Visible = true;
            // button1.Visible = true;
            label15.Visible = true;
          //  receipt_no.Visible = true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView2.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView2.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView2.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Customer Summary", new Font(dataGridView2.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(dataGridView2.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView2.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView2.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(new Font(dataGridView2.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView2.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* Bitmap bmp = new Bitmap(dataGridView2.Width, dataGridView2.Height);
             dataGridView2.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
             e.Graphics.DrawImage(bmp, 0, 0);
             int row = 1;
             if (row <= 12)
             {
                 e.HasMorePages = true;
             }*/
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel9.Width, panel9.Height);
            panel9.DrawToBitmap(bmp, new Rectangle(0, 0, panel9.Width, panel9.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            result.Visible = true;

           // MessageBox.Show("Sorting and Collation takes time depending on the number of data in the database ...", " Message Center ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             DialogResult dr27 = MessageBox.Show("Sorting and Collation takes time depending on the number of data in the database.\n \n Click Yes to Continue or No to Abort ...", "  Message from School-MS Online Monitoring Server: ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             if (dr27 == DialogResult.Yes)
             {
                 gclass.display_in_dgv("Select distinct(product_name),Category,date,day,month,year,code,branch,p_id from table_stock_inventory_summary where branch='" + branch.Text + "' and year='" + year.Text + "' and month='" + month.Text + "' order by p_id", dataGridView1);

                 try
                 {
                     for (int i = 0; i < dataGridView1.Rows.Count; i++)
                     {
                         dataGridView2.DataSource = null;
                         dataGridView2.Rows.Clear();
                         dataGridView3.DataSource = null;
                         dataGridView3.Rows.Clear();
                         string code = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + year.Text + month.Text;
                         string query = "SELECT product_name,category,sum(quantity_in),sum(quantity_out),Date,Day,Month,Year,Code,Branch,quantity_left from table_stock_inventory_summary where product_name='" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "' and category='" + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "' and branch='" + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + "' and year='" + Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "' and month='" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "' order by p_id desc";
                         string query1 = "SELECT p_id,quantity_left from table_stock_inventory_summary where product_name='" + Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + "' and category='" + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "' and branch='" + Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) + "' and year='" + Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "' and month='" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "' order by p_id desc limit 1";

                         gclass.display_in_dgv(query, dataGridView3);
                         gclass.display_in_dgv(query1, dataGridView4);
                         gclass.insert1("update table_stock_inventory_analysis set quantity_in='0',quantity_out='0' where code='" + code + "'");
                         ////////////////////// INSERTING FOR ANALYSIS MAIN //////////////////////////
                         try
                         {
                             for (int j = 0; j < dataGridView3.Rows.Count; j++)
                             {
                                 if (!string.IsNullOrWhiteSpace(Convert.ToString(dataGridView3.Rows[j].Cells[0].Value)))
                                 {
                                     //  gclass.insert1("INSERT INTO TABLE_STOCK_INVENTORY_ANALYSIS(product_name,category,quantity_in,quantity_out,date,day,month,year,code,branch)values('" + Convert.ToString(dataGridView3.Rows[j].Cells[0].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[1].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[2].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[3].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[4].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[5].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[6].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[7].Value) + "','" + code + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[9].Value) + "') on duplicate key update quantity_in=values(quantity_in),quantity_out=values(quantity_out);update table_stock_inventory_analysis set quantity_in=quantity_in+'" + Convert.ToString(dataGridView3.Rows[j].Cells[2].Value) + "',quantity_out=quantity_out+'" + Convert.ToString(dataGridView3.Rows[j].Cells[3].Value) + "' where code='" + code + "'");
                                     gclass.insert1("INSERT INTO TABLE_STOCK_INVENTORY_ANALYSIS(product_name,category,date,day,month,year,code,branch)values('" + Convert.ToString(dataGridView3.Rows[j].Cells[0].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[1].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[4].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[5].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[6].Value) + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[7].Value) + "','" + code + "','" + Convert.ToString(dataGridView3.Rows[j].Cells[9].Value) + "') on duplicate key update category=values(category);update table_stock_inventory_analysis set quantity_in=quantity_in+'" + Convert.ToString(dataGridView3.Rows[j].Cells[2].Value) + "',quantity_out=quantity_out+'" + Convert.ToString(dataGridView3.Rows[j].Cells[3].Value) + "' where code='" + code + "'");

                                 }
                             }
                         }
                         catch (Exception ex)
                         {
                             //  MessageBox.Show(ex.Message);
                         }
                         ////////////////////////////// UPDATING QUANTITY LEFT FOR ANALYSIS MAIN
                         try
                         {
                             for (int K = 0; K < dataGridView4.Rows.Count; K++)
                             {
                                 if (!string.IsNullOrWhiteSpace(Convert.ToString(dataGridView4.Rows[K].Cells[0].Value)))
                                 {
                                     gclass.insert1("UPDATE table_stock_inventory_analysis set quantity_left='" + Convert.ToString(dataGridView4.Rows[K].Cells[1].Value) + "' where code='" + code + "'");
                                 }
                             }
                         }
                         catch (Exception ex)
                         {
                             //  MessageBox.Show(ex.Message);
                         }




                     }
                 }
                 catch (Exception ex)
                 {
                     // MessageBox.Show(ex.Message);
                 }


                 gclass.display_in_dgv("SELECT pRODUCT_nAME AS 'Name of Product',quantity_in as 'Total Quantity In',Quantity_Out as 'Total Quantity Out', quantity_left as 'Total Quantity Left',Month,Year from table_stock_inventory_analysis where year='" + year.Text + "' and month='" + month.Text + "'", dataGridView2);

                 for (int i = 0; i < dataGridView2.Rows.Count; i++)
                 {
                     if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "1")
                     {
                         // dataGridView2.Rows[i].Cells[4].Value = null;
                         dataGridView2.Rows[i].Cells[4].Value = "JANUARY";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "2")
                     {
                         // dataGridView2.Rows[i].Cells[4].Value = null;
                         dataGridView2.Rows[i].Cells[4].Value = "FEBRUARY";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "3")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "MARCH";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "4")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "APRIL";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "5")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "MAY";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "6")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "JUNE";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "7")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "JULY";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "8")
                     {
                         //dataGridView2.Rows[i].Cells[4].Value= Convert.ToString(dataGridView2.Rows[i].Cells[4].Value).Replace("8", "August");
                         dataGridView2.Rows[i].Cells[4].Value = "AUGUST";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "9")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "SEPTEMBER";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "10")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "OCTOBER";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "11")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "NOVEMBER";
                     }
                     else if (Convert.ToString(dataGridView2.Rows[i].Cells[4].Value) == "12")
                     {
                         dataGridView2.Rows[i].Cells[4].Value = "DECEMBER";
                     }
                 }
             }

                result.Visible = false;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            result.Visible = true;


            result.Visible = false;
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            gclass.export_to_excell(dataGridView2);
        }
    }
}
