using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RC
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CForm nc = new CForm();
            nc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Setting_Form sf = new Setting_Form();
            sf.Show();
        }
    }
}
