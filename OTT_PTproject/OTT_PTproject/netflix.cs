using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTT_PTproject
{
    public partial class netflix : Form
    {
        public netflix()
        {
            InitializeComponent();
        }

        private void netflix_Load(object sender, EventArgs e)
        {

        }
         
        public void gettext(string str)
        {
            label1.Text = "hi ,"+str;
        }

       
    }
}
