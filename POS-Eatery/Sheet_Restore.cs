using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS_Eatery
{
    public partial class Sheet_Restore : Form
    {
        public Sheet_Restore()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Sheet_Restore_Load(object sender, EventArgs e)
        {
            //gclass.display_in_dgv_online("SELECT* FROM table_sales_summary WHERE Month='7' and Day='4'", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Jesus, is, Lord,";
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
           // textBox2.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
    }
}
