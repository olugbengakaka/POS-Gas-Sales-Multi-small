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
    public partial class Unit_Conversion : Form
    {
        public Unit_Conversion()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Unit_Reg_Load(object sender, EventArgs e)
        {
            gclass.format_form(panel1, groupBox1, pictureBox2, statusStrip1, toolStripStatusLabel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(conversion.Text))
            {
                MessageBox.Show("Enter the Conversion Rate ...", "Point of Sales Intelliscence Says:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                    string code = unit.Text;
                    string query = "INSERT INTO Table_Unit(Unit,Conversion,Reg_By,Date,Code)VALUES('" + unit.Text + "','" + conversion.Text + "','" + users.Text + "','" + DateTime.Now + "','"+ code.ToString() +"') ON DUPLICATE KEY UPDATE unit=values(unit),conversion=values(conversion),code=values(code)";
                    gclass.insert(query);

                    conversion.Text = null;
                }
            }
        }
    }
