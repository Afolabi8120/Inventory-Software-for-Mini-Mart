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
    public partial class frmSystemLock : Form
    {
        public frmSystemLock()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                txtName.Focus();
                MessageBox.Show("Password Field Cannot Be Empty", "FIELD EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtName.Text == frmLogin.password)
            {
                this.Dispose();
            }
            else
            {
                txtName.Focus();
                MessageBox.Show("Unable to unlock system", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
