using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_Software
{
    public partial class frmUserReg : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public frmUserReg()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtUsername.Text == String.Empty || txtFullname.Text == String.Empty || txtPassword.Text == String.Empty || txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (txtPassword.Text != txtCPassword.Text) // check if password match
                {
                    MessageBox.Show("Both password do not match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tbluser (username,fullname,password,usertype,email,status) VALUES(@username,@fullname,@password,@usertype,@email,@status) ", cn);
                    cm.Parameters.AddWithValue("@username", txtUsername.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullname.Text);
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@usertype", txtUsertype.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@status", txtStatus.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Account Saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    // Redirect To Login
                    frmLogin f1 = new frmLogin();
                    f1.ShowDialog();
                    
                }
            }
        }

        private void frmUserReg_Load(object sender, EventArgs e)
        {
            //cn.Open();
            //cm = new MySqlCommand("SELECT COUNT(username) FROM tbluser", cn);
            //int counter = int.Parse(cm.ExecuteScalar().ToString());
            //cn.Close();

            
            //if (counter > 0)
            //{
            //    this.Hide();
            //    frmLogin f1 = new frmLogin();
            //    f1.ShowDialog();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
