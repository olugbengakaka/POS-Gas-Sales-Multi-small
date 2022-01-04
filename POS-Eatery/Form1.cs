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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            General_Class_Imp gclass = new General_Class_Imp();
            gclass.display_in_dgv("SELECT* FROM Table_login", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.Simple;
        }
    }
}
