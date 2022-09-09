using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Software
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            label5.Text = "Copyright " + DateTime.Now.Year;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:afolabi8120@gmail.com");
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com/afolabitemidee");
        }

        private void btnLinkedIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/afolabi-temidayo-timothy-6ab2261a5");
        }
    }
}
