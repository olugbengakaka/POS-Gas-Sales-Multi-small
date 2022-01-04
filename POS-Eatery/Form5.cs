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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Form5_Load(object sender, EventArgs e)
        {
            //gclass.display_in_dgv_online("SELECT* FROM Table_Login", dataGridView1);
        }
    }
}
