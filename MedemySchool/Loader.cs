using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedemySchool
{
    public partial class Loader : Form
    {
        int secound = 0;
        public Loader()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (secound == 8)
            {
                timer.Enabled = false;
                secound = 0;
                MedemyLogin ml = new MedemyLogin();
                this.Hide();
                ml.ShowDialog();
            }
            secound++;
        }
    }
}
