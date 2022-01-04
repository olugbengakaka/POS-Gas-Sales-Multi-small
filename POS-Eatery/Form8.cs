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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            General_Class_Imp gclass = new General_Class_Imp();
            for (int i = 0; i < 6000; i++)
            {
                gclass.insert1("insert into table_in(invo)values('" + i.ToString() + "')");
               // MessageBox.Show(i.ToString());
            }
            MessageBox.Show("Success ...");
        }
    }
}
