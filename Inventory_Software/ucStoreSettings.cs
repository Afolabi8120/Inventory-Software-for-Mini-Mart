using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_Software
{
    public partial class ucStoreSettings : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();
        public ucStoreSettings()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void getStoreDetails()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsettings", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txtName.Text = dr["name"].ToString();
                txtPhone.Text = dr["phone"].ToString();
                txtEmail.Text = dr["email"].ToString();
                txtAddress.Text = dr["address"].ToString();
                txtMotto.Text = dr["motto"].ToString();
            }
            else
            {
                txtName.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtMotto.Text = "";
            }
            dr.Close();
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtName.Text == String.Empty || txtPhone.Text == String.Empty || txtAddress.Text == String.Empty || txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cn.Open();
                    cm = new MySqlCommand("DELETE FROM tblsettings ", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tblsettings (name,phone,email,address,motto) VALUES(@name,@phone,@email,@address,@motto) ", cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@motto", txtMotto.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Store details has been saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getStoreDetails();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete store information?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new MySqlCommand("DELETE FROM tblsettings ", cn);
                cn.Close();
                MessageBox.Show("Store details has been deleted successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getStoreDetails();
            }
        }

        private void ucStoreSettings_Load(object sender, EventArgs e)
        {
            getStoreDetails();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
